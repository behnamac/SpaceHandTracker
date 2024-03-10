using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;
using UnityEngine.XR.Content.Interaction;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorVisual;
    [SerializeField] private Material m_Renderer;
    [SerializeField] private Vector3 target;

    void Start()
    {
        m_Renderer.color = Color.red;
    }



    public void OpenDoor()
    {
        m_Renderer.color = Color.green;
        doorVisual.transform.DOLocalMoveX(target.x, 2);
    }
}





