using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Notes : MonoBehaviour
{
    public float moyenneG;
    public TextMeshProUGUI textmoyenne;
    public TextMeshProUGUI textmoyenne2;
    public string name;
    public List<NotesAs> NotesAsses;
    public int megaCoef;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract float MoyenneG();

    public abstract void moyenneGtext();

}

