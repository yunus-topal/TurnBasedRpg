using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [Header("Player Stats")]
    [SerializeField] private float speed;

    private Rigidbody _rigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        TryGetComponent(out _rigidbody);
        if (_rigidbody is null) {
            Debug.LogError("Rigidbody not found on player object");
        }
    }
}
