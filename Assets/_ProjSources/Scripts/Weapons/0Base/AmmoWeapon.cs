using UnityEngine;

namespace Weapons
{
    public class AmmoWeapon : WeaponBase, IWeaponAmmo, IWeaponIssue
    {
        #region Variables & Properties

        IWeaponAmmo weaponAmmunition;
        IWeaponIssue[] weaponIssues;

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

            // find and get the reference of the IWeaponAmmo from the children of this weapon gameobject
            weaponAmmunition = GetComponentFromChildren<IWeaponAmmo>(componentTransforms);
            // find and get the references of the IWeaponIssue from the children of this weapon gameobject
            weaponIssues = GetAllComponentsInChildren<IWeaponIssue>(componentTransforms);
        }

        #endregion

        #region Custom Methods
        /// <summary>
        /// Overrides the base class's Attack method
        /// </summary>
        public override void Attack()
        {
            // Checks if the weapon can attack
            if (CanAttack())
            {
                // Checks if the weapon can attack
                base.Attack();
            }
            else
            {
                // Run the CannotAttack method
                CannotAttack();
            }
        }
        /// <summary>
        /// Checks the weapons ammunition component if the weapon can shoot/attack now
        /// </summary>
        /// <returns></returns>
        public bool CanAttack()
        {
            return weaponAmmunition.CanAttack();
        }
        /// <summary>
        /// Checks the weapons ammunition component if the weapon can reload now
        /// </summary>
        /// <returns></returns>
        public bool CanReload()
        {
            return weaponAmmunition.CanReload();
        }
        /// <summary>
        /// Called when the player picks ammo from the ammo crate
        /// </summary>
        /// <param name="newAmmo">The number of ammo picked up from the crate</param>
        /// <param name="isGoActive">Returns if the weapon gameobject is active or not in the scene when the ammo was picked</param>
        public void Refill(int newAmmo, bool isGoActive)
        {
            weaponAmmunition.Refill(newAmmo, isGoActive);
        }
        /// <summary>
        /// Iterate through all the components that implements IWeaponIssue and call the Cannot Attack method
        /// </summary>
        public void CannotAttack()
        {
            for (int i = 0; i < weaponIssues.Length; i++)
            {
                weaponIssues[i].CannotAttack();
            }
        }

        #endregion
    }
}