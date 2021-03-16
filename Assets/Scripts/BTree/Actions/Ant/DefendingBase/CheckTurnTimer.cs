using UnityEngine;

public class CheckTurnTimer : BNode
{
    float timer = 0f;
    float turnTime = 30f;
    bool isChangingTurn = false;

    public override NodeState Evaluate()
    {
        if(timer >= turnTime)
        {
            if(isChangingTurn == false)
            {
                AntGlobalBlackboard.Instance.UpdateValue("antsDefending", (int)AntGlobalBlackboard.Instance.GetValue("antsDefending") - 1);
                isChangingTurn = true;
            }
            else
            {
                if(timer >= turnTime + 1)
                {
                    return NodeState.SUCCESS;
                }
            }
        }
        timer += Time.deltaTime;
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        timer = 0f;
        isChangingTurn = false;
    }
}