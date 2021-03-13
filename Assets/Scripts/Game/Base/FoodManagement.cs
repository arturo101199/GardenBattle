using System.Collections.Generic;
using UnityEngine;

public class FoodManagement : MonoBehaviour
{
    Stack<Vector3> sortedFoodPositions = new Stack<Vector3>();
    bool isSet = false;

    public void SetFood(List<Vector3> foodPositions)
    {
        ListUtilites.SortFromDistanceToAnObject(foodPositions, transform.position);
        foodPositions.Reverse();
        foreach (Vector3 position in foodPositions)
        {
            AddFood(position);
        }
        isSet = true;
        AntGlobalBlackboard.Instance.AddKeyValue("foodManagement", this);
    }

    public Vector3 GetFood()
    {
        if(sortedFoodPositions.Count > 0)
            return sortedFoodPositions.Pop();
        return Vector3.zero;
    }

    public void AddFood(Vector3 position)
    {
        sortedFoodPositions.Push(position);
    }

    private void OnDrawGizmos()
    {
        if (isSet)
        {
            Stack<Vector3> backUpStack = new Stack<Vector3>(new Stack<Vector3>(sortedFoodPositions));
            for (int i = 0; i < sortedFoodPositions.Count; i++)
            {
                float t = i / (float)(sortedFoodPositions.Count-1);
                Gizmos.color = Color.Lerp(Color.red, Color.cyan, t);
                Gizmos.DrawSphere(backUpStack.Pop(), 0.3f);
            }
        }
    }
}