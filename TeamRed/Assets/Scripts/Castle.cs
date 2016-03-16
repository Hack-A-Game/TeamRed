using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;

public class Castle : Character {

    public Player owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //llamar RandomAttack() cada X segundos
	
	}

    private void RandomAttack()
    {
        //generar casilla aleatoria del otro lado
        //cell = MapController.instance.map[,]
        //CharacterAttack(cell);
    }
    
    public void SpawnPlayer(Character character)
    {
		// Search nearby free cell
		Cell freeCell = SearchFreeCell();
		character.Move (freeCell);
    }

	private Cell SearchFreeCell() {
		Cell castleCell = owner.castleCell;
		List<Cell> cells = GameController.instance.mapController.GetContiguousCells (castleCell);
		foreach (Cell cell in cells) {
			if (cell.hoverCharacter == null) {
				return cell;
			}
		}
		return null;
	}

    public override void StartVariables()
    {
        maxHealth = int.MaxValue;
        currentHealth = maxHealth;
        maxMove = 0;
        maxAction = 0;
        costPerAction = 0;
        costPerMovement = 0;
        damage = 50;
        //attackRange = 10;
}

    public override void CharacterAttack(Cell cell)
    {
        throw new NotImplementedException();
    }
}
