using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileUnit))]
[CanEditMultipleObjects]
public class TileUnitEditor : Editor
{
    SerializedProperty tileType;
    TileUnit tileUnit = null;

    void OnEnable()
    {
        tileType = serializedObject.FindProperty("tileType");
    }

    public override void OnInspectorGUI()
    {
        tileUnit = target as TileUnit;

        EditorGUI.BeginChangeCheck();

        serializedObject.Update();

        EditorGUILayout.PropertyField(tileType);

        serializedObject.ApplyModifiedProperties();

        if (EditorGUI.EndChangeCheck())
        {
            tileUnit.SpawnTileContent();
        }
    }


    [MenuItem("BomberMan/Refresh All Tiles")]
    private static void NewMenuOption()
    {
        TileUnit[] tileUnits = FindObjectsOfType<TileUnit>();
        foreach(TileUnit tileUnit in tileUnits)
        {
            tileUnit.SpawnTileContent();
        }
    }
}
