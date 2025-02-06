using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PoolingSystem<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    
    private Vector3 position;
    private Transform spawn;

    public PoolingSystem(T prefab, int initialSize, Transform spawnlocation)
    {
        this.prefab = prefab;
        
        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, spawnlocation);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }

        spawn = spawnlocation;
        position = spawn.position;
       
    }

    public T GetFromPool()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T newObj = GameObject.Instantiate(prefab, spawn);
            return newObj;
        }
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        //reset position
        obj.GetComponent<Transform>().position = position;
        pool.Enqueue(obj);
    }
}