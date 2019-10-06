using UnityEngine;
using System;

namespace Managers
{
    public class Manager : MonoBehaviour
    {
        public Action<int> updateMagazineAmount;
        public Action<int> updateAmmoAmount;

        [SerializeField] private Player player;
        
        private void Awake()
        {
            player.updateAmmoHud += updateAmmoAmount;
            player.updateMagazinesHud += updateMagazineAmount;
        }
    }
}
