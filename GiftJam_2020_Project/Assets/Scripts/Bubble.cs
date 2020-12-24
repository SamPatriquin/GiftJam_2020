using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float _launchMultiplier = 5f;
    public BubbleSpawner spawnedFrom { get; set; }

    public float launchMultiplier {
        get { return _launchMultiplier; }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            spawnedFrom.ReturnBubble(this.gameObject);
        }
    }
}
