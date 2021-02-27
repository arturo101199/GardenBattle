using UnityEngine;

[System.Serializable]
public class Transition
{
    [SerializeField] State targetNode;
    [SerializeField] Condition condition;

    public State TargetNode { get => targetNode; }

    public bool isTriggered()
    {
        if(condition != null)
            return condition.EvaluateCondition();
        return false;
    }
}