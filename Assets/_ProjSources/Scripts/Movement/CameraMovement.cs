using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class CameraMovement : MonoBehaviour
    {
        #region Variables & Properties

        [SerializeField] Transform player;
        [SerializeField] float lookSpeed = 3;
        private bool lockMovement = true;
        private Vector2 rotation = Vector2.zero;
        public bool LockMovement { get => lockMovement; set => lockMovement = value; }

        #endregion

        #region Monobehaviour Methods

        void LateUpdate()
        {
            if(lockMovement)
                return;

            Look();
        }
        #endregion

        #region Custom Methods

        private void Look()
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
            player.transform.eulerAngles = new Vector2(0,rotation.y) * lookSpeed;
            transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
        }

        #endregion
    }
}