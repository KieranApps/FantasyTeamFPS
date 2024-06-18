using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float speed, size, gravity;
    protected GameObject bullet;
    public virtual void SetValues(float pSpeed, float pSize, float pGravity, GameObject bullet)
    {
        speed = pSpeed;
        size = pSize;
        gravity = pGravity;
    }

    // Need a destroy function for collisions
    public abstract GameObject CreateProjectile(Vector3 playerPosition);

    public abstract void CalculateProjectilePosition();
}
