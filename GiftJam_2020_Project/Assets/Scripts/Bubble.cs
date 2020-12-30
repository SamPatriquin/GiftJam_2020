using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float _launchMultiplier = 5f;

    public LevelGenerator spawnedFrom { get; set; }
    private Transform playerTransform;

    public float launchMultiplier {
        get { return _launchMultiplier; }
    }

    private void Awake() {
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
    }

    private void Update() {
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { spawnedFrom.despawnBubble(this.gameObject); }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            spawnedFrom.despawnBubble(this.gameObject);
        }
    }
}
