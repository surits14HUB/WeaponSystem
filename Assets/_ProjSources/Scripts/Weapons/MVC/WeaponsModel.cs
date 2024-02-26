using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    internal class WeaponsModel
    {
        #region Variables & Properties

        private readonly WeaponData[] weaponData;
        private readonly List<WeaponBase> weaponWheel;
        internal WeaponBase currentWeapon;
        internal readonly Transform weaponsHolder;
        internal WeaponsModel(int initCapacity, Transform _holder, string _response)
        {
            if (K.Instance.kDebug) { Debug.Log("Init Weapons model"); }

            weaponWheel = new List<WeaponBase>(initCapacity);
            weaponsHolder = _holder;
            var response = JsonUtility.FromJson<WeaponDataResponse>(_response);
            weaponData = response.data;
        }

        #endregion

        #region Custom Methods

        internal void SetDefaultWeapon()
        {
            if (K.Instance.kDebug) { Debug.Log("SetDefaultWeapon"); }

            for (int i = 0; i < weaponData.Length; i++)
            {
                if (weaponData[i].isDefault)
                {
                    System.Action<GameObject> callback = (result) =>
                    {
                        if (K.Instance.kDebug) { Debug.Log("result = " + result.name); }

                        var weaponGO = GameObject.Instantiate(result, weaponsHolder);
                        AddToWeaponWheel(weaponGO);
                    };
                    WeaponAsset.GetAsset(weaponData[i].name, callback);
                    break;
                }
            }
        }
        internal void AddToWeaponWheel(GameObject InstantiatedFile, bool isCurrentWeapon = true)
        {
            if (K.Instance.kDebug) { Debug.Log("AddToWeaponWheel"); }

            WeaponBase weapon = InstantiatedFile.GetComponent<WeaponBase>();
            weaponWheel.Add(weapon);
            InstantiatedFile.SetActive(isCurrentWeapon);

            if (isCurrentWeapon)
            {
                if (K.Instance.kDebug) { Debug.Log("isCurrentWeapon"); }
                if (currentWeapon != null)
                {
                    currentWeapon.gameObject.SetActive(false);
                }
                currentWeapon = weapon;
            }
            weapon.Init();
        }

        #endregion
    }
}