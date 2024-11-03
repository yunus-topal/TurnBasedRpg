using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [Header("Assets")]
    [SerializeField] private PlayerInput playerInput;
    
    [Header("Player Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float attackCooldown;
    
    private Vector2 _moveDirection;
    private Rigidbody _rigidbody;
    private float _lastJumpTime;
    private float _lastAttackTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        TryGetComponent(out _rigidbody);
        if (_rigidbody is null) {
            Debug.LogError("Rigidbody not found on player object");
        }
    }
    
    private void FixedUpdate() {
        transform.position += new Vector3(_moveDirection.x, 0, _moveDirection.y) * (speed * Time.fixedDeltaTime);
    }

    // callback functions
    public void Move(InputAction.CallbackContext value)
    {
        Vector2 direction = value.ReadValue<Vector2>();
        _moveDirection = direction;
    }
    
    public void Jump()
    {
        if (Time.time - _lastJumpTime < jumpCooldown) return;
        
        _lastJumpTime = Time.time;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
