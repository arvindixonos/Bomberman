using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    private int numTilesX = 15;
    private int numTilesY = 11;

    public int NumTilesX { get { return numTilesX; } set { numTilesX = value; } }
    public int NumTilesY { get { return numTilesY; } set { numTilesY = value; } }

    public TileUnit[] tiles;

    internal void InitMap()
    {
        tiles = GetComponentsInChildren<TileUnit>(true);
    }

    public TileUnit GetTile(int x, int y)
    {
        return tiles[x * numTilesY + y];
    }

    public Vector3 GetTilePosition(int x, int y)
    {
        print(x + " " + y);
        print(x * numTilesY + y);

        return tiles[x * numTilesY + y].transform.position;
    }
}
