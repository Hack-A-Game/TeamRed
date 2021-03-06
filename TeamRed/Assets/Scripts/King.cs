﻿using UnityEngine;
using System.Collections;
using System;

public class King : Character
{

   public bool hasSword;
    public Sprite kingSwordBlue;
    public Sprite kingSwordRed;

    public bool CanGetSword(Cell cell)
    {
        return ManhattanDistance(cell) == 1;
    }

    public override void CharacterAttack(Cell cell)
    {
        int currentdmg;
        if (hasSword)
        {
            currentdmg = damage*2;
        }
        else
        {
            currentdmg = damage;
        }
		Debug.Log ("Hit: " + damage);
        cell.hoverCharacter.currentHealth -= currentdmg;
    }

    public void GetSword(Cell cell)
    {
        hasSword = true;
	}
}