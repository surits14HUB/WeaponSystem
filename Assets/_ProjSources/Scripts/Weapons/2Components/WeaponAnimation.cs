using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class WeaponAnimation : MonoBehaviour, IWeaponInit, IWeaponAttack, IWeaponReload, IWeaponIssue
    {
        #region Variables & Properties

        private Animator animator;

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Called by the weapon class on Init
        /// </summary>
        public void Init()
        {
            if (K.Instance.kDebug) { Debug.Log("WeaponAnimation Init"); }
            Animate(WeaponConstants.CLIPNAME_INIT);
        }
        /// <summary>
        /// Called by the all the methods implemented by the interfaces this class implements
        /// </summary>
        private void Animate(string clipName, bool isRebind = true, bool checkIfCurrent = false)
        {
            if (animator != null)
            {
                if(isRebind)
                {
                    animator.Rebind();
                }
                if(checkIfCurrent && IsCurrentClipSame(clipName))
                {
                    return;
                }

                animator.Play("Base Layer." + clipName, 0, 0.0f);
            }
        }
        /// <summary>
        /// When called this method will animate the Attack clip
        /// </summary>
        public void Attack()
        {
            Animate(WeaponConstants.CLIPNAME_ATTACK);
        }
        /// <summary>
        /// When called this method will animate the Reload clip
        /// </summary>
        public void Reload()
        {
            Animate(WeaponConstants.CLIPNAME_RELOAD);
        }
        /// <summary>
        /// When called this method will animate the CannotAttack clip
        /// </summary>
        public void CannotAttack()
        {
            Animate(WeaponConstants.CLIPNAME_CANNOT_ATTACK, false, true);
        }

        #endregion

        #region Helper Methods

        private AnimationClip GetClip(string clipName)
        {
            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                if (animator.runtimeAnimatorController.animationClips[i].name == clipName)
                {
                    return animator.runtimeAnimatorController.animationClips[i];
                }
            }

            return null;
        }
        /// <summary>
        /// Checks if the clipName and he current clip in the animator are same
        /// </summary>
        /// <param name="clipName">The clip that the weapon wants to play</param>
        /// <returns>Returns true if the current clip in the animator is same as the requested clipName</returns>
        private bool IsCurrentClipSame(string clipName)
        {
            var info = animator.GetCurrentAnimatorClipInfo(0);
            return info[0].clip.name.Contains(clipName);
        }

        #endregion
    }
}