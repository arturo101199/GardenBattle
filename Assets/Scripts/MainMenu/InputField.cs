using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{
    GlobalBlackboard globalBlackboard;
    [SerializeField] TMP_InputField field;

    public void SetGlobalBlackboard(GlobalBlackboard globalBlackboard)
    {
        this.globalBlackboard = globalBlackboard;
    }

    public void OnValueChanged(string value)
    {
        if (value == "") return;
        int amount = int.Parse(value);
        amount = Mathf.Clamp(amount, 0, 100);
        field.text = (amount.ToString());

    }

    public void Test()
    {
        print("Hola");
    }

    private void OnEnable()
    {
        field.Select();
    }
}