using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THLR : MonoBehaviour
{
    public Maths moyenneGTHLR;

    public NotesAs sousTHLR;
    public NotesAs sousTHLR2;

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
        sousTHLR.calculMoyenne();
        sousTHLR2.calculMoyenne();
        moyenneGTHLR.moyenneGtext();
    }
}
