using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;

public class Castle : Character {

    public float contador;
	public List<Cell> adjacentCells;
    // Use this for initialization
    void Start () {
		adjacentCells = new List<Cell> ();
		foreach(Cell castleCell in owner.castleCells)
		{
			List<Cell> tmp = MapController.instance.GetContiguousCells (castleCell);
			foreach(Cell c in tmp) {
				if (owner.castleCells.IndexOf(c) <= 0)
					adjacentCells.Add(c);
			}
		}
		SpawnCharacters();
		contador = 0;
	}

	// Update is called once per frame
	void Update () {
        //contador += Time.deltaTime;
        //if(contador > 12)
        //{
        //    RandomAttack();
        //    contador = 0;
        //}
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
		foreach (Cell cell in adjacentCells) {
			if (cell.hoverCharacter == null) {
				return cell;
			}
		}
		return null;
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
                cell1.hoverCharacter.currentHealth -= damage;
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
        owner.characters.Add(archer);

        //Spawn Canoneer
        cell = SearchFreeCell();
        prefab = Resources.Load("Cannoneer") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Cannoneer cannoneer = gameObject.GetComponent<Cannoneer>();
        cannoneer.owner = owner;
        cell.hoverCharacter = cannoneer;
        cannoneer.actualCell = cell;
        owner.characters.Add(cannoneer);

        //Spawn King
        cell = SearchFreeCell();
        prefab = Resources.Load("King") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        King king = gameObject.GetComponent<King>();
        king.owner = owner;
        cell.hoverCharacter = king;
        king.actualCell = cell;
        owner.characters.Add(king);

        //Spawn Archer
        cell = SearchFreeCell();
        prefab = Resources.Load("Mage") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Mage mage = gameObject.GetComponent<Mage>();
        mage.owner = owner;
        cell.hoverCharacter = mage;
        mage.actualCell = cell;
        owner.characters.Add(mage);

        foreach(Character character in owner.characters)
        {
            SetCharacterSprite(character);
        }
    }



    void SetCharacterSprite(Character character)
    {
        if (character.owner.playerId == 1)
        {
            Debug.Log("Red player");
            character.GetComponent<SpriteRenderer>().sprite = character.red;
        }
        else
        {
            Debug.Log("Blue player");
            character.GetComponent<SpriteRenderer>().sprite = character.blue;
        }
    }

}
