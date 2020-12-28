using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovementObstacle : MonoBehaviour, IObstacle
{
    private float radius = 1f;
    private float periodInSec = 1f;
    private float cycle;
    private float startingX, startingY = 0f;

    private void Awake() {
        radius = Random.Range(1f, 2f);
        periodInSec = Random.Range(1f, 2f);
        cycle = (Mathf.PI * 2) / periodInSec;
        startingX = this.transform.position.x;
        startingY = this.transform.position.y;
    }

    void Update(){
        float xOffset = Mathf.Cos(cycle * Time.time) * radius;
        float yOffset = Mathf.Sin(cycle * Time.time) * radius;
        this.transform.position = new Vector2(startingX + xOffset, startingY + yOffset);
    }
}
