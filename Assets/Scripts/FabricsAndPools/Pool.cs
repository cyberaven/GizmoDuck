using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Queue<T> pool;
    private T Prefab;
    public Pool(T Prefab)
    {
        this.Prefab = Prefab;
        pool = new Queue<T>();
    }        
    public T Get()
    {
        T t;
        if (pool.Count ==0)
        {
            t = GameObject.Instantiate(Prefab);
        } else
        {
            t = pool.Dequeue();
            t.gameObject.SetActive(true);
        }
        
        t.transform.SetParent(Starter.Instance.MapPrefabHandler.GetCurrentMap.transform);

        return t;
    }
    public void Set(T t)
    {
        t.gameObject.SetActive(false);
        t.transform.SetParent(null);
        pool.Enqueue(t);
    }

}
