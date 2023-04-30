using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public  class Maths : Notes
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
        float coeff = 0;
        float moyenne = 0;
        for (int i = 0; i < NotesAsses.Count; i++)
        {
            if (NotesAsses[i].finalNote != -1)
            {
                moyenne += (NotesAsses[i].finalNote * NotesAsses[i].coeffFinal);
                coeff += NotesAsses[i].coeffFinal;
            }
        }
        return (float)Math.Round(moyenne / coeff, 2);
    }

    public override void moyenneGtext()
    {
        moyenneG = MoyenneG();
        if (moyenneG is Single.NaN)
        {
            textmoyenne.text = $"Moyenne {name} : N/a";
            textmoyenne2.text = "N/a";
            moyenneG = -1;
        }
        else
        {
            textmoyenne.text = $"Moyenne {name} : " + moyenneG.ToString("G", CultureInfo.InvariantCulture);
            textmoyenne2.text = moyenneG.ToString("G", CultureInfo.InvariantCulture);
        }
    }
}
