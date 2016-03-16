using UnityEngine;
using System.Collections;
using Assets;


public abstract class Character : MonoBehaviour {

    public Player owner;
    public int health;
    public int maxMove;
    public int maxAction;
    public int costPerAction;
    public int costPerMovement;
    public bool canMove = true;
    public string characterInfoText = "";

	// Use this for initialization
	void Start () {
        characterInfoText = "";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()

    {
        characterInfoText = "L: " + health.ToString() + "\n" + "M:";
        GUI.Label(new Rect(25, 25, 100, 30), characterInfoText);

    }
}
