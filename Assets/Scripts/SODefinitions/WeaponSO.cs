using UnityEngine;

namespace SODefinitions
{
    [CreateAssetMenu(menuName = "Weapons", fileName = "weapon")]
    public class WeaponSO : ScriptableObject
    {
        public GameObject bulletPrefab;
        public Sprite sprite;
        public int maxAmmo;
        public float bulletForce;
    }
}
