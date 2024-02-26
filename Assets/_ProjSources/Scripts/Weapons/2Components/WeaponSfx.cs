using UnityEngine;

namespace Weapons
{
    public class WeaponSfx : WeaponFx
    {
        #region Variables & Properties

        private AudioSource audioSource;
        [SerializeField] AudioClip[] fxClips;

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Overrided method of the abstract method from the base class
        /// </summary>
        /// <param name="fxName">Name of the FX file</param>
        public override void PlayFX(string fxName)
        {
            for (int i = 0; i < fxClips.Length; i++)
            {
                if (fxClips[i].name == fxName)
                {
                    audioSource.PlayOneShot(fxClips[i]);
                }
            }
        }

        #endregion
    }
}