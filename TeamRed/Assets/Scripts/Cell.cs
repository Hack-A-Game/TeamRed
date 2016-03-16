using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    public Character hoverCharacter = null;
    public int posX;
    public int posY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }
}
