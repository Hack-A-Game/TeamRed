using UnityEngine;
using System.Collections;
using System;

public class King : Character
{

    public bool hasSword;
    public override void StartVariables()
    {
        currentHealth = maxHealth;
        maxMove = 1;
        attackRange = 1;

        //TODO balanceo
        maxHealth = 50;
        maxAction = 2;
        costPerAction = 4;
        costPerMovement = 2;
        damage = 5;
    }

    public override void CharacterAttack(Cell cell)
    {
        if (hasSword)
        {
            damage = 10;
        }
        else
        {
            damage = 5;
        }
        cell.hoverCharacter.currentHealth -= damage;
    }
    public void GetSword(Cell cell)
    {
        Excalibur sword = new Excalibur();
        if (cell.hoverCharacter.CompareTo(sword))
        {
            cell.hoverCharacter.gameObject.SetActive(false);
            hasSword = true;
        }

    }

    // Use this for initialization
    void Start()
    {
        hasSword = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}