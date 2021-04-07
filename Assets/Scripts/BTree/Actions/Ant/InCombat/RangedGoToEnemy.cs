using UnityEngine;

public class RangedGoToEnemy : GoToEnemy
{
    protected override bool imNearTheEnemy()
    {
        return Vector3.Distance(transform.position, enemy.position) <= stoppingDistance;
    }
}