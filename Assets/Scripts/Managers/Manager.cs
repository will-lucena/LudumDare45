using UnityEngine;
using System;

namespace Managers
{
    public class Manager : MonoBehaviour
    {
        public Action<int> updateMagazineAmount;
        public Action<int> updateAmmoAmount;
        public Action<int> updateSelectedWeapon;
        public Action<Color> updatedWeaponBag;
        public Action<int> updateAmountOfWeapons;

        [SerializeField] private Player player;
        private EnemyManager _enemyManager;
        
        private void Awake()
        {
            player.updateAmmoHud += updateAmmoAmount;
            player.updateMagazinesHud += updateMagazineAmount;
            player.updateSelectedWeapon += updateSelectedWeapon;
            player.updateAmountOfWeapons += updateAmountOfWeapons;
            player.updatedWeaponBag += updatedWeaponBag;

            _enemyManager = GetComponent<EnemyManager>();
        }
    }
}
