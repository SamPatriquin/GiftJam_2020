using System;
using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField] private int value;
    
    private Score score;

    public LevelGenerator spawnedFrom {get; set;}
    private Transform playerTransform;

    private void Awake() {
        score = FindObjectOfType<Score>();
        if (score == null) { Debug.LogError("coin unable to find a reference to Score"); }
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
    }

    private void Update() {
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { spawnedFrom.despawnCoin(this.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            score.IncreaseScore(this.value);
            spawnedFrom.despawnCoin(this.gameObject);
        }
    }
}
