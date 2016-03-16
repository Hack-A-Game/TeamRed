using UnityEngine;
using System.Collections;
using Assets;


public abstract class Character : MonoBehaviour {

    public Player owner;
	public string tag;

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

    // Use this for initialization
    void Start () {
        characterInfoText = "";
		sprite = GetComponent<SpriteRenderer> ();

		StartVariables ();
	}

	abstract public void StartVariables ();
	abstract public void CharacterAttack (Cell cell);

	void BeginTurn() {
		if (isSpawning) {
			turnsToSpawn--;
			if (turnsToSpawn == 0) {
				Spawn ();
			}
		}
		turnMoves = maxMove;
		turnActions = maxAction;
	}

	void Spawn() {
		Castle castle = owner.castle;
		currentHealth = maxHealth;
		turnMoves = maxMove;
		turnActions = maxAction;
		this.sprite.enabled = true;
		castle.SpawnPlayer (this);
	}

	private void UpdateTime(float time) {
		GameController.instance.DecreaseTurnTime (time);
	}

	float CalculateMoveCost(Cell cell) {
		return costPerMovement * ManhattanDistance(cell);
	}

	private float ManhattanDistance(Cell cell) {
		return Mathf.Abs (actualCell.posX - cell.posX) + Mathf.Abs (actualCell.posY - cell.posY);
	}

	public bool CanMove(Cell cell) {
		return CalculateMoveCost(cell) >= GameController.instance.currentTurnTime;
	}

	public bool CanAttack(Cell cell) {
		return ManhattanDistance (cell) <= attackRange;
	}

	public void Move(Cell destiny) {
		this.transform.position = destiny.transform.position + new Vector3 (0, 1, 0);
		Vector3 tmp = this.transform.position;
		tmp.z = tmp.y;
		this.transform.position = tmp;
		actualCell.hoverCharacter = null;
		actualCell = destiny;
		destiny.hoverCharacter = this;

	}

	public void Attack(Cell cell) {
		if (turnActions > 0 && CanAttack (cell)) {
			CharacterAttack (cell);
			UpdateTime (costPerAction);
			turnActions--;
		}
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0 && !isSpawning) {
			isSpawning = true;
			sprite.enabled = false;
			turnsToSpawn = 2;
		}
	}


    void OnGUI()

    {
        characterInfoText = "L: " + currentHealth.ToString() + "\n" + "M:";
        Vector3 infoPosition = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(infoPosition.x, (Screen.height - 0.5f), 100, 50), characterInfoText);

    }

	public bool CompareTo(Character other) {
		if (other.GetType() == this.GetType())
			return true;
		return false;
	}

}
