public class EnemyScore : ObjectScore
{
    private EnemyHealth enemyHealth;

    private void OnEnable()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.OnDie += Activate;
    }

    private void OnDisable()
    {
        enemyHealth.OnDie -= Activate;
    }
}