
using UnityEngine;


public class InputReader : MonoBehaviour
{

    private InputSystem_Actions inputSystemActions;

    private void Awake()
    {
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Player.Enable();

        
    }

    public Vector2 GetMovementInput()
    {
        Vector2 moveInputValue = inputSystemActions.Player.Move.ReadValue<Vector2>();

        //moveInputValue = moveInputValue.normalized;
        return moveInputValue;
    }

    /*
    public static InputReader Instance { get; private set; }
    //public float Horizontal => inputAction.ReadValue<float>();
    private Vector2 moveInput;

    private InputAction inputAction;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Self-destruct if a duplicate is spawned
            return;
        }

        Instance = this;

        // Optional: Persist across scene changes
        DontDestroyOnLoad(gameObject);


        inputAction = new InputAction();


    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }


    private void Update()
    {
        moveInput =
    }
    */

}
