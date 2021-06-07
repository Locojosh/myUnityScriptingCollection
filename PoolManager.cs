using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager: MonoBehaviour
{
    #region SINGLETON
    //Turn this class into a Singleton
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("PoolManager is NULL");

            return instance; 
        }
    } 
    #endregion
    
    [SerializeField]
    private GameObject objectPrefab; //Object to instantiate, stored in pool
    [SerializeField]
    private GameObject poolContainer; //Parent of objects in pool
    [SerializeField]
    private int poolSize = 5; //How many initial instantiations 
    [SerializeField]
    private List<GameObject> objectPool = new List<GameObject>(); //The actual pool
    private void Awake() 
    {
        instance = this;  //Singleton  
    }
    private void Start() 
    {
        CreatePool();    
    }
    //Create the bulletPool list
    private List<GameObject> CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, poolContainer.transform);
            objectPool.Add(obj);
            obj.SetActive(false); //Should all objects be initially visible?
        }
        return objectPool;
    }
    public GameObject RequestObject() //Return an object from the objectPool
    {
        foreach(var obj in objectPool)
        {
            if(obj.activeSelf == false) //Check for inactive object
            {
                obj.SetActive(true);
                return obj;
            }
        }
        //Create a new object if all are active
        GameObject newObj = Instantiate(objectPrefab, poolContainer.transform);
        objectPool.Add(newObj);  
        return newObj;
    }
}