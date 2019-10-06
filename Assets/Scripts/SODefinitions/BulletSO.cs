using UnityEngine;

namespace SODefinitions
{
    [CreateAssetMenu(menuName = "Bullet", fileName = "bullet")]
    public class BulletSO : ScriptableObject
    {
        public GameObject vfx;
        public bool destroyOnFirstHit;
    }
}
