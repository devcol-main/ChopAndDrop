using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    // const strings
    private const string IS_WALKING = "IsWalking";
    
    //
    
    private Animator animator;
    private Player player;
    

    private void Awake()
    {
        //player = GetComponent<Player>();
        player = FindAnyObjectByType<Player>();
        
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking);
        
    }
}
