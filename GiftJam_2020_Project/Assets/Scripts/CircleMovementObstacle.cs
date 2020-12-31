using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovementObstacle : MonoBehaviour, IObstacle
{
    private float radius = 1f;
    private float periodInSec = 1f;
    private float cycle;
    private float startingX, startingY = 0f;
    private Transform playerTransform;
    private ObjectPool pool;

    private void Awake() {
        radius = Random.Range(1f, 2f);
        periodInSec = Random.Range(1f, 2f);
        cycle = (Mathf.PI * 2) / periodInSec;
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
        pool = FindObjectOfType<ObjectPool>();
        if (pool == null) { return; }
    }

    private void Start() { //Needs to be after initialized from pool
        startingX = this.transform.position.x;
        startingY = this.transform.position.y;
    }

    private void OnEnable() { //Done every reuse from pool
        startingX = this.transform.position.x;
        startingY = this.transform.position.y;
    }

    void Update(){
        float xOffset = Mathf.Cos(cycle * Time.time) * radius;
        float yOffset = Mathf.Sin(cycle * Time.time) * radius;
        this.transform.position = new Vector2(startingX + xOffset, startingY + yOffset);
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { pool.ReturnObject(this.gameObject); }
    }
}
