using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    private void FixedUpdate() {
        this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
    }
}
