using UnityEngine;

namespace Weapons
{
    public class K : MonoBehaviour
    {
        #region Variables & Properties

        private static K inst = null;
        public static K Instance
        {
            get
            {
                if (inst == null)
                    inst = FindObjectOfType<K>();

                if (inst == null)
                {
                    GameObject gObj = new GameObject();
                    gObj.name = "K";
                    inst = gObj.AddComponent<K>();
                    DontDestroyOnLoad(gObj);
                }
                return inst;
            }
        }
        public bool kDebug;

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            if (inst == null)
            {
                inst = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //    if(K.Instance.kDebug) {Debug.Log("");}

        #endregion
    }
}