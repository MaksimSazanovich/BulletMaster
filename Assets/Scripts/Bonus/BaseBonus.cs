using System;
using UnityEngine;

public abstract class BaseBonus : MonoBehaviour
{
    protected internal event Action OnPicked;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            OnPicked?.Invoke();
            Destroy(gameObject);
        }
    }
}