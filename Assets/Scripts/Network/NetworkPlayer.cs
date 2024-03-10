using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private Transform Head;
    [SerializeField] private Transform LeftHand;
    [SerializeField] private Transform RightHand;
    [SerializeField] private Transform Root;

    [SerializeField] private Renderer[] allMeshRenderers;

    private VRRigReferences link;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        Initialized();

    }



    private void Update()
    {
        if (!IsOwner) return;
        RefrenceBody();
    }

    private void Initialized()
    {
        link = VRRigReferences.Instance;
        foreach (Renderer item in allMeshRenderers)
        {
            item.enabled = false;
        }
    }

    private void RefrenceBody()
    {
        Root.transform.position = link.Root.transform.position;
        Root.transform.rotation = link.Root.transform.rotation;

        Head.transform.rotation = link.Head.transform.rotation;
        Head.transform.rotation = link.Head.transform.rotation;

        LeftHand.transform.rotation = link.LeftHand.transform.rotation;
        LeftHand.transform.rotation = link.LeftHand.transform.rotation;

        RightHand.transform.rotation = link.RightHand.transform.rotation;
        RightHand.transform.rotation = link.RightHand.transform.rotation;
    }
}
