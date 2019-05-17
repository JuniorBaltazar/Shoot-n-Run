using UnityEngine;

public class DestructibleObstacle : MonoBehaviour {

    public string obstacleTag;
    public string playerTag;

    private void OnTriggerEnter(Collider col) {
        if (col.CompareTag(this.playerTag)) {
            LifeCharacter life = col.gameObject.GetComponent<LifeCharacter>();

            if (life) {
                life.TakeDamage();
            }
        }
    }
}