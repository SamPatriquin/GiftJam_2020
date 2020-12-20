using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float _launchMultiplier = 5f;

    public float launchMultiplier {
        get { return _launchMultiplier; }
    }
}
