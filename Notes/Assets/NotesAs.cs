using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class NotesAs : MonoBehaviour
{
    public List<Note> notes;
    public float coeffFinal; //Exemple : All QCMs : 1
    public TextMeshProUGUI moyenneGText;
    public float finalNote;
    public string name;
    public Notes moyenneG;
    
    // Start is called before the first frame update
    void Awake()
    {
        notes = new List<Note>();
        for (int i = 0; i < transform.childCount; i++)
        {
            notes.Add(transform.GetChild(i).GetComponent<Note>());
        }
        finalNote = -1;
    }

    public float moyenneGNotesAs()
    {
        float finalNote = 0;
        float finalCoeff = 0;
        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i].note != -1 && !notes[i].isnotCount)
            {
                finalNote += (notes[i].note * notes[i].coeff);
                finalCoeff += notes[i].coeff;
            }
        }
        return (float)Math.Round(finalNote / finalCoeff, 2);
    }

    public void calculMoyenne()
    {
        notes = new List<Note>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            notes.Add(transform.GetChild(i).GetComponent<Note>());
        }

        var final = moyenneGNotesAs();
        if (final is Single.NaN)
        {
            moyenneGText.text = $"Moyenne {name} : N/a";
            finalNote = -1;
        }
        else
        {
            moyenneGText.text = $"Moyenne {name} : " + final.ToString("G", CultureInfo.InvariantCulture);
            finalNote = final;
        }

        moyenneG.moyenneGtext();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}