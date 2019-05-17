using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.WeaponManager;

public partial class PCSystemShoot {

    #region Create Bag
    /// <summary>
    /// Cria uma mochila para as balas.
    /// </summary>
    /// <param name="bagName">Nome da mochila (bag).</param>
    /// <param name="superBagBullet">Transform (superBagBullet) onde está guardada TODAS as MOCHILAS.</param>
    public void CreateBag(string bagName, Transform superBagBullet) {
        GameObject bagBullet = new GameObject(bagName + "_Bag");
        bagBullet.transform.parent = superBagBullet;
    }
    #endregion

    #region Create Bullet
    /// <summary>
    /// Cria as balas.
    /// </summary>
    /// <param name="weapon">Informações do SOWeapon.</param>
    /// <param name="bagBullet">Transform onde são guardado TODAS as BALAS.</param>
    public void CreateBullet(SOWeapon weapon, Transform bagBullet) {
        GameObject bulletObj = Instantiate(weapon.bullet.prefab, bagBullet);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        bulletObj.name = weapon.bullet.prefab.name;

        if(bullet == null)
            bulletObj.AddComponent(typeof(Bullet));

        this.GetBulletValues(weapon, bulletObj);
    }
    #endregion
}