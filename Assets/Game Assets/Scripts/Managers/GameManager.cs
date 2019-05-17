using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField] private PauseGame pauseGame = null;
    public SoundManager soundManager;

    #region Monobehaviour
    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(pauseGame.inputPause))
            this.pauseGame.Pause(true);
    }
    #endregion
}