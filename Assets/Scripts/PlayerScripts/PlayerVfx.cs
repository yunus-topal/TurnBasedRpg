using UnityEngine;

namespace PlayerScripts {
    public class PlayerVfx : MonoBehaviour
    {
        [SerializeField] private GameObject moveVfx;
        
        public void PlayMoveVfx(Vector3 target) {
            var vfx = Instantiate(moveVfx, target, Quaternion.identity);
            vfx.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(vfx, 1f);
        }
    }
}
