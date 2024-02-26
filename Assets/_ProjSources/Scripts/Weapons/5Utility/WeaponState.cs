using UnityEngine;

namespace Weapons
{
    public enum PickState
    {
        NotPicked,
        Picked
    }
    public class WeaponState : MonoBehaviour
    {
        [SerializeField] internal PickState pickState = PickState.NotPicked;
    }
}