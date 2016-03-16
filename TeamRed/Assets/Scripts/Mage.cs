using UnityEngine;
using System.Collections;
using System;

public class Mage : Character {
    public override void CharacterAttack(Cell cell)
    {
		Debug.Log ("Hit: " + damage);
        cell.hoverCharacter.currentHealth -= damage;
    }
}
