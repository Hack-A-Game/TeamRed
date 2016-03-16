using UnityEngine;
using System.Collections;
using System;

public class Mage : Character {
    public override void CharacterAttack(Cell cell)
    {
        throw new NotImplementedException();
    }

    public override void StartVariables()
    {
        maxHealth = 25;
        currentHealth = maxHealth;
        maxMove = 3;
        maxAction = 1;
        costPerAction = 1;
        costPerMovement = 5;
        damage = 15;
        attackRange = 8;

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
