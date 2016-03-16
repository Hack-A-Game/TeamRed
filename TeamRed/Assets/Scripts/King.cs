using UnityEngine;
using System.Collections;
using System;

public class King : Character {

    public bool hasSword;
    public override void startVariables()
    {
        currentHealth = maxHealth;
        maxMove = 1;

        //TODO balanceo
        maxHealth = 50;
        maxAction = 2; 
        costPerAction = 4;
        costPerMovement = 2;
        damage = 5;
    }

    public void getSword()
    {
        hasSword = true;
    }

    // Use this for initialization
    void Start () {
        hasSword = false;
	}
    

    // Update is called once per frame
    void Update () {
	
	}
}
