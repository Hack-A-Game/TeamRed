using UnityEngine;
using System.Collections;
using Assets;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public Player player1;
    public Player player2;
    public Player actualPlayer;
    public MapController mapController;
    public float currentTurnTime;
    public const float TURN_TIME=30;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            currentTurnTime = TURN_TIME;
        }
    }

    //Cambia actualPlayer y reseta el contador de tiempo
    void ChangeTurn()
    {
        if (actualPlayer.CompareTo(player1))
        {
            actualPlayer = player2;
        }
        else
        {
            actualPlayer = player1;
        }
        currentTurnTime = TURN_TIME;
    }
	// Use this for initialization
	void Start () {
        player1 = new Player(1);
        player2 = new Player(2);
        actualPlayer = player1; //TODO hacer aleatorio
	}
	
	// Update is called once per frame
	void Update () {
		decreaseTurnTime(Time.deltaTime); //Decremento por fotograma
        if (currentTurnTime <= 0)
        {
            ChangeTurn();
        }
        /*if (Input.touchCount == 1 )
        {*/
        if (Input.GetMouseButtonDown(0)) {

            //var touchPosition = Input.GetTouch(0).position;
            var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hit != null && hit.collider != null)
                {
                    Cell hitCell = hit.collider.gameObject.GetComponent<Cell>();
                    Destroy(hitCell.gameObject); // TODO Take this out, just for trials
                }
        }
        else
        {
            //Don't do anything
        }
    }
    public void decreaseTurnTime(float timeDecrease)
    {
        currentTurnTime -= timeDecrease; //TODO modificar el contador aqui!!
    }
}
