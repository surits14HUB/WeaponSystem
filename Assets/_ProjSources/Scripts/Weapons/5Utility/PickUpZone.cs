using UnityEngine;

namespace Weapons
{
    public enum PickZoneState
    {
        OutOfZone,
        InZone
    }
    public class PickUpZone : MonoBehaviour
    {
        #region Monobehaviour Methods

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == WeaponConstants.TAG_PLAYER)
            {
                Debug.Log("In");
                WeaponsView.OnPickZoneStateChanged?.Invoke(PickZoneState.InZone);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == WeaponConstants.TAG_PLAYER)
            {
                Debug.Log("Out");
                WeaponsView.OnPickZoneStateChanged?.Invoke(PickZoneState.OutOfZone);
            }
        }

        #endregion
    }
}