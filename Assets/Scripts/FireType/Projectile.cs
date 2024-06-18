using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed, size, gravity, fireRate;
    protected GameObject bullet;
    public bool hitObject;
    public virtual void SetValues(float pSpeed, float pSize, float pGravity, float pFireRate, GameObject bullet)
    {
        speed = pSpeed;
        size = pSize;
        gravity = pGravity;
        fireRate = pFireRate;
    }

    public abstract void CalculateProjectilePosition();
}
