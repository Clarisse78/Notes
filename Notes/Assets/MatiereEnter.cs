using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatiereEnter : MonoBehaviour
{
    public GameObject matiere;

    public GameObject UCUE;
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

    public void AffichageUCUE()
    {
        if (Menu.CurrentUCUE is not null)
            Menu.CurrentUCUE.SetActive(false);
        if (UCUE != Menu.CurrentUCUE)
        {
            UCUE.SetActive(true);
            Menu.CurrentUCUE = UCUE;
        }
        else
        {
            UCUE.SetActive(false);
            Menu.CurrentUCUE = null;
        }
    }
}
