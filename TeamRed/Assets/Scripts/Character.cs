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
    private Rect characterInfoRect = new Rect(95, 160, 175, 40);

    // Use this for initialization
    void Start () {
        characterInfoText = "";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()

    {
        Vector3 pos = characterInfoRect.center;
        pos.y += characterInfoRect.height / 2.0;  // Position at top of rect
        pos.y = Screen.height - pos.y;  // Convert from GUI to Screen
        pos.z = someDist;  // Distance in front of the camera
        pos = Camera.main.ScreenToWorldPoint(pos);
        characterInfoText = "L: " + health.ToString() + "\n" + "M:";
        GUI.Label(characterInfoRect, characterInfoText);

    }
}
