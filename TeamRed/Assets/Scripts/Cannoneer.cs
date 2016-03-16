using UnityEngine;
using System.Collections;
using System;

public class Cannoneer : Character {
    public override void CharacterAttack(Cell cell)
    {
        foreach (Cell cell1 in GameController.instance.mapController.GetContiguousCells(cell)){
            if (cell1.hoverCharacter!=null)
                cell1.hoverCharacter.currentHealth -= damage;
        }
    }

    public override void StartVariables()
    {
        maxHealth = 25;
        currentHealth = maxHealth;
        maxMove = 3;
        maxAction = 1;
        costPerAction = 1;
        costPerMovement = 3;
        damage = 10;
        attackRange = 8; 

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
