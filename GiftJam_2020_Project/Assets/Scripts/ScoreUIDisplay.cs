using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIDisplay : MonoBehaviour
{
    [SerializeField] Score score;

    private Text text;

    private void Awake() {
        text = this.GetComponent<Text>();
        text.text = "0";
    }

    private void Update() {
        if (text.text != score.value.ToString()) {
            text.text = score.value.ToString();
        }
    }
}
