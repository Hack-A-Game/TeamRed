using UnityEngine;
using System.Collections;
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
		//TODO: Implement search algorithm
		return null;
	}
}
