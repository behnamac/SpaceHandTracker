using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{

   [SerializeField] private UnityEngine.UI.Slider mainSlider;
    [SerializeField] private Animator animator;
    private const string OPEN_PARAM = "Open";

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();

       mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        animator.SetFloat(OPEN_PARAM, mainSlider.value);
    }

}
