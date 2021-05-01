using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private InputAction action;
    private Animator animator;
    private bool OverworldCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        
        action.Disable();
    }

    void Start()
    {
        action.performed += _ => SwitchState();
        
    }

    private void SwitchState()
    {
        if (OverworldCamera)
        {
            animator.Play("CloseUp");
        }
        else
        {
            animator.Play("Overworld");
        }

        OverworldCamera = !OverworldCamera;
    }

}
