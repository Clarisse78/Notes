using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatiereEnter : MonoBehaviour
{
    public GameObject matiere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AffichageMatiere()
    {
        matiere.SetActive(true);
        Menu.CurrentMatiere = matiere;
        Menu.menuPrincipale.SetActive(false);
    }
}
