using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int value { get; private set; } = 0;

    public void IncreaseScore(int _value) {
        value += _value;
    }
}
