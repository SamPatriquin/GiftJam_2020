using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInBubbleHandler : MonoBehaviour {

    private Rigidbody2D playerRigidBody;
    private CircleCollider2D playerCollider;

    public Bubble currentBubble;
    public bool isPlayerInBubble { get; private set; } = true;

    private void Awake() {
        playerCollider = GetComponent<CircleCollider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Bubble>()) {
            isPlayerInBubble = true;
            currentBubble = collision.gameObject.GetComponent<Bubble>();
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.isKinematic = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Bubble>()) {
            isPlayerInBubble = false;
        }
    }
}
