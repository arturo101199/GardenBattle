using UnityEngine;

public class InputField : MonoBehaviour
{
    GlobalBlackboard globalBlackboard;

    public void SetGlobalBlackboard(GlobalBlackboard globalBlackboard)
    {
        this.globalBlackboard = globalBlackboard;
    }

    public void OnValueChanged(string value)
    {
        int amount = int.Parse(value);
    }

    public void Test()
    {
        print("Hola");
    }
}