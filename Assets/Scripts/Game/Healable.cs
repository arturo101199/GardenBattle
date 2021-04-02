using UnityEngine;

public class Healable : MonoBehaviour, IHealable
{
    float maxHealth = 100f;

    Blackboard blackboard;
    GlobalBlackboard globalBlackboard;

    private void Awake()
    {
        blackboard = GetComponent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        maxHealth = (float)globalBlackboard.GetValue("maxHealth");
    }

    public void Heal(float value)
    {
        float health = (float)blackboard.GetValue("health");
        if(health < maxHealth)
        {
            float newHealth = Mathf.Clamp(health + value, 0, maxHealth);
            blackboard.UpdateValue("health", newHealth);

        }
    }
}