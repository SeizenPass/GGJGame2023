using Project.Gameplay.Weapon;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Gameplay.Player
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private AbstractWeapon abstractWeapon;

        public void SetWeapon(AbstractWeapon weapon)
        {
            abstractWeapon = weapon;
        }

        private void OnShoot(InputValue value)
        {
            Debug.Log("Shoot event");
        }
    }
}