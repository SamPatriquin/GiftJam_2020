using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerWithBubble : MonoBehaviour {

    public Bubble currentBubble;
    public bool isPlayerInBubble { get; private set; } = true;

    private Rigidbody2D playerRigidBody;
    private CircleCollider2D playerCollider;

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
            StartCoroutine(TweenPlayerToBubble());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Bubble>()) {
            isPlayerInBubble = false;
        }
    }

    IEnumerator TweenPlayerToBubble() {
        while (this.transform.position != currentBubble.transform.position) {
            this.transform.position = Vector2.Lerp(this.transform.position, currentBubble.transform.position, 1f * Time.deltaTime);
        }
        yield return null;
    }
}
