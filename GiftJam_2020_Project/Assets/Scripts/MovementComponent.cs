using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent{
    public Vector2 CalculateLaunchForce(Vector2 playerPos, Vector2 pulledBackPos, float movementMult) {
        return (playerPos - pulledBackPos) * movementMult *Time.deltaTime;
    }
}
