public class ShieldBonusScore : BaseBonusScore
{
    protected override void Start()
    {
        bonus = GetComponent<ShieldBonus>();
        base.Start();
    }
}