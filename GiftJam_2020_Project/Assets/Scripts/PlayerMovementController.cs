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
    public bool isBubbleLaunch { get; private set; } = false;
    private bool isMoveReleased = false;
    private bool isSecondLaunchAvailable = false;
    public bool isSecondLaunch { get; private set; } = false;
    private float clampMouseVector = 3f;

    private Vector2 mousePos;

    private void Awake() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerTransform = GetComponent<Transform>();
        onPlayerWithBubble = GetComponent<OnPlayerWithBubble>();
    }
    private void FixedUpdate() {
        if (isBubbleLaunch || isSecondLaunch) {
            launchVelocity = Vector2.ClampMagnitude(((Vector2)this.transform.position - mousePos), clampMouseVector) * onPlayerWithBubble.currentBubble.launchMultiplier * Time.deltaTime;
            if (isSecondLaunch) {
                playerRigidBody.velocity = new Vector2(0f, 0f);
            }
        }
        if (isMoveReleased) {
            playerRigidBody.isKinematic = false;
            playerRigidBody.velocity = launchVelocity;
            isMoveReleased = false;
            if (isSecondLaunch) {
                isSecondLaunchAvailable = false;
                isSecondLaunch = false;
            } else if (isBubbleLaunch) {
                isBubbleLaunch = false;
            }
        }
    
    }
    private void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (onPlayerWithBubble.isPlayerInBubble) { isSecondLaunchAvailable = true; }

        if (Input.GetMouseButtonDown(0)) {
            isBubbleLaunch = playerCollider.OverlapPoint(mousePos) && onPlayerWithBubble.isPlayerInBubble;
            isSecondLaunch = playerCollider.OverlapPoint(mousePos) && onPlayerWithBubble.isPlayerInBubble == false && isSecondLaunchAvailable;
        }

        if ((isBubbleLaunch || isSecondLaunch) && Input.GetMouseButtonUp(0)) {
            isMoveReleased = true;
            onPlayerWithBubble.isPlayerInBubble = false;
        }
    }
}
