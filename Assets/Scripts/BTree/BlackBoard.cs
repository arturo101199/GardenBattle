using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    Dictionary<string, object> blackBoard = new Dictionary<string, object>();

    public void AddKeyValue(string key, object value)
    {
        blackBoard.Add(key, value);
    }

    public void UpdateValue(string key, object value)
    {
        blackBoard[key] = value;
    }

    public object GetValue(string key)
    {
        object value;
        bool found = blackBoard.TryGetValue(key, out value);
        if (!found)
        {
            Debug.LogError("Not found " + key);
        }
        return value;
    }
}
