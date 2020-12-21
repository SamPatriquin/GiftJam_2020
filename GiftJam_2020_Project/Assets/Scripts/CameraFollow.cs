using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float xOffset;
    [SerializeField] float cameraSmoothing= 0.5f;

    private void FixedUpdate() {
        float xPos = Mathf.Lerp(this.transform.position.x, target.transform.position.x + xOffset, cameraSmoothing * Time.deltaTime);
        this.transform.position = new Vector3(xPos, this.transform.position.y, this.transform.position.z);
    }
}
