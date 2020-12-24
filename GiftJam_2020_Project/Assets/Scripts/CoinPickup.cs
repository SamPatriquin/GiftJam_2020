using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            score.IncreaseScore(this.value);
        }
    }
}
