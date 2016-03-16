using UnityEngine;
using System.Collections;

public class Cannoneer : Character {

    public override void startVariables()
    {
        maxHealth = 10;
        currentHealth = maxHealth;
        maxMove = 3;
        maxAction = 1;
        costPerAction = 1;
        costPerMovement = 3;
        damage = 10;
        attackRange = 11; //maximo del tablero

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
