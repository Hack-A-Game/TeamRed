using UnityEngine;
using System.Collections;
using System;

public class King : Character
{

   public bool hasSword;
    public Sprite kingSwordBlue;
    public Sprite kingSwordRed;

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