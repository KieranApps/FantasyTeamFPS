using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed, gravity, fireRate, lifeTime;
    protected GameObject bullet;
    public bool hitObject;
    public virtual void SetValues(float pSpeed, float pGravity, float pFireRate, GameObject bullet)
    {
        speed = pSpeed;
        gravity = pGravity;
        fireRate = pFireRate;
    }

    public abstract void Fire(Camera cam);
}
