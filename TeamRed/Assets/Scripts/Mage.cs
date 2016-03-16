using UnityEngine;
using System.Collections;
using System;

public class Mage : Character {
    public override void CharacterAttack(Cell cell)
    {
        cell.hoverCharacter.currentHealth -= damage;
    }
}
