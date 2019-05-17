using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.WeaponManager;

#region Require Component
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
#endregion

public class Bullet : MonoBehaviour {

    [HideInInspector] public SOBullet infoData;

    Rigidbody rb;

    #region MonoBehaviour

    #region Initialization
    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        this.rb.useGravity = false;
    }
    #endregion

    #region Colission
    private void OnTriggerEnter(Collider col) {
        DestructibleObstacle destructibleObs =  col.GetComponent<DestructibleObstacle>();

        if (destructibleObs) {

            if (destructibleObs.obstacleTag == this.infoData.destructibleObjName)
                col.gameObject.SetActive(false);

            this.gameObject.SetActive(false);
        }
    }
    #endregion

    #region On
    private void OnEnable() {
        this.MovementBullet();
        this.StartCoroutine(this.DesactiveBullet());
    }

    private void OnBecameInvisible() {
        this.gameObject.SetActive(false);
    }
    #endregion

    #endregion

    #region Movement Bullet
    /// <summary>
    /// Movemento da bala.
    /// </summary>
    private void MovementBullet () {
        Vector3 moveBullet = this.transform.forward * 100 * this.infoData.speed * Time.fixedDeltaTime;
        this.rb.velocity = Vector3.zero;
        this.rb.velocity = moveBullet;
    }
    #endregion

    #region Cooldown Shoot
    /// <summary>
    /// Tempo de recarga para desativar o tiro.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DesactiveBullet() {
        yield return new WaitForSeconds(this.infoData.cooldownDesactive);
        this.gameObject.SetActive(false);
    }
    #endregion
}