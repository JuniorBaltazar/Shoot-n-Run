using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText = null;

    [SerializeField] [Range(0, 120)]
    private float intervalAddPoints = 0.0f;

    [SerializeField] [Range(0, 255)]
    private byte amountPoints = 0;

    private int maxPoints = 0;

    void Start() {
        StartCoroutine(AddPointsInTime());
    }

    void AddPoints() {
        this.maxPoints += this.amountPoints;

        if (this.maxPoints >= 9999)
            this.maxPoints = 0;

        scoreText.text = "Score: " + this.maxPoints.ToString("0000");
    }

    private IEnumerator AddPointsInTime () {
        this.AddPoints();
        yield return new WaitForSeconds(this.intervalAddPoints);
        StartCoroutine(AddPointsInTime());
    }
}