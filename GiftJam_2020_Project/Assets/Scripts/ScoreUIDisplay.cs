
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUIDisplay : MonoBehaviour {
    [SerializeField] Score score;

    private TMP_Text text;
    private Animator pearlAnimator;
    private int animatorPearlGrow = Animator.StringToHash("grow");

    private void Awake() {
        text = this.GetComponentInChildren<TMP_Text>();
        pearlAnimator = this.GetComponentInChildren<Animator>(); //BAD, change this 
        text.text = "0";
        score.OnScoreIncrease += IncreaseScore;
    }

    private void IncreaseScore(int score) {
        text.text = score.ToString();
        pearlAnimator.SetTrigger(animatorPearlGrow);
    }
}
