using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

namespace Manager
{
    public class Lobby : MonoBehaviour
    {
        public int MaxConnection = 2;
        public UnityTransport Transport;

        private Unity.Services.Lobbies.Models.Lobby _currentLobby;
        private float heartbeatTimer;
        private float MaxheartbeatTimer = 15f;

        /// <summary>
        /// Test
        /// </summary>
        private Unity.Services.Lobbies.Models.Lobby lobby;





        private async void Awake()
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            JoinOrCreate();
        }

        private void Update()
        {
            handleLobbyHeatBeat();
        }

        private async void handleLobbyHeatBeat()
        {
            if (_currentLobby != null)
            {
                heartbeatTimer -= Time.deltaTime;
                if (heartbeatTimer < 0f)
                {
                    heartbeatTimer = MaxheartbeatTimer;
                    await LobbyService.Instance.SendHeartbeatPingAsync(_currentLobby.Id);
                }
            }
        }


        public async void JoinOrCreate()
        {
            try
            {
                _currentLobby = await Lobbies.Instance.QuickJoinLobbyAsync();
                string relayJoinCode = _currentLobby.Data["JOIN_CODE"].Value;

                JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(relayJoinCode);

                Transport.SetClientRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port,
                    allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData, allocation.HostConnectionData);

                NetworkManager.Singleton.StartClient();
            }
            catch
            {
                Create();
            }
        }
        public async void Create()
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(MaxConnection);
            string newJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            Transport.SetHostRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port,
                allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData);

            CreateLobbyOptions lobbyOptions = new CreateLobbyOptions();
            lobbyOptions.IsPrivate = false;
            lobbyOptions.Data = new Dictionary<string, DataObject>();
            DataObject dataObject = new DataObject(DataObject.VisibilityOptions.Public, newJoinCode);
            lobbyOptions.Data.Add("JOIN_CODE", dataObject);
            Debug.Log(newJoinCode);

            _currentLobby = await Lobbies.Instance.CreateLobbyAsync("Lobby Name", MaxConnection, lobbyOptions);

            NetworkManager.Singleton.StartHost();
        }

        public async void Join()
        {
            try
            {
                _currentLobby = await Lobbies.Instance.QuickJoinLobbyAsync();
                string relayJoinCode = _currentLobby.Data["JOIN_CODE"].Value;

                JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(relayJoinCode);

                Transport.SetClientRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port,
                    allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData, allocation.HostConnectionData);

                NetworkManager.Singleton.StartClient();

            }
            catch (LobbyServiceException ex)
            {
                Debug.LogException(ex);
            }


        }
    }
}
