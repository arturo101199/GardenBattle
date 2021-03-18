using UnityEngine;

public class WaitTimer : BNode
{
    float timer = 0f;
    [SerializeField] float time = 1f;

    public override NodeState Evaluate()
    {
        if(timer >= time)
        {
            return NodeState.SUCCESS;
        }
        timer += Time.deltaTime;
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        timer = 0f;
    }
}
