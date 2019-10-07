using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class HudManager : MonoBehaviour
    {
        [SerializeField] private Manager _manager;

        [SerializeField] private TextMeshProUGUI ammoLabel;
        [SerializeField] private TextMeshProUGUI magazinesLabel;
        [SerializeField] private TextMeshProUGUI changeLabel; 
        [SerializeField] private List<Image> weapons;
        [SerializeField] private List<Image> weaponsHighlight;
        [SerializeField] private TextMeshProUGUI scoreLabel;

        private int items;
        private int selectedIndex;
        
        private void Awake()
        {
            _manager.updateAmmoAmount += updateAmmo;
            _manager.updateMagazineAmount += updateMagazines;
            _manager.updateAmountOfWeapons += showChangebutton;
            _manager.updatedWeaponBag += updateWeapons;
            _manager.updateSelectedWeapon += changeSelection;
            _manager.updateScore += updateScore;
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

        private void updateWeapons(Color weapon)
        {
            int index = items;
            if (items > 1)
            {
                index = selectedIndex == 0 ? 1 : 0;
                items--;
            }
            weapons[index].gameObject.SetActive(true);
            weapons[index].color = weapon;
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
