using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    [SerializeField] private float parallaxEffect;
    [SerializeField] private Camera cam;
    private float startPosX, length;

    private void Awake() {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosX = this.transform.position.x;
    }
    private void Update() {
        float distX = (cam.transform.position.x * parallaxEffect);
        float distXCam = (cam.transform.position.x * (1 - parallaxEffect));

        if (distXCam > startPosX + length) { startPosX += length; } 
        else if (distXCam < startPosX - length) { startPosX -= length; }

        transform.position = new Vector2(startPosX + distX, this.transform.position.y);
    }
}
