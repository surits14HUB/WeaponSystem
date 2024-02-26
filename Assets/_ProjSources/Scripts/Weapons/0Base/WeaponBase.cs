using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponBase : MonoBehaviour, IWeaponAttack, IWeaponInit
    {
        #region Variables & Properties

        [SerializeField] internal InitData initData;
        [SerializeField] internal AttackData attackData;
        protected Transform[] componentTransforms;
        private IWeaponAttack[] weaponAttacks;
        private IWeaponInit[] weaponInits;
        protected bool isAttackReady = true;

        #endregion

        #region Monobehaviour Methods
        /// <summary>
        /// Get all the references of all the components in the children that implements the interfaces
        /// </summary>
        protected virtual void Awake()
        {
            // create a new array of transform
            componentTransforms = new Transform[this.transform.childCount];
            // get all the child transform and add as transform element
            for (int i = 0; i < componentTransforms.Length; i++)
            {
                componentTransforms[i] = this.transform.GetChild(i);
            }
            // find and get the references of the IWeaponAttack from the children of this weapon gameobject
            weaponAttacks = GetAllComponentsInChildren<IWeaponAttack>(componentTransforms);
            // find and get the references of the IWeaponInit from the children of this weapon gameobject
            weaponInits = GetAllComponentsInChildren<IWeaponInit>(componentTransforms);
        }

        #endregion

        #region Custom Methods
        /// <summary>
        /// Called in the model when this weapon is added to the weapon wheel/inventory
        /// </summary>
        public void Init()
        {
            if (K.Instance.kDebug) { Debug.Log("WeaponBase Init"); }
            // call the action to update the UI
            WeaponsView.OnWeaponChanged?.Invoke(initData);
            // iterate through all the references of the components that implements IWeaponInit and init those components
            for (int i = 0; i < weaponInits.Length; i++)
            {
                weaponInits[i].Init();
            }
            // set the transform values after adding the weapon to the player
            this.transform.localPosition = initData.postion;
            this.transform.localScale = initData.scale;
            this.transform.localRotation = initData.Rotation();
        }
        /// <summary>
        /// Called by the weapons controller on left mouse click
        /// </summary>
        public virtual void Attack()
        {
            // Check if the weapon is attack ready
            if (isAttackReady)
            {
                // Start the wait for next attack based on the attribute 'attackData.waitTime' for each attack
                StartCoroutine(WaitForNextAttack());
                // iterate through all the references of the components that implements IWeaponAttack and run the attack method
                for (int i = 0; i < weaponAttacks.Length; i++)
                {
                    weaponAttacks[i].Attack();
                }
            }
        }
        /// <summary>
        /// Called by the Attack method to setup for the next attack
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForNextAttack()
        {
            isAttackReady = false;
            yield return new WaitForSeconds(attackData.waitTime);
            isAttackReady = true;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Custom generic method to return the array of weapon components from the children
        /// </summary>
        /// <typeparam name="T">The interface class that needs to be found from the children</typeparam>
        /// <param name="children">All the children found in the weapon gameobject</param>
        /// <returns></returns>
        protected T[] GetAllComponentsInChildren<T>(Transform[] children)
        {
            var components = new List<T>();
            for (int i = 0; i < children.Length; i++)
            {
                var component = GetComponentFromTransform<T>(children[i]);
                if (component != null)
                {
                    components.Add(component);
                }
            }

            return components.ToArray();
        }
        /// <summary>
        /// Custom generic method to return the first element of weapon components from the children
        /// </summary>
        /// <typeparam name="T">The interface class that needs to be found from the children</typeparam>
        /// <param name="children">All the children found in the weapon gameobject</param>
        /// <returns></returns>
        protected T GetComponentFromChildren<T>(Transform[] children)
        {
            var components = new List<T>();
            for (int i = 0; i < children.Length; i++)
            {
                var component = GetComponentFromTransform<T>(children[i]);
                if (component != null)
                {
                    components.Add(component);
                    break;
                }
            }

            return components[0];
        }
        /// <summary>
        /// Custom generic method to return the weapon components from the transform
        /// </summary>
        /// <typeparam name="T">The interface class that needs to be found from the input transform</typeparam>
        /// <param name="child">The child found in the weapon gameobject</param>
        /// <returns></returns>
        protected T GetComponentFromTransform<T>(Transform child)
        {
            var component = child.GetComponent<T>();

            return component;
        }

        #endregion
    }
}