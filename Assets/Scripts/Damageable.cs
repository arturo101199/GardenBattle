using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    Blackboard blackboard;
    private CharacterType characterType;
    public CharacterType CharacterType { get => characterType; }

    private void Awake()
    {
        blackboard = GetComponent<Blackboard>();
        characterType = (CharacterType)blackboard.GetValue("characterType");
    }

    public void GetDamage(float damage)
    {
        blackboard.UpdateValue("health", (float)blackboard.GetValue("health") - damage);
    }
}
