using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUpdate : MonoBehaviour
{
    [SerializeField] Score score;
    
    private Text text;

    private void Awake() {
        text = this.GetComponent<Text>();
    }

    private void Update() {
        text.text = score.value.ToString();
    }
}
