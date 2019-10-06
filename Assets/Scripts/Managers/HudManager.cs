using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class HudManager : MonoBehaviour
    {
        [SerializeField] private Manager _manager;

        [SerializeField] private TextMeshProUGUI ammoLabel;
        [SerializeField] private TextMeshProUGUI magazinesLabel;

        private void Awake()
        {
            _manager.updateAmmoAmount += updateAmmo;
            _manager.updateMagazineAmount += updateMagazines;
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
