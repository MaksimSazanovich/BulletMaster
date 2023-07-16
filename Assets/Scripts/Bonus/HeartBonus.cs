using UnityEngine;

public class HeartBonus : BaseBonus
{
    [SerializeField] private int healValue;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                playerHealth.Heal(healValue);
                Destroy(gameObject);
            }
            else
                base.OnCollisionEnter2D(collision);
        }

    }
}