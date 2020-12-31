using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private float amp = 5f;
    private float periodInSec;
    private float cycle;
    private float startingPosY;
    private Transform playerTransform;
    public LevelGenerator spawnedFrom { get; set; }

    private void Awake() {
        periodInSec = Random.Range(1.5f, 4f);
        cycle = (Mathf.PI * 2) / periodInSec;
        startingPosY = transform.position.y;
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
    }

    void Update(){
        float offset = Mathf.Sin(cycle * Time.time) * amp;
        this.transform.position = new Vector2(this.transform.position.x, startingPosY + offset);
        if (this.transform.position.magnitude - playerTransform.position.magnitude <= -10) { spawnedFrom.despawnObstacle(this.gameObject); }
    }
}
