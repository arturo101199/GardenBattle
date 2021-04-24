using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    List<Base> bases = new List<Base>();

    public void AddBase(Base myBase)
    {
        bases.Add(myBase);
    }

    public bool isBaseAlive(Vector3 basePosition)
    {
        foreach (Base myBase in bases)
        {
            if (myBase.transform.position == basePosition)
                return true;
        }
        return false;
    }

    public void RemoveBase(Base myBase)
    {
        bases.Remove(myBase);
    }

    public Vector3 findClosestBase(Vector3 position, Vector3 myBasePosition)
    {
        float minDistance = float.MaxValue;
        Vector3 basePosition = Vector3.zero;
        foreach (Base myBase in bases)
        {
            if (myBase.transform.position == myBasePosition)
                continue;
            float distance = Vector3.Distance(position, myBase.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                basePosition = myBase.transform.position;
            }
        }
        return basePosition;
    }

    public void AddCharacterToBase(IDamageable character, Vector3 myBasePosition)
    {
        foreach (Base myBase in bases)
        {
            if (myBase.transform.position == myBasePosition)
            {
                myBase.AddCharacter(character);
            }
        }
    }

    public void RemoveCharacterFromBase(IDamageable character, Vector3 myBasePosition)
    {
        foreach (Base myBase in bases)
        {
            if (myBase.transform.position == myBasePosition)
                myBase.RemoveCharacter(character);
        }
    }

    public void ResetBaseManager()
    {
        bases.Clear();
    }
}