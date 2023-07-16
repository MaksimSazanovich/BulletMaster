public abstract class BaseBonusScore : ObjectScore
{
    protected BaseBonus bonus;

    protected virtual void Start()
    {
        bonus.OnPicked += Activate;
    }

    private void OnDisable()
    {
        bonus.OnPicked -= Activate;
    }
}