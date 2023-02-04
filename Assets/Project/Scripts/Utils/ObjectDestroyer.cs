using UnityEngine;

namespace Project.Utils
{
    public class ObjectDestroyer : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}