using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public PlayerController playerController { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;

        // Optional: Persist across scene changes
        DontDestroyOnLoad(gameObject);
        
        playerController = GetComponent<PlayerController>();
        
    }
    
    
    
    
    
    

}
