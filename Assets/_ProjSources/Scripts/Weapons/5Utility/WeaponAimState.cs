using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponAimState : MonoBehaviour
    {
        #region Variables & Properties

        [SerializeField] GameObject aimCam;

        #endregion

        #region Custom Methods

        public void AimToggle(bool isAim)
        {
            aimCam.SetActive(isAim);
        }

        #endregion
    }

}