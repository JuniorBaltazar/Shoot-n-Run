using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PCSystemShoot))]
public class InputShoot : MonoBehaviour {

    [Header("SHOOT EDITION")]
    [SerializeField]
    [Tooltip("Botão para atirar projétil.")]
    private KeyCode inputShoot = KeyCode.Mouse0;

    PCSystemShoot systemShoot;

    #region MonoBehaviours

    void Start() {
        this.systemShoot = GetComponent<PCSystemShoot>();
    }

    void Update() {
        if (Input.GetKeyDown(this.inputShoot)) {
            this.systemShoot.Shoot();
        }
    }
    #endregion
}