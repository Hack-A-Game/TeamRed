using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {


    public Text timeText1;
    public Text timeText2;

    


    void Start () {
        timeText1.text = "";
        timeText2.text = "";
	
	}
	
	// Update is called once per frame

	void Update () {
        if (GameController.instance.actualPlayer.playerId ==1)
        {
            timeText1.text = "TIME: " + Mathf.Floor(GameController.instance.currentTurnTime).ToString();
        }
        else
        {
            timeText2.text = "TIME: " + Mathf.Floor(GameController.instance.currentTurnTime).ToString();
        }
        
	
	}
}
