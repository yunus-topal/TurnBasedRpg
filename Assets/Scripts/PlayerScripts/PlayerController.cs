using System;
using PlayerScripts;
using UnityEngine;
using UnityEngine.InputSystem;

internal class PlayerController : MonoBehaviour {

    public enum PlayerState {
        Normal,
        Stealth,
        Combat,
        Cutscene
    }
    private Rigidbody _rigidbody;
    private PlayerState _playerState;
    
    private PlayerMovement _playerMovement;
    private PlayerVfx _playerVfx;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        TryGetComponent(out _rigidbody);
        TryGetComponent(out _playerMovement);
        TryGetComponent(out _playerVfx);
        
        if (_rigidbody is null) Debug.LogError("Rigidbody not found on player object");
        if (_playerMovement is null) Debug.LogError("PlayerMovement not found on player object");
        if (_playerVfx is null) Debug.LogError("PlayerVfx not found on player object");
        
        _playerState = PlayerState.Normal;
    }

    private void Update() {
        if (_playerState == PlayerState.Normal && Mouse.current.rightButton.wasPressedThisFrame) {
            _playerMovement.MovePlayer();
        }
    }
}
