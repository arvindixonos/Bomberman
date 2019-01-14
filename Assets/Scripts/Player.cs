using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Moveable
{
    private int bombCapacity = 1;
    public int BombCapacity { get { return bombCapacity; } set { bombCapacity = value; } }

    private List<Powerup> activePowerUps = new List<Powerup>();
    private List<Bomb> activeBombs = new List<Bomb>();

    public  void InitPlayer(Vector3 startPosition, eDir facingDir)
    {
        transform.position = startPosition;
        this.facingDirection = facingDir;
    }

    public void PlaceBomb()
    {

    }

    public void BlastLastBomb()
    {

    }
}
