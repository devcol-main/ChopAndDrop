using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputReader : MonoBehaviour
{
    public static InputReader Instance { get; private set; }

    public event EventHandler OnInteractAction;
    
    private InputSystem_Actions inputSystemActions;


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
        
        //
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Player.Enable();
        
        //
        inputSystemActions.Player.Interact.performed += Interect_performed;
    }

    private void Interect_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementInput()
    {
        return inputSystemActions.Player.Move.ReadValue<Vector2>();
    }

}



