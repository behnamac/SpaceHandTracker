using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Transform targetObj;
    [SerializeField] private float speed=0.5f;
    [SerializeField] private Vector3 RotateValue=new Vector3(0,360,0);
    [SerializeField] private bool canRotate = true;
    // Start is called before the first frame update
    void Start()
    {
        RotateEngine();

    }

    public void RotateEngine()
    {
        if (!canRotate) return;
        if (!targetObj) return;
        targetObj.DOLocalRotate(RotateValue, speed, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

    public void SetCanRotate()
    {
        canRotate = !canRotate;
    }
}
