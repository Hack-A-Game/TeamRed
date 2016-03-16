using UnityEngine;
using System.Collections;
using System;

public class Archer : Character {
    public override void CharacterAttack(Cell cell)
    {
        cell.hoverCharacter.currentHealth -= damage; //TODO falta animacion??
    }

    public override void StartVariables()
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
