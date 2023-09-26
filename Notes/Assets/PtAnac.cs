using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PtAnac : Notes
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float MoyenneG()
    {
        return moyenneG;
    }

    public override void moyenneGtext()
    {
        moyenneG = MoyenneG();
        if (moyenneG == -1)
        {
            textmoyenne2.text = "N/a";
            moyenneG = -1;
        }
        else
        {
            textmoyenne2.text = moyenneG.ToString("G", CultureInfo.InvariantCulture);
        }
        Menu.instance.CalculMoyenneGeneral();
    }

    public void ClickOnSlotNext()
    {
        if (moyenneG == 20)
        {
            moyenneG = -1;
        }
        else
        {
            moyenneG += 1;
        }
        moyenneGtext();
    }
    
    public void ClickOnSlotBefore()
    {
        if (moyenneG == 0)
        {
            moyenneG = -1;
        }
        else if (moyenneG == -1)
        {
            moyenneG = 20;
        }
        else 
        {
            moyenneG -= 1;
        }
        moyenneGtext();
    }
}
