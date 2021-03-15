using UnityEngine;

public class Base : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    BaseManager baseManager;

    private void Start()
    {
        baseManager = FindObjectOfType<BaseManager>();
        baseManager.AddBase(this);
    }

    public void GetDamage(float damageValue)
    {
        health -= damageValue;
        if(health < 0f)
        {
            baseManager.RemoveBase(this);
        }
    }
}
