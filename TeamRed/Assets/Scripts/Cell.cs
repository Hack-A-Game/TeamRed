using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    Character hoverCharacter = null;
    int _posX;
    int _posY;

    int posX { get { return _posX; } }
    int posY { get { return _posY; } }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPosition(int x, int y)
    {
        _posX = x;
        _posY = y;
    }
}
