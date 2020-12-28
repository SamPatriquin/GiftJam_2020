using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private float amp = 5f;
    private float periodInSec;
    private float cycle;
    private float startingPosY;

    private void Awake() {
        periodInSec = Random.Range(1.5f, 4f);
        cycle = (Mathf.PI * 2) / periodInSec;
        startingPosY = transform.position.y;
    }

    void Update(){
        float offset = Mathf.Sin(cycle * Time.time) * amp;
        this.transform.position = new Vector2(this.transform.position.x, startingPosY + offset);
    }
}
