using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {


    public Text timeText;
    public Text pointsText;
    public Text playerText;
    public Text remainingMovementsText;
    public Text liveText;          //Store a reference to the UI Text component which will display the number remaining lives
                                   // Use this for initialization


    void Start () {
        timeText.text = "";
        pointsText.text = "";
        playerText.text = "";
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //playerText = "PLAYER"+ GameController.actualPlayer.toString();
        //pointsText = "POINTS" + GameController.actualPlayer.points.toString();
        //timeText = "TIME" + GameController.remainingTime.toString();
	
	}
}
