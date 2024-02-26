using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponFx : MonoBehaviour, IWeaponInit, IWeaponFx, IWeaponAttack, IWeaponReload, IWeaponIssue
    {
        #region Variables & Properties

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Custom Methods
        /// <summary>
        /// An abstract method that should be implemented by all the class that inherits this class
        /// </summary>
        /// <param name="fxName">Name of the FX file</param>
        public abstract void PlayFX(string fxName);
        /// <summary>
        /// Called by the weapon base class on attack
        /// </summary>
        public void Attack()
        {
            PlayFX(WeaponConstants.CLIPNAME_ATTACK);
        }
        /// <summary>
        /// Called by the weapon base class on reload
        /// </summary>
        public void Reload()
        {
            PlayFX(WeaponConstants.CLIPNAME_RELOAD);
        }
        /// <summary>
        /// Called by the weapon base class on init
        /// </summary>
        public void Init()
        {
            PlayFX(WeaponConstants.CLIPNAME_INIT);
        }
        /// <summary>
        /// Called by the weapon class on cannot attack
        /// </summary>
        public void CannotAttack()
        {
            PlayFX(WeaponConstants.CLIPNAME_CANNOT_ATTACK);
        }

        #endregion
    }
}