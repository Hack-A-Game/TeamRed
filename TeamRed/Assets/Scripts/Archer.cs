using UnityEngine;
using System.Collections;
using System;

public class Archer : Character {
    public override void characterAttack(Cell cell)
    {
        throw new NotImplementedException();
    }

    public override void startVariables()
    {
        maxHealth = 10;
        currentHealth = maxHealth;
        maxMove = 3;
        maxAction = 1;
        costPerAction = 1;
        costPerMovement = 3;
        damage = 10;
        attackRange = 5; 

    }


// Use this for initialization
void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
