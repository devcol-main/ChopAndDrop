using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    // const strings
    private const string IS_WALKING = "IsWalking";
    
    // Objects
    private Player player;
    private PlayerController playerController;
    
    // Components
    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        playerController = FindAnyObjectByType<PlayerController>();   
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, playerController.IsWalking);
        
    }
}
