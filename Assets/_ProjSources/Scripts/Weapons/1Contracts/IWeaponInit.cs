using UnityEngine;

namespace Weapons
{
    public interface IWeaponInit
    {
        public void Init();
    }

    [System.Serializable]
    public class InitData
    {
        public string name;
        public WeaponType weaponType;
        public Vector3 postion;
        public Vector3 rotation;
        public Vector3 scale;

        public Quaternion Rotation()
        {
            return Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        }
    }
}