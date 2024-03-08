using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField] private Transform[] monkeyPices;
    [SerializeField] private Vector3[] monkeyFirstPos=new Vector3[5];
    [SerializeField] private Vector3[] monkeyFirstScale;


    private void Start()
    {
        for (int i = 0; i < monkeyPices.Length; i++)
        {
            monkeyFirstPos[i] = monkeyPices[i].position;
            monkeyFirstScale[i] = monkeyPices[i].localScale;
        }
    }




}
