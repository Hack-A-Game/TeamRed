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
        /**while (cell.hoverCharacter.owner.CompareTo(this.owner))
        {
            cell = MapController.instance.map[Mathf.RoundToInt(UnityEngine.Random.value * 6), Mathf.RoundToInt(UnityEngine.Random.value * 10)];
        }**/
        CharacterAttack(cell);
    }
    
    public void SpawnPlayer(Character character)
    {
		// Search nearby free cell
		Cell freeCell = SearchFreeCell();
		character.Move (freeCell);
    }

	private Cell SearchFreeCell() {
        List<Cell> cells = new List<Cell>();
        foreach(Cell castleCell in owner.castleCells)
        {
            foreach(Cell c in MapController.instance.GetContiguousCells(castleCell)){
                cells.Add(c);
            }
        }
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
        if (cell.hoverCharacter != null)
        {
            cell.hoverCharacter.currentHealth -= damage;
        }
        foreach (Cell cell1 in GameController.instance.mapController.GetContiguousCells(cell))
        {
            if (cell1.hoverCharacter != null)
                cell1.hoverCharacter.currentHealth -= damage/5;
        }
    }
    public void  SpawnCharacters()
    {
        //Spawn Archer
        Cell cell = SearchFreeCell();
        GameObject prefab = Resources.Load("Archer") as GameObject;
        GameObject gameObject = (GameObject) GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Archer archer = gameObject.GetComponent<Archer>();
        archer.owner = owner;
        cell.hoverCharacter = archer;
        archer.actualCell = cell;

        //Spawn Canoneer
        cell = SearchFreeCell();
        prefab = Resources.Load("Cannoneer") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Cannoneer cannoneer = gameObject.GetComponent<Cannoneer>();
        cannoneer.owner = owner;
        cell.hoverCharacter = cannoneer;
        cannoneer.actualCell = cell;

        //Spawn King
        cell = SearchFreeCell();
        prefab = Resources.Load("King") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        King king = gameObject.GetComponent<King>();
        king.owner = owner;
        cell.hoverCharacter = king;
        king.actualCell = cell;

        //Spawn Archer
        cell = SearchFreeCell();
        prefab = Resources.Load("Mage") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Mage mage = gameObject.GetComponent<Mage>();
        mage.owner = owner;
        cell.hoverCharacter = mage;
        mage.actualCell = cell;
    }
}
