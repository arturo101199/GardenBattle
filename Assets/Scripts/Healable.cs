using UnityEngine;

public class Healable : MonoBehaviour, IHealable
{
    Blackboard blackboard;
    [SerializeField] float maxHealth;

    private void Awake()
    {
        blackboard = GetComponent<Blackboard>();
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