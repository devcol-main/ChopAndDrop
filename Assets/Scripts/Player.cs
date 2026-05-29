using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    //
    private InputReader inputReader;
    
    //
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 10f;
    
    private bool isWalking;
    public bool IsWalking => isWalking;

    private Vector2 moveInput;
    
    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        moveInput = inputReader.GetMovementInput();
    }

    private void FixedUpdate()
    {
        ControlMovement();
    }
    
    private void ControlMovement()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        
        transform.Translate(moveDir * (movementSpeed * Time.fixedDeltaTime), Space.World);
        
        isWalking = moveDir.sqrMagnitude > 0.001f;
        
        if (isWalking)
        {
            // Y축(높이) 성분을 확실하게 제거하여 캐릭터가 위아래로 기울어지는 현상을 원천 차단합니다.
            Vector3 targetDirection = new Vector3(moveDir.x, 0f, moveDir.z).normalized;
            
            // 이동하려는 방향을 바라보는 목표 쿼터니언 회전값을 계산합니다.
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        }
        
        //transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.fixedDeltaTime * rotationSpeed);

    }
    
}
