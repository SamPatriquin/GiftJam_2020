using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIDisplay : MonoBehaviour {
    [SerializeField] Score score;

    private Text text;

    private void Awake() {
        text = this.GetComponentInChildren<Text>();
        text.text = "0";
        score.OnScoreIncrease += IncreaseScore;
    }

    private void IncreaseScore(int score) {
        text.text = score.ToString();
    }
}
