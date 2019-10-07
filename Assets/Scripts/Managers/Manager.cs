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
        public Action showGameoverScreen;

        [SerializeField] private Player player;
        private float score;

        private void Update()
        {
            listenScoreChange(Time.deltaTime);
        }

        private void listenScoreChange(float amount)
        {
            score += amount;
            updateScore?.Invoke(score);
        }

        private void callEndGame()
        {
            showGameoverScreen?.Invoke();
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            subscription();
        }

        private void OnDisable()
        {
            unsubscription();        
        }

        private void subscription()
        {
            player.updateAmmoHud += updateAmmoAmount;
            player.updateMagazinesHud += updateMagazineAmount;
            player.updateSelectedWeapon += updateSelectedWeapon;
            player.updateAmountOfWeapons += updateAmountOfWeapons;
            player.updatedWeaponBag += updatedWeaponBag;
            player.deathPerAmmo += callEndGame;
            player.deathPerHealth += callEndGame;
        }

        private void unsubscription()
        {
            player.updateAmmoHud -= updateAmmoAmount;
            player.updateMagazinesHud -= updateMagazineAmount;
            player.updateSelectedWeapon -= updateSelectedWeapon;
            player.updateAmountOfWeapons -= updateAmountOfWeapons;
            player.updatedWeaponBag -= updatedWeaponBag;
            player.deathPerAmmo -= callEndGame;
            player.deathPerHealth -= callEndGame;
        }
    }
}
