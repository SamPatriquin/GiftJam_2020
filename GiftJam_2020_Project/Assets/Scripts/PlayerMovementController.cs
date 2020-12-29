using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float secondJumpMult = 2f;

    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;
    private Transform playerTransform;
    private OnPlayerWithBubble onPlayerWithBubble;

    public Vector2 launchVelocity { get; private set; }
    public bool isValidMove { get; private set; } = false;
    private bool isMoveReleased = false;
    private bool isSecondJumpUsed = false;

    private Vector2 mousePos;

    private void Awake() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerTransform = GetComponent<Transform>();
        onPlayerWithBubble = GetComponent<OnPlayerWithBubble>();
    }
    private void FixedUpdate() {
        if (isValidMove) {
            launchVelocity = ((Vector2)this.transform.position - mousePos) * onPlayerWithBubble.currentBubble.launchMultiplier * Time.deltaTime;
        }
        if (isMoveReleased) {
            playerRigidBody.isKinematic = false;
            playerRigidBody.velocity = launchVelocity;
            isMoveReleased = false;
        }
        if (isSecondJumpUsed) {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, secondJumpMult * Time.deltaTime);
            isSecondJumpUsed = false;
        }
    }
    private void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            isValidMove = playerCollider.OverlapPoint(mousePos) && onPlayerWithBubble.isPlayerInBubble;
            if (onPlayerWithBubble.isPlayerInBubble == false) {
                isSecondJumpUsed = true;
            }
        }
        if (isValidMove && Input.GetMouseButtonUp(0)) {
            isMoveReleased = true;
            onPlayerWithBubble.isPlayerInBubble = false;
            isValidMove = false;
        }
    }
}
