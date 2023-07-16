using UnityEngine;
using Zenject;

public class ShieldBonus : BaseBonus
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField, Inject] private DiContainer container;

    private static bool isEnable = false;

    private UIExtraLife uIExtraLife;

    [Inject]
    private void Init(UIExtraLife uIExtraLife)
    {
        this.uIExtraLife = uIExtraLife;
    }

    private void Start()
    {
        isEnable = false;
    }

    private void OnEnable()
    {
        Shield.OnDestroy += Disable;
    }

    private void OnDisable()
    {
        Shield.OnDestroy -= Disable;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            if (isEnable == false)
            {
                isEnable = true;
                container.InstantiatePrefab(shieldPrefab);
                uIExtraLife.gameObject.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                isEnable = false;
                base.OnCollisionEnter2D(collision);
            }

        }

    }

    private void Disable()
    {
        isEnable = false;
    }
}
