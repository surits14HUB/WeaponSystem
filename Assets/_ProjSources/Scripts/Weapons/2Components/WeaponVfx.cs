using UnityEngine;

namespace Weapons
{
    public class WeaponVfx : WeaponFx
    {
        #region Variables & Properties

        // private ParticleSystem[] fxSystems;

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            // fxSystems = GetComponentsInChildren<ParticleSystem>();
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Overrided method of the abstract method from the base class
        /// </summary>
        /// <param name="fxName">Name of the FX file</param>
        public override void PlayFX(string fxName)
        {
            // for (int i = 0; i < fxSystems.Length; i++)
            // {
            //     if (fxSystems[i].name == fxName)
            //     {
            //         fxSystems[i].Play();
            //     }
            // }
        }

        #endregion
    }
}