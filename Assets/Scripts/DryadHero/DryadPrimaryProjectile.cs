using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DryadPrimaryProjectile : Projectile
{
    public new const float lifeTime = 5f;
    public override void SetValues(float pSpeed, float pGravity, float pFireRate, GameObject pBullet)
    {
        speed = pSpeed;
        fireRate = pFireRate;
        bullet = pBullet;
    }

    void OnCollisionEnter(Collision collision)
    {
        // // Perform hit calculations (if another player, damage, explosion etc....), then destroy
        DestroyProjectile();
    }

    public void SetLifeTimeTimer()
    {
        Invoke(nameof(DestroyOnLifeEnd), lifeTime);
    }
    public override void Fire(Camera cam)
    {
        // https://www.youtube.com/watch?v=wZ2UUOC17AY At some point, upgrade to use the ray case from this to get target position from camera.
        // This will help for when the bullet is spawn by the 'Weapon' of the hero, so it would not itself be centered but still needs to aim towards the centre
        this.GetComponent<Rigidbody>().velocity = cam.transform.forward * speed;
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // Raycast hit;
        // Vector3 targetPoint
    }

    public void DestroyOnLifeEnd()
    {
        DestroyProjectile();
    }

    private void DestroyProjectile() {
        CancelInvoke(nameof(DestroyOnLifeEnd));
        Destroy(this.gameObject);
    }
}
