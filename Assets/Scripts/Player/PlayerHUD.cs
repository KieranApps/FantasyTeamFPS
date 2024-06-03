using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxHealthText;


    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthText.text = currentHealth.ToString();
        maxHealthText.text = maxHealth.ToString();
    }
}
