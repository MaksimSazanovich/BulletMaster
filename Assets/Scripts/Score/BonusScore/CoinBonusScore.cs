public class CoinBonusScore : BaseBonusScore
{
    protected override void Start()
    {
        bonus = GetComponent<CoinBonus>();
        base.Start();
    }
}