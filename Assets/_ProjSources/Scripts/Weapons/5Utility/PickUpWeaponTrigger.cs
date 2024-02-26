using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class PickUpWeaponTrigger : MonoBehaviour
    {
        #region Variables & Properties

        RaycastHit[] hits;
        private PickZoneState pickZoneState;

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            pickZoneState = PickZoneState.OutOfZone;
            hits = new RaycastHit[1];
            WeaponsView.OnPickZoneStateChanged = OnPickUpZoneValueChanged;
        }
        void OnDestroy()
        {
            WeaponsView.OnPickZoneStateChanged -= OnPickUpZoneValueChanged;
        }
        private void Update()
        {
            if (pickZoneState == PickZoneState.OutOfZone)
            {
                WeaponsView.ShowPickUpWeapon?.Invoke(null, false);
                return;
            }

            var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            var count = Physics.RaycastNonAlloc(ray, hits, WeaponConstants.MAX_RAYCAST_DISTANCE, 1 << WeaponConstants.LAYER_PICKUP_ITEM);

            if (count == 0)
            {
                return;
            }

            var tempWeaponObj = hits[0].collider.gameObject;
            var weaponState = tempWeaponObj.GetComponent<WeaponState>();

            if (weaponState == null)
                return;

            if (weaponState.pickState == PickState.NotPicked)
            {
                WeaponsView.ShowPickUpWeapon?.Invoke(tempWeaponObj, true);
            }
        }

        #endregion

        #region Custom Methods

        private void OnPickUpZoneValueChanged(PickZoneState state)
        {
            pickZoneState = state;
        }

        #endregion
    }
}