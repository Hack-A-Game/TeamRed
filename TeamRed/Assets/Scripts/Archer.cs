﻿using UnityEngine;
using System.Collections;
using System;

public class Archer : Character {
    public override void CharacterAttack(Cell cell)
    {
        cell.hoverCharacter.currentHealth -= damage; //TODO falta animacion??
    }

    


// Use this for initialization
void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
