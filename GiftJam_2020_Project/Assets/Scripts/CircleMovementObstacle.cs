using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovementObstacle : MonoBehaviour, IObstacle
{

    public Vector2 spawnedAt { get; set; } = Vector2.zero;

    private float radius = 1f;
    private float periodInSec = 1f;
    private float cycle;
    private Transform playerTransform;
    private ObjectPool pool;

    private void Awake() {
        radius = Random.Range(.5f, 1f);
        periodInSec = Random.Range(2f, 3f);
        cycle = (Mathf.PI * 2) / periodInSec;
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
        pool = FindObjectOfType<ObjectPool>();
        if (pool == null) { return; }
    }

    void Update(){
        float xOffset = Mathf.Cos(cycle * Time.time) * radius;
        float yOffset = Mathf.Sin(cycle * Time.time) * radius;
        this.transform.position = new Vector2(spawnedAt.x + xOffset, spawnedAt.y + yOffset);
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { pool.ReturnObject(this.gameObject); }
    }
}
