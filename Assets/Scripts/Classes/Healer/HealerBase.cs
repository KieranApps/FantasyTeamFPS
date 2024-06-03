using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerBase : MonoBehaviour
{
    // Class Passives
    // public float healthRegenRate;
    
    // Managing Health and such here, allows class wide damage and healing changes (buffs, debuffs)
    private PlayerHUD hud;
    public float health;
    private float maxHealth;

    public void InitHUD(PlayerHUD phud)
    {
        hud = phud;
    }

    public void InitHealth(float hp, float maxHp)
    {
        health = hp;
        maxHealth = maxHp;
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
