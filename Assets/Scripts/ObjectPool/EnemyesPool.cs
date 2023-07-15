using UnityEngine;
using Zenject;

public class EnemyesPool : ObjectsPool
{
    [SerializeField, Inject] private DiContainer container;

    public override void InitObject(GameObject objectPrefab)
    {
        GameObject currentObject = container.InstantiatePrefab(objectPrefab, transform);
        currentObject.SetActive(false);
        objects.Add(currentObject);
    }
}