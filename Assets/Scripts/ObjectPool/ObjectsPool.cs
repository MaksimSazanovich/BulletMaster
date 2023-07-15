using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    protected readonly List<GameObject> objects = new List<GameObject>();
    public virtual void AddObjects(GameObject objectPrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InitObject(objectPrefab);
        }
    }

    public virtual void AddObject(GameObject objectPrefab)
    {
        InitObject(objectPrefab);
    }

    public virtual void InitObject(GameObject objectPrefab)
    {
        GameObject currentObject = Instantiate(objectPrefab, transform);
        currentObject.SetActive(false);
        objects.Add(currentObject);
    }

    public virtual GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
                return objects[i];
        }
        return null;
    }

    public virtual GameObject GetRandomObject()
    {
        int i = Random.Range(0, objects.Count);
        if (!objects[i].activeInHierarchy)
            return objects[i];
        return GetRandomObject();
    }
}
