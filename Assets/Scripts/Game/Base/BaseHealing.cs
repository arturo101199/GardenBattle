using System.Collections.Generic;
using UnityEngine;

public class BaseHealing : MonoBehaviour
{
    [SerializeField] float healPerSecond = 10f;

    int myLayer;
    List<IHealable> antsNearBase = new List<IHealable>();

    private void Awake()
    {
        myLayer = gameObject.layer;
    }

    private void Update()
    {
        heal();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == myLayer)
        {
            antsNearBase.Add(other.GetComponent<IHealable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == myLayer)
            antsNearBase.Remove(other.GetComponent<IHealable>());
    }

    void heal()
    {
        foreach (IHealable ant in antsNearBase)
        {
            ant.Heal(healPerSecond * Time.deltaTime);
        }
    }
}
