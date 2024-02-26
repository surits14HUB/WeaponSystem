using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables & Properties

        [SerializeField] float moveSpeed;

        #endregion

        #region Monobehaviour Methods

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position = this.transform.position + new Vector3(0, 0, 1f * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position = this.transform.position + new Vector3(1f * moveSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position = this.transform.position + new Vector3(0, 0, -1f * moveSpeed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.position = this.transform.position + new Vector3(-1f * moveSpeed, 0, 0);
            }
        }

        #endregion
    }
}