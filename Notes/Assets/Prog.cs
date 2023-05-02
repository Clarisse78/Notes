using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prog : MonoBehaviour
{
    public Maths moyenneGProg;

    public NotesAs sousProg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Calcul()
    {
        Debug.Log("oui");
        sousProg.calculMoyenne();
        moyenneGProg.moyenneGtext();
    }
}
