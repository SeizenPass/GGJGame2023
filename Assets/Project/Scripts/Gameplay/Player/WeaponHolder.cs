using Project.Gameplay.Weapon;
using Project.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Gameplay.Player
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private AbstractWeapon abstractWeapon;

        [Inject] private PauseBehaviour _pauseBehaviour;

        public void SetWeapon(AbstractWeapon weapon)
        {
            abstractWeapon = weapon;
        }

        private void OnShoot(InputValue value)
        {
            if (_pauseBehaviour.Pause) return;
            abstractWeapon.Shoot();
        }
    }
}