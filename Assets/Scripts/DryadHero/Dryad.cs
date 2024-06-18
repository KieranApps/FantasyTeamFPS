using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Dryad : HealerBase
{
    // Ability functions go in here?

    [SerializeField] private GameObject primaryProjectile; // This is the PREFAB (Created by creating the object and dragging it into the project folder/tab)
    [SerializeField] private GameObject primaryProjectileSpawnPoint;
    [SerializeField] private Camera cam;

    public int maxAmmo = 50;
    // ^^ Reason for not being in parent class, is all heros will have unique ammo counts, and such
    private int ammoCount;
    private bool shooting = false;

    private const float primaryProjectileSpeed = 10f;
    private const float primaryProjectileSize = 2f;
    private const float primaryProjectileGravity = 4.95f;
    private const float primaryProjectileFireRate = 0.5f;

    private const float reloadTime = 1.5f;
    private bool allowInvoke = true;
    private bool readyToShoot = true;
    
    public override void ShootPrimaryWeapon()
    {
        readyToShoot = false;
        // Create new projectile
        GameObject projectile = Instantiate(primaryProjectile, primaryProjectileSpawnPoint.transform.position, Quaternion.identity);
        DryadPrimaryProjectile currentProjectile = projectile.GetComponent<DryadPrimaryProjectile>();


        currentProjectile.SetValues(primaryProjectileSpeed, primaryProjectileSize, primaryProjectileGravity, primaryProjectileFireRate, primaryProjectile);

        // At some point will need to match rotation

        if (currentProjectile.hitObject)
        {
            Debug.Log("We hit something");
        }        
        // https://www.youtube.com/watch?v=wZ2UUOC17AY Has some physics calculations that might help with projectile movement
        
        ammoCount = base.ReduceAmmo(ammoCount);
        if (ammoCount == 0)
        {
            base.ReloadAmmo(ammoCount, maxAmmo);
        }

        if (allowInvoke)
        {
            Invoke(nameof(ResetPrimaryWeapon), primaryProjectileFireRate);
            allowInvoke = false;
        }
    }

    private void ResetPrimaryWeapon()
    {
        allowInvoke = true;
        readyToShoot = true;
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
        if (readyToShoot && shooting /* && !reloading && ammoCount > 0*/)
        {
            ShootPrimaryWeapon();
        }
    }
}
