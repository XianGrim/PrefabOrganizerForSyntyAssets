using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[ExecuteInEditMode]
public class SyntyPrefabNameUpdater : MonoBehaviour
{
    private Transform parentObject;
    private List<GameObject> houseParts = new List<GameObject>();

    [HideInInspector,SerializeField] GameObject basePrefab;
    [HideInInspector,SerializeField] GameObject _floors;
    [HideInInspector, SerializeField] GameObject _walls;
    [HideInInspector, SerializeField] GameObject _doors;
    [HideInInspector, SerializeField] GameObject _roof;
    [HideInInspector, SerializeField] GameObject _windows;
    [HideInInspector, SerializeField] GameObject _dressings;
    [HideInInspector, SerializeField] GameObject _interior;
    [HideInInspector, SerializeField] GameObject _stairs;
    [HideInInspector, SerializeField] GameObject _misc;
    private void Awake()
    {
        parentObject = transform;
    }
    //Build a list of all the house parts within a prefabs hierarchy
    public void BuildList()
    {
        houseParts.Clear();
        foreach(Transform child in parentObject)
        {
            houseParts.Add(child.gameObject);
        }
    }

    //Base the Empty Objects the items in the prefab will be parented to
    public void AddBaseParents()
    {
         _floors= new GameObject("Floor");
         _walls = new GameObject("Walls");
         _doors = new GameObject("Doors");
         _roof = new GameObject("Roof");
         _windows = new GameObject("Windows");
         _dressings = new GameObject("Dressings");
         _interior = new GameObject("Interior Props and Items");
        _stairs = new GameObject("Stairs");
        _misc = new GameObject("Misc");
        _floors.transform.parent = gameObject.transform;
        _walls.transform.parent = gameObject.transform;
        _doors.transform.parent = gameObject.transform;
        _roof.transform.parent = gameObject.transform;
        _windows.transform.parent = gameObject.transform;
        _dressings.transform.parent = gameObject.transform;
        _interior.transform.parent = gameObject.transform;
        _stairs.transform.parent = gameObject.transform;
        _misc.transform.parent = gameObject.transform;
    }

    //Do the organization part, iterating between the objects and separating based on names
    public void OrganizePrefab()
    {
        BuildList();
        AddBaseParents();
        foreach(GameObject part in houseParts)
        {
            switch(part.gameObject.name)
            {
                case string a when a.Contains("Floor"):
                {
                        part.transform.parent = _floors.gameObject.transform;
                }
                break;
                case string a when a.Contains("Door"):
                    {
                        part.transform.parent = _doors.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Window"):
                    {
                        part.transform.parent = _windows.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Wall"):
                    {
                        part.transform.parent = _walls.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Roof"):
                    {
                        part.transform.parent = _roof.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Item"):
                    {
                        part.transform.parent = _interior.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Prop"):
                    {
                        part.transform.parent = _interior.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Interior"):
                    {
                        part.transform.parent = _interior.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Stair"):
                    {
                        part.transform.parent = _stairs.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Corner"):
                    {
                        part.transform.parent = _dressings.gameObject.transform;
                    }
                    break;
                case string a when a.Contains("Beam"):
                    {
                        part.transform.parent = _dressings.gameObject.transform;
                    }
                    break;
                default:
                    {
                        part.transform.parent = _misc.gameObject.transform;
                    }
                    break;
            }
        }
    }
}
