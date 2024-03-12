using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SocketManager : MonoBehaviour
{
    [SerializeField]private UnityEvent OnPuzzleComplete;
    private int pieceCounter;


    public void SetCounter()
    {
        pieceCounter++;
        if(pieceCounter>4)
            OnPuzzleComplete?.Invoke();
    }
}
