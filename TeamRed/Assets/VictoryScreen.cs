using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    public Sprite player1, player2;
    public Image image;

	// Use this for initialization
	void Start () {

        int winner = PlayerPrefs.GetInt("Winner");
        if (winner == 1)
        {
            image.sprite = player1;
        }
        else
        {
            image.sprite = player2;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ReturnToMainMenu()
    {
        Application.LoadLevel("initMenu");
    }
}
