using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.Rendering;
using UnityEngine;

public class Dryad : HealerBase
{
    // Ability functions go in here?

    [SerializeField] private GameObject primaryProjectile;
    [SerializeField] private Camera cam;

    public int maxAmmo = 50;
    // ^^ Reason for not being in parent class, is all heros will have unique ammo counts, and such
    private int ammoCount;
    private bool shooting = false;

    private const float primaryProjectileSpeed = 10f;
    private const float primaryProjectileSize = 2f;
    private const float primaryProjectileGravity = 4.95f;
    
    public override void ShootPrimaryWeapon()
    {
        // Shoot projectile
        DryadPrimaryProjectile projectile = gameObject.AddComponent<DryadPrimaryProjectile>();
        projectile.SetValues(primaryProjectileSpeed, primaryProjectileSize, primaryProjectileGravity, primaryProjectile);
        GameObject activeProjectile = projectile.CreateProjectile(cam.transform.position);

        // https://www.youtube.com/watch?v=wZ2UUOC17AY Has some physics calculations that might help with projectile movement

        ammoCount = base.ReduceAmmo(ammoCount);
        if (ammoCount == 0)
        {
            base.ReloadAmmo(ammoCount, maxAmmo);
        }
    }

    // Portrait heroPortrait;
    void Start()
    {
        PlayerHUD hud = gameObject.GetComponent<PlayerHUD>();
        // ^ Can also AddComponent, and then set the Text object by code. Might be more 'flexible' also might be pointless, look into it
        InitAmmo();

        base.InitHUD(hud/*, heroPortrait*/); 
        // ^ Can add a symbol for the class and hero you are playing, passed through here as UI is inited though the healer base, which handles symbol, this class handles hero portrait
        base.InitHealth();
        base.CheckAmmo(ammoCount, maxAmmo);
    }

    private void InitAmmo()
    {
        ammoCount = maxAmmo;
    }
    // Can UI Stuff go in here?
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.R)) // For now default to R, make all buttons configurable at some point
        {
            base.ReloadAmmo(ammoCount, maxAmmo);
        }
        if (Input.GetKey(KeyCode.Mouse0)) // 0 === Left Click, 1 === Right Click, 2 Middle Click (scroll wheel press)
        // Use GetKeyDown for single shot
        {
            shooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
        }
        if (shooting)
        {
            ShootPrimaryWeapon();
        }
    }
}
