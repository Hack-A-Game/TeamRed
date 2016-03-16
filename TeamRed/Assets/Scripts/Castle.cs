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
		Cell castleCell = owner.castleCell;
		List<Cell> cells = MapController.instance.GetContiguousCells (castleCell);
		foreach (Cell cell in cells) {
			if (cell.hoverCharacter == null) {
				return cell;
			}
		}
		return null;
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
