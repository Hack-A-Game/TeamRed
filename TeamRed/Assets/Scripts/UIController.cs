using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {


    public Text timeText;
    public Text playerText;
    


    void Start () {
        timeText.text = "";
        playerText.text = " ";
	
	}
	
	// Update is called once per frame

	void Update () {
    
        //pointsText = "POINTS" + GameController.actualPlayer.points.toString();
        timeText.text = "TIME: " + Mathf.Floor(GameController.instance.currentTurnTime).ToString();
	
	}
}
