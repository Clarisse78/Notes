using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class SlotsCP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite contour;
    [SerializeField]
    public Image image;

    [SerializeField]public GameObject other1;
    [SerializeField]public GameObject other2;
    [SerializeField]public GameObject other3;
    
    [SerializeField]public GameObject info1;
    [SerializeField]public GameObject info2;
    [SerializeField]public GameObject info3;
    
    [SerializeField]public GameObject panel;

    [SerializeField]
    public GameObject retour;

    public int isSelected;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
        Screen.SetResolution (1920, 1080, true);
        isSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPlayer(int i)
    {
        isSelected += 1;
        if (isSelected % 2 == 0)
        {
            panel.SetActive(false);
            other1.SetActive(false);
            other2.SetActive(false);
            other3.SetActive(false);
            player.ChoicePlayer(i);
        }
        else if (i == 0) //Arya
        {
            other1.SetActive(true);
            info1.SetActive(true);
            other2.SetActive(false);
            other3.SetActive(false);
        }
        else if (i == 1) //Davyn
        {
            info2.SetActive(true);
            other1.SetActive(false);
            other2.SetActive(true);
            other3.SetActive(false);
        }
        else //Destiny
        {
            info3.SetActive(true);
            other1.SetActive(false);
            other2.SetActive(false);
            other3.SetActive(true);
        }
        panel.SetActive(true);
        retour.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = contour;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = null;
    }
}
