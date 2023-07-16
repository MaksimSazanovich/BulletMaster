using System;
using UnityEngine;
using Zenject;

public class Shield : UnitHealth
{   
    private PlayerHealth PlayerHealth;

    [SerializeField] private float offsetY;

    public static event Action OnDestroy;

    private UIExtraLife uIExtraLife;

    [Inject]
    private void Init(PlayerHealth playerHealth, UIExtraLife uIExtraLife)
    {
        this.PlayerHealth = playerHealth;
        this.uIExtraLife = uIExtraLife;
    }

    protected override void Start()
    {
        base.Start();
        transform.position = PlayerHealth.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z);
    }

    private void Update()
    {
        transform.position = PlayerHealth.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z);
    }

    public override void Die()
    {
        OnDestroy?.Invoke();
        uIExtraLife.gameObject.SetActive(false);
        Destroy(gameObject, 0.2f);
    }
}