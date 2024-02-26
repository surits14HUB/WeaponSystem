using UnityEngine;

namespace Weapons
{
    public class ReloadWeapon : AmmoWeapon, IWeaponReload
    {
        #region Variables & Properties

        IWeaponReload[] weaponReloads;

        #endregion

        #region Monobehaviour Methods
        /// <summary>
        /// Overrides the base class's Awake method
        /// Get all the references of all the components in the children that implements the interfaces
        /// </summary>
        protected override void Awake()
        {
            // Run the base class's awake method to get all the basic references
            base.Awake();
            // find and get the references of the IWeaponReload from the children of this weapon gameobject
            weaponReloads = GetAllComponentsInChildren<IWeaponReload>(componentTransforms);
        }

        #endregion

        #region Custom Methods
        /// <summary>
        /// Iterate through all the components that implements the IWeaponReload interface and run the Reload method
        /// </summary>
        public void Reload()
        {
            // Checks the base class method CanReload to see if the weapon can reload
            if (CanReload())
            {
                for (int i = 0; i < weaponReloads.Length; i++)
                {
                    weaponReloads[i].Reload();
                }
            }
        }

        #endregion
    }
}