public class ImDeadCondition : Condition
{
    bool dead = false;

    private void Awake()
    {
        GetComponentInParent<Damageable>().DeathEvent += die;
    }

    public override bool EvaluateCondition()
    {
        return dead;
    }

    void die()
    {
        dead = true;
        GetComponentInParent<Damageable>().DeathEvent -= die;
    }
}
