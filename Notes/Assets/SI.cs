using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SI : Notes
{
    public List<Notes> ue;
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
        float moyenneUCUE = 0;
        float coeff = 0;
        for (int i = 0; i < ue.Count; i++)
        {
            if (ue[i].moyenneG != -1)
            {
                moyenneUCUE += ue[i].moyenneG * ue[i].megaCoef;
                coeff += ue[i].megaCoef;
            }
        }
        return (float)Math.Round(moyenneUCUE / coeff, 2);
    }

    public override void moyenneGtext()
    {
        moyenneG = MoyenneG();
        if (moyenneG is Single.NaN)
        {
            textmoyenne2.text = "N/a";
            moyenneG = -1;
        }
        else
        {
            textmoyenne2.text = moyenneG.ToString("G", CultureInfo.InvariantCulture);
        }
    }
}
