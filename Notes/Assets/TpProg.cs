using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;

public class TpProg : MonoBehaviour
{
    public static Note currentMinTp;

    public Note actualTp;

    public static List<float> allNotesTp;

    public static List<Note> AllTp;

    public GameObject parent;

    public static float saveMinNote;

    public static TpProg instance;
    // Start is called before the first frame update
    void Start()
    {
        AllTp = new List<Note>();
        allNotesTp = new List<float>();
        actualTp = GetComponent<Note>();
        Min();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTPNote(int current)
    {
        //Debug.Log("Actual: " + actualTp.name + "Min: " + currentMinTp.name);
        //Debug.Log(actualTp.name == currentMinTp.name);
        //Debug.Log(actualTp.note > saveMinNote);
       // Debug.Log("Actual: " + actualTp.note + "Min: " + saveMinNote);
        if (actualTp.note < 0 || actualTp.note > 20)
        {
            allNotesTp[current] = -1;
        }
        else
        {
            allNotesTp[current] = actualTp.note;
        }
        if (currentMinTp != null && actualTp.notetext == currentMinTp.notetext)
        {
            if (actualTp.note == -1)
            {
                actualTp.notetext.color = Color.black;
                actualTp.isnotCount = false;
                var withoutone = new List<float>();
                for (int i = 0; i < allNotesTp.Count; i++)
                {
                    if (allNotesTp[i] != -1 && i != current)
                    {
                        withoutone.Add(allNotesTp[i]);
                    }
                }
                if (withoutone.Count > 1)
                {
                    currentMinTp = AllTp[allNotesTp.IndexOf(withoutone.Min())];
                    if (currentMinTp != actualTp)
                    {
                        currentMinTp.notetext.color = Color.red;
                    }
                    saveMinNote = withoutone.Min();
                    currentMinTp.isnotCount = true;
                }
                else
                {
                    currentMinTp = null;
                    saveMinNote = 20;
                }
            }
            else if (actualTp.note > saveMinNote)
            {
                actualTp.notetext.color = Color.black;
                actualTp.isnotCount = false;
                currentMinTp = actualTp;
                saveMinNote = actualTp.note;
                var withoutone = new List<float>();
                
                for (int i = 0; i < allNotesTp.Count; i++)
                {
                    if (allNotesTp[i] != -1)
                    {
                        Debug.Log(AllTp[i]);                
                        withoutone.Add(allNotesTp[i]);
                    }
                }
                Debug.Log("Number: " + withoutone.Count);
                if (withoutone.Count > 1)
                {
                    currentMinTp = AllTp[allNotesTp.IndexOf(withoutone.Min())];
                    currentMinTp.notetext.color = Color.red;
                    
                    saveMinNote = withoutone.Min();
                    currentMinTp.isnotCount = true;
                }
                else
                {
                    currentMinTp = null;
                    saveMinNote = 20;
                }
            }
            else
            {
                saveMinNote = actualTp.note;
                var withoutone = new List<float>();
                for (int i = 0; i < allNotesTp.Count; i++)
                {
                    if (allNotesTp[i] != -1)
                    {
                        withoutone.Add(allNotesTp[i]);
                    }
                }
                if (withoutone.Count > 1)
                {
                    currentMinTp = AllTp[allNotesTp.IndexOf(withoutone.Min())];
                    if (currentMinTp != actualTp)
                    {
                        currentMinTp.notetext.color = Color.red;
                        actualTp.notetext.color = Color.black;
                    }
                    saveMinNote = withoutone.Min();
                    currentMinTp.isnotCount = true;
                }
                else
                {
                    currentMinTp = null;
                    saveMinNote = 20;
                }
            }
        }
        else if (actualTp.note != -1)
        {
            if (currentMinTp == null)
            {
                var withoutone = new List<float>();
                for (int i = 0; i < allNotesTp.Count; i++)
                {
                    if (allNotesTp[i] != -1)
                    {
                        withoutone.Add(allNotesTp[i]);
                    }
                }
                if (withoutone.Count > 1)
                {
                    currentMinTp = AllTp[allNotesTp.IndexOf(withoutone.Min())];
                    currentMinTp.notetext.color = Color.red;
                    
                    saveMinNote = withoutone.Min();
                    currentMinTp.isnotCount = true;
                }
                else
                {
                    currentMinTp = null;
                    saveMinNote = 20;
                }
            }
            else if (actualTp.note < saveMinNote)
            {
                if (actualTp.note < 0 || actualTp.note > 20)
                {
                    saveMinNote = -1;
                }
                else
                {
                    saveMinNote = actualTp.note;
                }

                actualTp.isnotCount = true;
                currentMinTp.isnotCount = false;
                UpdateTextNoteMin();
                currentMinTp = actualTp;
            }
        }
        else if (actualTp.note == -1)
        {
            actualTp.notetext.color = Color.black;
            actualTp.isnotCount = false;
            var withoutone = new List<float>();
            for (int i = 0; i < allNotesTp.Count; i++)
            {
                if (allNotesTp[i] != -1)
                {
                    withoutone.Add(allNotesTp[i]);
                }
            }
            if (withoutone.Count > 1)
            {
                currentMinTp = AllTp[allNotesTp.IndexOf(withoutone.Min())];
                if (currentMinTp != actualTp)
                {
                    currentMinTp.notetext.color = Color.red;
                }
                saveMinNote = withoutone.Min();
                currentMinTp.isnotCount = true;
            }
            else
            {
                currentMinTp.isnotCount = false;
                currentMinTp.notetext.color = Color.black;
                currentMinTp = null;
                saveMinNote = 20;
            }
        }
        actualTp.parent.calculMoyenne();
    }

    public void UpdateTextNoteMin()
    {
        actualTp.notetext.color = Color.red;
        currentMinTp.notetext.color = Color.black;
    }

    public void Min()
    {
        for (int i = 0; i < actualTp.parent.transform.childCount; i++)
            AllTp.Add(parent.transform.GetChild(i).GetComponent<Note>());
        for (int i = 0; i < parent.transform.childCount; i++)
            allNotesTp.Add(AllTp[i].note);
        var withoutone = new List<float>();
        for (int i = 0; i < allNotesTp.Count; i++)
        {
            if (allNotesTp[i] != -1)
            {
                withoutone.Add(allNotesTp[i]);
            }
        }
        if (withoutone.Count > 0)
        {
            currentMinTp = AllTp[allNotesTp.IndexOf(withoutone.Min())];
            currentMinTp.notetext.color = Color.red;
            saveMinNote = withoutone.Min();
            currentMinTp.isnotCount = true;
        }
        else
        {
            currentMinTp = null;
            saveMinNote = 20;
        }
    }
}
