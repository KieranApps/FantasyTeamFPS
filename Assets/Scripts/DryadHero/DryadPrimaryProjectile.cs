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

    public override void CalculateProjectilePosition()
    {
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        hitObject = true;
        // Debug.Log(collision.gameObject.name);
        // // Perform hit calculations (if another player, damage, explosion etc....), then destroy
        // Invoke(nameof(DelayProjectileDestruction), 0.25f);
    }

    private void DelayProjectileDestruction() {
        Destroy(currentBullet);
    }
}
