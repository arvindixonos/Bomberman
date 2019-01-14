using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileInfo
{
    public bool staticObject = true;
    public eTileType tileType;
    public GameObject content;
    public Vector3 contentSpawnOffset = Vector3.zero;
    public eParticleEffectsType contentHitEffect;
}

[ExecuteInEditMode]
public class TilesManager : MonoBehaviour
{
    public TileInfo[] tileInfos;
    private int numTileInfos = 0;

    public static TilesManager Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        numTileInfos = tileInfos.Length;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Instance == null)
            Instance = this;
#endif
    }

    public TileInfo GetTileInfo(eTileType tileType)
    {
        for (int i = 0; i < numTileInfos; i++)
        {
            if (tileInfos[i].tileType == tileType)
                return tileInfos[i];
        }

        return null;
    }

}
