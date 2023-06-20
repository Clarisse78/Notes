using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SemesterChoice : MonoBehaviour
{

    public int numberS;
    public string nameS;
    
    public void ChoiceS()
    {
        SceneManager.LoadScene(nameS);
        Menu.numberSemester = numberS;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
