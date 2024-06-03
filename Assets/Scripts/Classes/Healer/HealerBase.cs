using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerBase : MonoBehaviour
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

}
