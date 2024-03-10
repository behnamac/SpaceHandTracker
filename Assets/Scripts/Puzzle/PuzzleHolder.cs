using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class PuzzleHolder : XRSocketInteractor
{
    [SerializeField] private int ID;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        var _IDCheck = CheckIDHover(interactable);
        return base.CanHover(interactable) && _IDCheck;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        var _IDCheck = CheckIDSelect(interactable);
        return base.CanSelect(interactable) && _IDCheck ;
    }

    private bool CheckIDHover(IXRHoverInteractable interactable)
    {
        var id = interactable.transform.GetComponent<PuzzlePiece>().ID;
        return id == ID;
    }

    private bool CheckIDSelect(IXRSelectInteractable interactable)
    {
        var id = interactable.transform.GetComponent<PuzzlePiece>().ID;
        return id == ID;
    }


}
