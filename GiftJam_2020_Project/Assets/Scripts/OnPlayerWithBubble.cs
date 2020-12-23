using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerWithBubble : MonoBehaviour {

    public Bubble currentBubble;
    public bool isPlayerInBubble { get; private set; } = true;

    private Rigidbody2D playerRigidBody;

    private void Awake() {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (isPlayerInBubble) {
            this.transform.position = Vector2.Lerp(this.transform.position, currentBubble.transform.position, 5f * Time.deltaTime);
        }
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
