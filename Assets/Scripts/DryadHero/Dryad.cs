using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryad : HealerBase
{
    // Ability functions go in here?

    // Portrait heroPortrait;
    void Start()
    {
        PlayerHUD hud = gameObject.GetComponent<PlayerHUD>();
        // ^ Can also AddComponent, and then set the Text object by code. Might be more 'flexible' also might be pointless, look into it
        InitHUD(hud/*, heroPortrait*/); 
        // ^ Can add a symbol for the class and hero you are playing, passed through here as UI is inited though the healer base, which handles symbol, this class handles hero portrait
        InitHealth();
    }
    // Can UI Stuff go in here? Depends how it works
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeHealing(1);
        }
    }
}
