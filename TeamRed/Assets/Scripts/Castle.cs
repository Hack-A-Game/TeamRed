using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;

public class Castle : Character {

    public float contador;

    // Use this for initialization
    void Start () {
        SpawnCharacters();
        contador = 0;
}

// Update is called once per frame
void Update () {
        contador += Time.deltaTime;
        if(contador > 12)
        {
            RandomAttack();
            contador = 0;
        }
	}

    private void RandomAttack()
    {
        //generar casilla aleatoria del otro lado
        Cell cell = MapController.instance.map[Mathf.RoundToInt(UnityEngine.Random.value*6), Mathf.RoundToInt(UnityEngine.Random.value*10)];
        while (cell.hoverCharacter.owner.CompareTo(this.owner))
        {
            cell = MapController.instance.map[Mathf.RoundToInt(UnityEngine.Random.value * 6), Mathf.RoundToInt(UnityEngine.Random.value * 10)];
        }
        CharacterAttack(cell);
    }
    
    public void SpawnPlayer(Character character)
    {
		// Search nearby free cell
		Cell freeCell = SearchFreeCell();
		character.Move (freeCell);
    }

	private Cell SearchFreeCell() {
		Cell castleCell = owner.castleCell;
		List<Cell> cells = MapController.instance.GetContiguousCells (castleCell);
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
        cell.hoverCharacter.currentHealth -= damage;
        foreach (Cell cell1 in GameController.instance.mapController.GetContiguousCells(cell))
        {
            if (cell1.hoverCharacter != null)
                cell1.hoverCharacter.currentHealth -= damage;
        }
    }
    public void  SpawnCharacters()
    {
        Cell cell = SearchFreeCell();
        GameObject prefab = Resources.Load("Archer") as GameObject;
        GameObject gameObject = (GameObject) GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Archer archer = gameObject.GetComponent<Archer>();
        cell.hoverCharacter = archer;
    }
}
