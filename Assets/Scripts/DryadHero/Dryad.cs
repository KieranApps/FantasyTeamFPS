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

    private const float primaryProjectileSpeed = 100f;
    private const float primaryProjectileGravity = 4.95f;
    private const float primaryProjectileFireRate = 0.075f;
    private float primarySpread = 0.2f; // Not const as may want to 'ramp up' the spread as firing continues

    private bool allowInvoke = true;
    private bool readyToShoot = true;

    private const float reloadTime = 1.5f;
    private bool reloading = false;
    
    public override void ShootPrimaryWeapon()
    {
        readyToShoot = false;
        // Create new projectile
        float x = Random.Range(-primarySpread, primarySpread);
        float y = Random.Range(-primarySpread, primarySpread);
        Vector3 spawnPoint = primaryProjectileSpawnPoint.transform.position + new Vector3(x, y, 0);
        GameObject projectile = Instantiate(primaryProjectile, spawnPoint, cam.transform.rotation);
        DryadPrimaryProjectile currentProjectile = projectile.GetComponent<DryadPrimaryProjectile>();


        currentProjectile.SetValues(primaryProjectileSpeed, primaryProjectileGravity, primaryProjectileFireRate, primaryProjectile);
        currentProjectile.Fire(cam);
        currentProjectile.SetLifeTimeTimer();
                
        ammoCount = base.ReduceAmmo(ammoCount);
        base.CheckAmmo(ammoCount, maxAmmo);
        if (ammoCount == 0)
        {
            ReloadAmmo();
        }

        if (allowInvoke)
        {
            Invoke(nameof(ResetPrimaryWeapon), primaryProjectileFireRate);
            allowInvoke = false;
        }
    }

    public override void ReloadAmmo()
    {
        reloading = true;
        ammoCount = maxAmmo;
        Invoke(nameof(CompleteReload), reloadTime);
    }

    private void ResetPrimaryWeapon()
    {
        allowInvoke = true;
        readyToShoot = true;
    }

    private void CompleteReload()
    {
        base.CheckAmmo(ammoCount, maxAmmo);
        reloading = false;
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
            ReloadAmmo();
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
        if (readyToShoot && shooting && !reloading && ammoCount > 0)
        {
            ShootPrimaryWeapon();
        }
    }
}
