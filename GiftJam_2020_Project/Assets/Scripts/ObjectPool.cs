using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetObject(GameObject gameObject) {
        if (pool.TryGetValue(gameObject.name, out Queue<GameObject> objQueue)){
            if (objQueue.Count == 0) {
                return CreateObject(gameObject);
            } else {
                return objQueue.Dequeue();
            }
        } else {
            return CreateObject(gameObject);
        }
    }

    public void ReturnObject(GameObject gameObject) {
        if (pool.TryGetValue(gameObject.name, out Queue<GameObject> objQueue)){
            objQueue.Enqueue(gameObject);
        } else {
            Queue<GameObject> newQueue = new Queue<GameObject>();
            newQueue.Enqueue(gameObject);
            pool.Add(gameObject.name, newQueue);
        }
    }

    private GameObject CreateObject(GameObject gameObject) {
        GameObject newObj = Instantiate(gameObject);
        newObj.name = gameObject.name;
        return newObj;
    }
}
