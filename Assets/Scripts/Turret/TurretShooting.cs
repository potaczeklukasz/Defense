using UnityEngine;
using UnityEngine.InputSystem;

namespace Turret
{
    public class TurretShooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float spawnBulletDuration;

        private Camera _mainCamera;
        private float _bulletTimer;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            _bulletTimer -= Time.deltaTime;

            if (_bulletTimer <= 0 && Touchscreen.current.primaryTouch.press.isPressed)
            {
                var touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                Vector2 targetPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

                var spawnPosition = Vector2.MoveTowards(transform.position, targetPosition, .75f);
                var direction = targetPosition - (Vector2) transform.position;

                var bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                var bulletControls = bullet.GetComponent<Bullet.Bullet>();
                bulletControls.SetDirection(direction);
                _bulletTimer = spawnBulletDuration;
            }
        }
    }
}