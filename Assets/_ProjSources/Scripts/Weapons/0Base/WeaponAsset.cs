using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Weapons
{
    public struct WeaponAsset
    {
        #region Custom Methods
        /// <summary>
        /// A static method that loads the weapon asset from the local addressables path
        /// </summary>
        /// <param name="objName">Name of the addressables asset</param>
        /// <param name="callback">Callback to return the gameobject result on completion</param>
        public static void GetAsset(string objName, System.Action<GameObject> callback)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(objName);
            handle.Completed += (operation) =>
            {
                if (operation.Status == AsyncOperationStatus.Succeeded)
                {
                    callback?.Invoke(operation.Result);
                }
                else
                {
                    Debug.LogError("Asset failed to load.");
                }
            };
        }

        #endregion
    }
}