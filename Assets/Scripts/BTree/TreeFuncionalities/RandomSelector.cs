using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : BNode
{
    [SerializeField] List<RandomNode> randomNodes = new List<RandomNode>();
    NodeState currentState;
    RandomNode currentNode;
    List<RandomNode> nodes = new List<RandomNode>();
    float randSum = 0f;
    float totalSum = 0f;

    public override NodeState Evaluate()
    {
        if(currentState == NodeState.RUNNING)
        {
            int index = randomNodes.IndexOf(currentNode);
            currentState = randomNodes[index].node.Evaluate();
            if(currentState == NodeState.FAIL)
            {
                nodes.Remove(currentNode);
                return SelectRandom();
            }
            return currentState;
        }

        FillNodesList();
        return SelectRandom();

    }

    void FillNodesList()
    {
        foreach (RandomNode node in randomNodes)
        {
            nodes.Add(node);
        }
    }

    NodeState SelectRandom()
    {
        totalSum = 0f;
        foreach(RandomNode node in nodes)
        {
            totalSum += node.percentage;
        }
        foreach(RandomNode node in nodes)
        {
            float rand = Random.Range(0, totalSum);
            currentNode = node;
            randSum = currentNode.percentage;

            if (rand <= randSum)
            {
                currentState = currentNode.node.Evaluate();
                if (currentState == NodeState.FAIL)
                {
                    nodes.Remove(node);
                    return SelectRandom();
                }
                return currentState;
            }
            totalSum -= currentNode.percentage;
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        randSum = 0f;
        totalSum = 0f;
        currentState = NodeState.FAIL;
        nodes.Clear();
    }

}