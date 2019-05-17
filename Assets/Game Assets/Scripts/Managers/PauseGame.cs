using System;
using UnityEngine;
using UnityEngine.Events;

public class PauseGame : MonoBehaviour {

    public KeyCode inputPause;
    public UnityEvent pauseEvents;

    /// <summary>
    /// Pause durante o jogo.
    /// </summary>
    /// <param name="ispaused">Se é verdadeiro ou falso.</param>
    public void Pause (bool ispaused) {
        Time.timeScale = Convert.ToInt32(!ispaused);

        if (ispaused == true)
            this.pauseEvents.Invoke();
    }
}