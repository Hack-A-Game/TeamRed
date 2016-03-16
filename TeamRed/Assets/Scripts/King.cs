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

    public bool CanGetSword(Cell cell)
    {
        return ManhattanDistance(cell) == 1;
    }

    public override void CharacterAttack(Cell cell)
    {
        int currentdmg;
        if (hasSword)
        {
            currentdmg = damage*2;
        }
        else
        {
            currentdmg = damage;
        }
        cell.hoverCharacter.currentHealth -= currentdmg;
    }

    public void GetSword(Cell cell)
    {
        hasSword = true;
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