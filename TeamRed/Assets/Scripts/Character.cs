using UnityEngine;
using System.Collections;
using Assets;


public abstract class Character : MonoBehaviour {

    public Player owner;

	// Las que hay que implementar
	public int maxHealth;
	public int currentHealth;
	public int maxMove;
	public int maxAction;
	public int costPerAction;
	public int costPerMovement;
	public int damage;
	public int attackRange;

	public int turnMoves;
	public int turnActions;
	public int turnsToSpawn = 0;
	public bool isSpawning = false;
    public string characterInfoText = "";    
	private SpriteRenderer sprite;
	public Cell actualCell;
    public SpriteRenderer hpUi;

    public Sprite red;
    public Sprite blue;

    // Use this for initialization
    public void Start () {
        characterInfoText = "";
		sprite = gameObject.GetComponent<SpriteRenderer> ();
        hpUi = transform.Find("HP").GetChild(0).GetComponent<SpriteRenderer>();
	}

	abstract public void CharacterAttack (Cell cell);

	public void BeginTurn() {
		if (turnsToSpawn > 0) {
			turnsToSpawn--;
			if (turnsToSpawn == 0) {
				Spawn ();
			}
		}
		turnMoves = maxMove;
		turnActions = maxAction;
       // hpUi.transform.localScale(new Vector3(1, 0, 0));
	}

	void Spawn() {
		Castle castle = owner.castle;
		currentHealth = maxHealth;
		turnMoves = maxMove;
		turnActions = maxAction;
		this.sprite.enabled = true;
		transform.Find("HP").localScale = new Vector3(1,1,1);
		castle.SpawnPlayer (this);
	}

	private void UpdateTime(float time) {
		GameController.instance.DecreaseTurnTime (time);
	}

	float CalculateMoveCost(Cell cell) {
		Debug.Log ("CostMov: " + costPerMovement + " Manh:" +ManhattanDistance(cell));
        if (ManhattanDistance(cell) <= turnMoves)
            return costPerMovement * ManhattanDistance(cell);
        else
            return 1000;
	}

	public float ManhattanDistance(Cell cell) {
		return Mathf.Abs (actualCell.posX - cell.posX) + Mathf.Abs (actualCell.posY - cell.posY);
	}

	public bool CanMove(Cell cell) {
		return CalculateMoveCost(cell) <= GameController.instance.currentTurnTime;
	}

	public bool CanAttack(Cell cell) {
		return ManhattanDistance (cell) <= attackRange;
	}

	public void Move(Cell destiny) {
		this.transform.position = destiny.transform.position;
		Vector3 tmp = this.transform.position;
		tmp.z = -tmp.y;
		this.transform.position = tmp;
		UpdateTime (CalculateMoveCost(destiny));
		actualCell.hoverCharacter = null;
		actualCell = destiny;
		destiny.hoverCharacter = this;
		turnMoves--;
	}

	public void Attack(Cell cell) {
		if (turnActions > 0 && CanAttack (cell)) {
			CharacterAttack (cell);
			UpdateTime (costPerAction);
			turnActions--;
			cell.hoverCharacter.hpUi.transform.localScale = new Vector3(((float) currentHealth * 0.3f)/maxHealth, 0.1f, 1);
        }
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0 && turnsToSpawn == 0) {
			this.sprite.enabled = false;
			transform.Find("HP").localScale = new Vector3(0,0,0);
			turnsToSpawn = 2;
		}
	}

	public bool CompareTo(Character other) {
		if (other.GetType() == this.GetType())
			return true;
		return false;
	}

}
