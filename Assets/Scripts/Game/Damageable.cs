using System;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    Blackboard blackboard;
    public event Action DeathEvent;

    private void Awake()
    {
        blackboard = GetComponent<Blackboard>();
        print(blackboard);
    }

    public void GetDamage(float damage)
    {
        float health = (float)blackboard.GetValue("health") - damage;
        blackboard.UpdateValue("health", health);
        if(health <= 0f)
        {
            DeathEvent?.Invoke();
        }
    }
}