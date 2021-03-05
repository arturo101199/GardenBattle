using UnityEngine;

public class AntBase : MonoBehaviour, IDamageable
{
    int totalNumberOfAnts;
    AntGlobalBlackboard antGlobalBlackboard;
    [SerializeField] float health;

    void Start()
    {
        antGlobalBlackboard = AntGlobalBlackboard.Instance;
        totalNumberOfAnts = (int)antGlobalBlackboard.GetValue("totalNumberOfAnts");
    }

    public void GetDamage(float damageValue)
    {
        health -= damageValue;
    }

}