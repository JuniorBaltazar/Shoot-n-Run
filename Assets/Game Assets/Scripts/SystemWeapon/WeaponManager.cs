using System.Collections.Generic;
using UnityEngine;
using SO.WeaponManager;

public class WeaponManager : MonoBehaviour {
    
    [Space(5)]
    [Header("WEAPONS EDITION")]
    [SerializeField] [Tooltip("Vá em Create -> Weapon -> Weapons Manager -> Create List Weapon.")]
    private SOListWeapon weapons = null;

    [SerializeField] [Tooltip("Mochila onde são guardadas TODAS as balas.")]
    private Transform superBagBullet = null;

    private PCSystemShoot sShoot;
    private byte indexWeapon = 0;

    #region MonoBehaviour
    private void Awake() {
        this.sShoot = GetComponent<PCSystemShoot>();
    }

    private void Start() {
        this.indexWeapon = 0; // Por default a primeira arma é utilizada.
        SOWeapon weapon = this.weapons.listWeapons[indexWeapon].weapon;

        this.CreateWeapon();
        this.sShoot.SetWeaponValues(weapon, this.superBagBullet, this.indexWeapon);
    }

    private void Update() {
        this.SwitchWeapons();
    }
    #endregion

    #region Create Weapon
    /// <summary>
    /// Cria todas as armas.
    /// </summary>
    private void CreateWeapon() {
        //Cria todas as armas dentro da lista.
        for (byte i = 0; i < this.weapons.listWeapons.Count; i++) {
            SOWeapon weapon = this.weapons.listWeapons[i].weapon;
            this.sShoot.InstantiateBullet(weapon, superBagBullet, i);
        }
    }
    #endregion

    #region Switch Weapons
    /// <summary>
    /// Faz a troca de armas.
    /// </summary>
    private void SwitchWeapons () {
        float mouseAxis =  Input.GetAxisRaw("Mouse ScrollWheel");
        int weaponsAmount = this.weapons.listWeapons.Count - 1;

        #region Mouse Scroll
        if (mouseAxis > 0) {
            if (this.indexWeapon == (byte) weaponsAmount)
                this.indexWeapon = 0;
            else
                this.indexWeapon++;

        } else if (mouseAxis < 0) {
            this.indexWeapon--;
        }
        #endregion

        this.indexWeapon = (byte) Mathf.Clamp(this.indexWeapon, 0, (byte) weaponsAmount);
        SOWeapon weapon = this.weapons.listWeapons[indexWeapon].weapon;

        this.sShoot.SetWeaponValues(weapon, this.superBagBullet, this.indexWeapon);
    }
    #endregion    
}

#region Weapons
[System.Serializable]
public class Weapons {
    [Tooltip("Nome da arma.")]
    public string weaponName;

    [Tooltip("Estrutura completa da arma.")]
    public SOWeapon weapon;
}
#endregion