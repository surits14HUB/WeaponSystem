using System.Runtime.InteropServices.WindowsRuntime;

namespace Weapons
{
    [System.Serializable]
    public class WeaponDataResponse
    {
        public bool status;
        public string message;
        public WeaponData[] data;
    }
    [System.Serializable]
    public class WeaponData
    {
        public bool isDefault;
        public string weaponType;
        public string name;
    }
}