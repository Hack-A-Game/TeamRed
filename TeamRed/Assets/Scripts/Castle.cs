using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;

public class Castle : Character {

    public float contador;
	public List<Cell> adjacentCells;
    // Use this for initialization
    void Start () {
		adjacentCells = new List<Cell> ();
		foreach(Cell castleCell in owner.castleCells)
		{
			List<Cell> tmp = MapController.instance.GetContiguousCells (castleCell);
			foreach(Cell c in tmp) {
				if (owner.castleCells.IndexOf(c) == -1)
					adjacentCells.Add(c);
			}
		}
		SpawnCharacters();
		contador = 0;
	}

	// Update is called once per frame
	void Update () {
        contador += Time.deltaTime;
        if(contador > 10)
        {
            RandomAttack();
            contador = 0;
        }
	}

    private void RandomAttack()
    {
        int randomX = Mathf.RoundToInt(UnityEngine.Random.value * 3);
        int randomY = Mathf.RoundToInt(UnityEngine.Random.value * 5);
        if (owner.playerId != 1)
        {
            randomX += 3;
            randomY += 5;
        }

        Cell cell = MapController.instance.map[randomX, randomY];

        SpawnBullet(cell.transform.position);
        CharacterAttack(cell);
        Debug.Log("Castillo ataca celda. x= " + cell.posX + "y= " + cell.posY);
    }

    public void SpawnBullet(Vector3 position){
        GameObject bullet = Resources.Load("Bullet") as GameObject;
        GameObject instance = (GameObject) GameObject.Instantiate(bullet, transform.position, transform.rotation);
        instance.GetComponent<BulletBehavior>().position = position;
    }
    
    public void SpawnPlayer(Character character)
    {
		// Search nearby free cell
		Cell freeCell = SearchFreeCell(); 
		character.Move (freeCell);
    }

	private Cell SearchFreeCell() {
		foreach (Cell cell in adjacentCells) {
			if (cell.hoverCharacter == null) {
				return cell;
			}
		}
		return null;
	}

   

    public override void CharacterAttack(Cell cell)
    {
		if (cell.hoverCharacter != null && cell.hoverCharacter.owner != owner)
        {
            //Debug.Log("Damage " + 30);//this.damage);
            //Debug.Log("currenthoveredhealth " + cell.hoverCharacter.currentHealth);
            cell.hoverCharacter.currentHealth -= 15;//this.damage;
            //Debug.Log("nuevahealt" + cell.hoverCharacter.currentHealth);

        }

        foreach (Cell cell1 in MapController.instance.GetContiguousCells(cell))
        {
			if (cell1.hoverCharacter != null && cell.hoverCharacter.owner != owner)
            {
                //Debug.Log("celda contiguacon enemigo " + cell1);//this.damage);
                cell1.hoverCharacter.currentHealth -= 3;
            }
        }
    }
    public void  SpawnCharacters()
    {
        //Spawn Archer
        Cell cell = SearchFreeCell();
        GameObject prefab = Resources.Load("Archer") as GameObject;
        GameObject gameObject = (GameObject) GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Archer archer = gameObject.GetComponent<Archer>();
        archer.owner = owner;
        cell.hoverCharacter = archer;
        archer.actualCell = cell;
        owner.characters.Add(archer);

        //Spawn Canoneer
        cell = SearchFreeCell();
        prefab = Resources.Load("Cannoneer") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Cannoneer cannoneer = gameObject.GetComponent<Cannoneer>();
        cannoneer.owner = owner;
        cell.hoverCharacter = cannoneer;
        cannoneer.actualCell = cell;
        owner.characters.Add(cannoneer);

        //Spawn King
        cell = SearchFreeCell();
        prefab = Resources.Load("King") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        King king = gameObject.GetComponent<King>();
        king.owner = owner;
        cell.hoverCharacter = king;
        king.actualCell = cell;
        owner.characters.Add(king);

        //Spawn Archer
        cell = SearchFreeCell();
        prefab = Resources.Load("Mage") as GameObject;
        gameObject = (GameObject)GameObject.Instantiate(prefab, new Vector3(cell.transform.position.x, cell.transform.position.y, -9.6f), transform.rotation);
        Mage mage = gameObject.GetComponent<Mage>();
        mage.owner = owner;
        cell.hoverCharacter = mage;
        mage.actualCell = cell;
        owner.characters.Add(mage);

        foreach(Character character in owner.characters)
        {
            SetCharacterSprite(character);
        }

        SetCharacterSprite(this);
    }



    void SetCharacterSprite(Character character)
    {
        if (character.owner.playerId == 1)
        {
            Debug.Log("Red player");
            character.GetComponent<SpriteRenderer>().sprite = character.red;
        }
        else
        {
            Debug.Log("Blue player");
            character.GetComponent<SpriteRenderer>().sprite = character.blue;
        }
    }

}
