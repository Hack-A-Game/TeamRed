using UnityEngine;
using System.Collections;
using Assets;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public Player player1;
    public Player player2;
    public Player actualPlayer;
    public MapController mapController;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1 )
        {
           if( Input.GetTouch(0).phase == TouchPhase.Began)
           {
                var touchPosition = Input.GetTouch(0).position;
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hit != null && hit.collider != null)
                {
                    Cell hitCell = hit.collider.gameObject.GetComponent<Cell>();
                    Destroy(hitCell.gameObject); // TODO Take this out
                }
           }
        }
        else
        {
            //Don't do anything
        }
    }
}
