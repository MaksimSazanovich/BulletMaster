using UnityEngine;
using UnityEngine.Events;

public abstract class BaseBonus : MonoBehaviour
{
    [SerializeField] protected UnityEvent OnPicked;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            OnPicked.Invoke();
            Destroy(gameObject);
        }
    }
}