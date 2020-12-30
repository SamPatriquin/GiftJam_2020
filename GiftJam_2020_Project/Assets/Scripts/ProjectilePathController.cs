using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePathController : MonoBehaviour
{
    [SerializeField] int numPoints = 5;
    [SerializeField] float distBetweenPoints = 5f;
    [SerializeField] Sprite pointSprite;

    private PlayerMovementController parentMovementController;
    private ProjectilePathComponent projectilePath;

    private void Awake() {
        projectilePath = new ProjectilePathComponent(numPoints, distBetweenPoints, pointSprite, this.transform);
        parentMovementController = GetComponentInParent<PlayerMovementController>();
    }

    private void FixedUpdate() {
        if (parentMovementController.isBubbleLaunch || parentMovementController.isSecondLaunch) {
            projectilePath.CalculateProjectilePathPoints(this.transform.position, parentMovementController.launchVelocity);
            projectilePath.RenderProjectilePath();
        } else {
            projectilePath.StopRenderProjectilePath();
        }
    }
}
