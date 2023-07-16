public class HeartBonusScore : BaseBonusScore
{
    protected override void Start()
    {
        bonus = GetComponent<HeartBonus>();
        base.Start();
    }
}