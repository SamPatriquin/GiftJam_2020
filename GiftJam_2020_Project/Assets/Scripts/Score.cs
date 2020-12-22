using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int value { get; private set; } = 0;

    private void Start() {
        CoinPickup.onCoinPickup += increaseScore;
    }

    void increaseScore(int _value) {
        value += _value;
    }
}
