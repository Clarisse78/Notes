using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retour : MonoBehaviour
{
    [SerializeField] private SlotsCP slotscp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectRetour()
    { 
        slotscp.other1.SetActive(true);
        slotscp.other2.SetActive(true);
        slotscp.other3.SetActive(true);
        slotscp.retour.SetActive(false); 
        slotscp.panel.SetActive(false);
        slotscp.info1.SetActive(false);
        slotscp.info2.SetActive(false);
        slotscp.info3.SetActive(false);
    }
}
