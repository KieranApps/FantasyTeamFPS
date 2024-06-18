using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DryadPrimaryProjectile : Projectile
{
    GameObject currentBullet;
    public override void SetValues(float pSpeed, float pSize, float pGravity, float pFireRate, GameObject pBullet)
    {
        speed = pSpeed;
        size = pSize;
        gravity = pGravity;
        fireRate = pFireRate;
        bullet = pBullet;
    }

    // Need a destroy function for collisions
    public override GameObject CreateProjectile(Vector3 playerPosition)
    {
        // Instantiate is likely the cause of the lag, look into object pooling
        currentBullet = Instantiate(bullet, playerPosition, Quaternion.identity);
        return currentBullet;
    }

    public override void CalculateProjectilePosition()
    {
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    }

    public override void OnCollisionEnter()
    {
        // Perform hit calculations (if another player, damage, explosion etc....), then destroy
        Destroy(currentBullet);
    }
}
