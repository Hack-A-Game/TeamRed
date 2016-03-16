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
    private SpriteRenderer hpUi;

    // Use this for initialization
    void Start () {
        characterInfoText = "";
		sprite = GetComponent<SpriteRenderer> ();
        hpUi = transform.Find("HP").GetComponent<SpriteRenderer>();
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
       // hpUi.transform.localScale(new Vector3(1, 0, 0));
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
		this.transform.position = destiny.transform.position + new Vector3 (0, 0.1f, 0);
		Vector3 tmp = this.transform.position;
		tmp.z = -tmp.y;
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
            hpUi.transform.localScale += new Vector3(0.1F, 0, 0);
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

	public bool CompareTo(Character other) {
		if (other.GetType() == this.GetType())
			return true;
		return false;
	}

}
