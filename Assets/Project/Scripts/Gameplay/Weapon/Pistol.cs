using UnityEngine;
using Zenject;

namespace Project.Gameplay.Weapon
{
    public class Pistol : AbstractWeapon
    {
        [SerializeField] private float cooldown = 0.5f;
        [SerializeField] private float damage = 1;
        [SerializeField] private float reloadTime = 3;
        [SerializeField] private float range = 100;
        [SerializeField] private int ammo;
        [SerializeField] private LayerMask targetLayerMask;
        
        
        [Header("Dependencies")]
        [SerializeField] private Animator animator;

        [Inject] private CameraAnchor _cameraAnchor;
        

        private float _lastShotTime;
        private int _currentAmmo;
        private static readonly int ShootTrigger = Animator.StringToHash("Shoot");

        private void Start()
        {
            _currentAmmo = ammo;
        }

        public override void Shoot()
        {
            if (_lastShotTime + cooldown > Time.time) return;
            _lastShotTime = Time.time;

            RaycastHit hit;
            if (Physics.Raycast(_cameraAnchor.CurrentCamera.transform.position,
                    _cameraAnchor.CurrentCamera.transform.forward, out hit, range, targetLayerMask))
            {
                if (hit.collider.gameObject.TryGetComponent<Health>(out var health))
                {
                    health.Damage(damage);
                }
            }
            
            animator.SetTrigger(ShootTrigger);
        }
    }
}