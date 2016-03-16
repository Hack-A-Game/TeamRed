using UnityEngine;
using System.Collections;
using System;

public class Assasin : Character {
    public override void CharacterAttack(Cell cell)
    {
        throw new NotImplementedException();
    }

    public override void StartVariables()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
        maxMove = 9;
        maxAction = 1;
        costPerAction = 1;
        costPerMovement = 3;
        damage = 25;
        attackRange = 1;

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
