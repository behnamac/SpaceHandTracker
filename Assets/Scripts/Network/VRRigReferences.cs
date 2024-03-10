using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences Instance { get; private set; }

    public Transform Head;
    public Transform LeftHand;
    public Transform RightHand;
    public Transform Root;


    private void Awake()
    {

        Instance = this;
    }



}
