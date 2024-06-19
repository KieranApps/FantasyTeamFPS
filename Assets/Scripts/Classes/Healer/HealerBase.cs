using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class HealerBase : MonoBehaviour
{
    // Class Passives
    // public float healthRegenRate;
    
    // Managing Health and such here, allows class wide damage and healing changes (buffs, debuffs)
    private PlayerHUD hud;
    
    // private classSymbol;

    public float health;
    private float maxHealth = 100;

    public void InitHUD(PlayerHUD phud/*, heroPortrait*/)
    {
        hud = phud;
        // hud.SetSymbol(classSymbol)
        // hud.SetPortrait(heroPortrait)
    }

    public void InitHealth()
    {
        health = maxHealth;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            // player is dead
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        hud.UpdateHealth(health, maxHealth);
    }
    public void CheckAmmo(int ammoCount, int maxAmmo)
    {
        if (ammoCount <= 0)
        {
            ammoCount = 0;
        }
        hud.UpdateAmmo(ammoCount, maxAmmo);
    }
    public void InitValues(float hp)
    {
        health = hp;
        maxHealth = hp;
    }

    public void TakeDamage(float dam)
    {
        health -= dam;
        CheckHealth();
    }

    public void TakeHealing(float heal)
    {
        health += heal;
        CheckHealth();
    }

    public virtual int ReduceAmmo(int ammoCount)
    {
        ammoCount -= 1; // For simplicity, reduce by one here, override if needed for other characters
        return ammoCount;
    }

    public abstract void ReloadAmmo();

    public abstract void ShootPrimaryWeapon(); // Handle shooting of projectile or hitscan or melee
}
