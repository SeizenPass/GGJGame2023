using UnityEngine;

namespace Project.Gameplay.Weapon
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField] private string weaponName;
        
        public abstract void Shoot();
        
        
    }
}