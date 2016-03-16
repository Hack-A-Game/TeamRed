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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
