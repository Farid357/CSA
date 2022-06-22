using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script contains the list of objects, which should be pooled. When receiving the command, it returns the object. If the object is not on the list, it creates the new object.
/// </summary>
[System.Serializable]
public class PoolingObjects
{
    public UnityEngine.GameObject pooledPrefab;
    public int count;
}

public class PoolingController : MonoBehaviour {

    [Tooltip("Your 'pooling' objects. Add new element and add the prefab to create the object prefab")]
    public PoolingObjects[] poolingObjectsClass;

    //The list where 'pooling' objects will be stored
    List<UnityEngine.GameObject> pooledObjectsList = new List<UnityEngine.GameObject>();

    public static PoolingController instance; //unique class instance for the easy access

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        CreateNewList();        //Create the new list of 'pooling' objects
    }

    void CreateNewList()
    {
        for (int i = 0; i < poolingObjectsClass.Length; i++)    //for each prefab create the needed amount of objects and deactivate them
        {
            for (int k = 0; k < poolingObjectsClass[i].count; k++)
            {
                UnityEngine.GameObject newObj = Instantiate(poolingObjectsClass[i].pooledPrefab, transform);
                pooledObjectsList.Add(newObj);
                newObj.SetActive(false);                
            }
        }
    }

    
    public UnityEngine.GameObject GetPoolingObject(UnityEngine.GameObject prefab)   //Lookikng for the needed object by prefab name and return it
    {
        string cloneName = GetCloneName(prefab);
        for (int i =0; i<pooledObjectsList.Count; i++)      
        {
            if (!pooledObjectsList[i].activeSelf && pooledObjectsList[i].name == cloneName)
            {                
                return pooledObjectsList[i];
            }
        }
        return AddNewObject(prefab);                        //if there is no object needed create the new one
    }

    UnityEngine.GameObject AddNewObject(UnityEngine.GameObject prefab)              //create the new object and add it to the list
    {
        UnityEngine.GameObject newObj = Instantiate(prefab, transform);
        pooledObjectsList.Add(newObj);
        newObj.SetActive(false);
        return newObj;
    }

    string GetCloneName(UnityEngine.GameObject prefab)                  
    {
        return prefab.name + "(Clone)";
    }
}
