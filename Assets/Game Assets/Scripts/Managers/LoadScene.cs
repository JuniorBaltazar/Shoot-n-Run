using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    /// <summary>
    /// Carrega uma cena
    /// </summary>
    /// <param name="indexScene">Índice da cena</param>
    public void Load(int indexScene) {
        SceneManager.LoadScene(indexScene);
    }
}