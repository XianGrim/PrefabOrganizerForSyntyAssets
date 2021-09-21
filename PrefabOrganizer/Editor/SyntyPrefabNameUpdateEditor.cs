using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SyntyPrefabNameUpdater))]
public class SyntyPrefabNameUpdateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SyntyPrefabNameUpdater syntyUpdate = (SyntyPrefabNameUpdater)target;
        base.OnInspectorGUI();
        if(GUILayout.Button("Organize Prefab"))
        {
            syntyUpdate.OrganizePrefab();
        }
    }
}
