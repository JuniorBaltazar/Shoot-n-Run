using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.WeaponManager;

public partial class PCSystemShoot {

    #region Set Weapon Values
    /// <summary>
    /// Define os valores para a arma atual.
    /// </summary>
    /// <param name="indexWeapon">Índice da lista de armas.</param>
    public void SetWeaponValues(SOWeapon weapon, Transform superBagBullet, byte indexWeapon) {
        Transform bagBullet = superBagBullet.GetChild(indexWeapon).transform;

        this.GetWeaponValues(weapon, bagBullet);
    }
    #endregion

    #region Get Weapon Values
    /// <summary>
    /// Recebe os valores da arma atual selecionada.
    /// </summary>
    /// <param name="weapon">Informações do SOWeapon.</param>
    /// <param name="bagBullet">Transform (superBagBullet) onde está guardada TODAS as balas.</param>
    private void GetWeaponValues(SOWeapon weapon, Transform bagBullet) {
        this.currentWeapon = weapon;
        this.bagBullet = bagBullet;

        MeshRenderer[] meshRend = this.bagBullet.transform.GetComponentsInChildren<MeshRenderer>();

        if (meshRend != null) {
            foreach (MeshRenderer rend in meshRend) {
                rend.material.color = weapon.bullet.materialColor;
            }
        }
    }
    #endregion

    #region Get Bullet Values
    /// <summary>
    /// Recebe os valores da arma atual.
    /// </summary>
    /// <param name="weapon">Informações do SOWeapon.</param>
    /// <param name="bulletObj">Prefab instanciada da SOWeapon.</param>
    public void GetBulletValues(SOWeapon weapon, GameObject bulletObj) {
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (bullet) {
            bullet.infoData = weapon.bullet;

        } else
            Debug.Assert(bullet, "Componente Bullet não adicionado na bala.");
    }
    #endregion
}