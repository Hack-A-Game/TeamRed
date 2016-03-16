using UnityEngine;
using System.Collections.Generic;
using Assets;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public Player player1;
    public Player player2;
    public Player actualPlayer;
    public MapController mapController;
    public Character selectedCharacter;
    public float currentTurnTime;
    public const float TURN_TIME = 30;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentTurnTime = TURN_TIME;
        }
        player1 = new Player(1);
        player2 = new Player(2);
        actualPlayer = player1; //TODO hacer aleatorio
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
        selectedCharacter = null;
    }
    // Use this for initialization
    void Start()
    {
        selectedCharacter = null;
        SpawnCastles();
        SpawnExcalibur();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTurnTime(Time.deltaTime); //Decremento por fotograma
        if (currentTurnTime <= 0)
        {
            ChangeTurn();
        }
        /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {*/
        if (Input.GetMouseButtonDown(0))
        {
            //var touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                Cell hitCell = hit.collider.gameObject.GetComponent<Cell>();
                if (this.interactWithCell(hitCell))
                {
                    //Application.loadLevel();
                }
                
            }
        }
    }

    public bool interactWithCell(Cell c)
    {
        //Debug.Log("Han intentado interactuar conmigo");
        if (this.selectedCharacter == null)
        {
            if (c.hoverCharacter != null && c.hoverCharacter.owner == actualPlayer)
            {
                Debug.Log("Me han seleccionado");
                this.selectedCharacter = c.hoverCharacter;
            }
        }
        else
        {
            if (c.hoverCharacter == null && this.selectedCharacter.CanMove(c))
            {
                Debug.Log("Me he movido");
                this.selectedCharacter.Move(c);
            }
            else if (c.hoverCharacter != null)
            {
                if (c.hoverCharacter == this.selectedCharacter)
                {
                    Debug.Log("Me han deseleccionado");
                    this.selectedCharacter = null;
                }
                else if (c.hoverCharacter.owner == null)
                {
                    Debug.Log("Sóc l'excalibur!");
                    if (this.selectedCharacter is King)
                    {
                        King k = (King)this.selectedCharacter;
                        if (k.CanGetSword(c))
                        {
                            Debug.Log("El rey cogió el excalibur");
                            k.GetSword(c);
                            return true;
                        }
                    }
                }
                else if (c.hoverCharacter.owner != actualPlayer)
                {
                    Debug.Log("Soy un enemigo!");
                    if (this.selectedCharacter.CanAttack(c))
                    {
                        Debug.Log("He atacado!");
                        this.selectedCharacter.Attack(c);
                        if (c.hoverCharacter.currentHealth <= 0)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public void DecreaseTurnTime(float timeDecrease)
    {
        currentTurnTime -= timeDecrease; //TODO modificar el contador aqui!!
    }

    public void SpawnExcalibur()
    {
        GameObject gameObject = Instantiate(Resources.Load("Excalibur") as GameObject);
        Excalibur excalibur = gameObject.GetComponent<Excalibur>();
        excalibur.owner = null;
        MapController.instance.map[3, 5].hoverCharacter = excalibur;
        excalibur.actualCell = MapController.instance.map[3, 5];
        gameObject.transform.position = new Vector3(player1.castleCells[0].transform.position.x, player1.castleCells[0].transform.position.y, -9.6f);
        excalibur.Move(excalibur.actualCell);
    }

    public void SpawnCastles()
    {
        GameObject gameObject = Instantiate(Resources.Load("Castle") as GameObject);
        Castle castle = gameObject.GetComponent<Castle>();
        castle.owner = player1;

        player1.castleCells = new List<Cell>();       
        player1.castle = castle;
        player1.castleCells.Add(MapController.instance.map[0, 0]);
        player1.castleCells.Add(MapController.instance.map[1, 0]);
        gameObject.transform.position = new Vector3(player1.castleCells[0].transform.position.x, player1.castleCells[0].transform.position.y, -9.6f);

        GameObject gameObject2 = Instantiate(Resources.Load("Castle") as GameObject);
        Castle castle2 = gameObject2.GetComponent<Castle>();
        castle2.owner = player2;

        player2.castleCells = new List<Cell>();
        player2.castle = castle2;
        player2.castleCells.Add(MapController.instance.map[MapController.instance._mapWidth - 2  , MapController.instance._mapHeight - 1]);
        player2.castleCells.Add(MapController.instance.map[MapController.instance._mapWidth - 1, MapController.instance._mapHeight - 1]);
        gameObject.transform.position = new Vector3(player2.castleCells[0].transform.position.x, player2.castleCells[0].transform.position.y, -0.5f);

    }
}