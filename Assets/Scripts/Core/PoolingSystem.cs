using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PoolingSystem<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    private Vector3 position;
    private Quaternion rotation;
    private Transform spwan;

    public PoolingSystem(T prefab, int initialSize, Transform spawnlocation)
    {
        this.prefab = prefab;
        position = spawnlocation.position;
        rotation = spawnlocation.rotation;
        spwan = spawnlocation;
        
        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, spawnlocation);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public T GetFromPool()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        // If the list is empty we instantiate a new object
        return null;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        //reset position
        obj.GetComponent<Transform>().SetLocalPositionAndRotation(position, rotation);
        pool.Enqueue(obj);
    }
}