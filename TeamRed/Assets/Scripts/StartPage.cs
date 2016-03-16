using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartPage : MonoBehaviour {

   
	// Use this for initialization
	void Start () {



    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Application.LoadLevel("Scene1");
    }
}
