using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private float amp = 5f;

    public Vector2 spawnedAt { get; set; } = Vector2.zero;

    private float periodInSec;
    private float cycle;
    private float startingPosY;
    private Transform playerTransform;
    private ObjectPool pool;

    private void Awake() {
        periodInSec = Random.Range(1.5f, 4f);
        cycle = (Mathf.PI * 2) / periodInSec;
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
        pool = FindObjectOfType<ObjectPool>();
        if (pool == null) { return; }
    }

    void Update(){
        float offset = Mathf.Sin(cycle * Time.time) * amp;
        this.transform.position = new Vector2(this.transform.position.x, offset);
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { pool.ReturnObject(this.gameObject); }
    }
}
