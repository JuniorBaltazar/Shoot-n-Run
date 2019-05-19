using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.WeaponManager;

[RequireComponent(typeof(WeaponManager))] // Adiciona obrigatoriamente um componente.

// Classe partial é onde pode-se dividir o script em várias partes, SEM a necessidade de puxar referência.
// Necessário que as classes partials tenham PARTIAL e que tenham o MESMO NOME na classe.
// O Prefixo PC Aumenta a precisão de pesquisa da classe.
// As iniciais PC usadas como prefixo no nome da classe significam "Partial Class".
public partial class PCSystemShoot : MonoBehaviour {

    private SOWeapon currentWeapon = null;
    private Transform bagBullet = null;

    #region Instantiate Bullet
    /// <summary>
    /// Instancia todas as balas.
    /// </summary>
    /// <param name="weapon">Arma dentro da lista de armas.</param>
    /// <param name="superBagBullet">Transform onde são guardados TODAS as MOCHILAS.</param>
    /// <param name="indexWeapon">Índice da arma dentro da lista</param>
    public void InstantiateBullet(SOWeapon weapon, Transform superBagBullet, byte indexWeapon) {
        this.CreateBag(weapon.name, superBagBullet); // Criando e afiliando a mochila em superBagBullet.
        Transform bagBullet = superBagBullet.GetChild(indexWeapon).transform; // índice da mochila criada.

        for (byte i = 0; i < weapon.bulletAmount; i++) {
            this.CreateBullet(weapon, bagBullet); // Instanciando e afiliando as balas a mochila.
        }
    }
    #endregion

    #region Shoot
    /// <summary>
    /// Atirar um projétil.
    /// </summary>
    public void Shoot() {
        for (byte i = 0; i < this.bagBullet.childCount; i++) {

            if (!this.bagBullet.GetChild(i).gameObject.activeInHierarchy) { // Se a bala não está ativada na Herarquía.
                float offset = this.transform.position.z + this.currentWeapon.offsetPosZ;
                Vector3 bulletPos = new Vector3(this.transform.position.x, this.transform.position.y, offset);
                Vector3 bulletRot = new Vector3(0, this.transform.rotation.y, 0);

                AudioSource bulletAudio = GameManager.instance.soundManager.sfx;

                this.bagBullet.GetChild(i).transform.position = bulletPos;
                this.bagBullet.GetChild(i).transform.rotation = Quaternion.Euler(bulletRot);
                this.bagBullet.GetChild(i).gameObject.SetActive(true);

                this.currentWeapon.bulletSfx.Play(bulletAudio);
                break; // Usada para cancelar o FOR, evitando ATIVAR todas as balas DESATIVADAS.
            }
        }
    }
    #endregion    
}