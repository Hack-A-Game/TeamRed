using UnityEngine;
using System.Collections;
using System;

public class Excalibur : Character {
    public override void CharacterAttack(Cell cell)
    {
        throw new NotImplementedException();
    }

    public override void StartVariables()
    {
        maxHealth = int.MaxValue;
        currentHealth = maxHealth;
        maxMove = 0;
        maxAction = 0;
        costPerAction = 0;
        costPerMovement = 0;
        damage = 0;
        attackRange = 0;

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
