using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePathComponent
{
    public GameObject[] points { get; private set; }
    private float distPoints;

    public ProjectilePathComponent(int numPoints, float _disPoints, Sprite _pointSprite, Transform parent) {
        distPoints = _disPoints;
        points = new GameObject[numPoints];
        for (int i = 0; i < points.Length; ++i) {
            points[i] = new GameObject("point" + i, typeof(SpriteRenderer));
            points[i].transform.SetParent(parent);
            points[i].GetComponent<SpriteRenderer>().sprite = _pointSprite;
        }
    }

    public void CalculateProjectilePathPoints(Vector2 startingPos, Vector2 velocity) {
        for (int i = 0; i < points.Length; ++i) {
            float time = distPoints * i;
            points[i].transform.position = startingPos + (velocity * time) + (0.5f * Physics2D.gravity * Mathf.Pow(time, 2));
        }
    }

    public void RenderProjectilePath() {
        foreach(GameObject point in points) {
            point.SetActive(true);
        }
    }

    public void StopRenderProjectilePath() {
        foreach (GameObject point in points) {
            point.SetActive(false);
        }
    }
}
