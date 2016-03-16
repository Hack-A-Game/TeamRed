using UnityEngine;
using System.Collections;

public class Cannoneer : Character {

    public override void StartVariables()
    {
        maxHealth = 25;
        currentHealth = maxHealth;
        maxMove = 3;
        maxAction = 1;
        costPerAction = 1;
        costPerMovement = 3;
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
