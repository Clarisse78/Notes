using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.IO;
using TMPro;

public class Menu : MonoBehaviour
{
    public static GameObject menuPrincipale;

    public static GameObject CurrentMatiere;
    public List<GameObject> allMatiere;

    public List<Notes> allSave;

    public TextMeshProUGUI moyenneGENERAL;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.dataPath + "/save.txt"))
        {
            File.Create(Application.dataPath + "/save.txt");
        }
        else
        {
            var save= File.ReadAllText(Application.dataPath + "/save.txt");
            var saveMatiere = save.Split("FIN MATIERE");
            List<string[]> saveNoteAs = new List<string[]>();
            for (int i = 0; i < saveMatiere.Length; i++)
            {
                saveNoteAs.Add(saveMatiere[i].Split("*"));
            }
            for (int i = 0; i < allSave.Count; i++)
            {
                for (int j = 0; j <  allSave[i].NotesAsses.Count; j++)
                {
                    for (int k = 0; k < allSave[i].NotesAsses[j].notes.Count; k++)
                    {
                        allSave[i].NotesAsses[j].notes[k].UpdateTextSave(float.Parse(saveNoteAs[i][j].Split("|")[k]));
                    }
                }
                allMatiere[i].SetActive(false);
            }
            CalculMoyenneGeneral();
        }
        menuPrincipale = GameObject.FindGameObjectWithTag("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetourMenu()
    {
        menuPrincipale.SetActive(true);
        CurrentMatiere.SetActive(false);
        CalculMoyenneGeneral();
    }

    public void SaveAll()
    {
        string save = "";
        for (int i = 0; i < allSave.Count; i++)
        {
            for (int j = 0; j < allSave[i].NotesAsses.Count; j++)
            {
                for (int k = 0; k < allSave[i].NotesAsses[j].notes.Count-1; k++)
                {
                    save += $"{allSave[i].NotesAsses[j].notes[k].note}";
                    save += "|";
                }
                save += $"{allSave[i].NotesAsses[j].notes[^1].note}";
                save += "*";
                save += "\n";
            }
            save += "FIN MATIERE";
        }
        File.WriteAllText(Application.dataPath + "/" + "save" + ".txt", save);
    }

    public void CalculMoyenneGeneral()
    {
        float phase = 0;
        int coef = 0;
        for (int i = 0; i < allSave.Count; i++)
        {
            var ok = allSave[i].GetComponent<Notes>();
            if (ok.moyenneG != -1)
            {
                phase += ok.moyenneG * ok.megaCoef;
                coef += ok.megaCoef;
            }
        }
        var finish = Math.Round(phase / coef, 2);
        if (finish is Double.NaN)
        {
            moyenneGENERAL.text = "Moyenne générale : N/a";
        }
        else
        {
            moyenneGENERAL.text = "Moyenne générale : " + finish.ToString("G", CultureInfo.InvariantCulture);
        }
    }
}
