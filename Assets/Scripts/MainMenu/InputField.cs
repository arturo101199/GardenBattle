using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{
    GlobalBlackboard globalBlackboard;
    [SerializeField] TMP_InputField field = null;

    public void SetGlobalBlackboard(GlobalBlackboard globalBlackboard)
    {
        this.globalBlackboard = globalBlackboard;
    }

    public void OnValueChanged(string value)
    {
        if (value == "")
            globalBlackboard.UpdateValue("totalNumberOfCharacters", 0);
        else
        {
            int amount = int.Parse(value);
            amount = Mathf.Clamp(amount, 0, 100);
            field.text = amount.ToString();
            globalBlackboard.UpdateValue("totalNumberOfCharacters", amount);
        }
    }

    private void OnEnable()
    {
        field.Select();
    }
}