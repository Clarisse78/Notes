using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public double note;

    public TextMeshProUGUI notetext;


    // Start is called before the first frame update
    void Start()
    {
        notetext.text = note.ToString("G", CultureInfo.InvariantCulture);
    }
    
    public void UpdateText()
    {
        string oui = "";
        for (int i = 0; i < notetext.text.Length-1; i++)
        {
            oui += notetext.text[i];
        }
        if (float.TryParse(oui,  NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-US"), out float floatValue))
        {
            note = floatValue;
            Debug.Log("Le texte a été converti en float avec succès : " + floatValue);
        }
        else
        {
            notetext.text = "N/a";
            Debug.Log(notetext.text);
            Debug.Log("Impossible de convertir le texte en float.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
