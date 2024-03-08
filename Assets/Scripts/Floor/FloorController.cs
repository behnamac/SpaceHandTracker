using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FloorController : MonoBehaviour
{
    [SerializeField] private TeleportationArea[] mFloor;

    private void Start()
    {
        foreach (var floor in mFloor)
        {
            floor.GetComponent<TeleportationArea>().enabled = false;
        }
    }

    public void ActiveFloor()
    {
        foreach (var floor in mFloor)
        {
            floor.GetComponent<TeleportationArea>().enabled = true;
        }
    }



}
