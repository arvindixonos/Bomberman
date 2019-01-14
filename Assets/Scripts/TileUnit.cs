using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUnit : Blastable
{
    public int tileID;
    public eTileType tileType = eTileType.TILE_FLOOR;
    public GameObject spawnedContent = null;

    private Hideable hideable = null;

    private int blastOwner = -1;

    public void InitTile(int tileID, eTileType tileType, Hideable hideable = null)
    {
        this.tileID = tileID;
        this.tileType = tileType;
        this.hideable = hideable;
    }

    public override bool isBlastable()
    {
        if(tileType == eTileType.TILE_WALL || tileType == eTileType.TILE_FLOOR)
            return false;

        return true;
    }

    public int Blast(int ownerID)
    {
        if (!isBlastable())
            return -1;

        if (isBlasted)
            return -2;

        this.blastOwner = ownerID;

        return 0;
    }

    void OnTriggerEnter(Collider collider)
    {

    }

    void OnTriggerExit(Collider collider)
    {

    }

    public override void BlastReceived()
    {
        if (blasted)
            return;

        blasted = true;

        if(spawnedContent != null)
        {
            print(GetInstanceID());
            spawnedContent.gameObject.SetActive(false);
        }
    }

    public void RefreshAllTiles()
    {

    }

    public void SpawnTileContent()
    {
        if (spawnedContent != null)
        {
            GameObject.DestroyImmediate(spawnedContent.gameObject);
            spawnedContent = null;
        }

        TileInfo tileInfo = TilesManager.Instance.GetTileInfo(tileType);

        if (tileInfo != null && tileInfo.content != null)
        {
            spawnedContent = GameObject.Instantiate(tileInfo.content);
            spawnedContent.isStatic = tileInfo.staticObject;
            spawnedContent.transform.parent = transform;
            spawnedContent.transform.localPosition = tileInfo.contentSpawnOffset;
            spawnedContent.transform.localRotation = Quaternion.identity;
        }
    }
}
