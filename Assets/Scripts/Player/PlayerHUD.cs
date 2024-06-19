using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public TextMeshProUGUI healthText, maxHealthText;
    public TextMeshProUGUI ammoCountText, maxAmmoText;


    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthText.text = currentHealth.ToString();
        maxHealthText.text = maxHealth.ToString();
    }

    public void UpdateAmmo(int ammoCount, int maxAmmo)
    {
        ammoCountText.text = ammoCount.ToString();
        maxAmmoText.text = maxAmmo.ToString();
    }
}
