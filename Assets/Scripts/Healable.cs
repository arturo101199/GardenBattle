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
       blackboard.UpdateValue("health", (float)blackboard.GetValue("health") + value);
    }
}