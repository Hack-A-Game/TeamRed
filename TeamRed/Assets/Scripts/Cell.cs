using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    public Character hoverCharacter = null;
    [SerializeField]
    int _posX;
    [SerializeField]
    int _posY;

    public int posX { get { return _posX; } }
    public int posY { get { return _posY; } }


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
