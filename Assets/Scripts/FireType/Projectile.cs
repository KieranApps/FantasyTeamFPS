using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed, size, gravity, fireRate;
    protected GameObject bullet;
    public virtual void SetValues(float pSpeed, float pSize, float pGravity, float pFireRate, GameObject bullet)
    {
        speed = pSpeed;
        size = pSize;
        gravity = pGravity;
        fireRate = pFireRate;
    }

    // Need a destroy function for collisions
    public abstract GameObject CreateProjectile(Vector3 playerPosition);

    public abstract void CalculateProjectilePosition();

    public abstract void OnCollisionEnter();
}
