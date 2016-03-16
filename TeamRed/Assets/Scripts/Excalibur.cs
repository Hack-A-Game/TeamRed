using UnityEngine;
using System.Collections;

public class Excalibur : Character {

    public override void startVariables()
    {
        maxHealth = 99;
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
