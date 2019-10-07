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
        public Action<float> updateScore;

        [SerializeField] private Player player;
        private float score;
        
        private void Awake()
        {
            player.updateAmmoHud += updateAmmoAmount;
            player.updateMagazinesHud += updateMagazineAmount;
            player.updateSelectedWeapon += updateSelectedWeapon;
            player.updateAmountOfWeapons += updateAmountOfWeapons;
            player.updatedWeaponBag += updatedWeaponBag;

            Enemy.updateScore += listenScoreChange;
        }

        private void Update()
        {
            listenScoreChange(Time.deltaTime);
        }

        private void listenScoreChange(float amount)
        {
            score += amount;
            updateScore?.Invoke(score);
        }
    }
}
