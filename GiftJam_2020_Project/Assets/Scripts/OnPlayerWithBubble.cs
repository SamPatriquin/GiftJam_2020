using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerWithBubble : MonoBehaviour {

    public Bubble currentBubble { get; private set; }
    public bool isPlayerInBubble { get; set; } = false;

    private Rigidbody2D playerRigidBody;
    private AudioManager audioManager;

    private void Awake() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update() {
        if (isPlayerInBubble) {
            this.transform.position = Vector2.Lerp(this.transform.position, currentBubble.transform.position, 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Bubble>()) {
            isPlayerInBubble = true;
            audioManager.StopSound("spinning", this.gameObject);
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
