using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadPrimaryProjectile : Projectile
{
    public override void SetValues(float pSpeed, float pSize, float pGravity, GameObject pBullet)
    {
        speed = pSpeed;
        size = pSize;
        gravity = pGravity;
        bullet = pBullet;
    }

    // Need a destroy function for collisions
    public override GameObject CreateProjectile(Vector3 playerPosition)
    {
        // Instantiate is likely the cause of the lag, look into object pooling
        GameObject currentBullet = Instantiate(bullet, playerPosition, Quaternion.identity);
        return currentBullet;
    }

    public override void CalculateProjectilePosition()
    {
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    }

    // On collision, destroy the projectile (so we dont have millions spawned in causing lag)
}
