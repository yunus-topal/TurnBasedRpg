using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerScripts {
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Player Stats")]
        [SerializeField] private float speed;
        
        private Coroutine _moveCoroutine;
        private Camera _mainCamera;
        private PlayerVfx _playerVfx;

        private void Start() {
            TryGetComponent(out _playerVfx);
            _mainCamera = Camera.main;
        }

        public void MovePlayer() {
            // get the position of the mouse click
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                var hitTag = hit.transform.gameObject.tag;
                switch (hitTag) {
                    case "Ground":
                        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);
                        _moveCoroutine = StartCoroutine(MoveToTargetPoint(hit.point));
                        _playerVfx.PlayMoveVfx(hit.point);
                        break;
                    case "Enemy":
                        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);
                        AttackEnemy(hit.transform.gameObject);
                        break;
                        
                    default:
                        Debug.Log("Unknown tag clicked: " + hitTag);
                        break;
                }
            }
            
        }
        
        private IEnumerator MoveToTargetPoint(Vector3 target) {
            target.y = transform.position.y;
            while(transform.position != target) {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
        }
        
        private void AttackEnemy(GameObject enemy) {
            Debug.Log("Attacking enemy");
        }
    }
}
