using System;
using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField] private int value;
    
    private Score score;
    private ObjectPool pool;
    private Transform playerTransform;

    private void Awake() {
        score = FindObjectOfType<Score>();
        if (score == null) { Debug.LogError("coin unable to find a reference to Score"); }
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
        pool = FindObjectOfType<ObjectPool>();
        if (pool == null) { return; }
    }

    private void Update() {
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { pool.ReturnObject(this.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            score.IncreaseScore(this.value);
            pool.ReturnObject(this.gameObject);
        }
    }
}
