using UnityEngine;
using UnityEngine.AI;

public class AntRecollectState : State
{
    float timer = 0f;
    FoodManagement foodManagement;

    public override void OnStateEnter()
    {
        foodManagement = (FoodManagement)(AntGlobalBlackboard.Instance.GetValue("foodManagement"));
        Vector3 currentFood = foodManagement.GetFood();
        GetComponentInParent<NavMeshAgent>().SetDestination(currentFood);
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        if (timer > 5f)
        {
            Vector3 currentFood = foodManagement.GetFood();
            GetComponentInParent<NavMeshAgent>().SetDestination(currentFood);
            timer = 0f;
        }
        timer += Time.deltaTime;
        base.OnStateUpdate();
    }
}