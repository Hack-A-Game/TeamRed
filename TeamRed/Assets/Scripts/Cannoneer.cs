using UnityEngine;
using System.Collections;
using System;

public class Cannoneer : Character {
    public override void CharacterAttack(Cell cell)
    {
        cell.hoverCharacter.currentHealth -= damage;
        foreach (Cell cell1 in MapController.instance.GetContiguousCells(cell)){
            if (cell1.hoverCharacter!=null)
                cell1.hoverCharacter.currentHealth -= damage;
        }
    }

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
