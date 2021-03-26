using UnityEngine;

public class CheckIfImHealed : BNode
{
    [SerializeField] bool desiredBool = true;

    GlobalBlackboard globalBlackboard;
    float maxHealth = 100f;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        maxHealth = (float)globalBlackboard.GetValue("maxHealth");
    }

    public override NodeState Evaluate()
    {
        if(((float)blackboard.GetValue("health") >= maxHealth) == desiredBool)
            return NodeState.SUCCESS;
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}