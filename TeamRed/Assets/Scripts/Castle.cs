using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class Castle : MonoBehaviour {

    public Player owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnPlayer(Character character)
    {
		// Search nearby free cell
		Cell freeCell = searchFreeCell();
		character.Move (freeCell);
    }

	private Cell searchFreeCell() {
		Cell castleCell = owner.castleCell;
		List<Cell> cells = GameController.instance.mapController.GetContiguousCells (castleCell);
		foreach (Cell cell in cells) {
			if (cell.hoverCharacter == null) {
				return cell;
			}
		}
		return null;
	}
}
