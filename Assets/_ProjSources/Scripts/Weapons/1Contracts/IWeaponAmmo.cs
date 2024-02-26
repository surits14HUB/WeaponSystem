using System.Collections;
using System.Collections.Generic;

namespace Weapons
{
    public interface IWeaponAmmo
    {
        public bool CanAttack();
        public bool CanReload();
        public void Refill(int newAmmo, bool isGoActive);
    }

    [System.Serializable]
    public class AmmoData : IWeaponInit, IWeaponAmmo, IWeaponAttack, IWeaponReload
    {
        public bool isScoped = false;
        public int ammoMax;
        public int ammoMaxPerMagazine;
        public int ammoInCurrentMagazine { get; private set; }
        public int totalAmmoAvailable { get; private set; }
        /// <summary>
        /// Setup the weapon's ammo values
        /// </summary>
        public void Init()
        {
            ammoInCurrentMagazine = ammoMaxPerMagazine;
            totalAmmoAvailable = ammoMax - ammoMaxPerMagazine;
            UpdateUI();
        }
        /// <summary>
        /// Called when the player can attack on left mouse click
        /// </summary>
        public void Attack()
        {
            ammoInCurrentMagazine--;
            UpdateUI();
        }
        /// <summary>
        /// Called the weapon is reloadable
        /// </summary>
        public void Reload()
        {
            var bulletsToBeLoaded = ammoMaxPerMagazine - ammoInCurrentMagazine;
            if(bulletsToBeLoaded == 0)
            {
                return;
            }
            if(bulletsToBeLoaded > totalAmmoAvailable)
            {
                bulletsToBeLoaded = totalAmmoAvailable;
            }

            ammoInCurrentMagazine += bulletsToBeLoaded;
            totalAmmoAvailable = totalAmmoAvailable - bulletsToBeLoaded;
            UpdateUI();
        }
        /// <summary>
        /// Called to check if the player can attack
        /// </summary>
        /// <returns>Returns true if the total ammo left in the current magazine is more than 0</returns>
        public bool CanAttack()
        {
            return ammoInCurrentMagazine > 0;
        }
        /// <summary>
        /// Called to check if the player can reload the current weapon
        /// </summary>
        /// <returns>Returns true it the total ammo available is more than 0 and if the ammo in current magazine is less than the max ammo allowed per magazine</returns>
        public bool CanReload()
        {
            return totalAmmoAvailable > 0 && ammoInCurrentMagazine < ammoMaxPerMagazine;
        }
        /// <summary>
        /// Called when the player picks up ammo from the ammo crate
        /// </summary>
        /// <param name="newAmmo"></param>
        /// <param name="isGoActive"></param>
        public void Refill(int newAmmo, bool isGoActive)
        {
            var allowed = ammoMax - ammoMaxPerMagazine;
            totalAmmoAvailable += newAmmo;
            if (totalAmmoAvailable > allowed)
            {
                totalAmmoAvailable = allowed;
            }
            if (isGoActive)
            {
                UpdateUI();
            }
        }
        /// <summary>
        /// Called by the above methods to inform the view class to update the UI after ammo interaction as taken place
        /// </summary>
        private void UpdateUI()
        {
            WeaponsView.OnAmmoChanged?.Invoke(this);
        }
    }
}