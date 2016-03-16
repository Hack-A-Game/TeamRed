using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class Castle : MonoBehaviour {

    public Player owner;

	// Use this for initialization
	void Start () {
        SpawnCharacters();
	}
	
	// Update is called once per frame
	void Update () {
	
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
