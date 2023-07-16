public class BonusScore : ObjectScore
{
    private CoinBonus coinBonus;

    private void Start()
    {
        coinBonus = GetComponent<CoinBonus>();
    }

    private void OnEnable()
    {
        coinBonus.OnPicked += Activate;
    }

    private void OnDisable()
    {
        coinBonus.OnPicked -= Activate;
    }
}