using System;
using UnityEngine;

public abstract class ObjectScore : MonoBehaviour
{
    public static event Action<int> OnChanged;

    [SerializeField] private int score;

    public virtual void Activate()
    {
        OnChanged?.Invoke(score);
    }
}