using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float note;

    public TextMeshProUGUI notetext;
    
    public float coeff;

    public GameObject InputField;

    public NotesAs parent;

    // Start is called before the first frame update
    void Awake()
    {
        note = -1;
        notetext.text = note.ToString("G", CultureInfo.InvariantCulture);
    }
    
    public void UpdateText()
    {
        string oui = "";
        for (int i = 0; i < notetext.text.Length-1; i++)
        {
            oui += notetext.text[i];
        }
        if (float.TryParse(oui,  NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-US"), out float floatValue) && floatValue >= 0 && floatValue <= 20)
        {
            note = (float)Math.Round(floatValue,2);
            InputField.GetComponent<TMP_InputField>().text = note.ToString("G", CultureInfo.InvariantCulture);
            parent.calculMoyenne();
        }
        else
        {
            InputField.GetComponent<TMP_InputField>().text = "N/a";
            note = -1;
            parent.calculMoyenne();
        }
    }

    public void UpdateTextSave(float noteSave)
    {
        if (noteSave != -1)
        {
            note = noteSave;
            InputField.GetComponent<TMP_InputField>().text = note.ToString("G", CultureInfo.InvariantCulture);
            parent.calculMoyenne();
        }
        else
        {
            InputField.GetComponent<TMP_InputField>().text = "N/a";
            note = -1;
            parent.calculMoyenne();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
