public class ImDeadCondition : Condition
{
    bool dead = false;
    Damageable damageable;

    private void Awake()
    {
        damageable = GetComponentInParent<Damageable>();
        damageable.DeathEvent += die;
    }

    public override bool EvaluateCondition()
    {
        return dead;
    }

    void die()
    {
        dead = true;
        damageable.DeathEvent -= die;
    }
}
