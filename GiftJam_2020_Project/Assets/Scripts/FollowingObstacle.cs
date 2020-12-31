using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObstacle: MonoBehaviour, IObstacle
{
    [SerializeField] Transform target;

    public Vector2 spawnedAt { get; set; } = Vector2.zero;

    private void FixedUpdate() {
        this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
    }
}
