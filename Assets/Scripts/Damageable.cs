using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    Blackboard blackboard;

    private void Awake()
    {
        blackboard = GetComponent<Blackboard>();
    }

    public void GetDamage(float damage)
    {
        blackboard.UpdateValue("health", (float)blackboard.GetValue("health") - damage);
    }
}
