using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    private List<GameObject> availableObjectList;
    private List<GameObject> activeObjectList;

    [SerializeField] private GameObject poolPrefab;
    [SerializeField] private int startingNumberofObjects;

    public void Awake()
    {
        availableObjectList = new List<GameObject>();
        activeObjectList = new List<GameObject>();

    }

    void Start()
    {
        CreateObject(startingNumberofObjects);
    }
    
    void Update()
    {
        
    }

    private void CreateObject(int numberOfObjects)
    {
        GameObject tempObject;
        for (int i = 0; i < numberOfObjects; i++)
        {
            tempObject = Instantiate(poolPrefab, Vector3.zero, Quaternion.identity, transform);
            tempObject.SetActive(false);
            availableObjectList.Add(tempObject);
        }
    }

    public GameObject RequestObject()
    {
        if (availableObjectList.Count != 0)
        {
            return availableObjectList[0];
        }
        else
        {
            return null;
        }
    }
}
