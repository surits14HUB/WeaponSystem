using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponsController : MonoBehaviour
    {
        #region Variables & Properties

        private WeaponsModel model;
        private WeaponsView view;
        [SerializeField] TextAsset weaponsData;
        private bool isAimed = false;

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            view = GetComponent<WeaponsView>();
        }
        private void Start()
        {
            if (K.Instance.kDebug) { Debug.Log("Weapons controller start"); }
            InitWeaponSystem();
        }

        #endregion

        #region Custom Methods

        private void InitWeaponSystem()
        {
            if (K.Instance.kDebug) { Debug.Log("InitWeaponSystem"); }
            if (model == null)
                model = new WeaponsModel(WeaponConstants.MAX_WEAPONS, this.transform, weaponsData.text);

            model.SetDefaultWeapon();
        }
        internal void Attack()
        {
            model.currentWeapon.Attack();
        }
        internal void Reload()
        {
            (model.currentWeapon as IWeaponReload).Reload();
        }
        internal void Aim()
        {
            isAimed = !isAimed;
            var weaponAim = this.gameObject.GetComponentInChildren<WeaponAimState>();
            if (weaponAim != null)
            {
                weaponAim.AimToggle(isAimed);
            }
        }
        internal void OnPickWeapon(GameObject weaponObj)
        {
            if (weaponObj != null)
            {
                var weaponTransform = weaponObj.transform.root;
                weaponTransform.SetParent(model.weaponsHolder);
                model.AddToWeaponWheel(weaponTransform.gameObject);
            }
        }

        #endregion

        #region Helper Methods

        private GameObject CurrentWeapon()
        {
            if (model.currentWeapon == null)
            {
                return this.transform.GetChild(0).gameObject;
            }

            return model.currentWeapon.gameObject;
        }

        #endregion
    }
}