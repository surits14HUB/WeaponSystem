
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    public class WeaponAmmunition : MonoBehaviour, IWeaponInit, IWeaponAmmo, IWeaponAttack, IWeaponReload
    {
        #region Variables & Properties

        [SerializeField] private AmmoData ammoData;

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Custom Methods
        /// <summary>
        /// Called by the weapon class on Init
        /// </summary>
        public void Init()
        {
            ammoData.Init();
        }
        /// <summary>
        /// Called by the weapon controller when the player picks an ammmo crate
        /// </summary>
        /// <param name="newAmmo"></param>
        /// <param name="isGoActive"></param>
        public void Refill(int newAmmo, bool isGoActive)
        {
            ammoData.Refill(newAmmo, isGoActive);
        }
        /// <summary>
        /// Called by the AmmoWeapon class to check if the weapon can attack
        /// </summary>
        /// <returns>Returns true if the total ammo left in the current magazine is more than 0</returns>
        public bool CanAttack()
        {
            return ammoData.CanAttack();
        }
        /// <summary>
        /// Called by the ReloadWeapon class to check if the weapon can reload
        /// </summary>
        /// <returns>Returns true it the total ammo available is more than 0 and if the ammo in current magazine is less than the max ammo allowed per magazine</returns>
        public bool CanReload()
        {
            return ammoData.CanReload();
        }
        /// <summary>
        /// Called by the ReloadWeapon class on reload
        /// </summary>
        public void Reload()
        {
            ammoData.Reload();
        }
        /// <summary>
        /// Called by the weapon base class on attack
        /// </summary>
        public void Attack()
        {
            ammoData.Attack();
        }

        #endregion
    }
}