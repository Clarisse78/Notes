using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int strenght;
    public int health;
    public int agility;
    public int intelligence;
    
    public int attack;
    public int defense;

    public int maxAttack;
    public int maxDefense;

    public int money;
    
    
    // Start is called before the first frame update
    void Start()
    {
        strenght = 100;
        health = 100;
        agility = 100;
        intelligence = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
