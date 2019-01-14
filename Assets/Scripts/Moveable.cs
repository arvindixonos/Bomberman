using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Blastable
{
    public int ID = -1;

    private bool alive = false;
    public bool isAlive { get { return alive; } }

    private float moveSpeed = 2f;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

	protected	eDir	facingDirection = eDir.DIR_NONE;

    public void Move(eDir moveDir)
    {
		
    }
}
