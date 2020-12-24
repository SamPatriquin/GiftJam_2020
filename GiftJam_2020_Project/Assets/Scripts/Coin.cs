using System;
using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField] private int value;
    
    private Score score;

    public CoinSpawner spawnedFrom {get; set;}

    private void Awake() {
        score = FindObjectOfType<Score>();
        if (score == null) { Debug.LogError("coin unable to find a reference to Score"); }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            score.IncreaseScore(this.value);
            spawnedFrom.returnCoin(this.gameObject);
        }
    }
}
