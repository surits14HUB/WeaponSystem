using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Weapons
{
    [RequireComponent(typeof(WeaponsController))]
    public class WeaponsView : MonoBehaviour
    {
        #region Variables & Properties

        private bool initWeaponSystem;
        private bool canAim;
        private bool canPick;
        private WeaponsController controller;
        private GameObject tempWeaponObj;
        [SerializeField] GameObject pickWeapon;
        [SerializeField] TMPro.TMP_Text currentWeaponName;
        [SerializeField] TMPro.TMP_Text ammoInCurrentMagazine;
        [SerializeField] TMPro.TMP_Text totalAmmoRemaining;
        [SerializeField] GameObject instructionsPanel;
        [SerializeField] GameObject instructionsImage;
        [SerializeField] Movement.CameraMovement cameraMovement;
        public static System.Action<InitData> OnWeaponChanged { get; private set; }
        public static System.Action<AmmoData> OnAmmoChanged { get; private set; }
        public static System.Action<PickZoneState> OnPickZoneStateChanged { get; set; }
        public static System.Action<GameObject, bool> ShowPickUpWeapon { get; set; }

        #endregion

        #region Monobehaviour Methods

        private void Awake()
        {
            controller = GetComponent<WeaponsController>();

            ShowPickUpWeapon = NearWeapon;
            OnWeaponChanged = OnWeaponValueChanged;
            OnAmmoChanged = OnAmmoValueChanged;
        }
        private void Start()
        {
            SetInstructionPanelStatus(true);
        }
        private void OnDestroy()
        {
            ShowPickUpWeapon -= NearWeapon;
            OnWeaponChanged -= OnWeaponValueChanged;
            OnAmmoChanged -= OnAmmoValueChanged;
        }
        private void Update()
        {
            if (!initWeaponSystem)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                OnAttack();
            }
            if (canAim)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    OnAim();
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    OnAim();
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnReload();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                SetInstructionPanelStatus(true);
            }
            if (canPick && Input.GetKeyDown(KeyCode.E))
            {
                PickWeapon();
            }
        }

        #endregion

        #region Custom Methods

        private void OnWeaponValueChanged(InitData data)
        {
            if (K.Instance.kDebug) { Debug.Log("OnWeaponChanged"); }

            if (data != null)
            {
                currentWeaponName.text = data.name;
                SetUIStatus(data.weaponType);
            }
        }
        private void OnAmmoValueChanged(AmmoData data)
        {
            if (K.Instance.kDebug) { Debug.Log("OnWeaponChanged"); }

            if (data != null)
            {
                canAim = data.isScoped;
                ammoInCurrentMagazine.text = data.ammoInCurrentMagazine.ToString();
                totalAmmoRemaining.text = data.totalAmmoAvailable.ToString();
            }
        }
        private void SetUIStatus(WeaponType weaponType)
        {
            if (K.Instance.kDebug) { Debug.Log("Setting UI for type = " + weaponType); }

            canAim = weaponType != WeaponType.MELEE;
            totalAmmoRemaining.gameObject.SetActive(weaponType != WeaponType.MELEE);
            ammoInCurrentMagazine.gameObject.SetActive(weaponType == WeaponType.SHOOTING);
        }

        private void NearWeapon(GameObject weaponObj, bool isNear)
        {
            tempWeaponObj = weaponObj;
            canPick = isNear;
            pickWeapon.SetActive(isNear);
        }
        private void PickWeapon()
        {
            tempWeaponObj.GetComponent<WeaponState>().pickState = PickState.Picked;
            pickWeapon.SetActive(false);
            controller.OnPickWeapon(tempWeaponObj);
        }

        public void OnAttack()
        {
            controller.Attack();
        }
        public void OnReload()
        {
            controller.Reload();
        }
        private void OnAim()
        {
            controller.Aim();
        }
        public void SetInstructionPanelStatus(bool status)
        {
            instructionsPanel.SetActive(status);
            instructionsImage.SetActive(!status);

            cameraMovement.LockMovement = status;

            Cursor.visible = status;
            Cursor.lockState = status ? CursorLockMode.None : CursorLockMode.Locked;

            initWeaponSystem = !status;
        }

        #endregion
    }
}