using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 10f;
    
    [SerializeField] private float interactionDistance = 2f;
    
    [SerializeField] private LayerMask countersLayerMask;
    
    //
    private Vector2 moveInput;
    private bool isWalking;

    private float moveDistance;
    private float playerRadiuis = 0.7f;
    private float playerHeight = 2f;
    private bool canMove = true;
    
    private Vector3 lastInteractionDirection;
    
    //
    public bool IsWalking => isWalking;
    

    private void Start()
    {
        InputReader.Instance.OnInteractAction += InputReader_OnInteractAction;
    }

    private void OnDisable()
    {
        InputReader.Instance.OnInteractAction -= InputReader_OnInteractAction;
    }
    private void InputReader_OnInteractAction(object sender, System.EventArgs e)
    {
        
        Debug.Log("InputReader_OnInteractAction");
        
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (moveDir != Vector3.zero)
        {
            lastInteractionDirection = moveDir;
        }

        if (Physics.Raycast(transform.position, lastInteractionDirection, out RaycastHit hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interect();
            }
        }
    }
    
    private void Update()
    {
        moveInput = InputReader.Instance.GetMovementInput();
        
    }

    private void FixedUpdate()
    {
        ControlMovement();
        Interections();
    }
    
    private void ControlMovement()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        //isWalking = moveDir.sqrMagnitude > 0.001f;

        isWalking = (moveDir != Vector3.zero);
    
        if (isWalking)
        {
            moveDistance = (movementSpeed * Time.fixedDeltaTime);

            // 1. 먼저 원래 가려던 대각선 방향으로 갈 수 있는지 검사
            if (!CanMove(moveDir, moveDistance))
            {
                // 2. 대각선이 막혔다면 X축 단독 이동이 가능한지 검사
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            
                // X축 입력이 있고(0이 아니고), X축 방향으로 이동이 가능하다면
                if (moveDirX.sqrMagnitude > 0.001f && CanMove(moveDirX, moveDistance))
                {
                    moveDir = moveDirX; // 이동 방향을 X축으로 변경
                }
                else
                {
                    // 3. X축도 막혔다면 Z축 단독 이동이 가능한지 검사
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                
                    // Z축 입력이 있고, Z축 방향으로 이동이 가능하다면
                    if (moveDirZ.sqrMagnitude > 0.001f && CanMove(moveDirZ, moveDistance))
                    {
                        moveDir = moveDirZ; // 이동 방향을 Z축으로 변경
                    }
                    else
                    {
                        // X, Z축 둘 다 갈 수 없다면 완전히 멈춤
                        moveDir = Vector3.zero;
                    }
                }
            }
            
            if (moveDir != Vector3.zero)
            {
                transform.Translate(moveDir * moveDistance, Space.World);
            
                // Rotation (움직일 수 있는 최종 방향으로 회전)
                Vector3 targetDirection = new Vector3(moveDir.x, 0f, moveDir.z).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
            }
        }
    }
    

    private bool CanMove(Vector3 moveDirection, float distance)
    {
        canMove = !Physics.CapsuleCast(transform.position, 
            transform.position + Vector3.up * playerHeight, 
            playerRadiuis, 
            moveDirection, 
            distance);
        
        return canMove;
    }
    
    private void Interections()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (moveDir != Vector3.zero)
        {
            lastInteractionDirection = moveDir;
        }

        if (Physics.Raycast(transform.position, lastInteractionDirection, out RaycastHit hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interect();
            }
        }
    }
}
