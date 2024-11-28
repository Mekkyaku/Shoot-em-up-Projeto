using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;
    [SerializeField] private GameObject bulletPrefab;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }  
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }      
    }

    public GameObject GetPooledObject(){
        for (int i = 0; i < pooledObjects.Count; i++){
            if(!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        return null;
    }
}