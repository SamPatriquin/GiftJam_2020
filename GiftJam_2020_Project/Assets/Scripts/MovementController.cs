using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float movementMult = 5f;

    private Rigidbody2D playerRigidBody;
    private CircleCollider2D playerCollider;
    private Transform playerTransform;
    private MovementComponent movementComponent;

    public Vector2 launchVelocity { get; private set; }
    public bool isValidMove { get; private set; } = false;
    public bool isMoveReleased { get; private set; } = false;

    private Vector2 mousePos;

    private void Awake() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
        playerTransform = GetComponent<Transform>();
        movementComponent = new MovementComponent();
        playerRigidBody.isKinematic = true;
    }
    private void FixedUpdate() {
        if (isValidMove) {
            launchVelocity = movementComponent.CalculateLaunchForce(this.transform.position, mousePos, movementMult);
        }
        if (isMoveReleased) {
            playerRigidBody.isKinematic = false;
            playerRigidBody.velocity = launchVelocity;
            isMoveReleased = false;
        }
    }
    private void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            isValidMove = playerCollider.OverlapPoint(mousePos);
        }
        if (isValidMove && Input.GetMouseButtonUp(0)) {
            isMoveReleased = true;
            isValidMove = false;
        }
    }
}
