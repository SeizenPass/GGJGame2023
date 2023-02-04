using UnityEngine;

namespace Project.Zone
{
    public class ZoneChecker : MonoBehaviour
    {
        [SerializeField] private float radius;

        public bool Check(LayerMask targetLayer)
        {
            var position = transform.position;
            return Physics.CheckSphere(position, radius, targetLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, radius/2);
        }
    }
}