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

	public int turnMoves;
	public int turnActions;
	public int turnsToSpawn = 0;
	public bool isSpawning = false;
    public bool canMove = true;
    public string characterInfoText = "";
    private Rect characterInfoRect = new Rect(95, 160, 175, 40);

	private SpriteRenderer sprite;
	private Cell actualCell;

    // Use this for initialization
    void Start () {
        characterInfoText = "";
		sprite = GetComponent<SpriteRenderer> ();
		startVariables ();
	}

	abstract public void startVariables ();

	void beginTurn() {
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
		this.sprite.enabled = true;
		castle.SpawnPlayer (this, null);
	}

	private void updateTime(float time) {
		GameController.instance.decreaseTurnTime (time);
	}

	float calculateMoveCost(int x, int y) {
		return costPerMovement * (Mathf.Abs(actualCell.posX - x) + Mathf.Abs(actualCell.posY - y));
	}

	void Move(int x, int y) {
		
	}

	void Move(Cell destiny) {
		this.transform.position = destiny.transform.position + new Vector3 (0, 1, 1);
		Vector3 tmp = this.transform.position;
		tmp.z = tmp.y;
		this.transform.position = tmp;
		actualCell = destiny;
		destiny.hoverCharacter = this;
	}

	void Attack(Character enemy) {
		if (turnActions > 0) {
			enemy.currentHealth -= damage;
			updateTime (costPerAction);
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
        Vector3 pos = characterInfoRect.center;
        pos.y += characterInfoRect.height / 2.0;  // Position at top of rect
        pos.y = Screen.height - pos.y;  // Convert from GUI to Screen
        pos.z = someDist;  // Distance in front of the camera
        pos = Camera.main.ScreenToWorldPoint(pos);
        characterInfoText = "L: " + health.ToString() + "\n" + "M:";
        GUI.Label(characterInfoRect, characterInfoText);

    }
	//TODO: EVERYTHING
}
