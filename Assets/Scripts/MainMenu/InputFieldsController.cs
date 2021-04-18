using UnityEngine;

public class InputFieldsController : MonoBehaviour
{
    InputField[] inputFields;
    int currentIndex = 0;

    public void SetInputFields(InputField[] inputFields)
    {
        this.inputFields = inputFields;
        inputFields[0].gameObject.SetActive(true);
    }

    public void ChangeInputField(int dir)
    {
        inputFields[currentIndex].gameObject.SetActive(false);
        currentIndex += dir;
        if(currentIndex < 0)
        {
            currentIndex = inputFields.Length - 1;
        }
        else if(currentIndex > inputFields.Length - 1)
        {
            currentIndex = 0;
        }
        inputFields[currentIndex].gameObject.SetActive(true);
    }
}
