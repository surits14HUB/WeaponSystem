using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public struct WeaponConstants
    {
        #region Attribute
        public const int MAX_WEAPONS = 4;
        public const float MAX_RAYCAST_DISTANCE = 1f;

        #endregion

        #region Animation

        public const string CLIPNAME_ATTACK = "Attack";
        public const string CLIPNAME_CANNOT_ATTACK = "CannotAttack";
        public const string CLIPNAME_RELOAD = "Reload";
        public const string CLIPNAME_INIT = "Init";

        #endregion

        #region Tags

        public const string TAG_PLAYER = "Player";
        public const string TAG_WEAPON = "Weapon";

        #endregion

        #region Layers
        public const int LAYER_PICKUP_ZONE = 6;
        public const int LAYER_PICKUP_ITEM = 7;

        #endregion
    }

    public enum WeaponType
    {
        MELEE,
        SHOOTING,
        THROWABLE
    }
    public enum WeaponDataStatus
    {
        INIT,
        ATTACK,
        RELOAD
    }
}