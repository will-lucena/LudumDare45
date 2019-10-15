﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class HudManager : MonoBehaviour
    {
        [SerializeField] private Manager _manager;

        [SerializeField] private TextMeshProUGUI ammoLabel;
        [SerializeField] private TextMeshProUGUI magazinesLabel;
        [SerializeField] private Image changeLabel; 
        [SerializeField] private List<Image> weapons;
        [SerializeField] private List<Image> weaponsHighlight;
        [SerializeField] private TextMeshProUGUI scoreLabel;
        [SerializeField] private GameObject gameoverScreen;
        [SerializeField] private Image health;

        private int items;
        private int selectedIndex;

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
            _manager.updateAmmoAmount += updateAmmo;
            _manager.updateMagazineAmount += updateMagazines;
            _manager.updateAmountOfWeapons += showChangebutton;
            _manager.updatedWeaponBag += updateWeapons;
            _manager.updateSelectedWeapon += changeSelection;
            _manager.updateScore += updateScore;
            _manager.showGameoverScreen += gameover;
            _manager.updateHealthHud += updateHealth;
        }
        
        private void unsubscription()
        {
            _manager.updateAmmoAmount -= updateAmmo;
            _manager.updateMagazineAmount -= updateMagazines;
            _manager.updateAmountOfWeapons -= showChangebutton;
            _manager.updatedWeaponBag -= updateWeapons;
            _manager.updateSelectedWeapon -= changeSelection;
            _manager.updateScore -= updateScore;
            _manager.showGameoverScreen -= gameover;
            _manager.updateHealthHud -= updateHealth;
        }

        private void updateHealth(float amount)
        {
            float healthRate = amount / 100;
            Debug.Log(healthRate);
            health.color = new Color(255, 0, 0, 1 * (1 - healthRate) * 0.8f);
        }
        
        private void gameover()
        {
            gameoverScreen.SetActive(true);
            Invoke("goToMenu", 3);
        }

        private void goToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        
        private void updateScore(float value)
        {
            scoreLabel.text = "Score: " + value.ToString("F2");
        }
        
        //TODO: To generalize it to any size of items
        private void changeSelection(int index)
        {
            if (index == 0)
            {
                weaponsHighlight[0].gameObject.SetActive(true);
                weaponsHighlight[1].gameObject.SetActive(false);
                selectedIndex = 0;
            }
            else
            {
                weaponsHighlight[1].gameObject.SetActive(true);
                weaponsHighlight[0].gameObject.SetActive(false);
                selectedIndex = 1;
            }
        }

        private void showChangebutton(int amount)
        {
            if (amount > 1)
            {
                changeLabel.gameObject.SetActive(true);
            }
        }

        private void updateWeapons(Sprite weapon)
        {
            int index = items;
            if (items > 1)
            {
                index = selectedIndex == 0 ? 1 : 0;
                items--;
            }
            weapons[index].gameObject.SetActive(true);
            weapons[index].sprite = weapon;
            changeSelection(0);
            items++;
        }
        
        private void updateAmmo(int amount)
        {
            ammoLabel.text = "Ammunition\nx " + amount;
        }

        private void updateMagazines(int amount)
        {
            magazinesLabel.text = "Magazines\nx " + amount;
        }
    }
}
