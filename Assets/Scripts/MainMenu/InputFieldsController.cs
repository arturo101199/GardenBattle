using UnityEngine;

public class InputFieldsController : MonoBehaviour
{
    InputField[] inputFields;
    int currentIndex = 0;
    int numberOfInputFields;

    public int NumberOfInputFields { get => numberOfInputFields; }

    public void SetInputFields(InputField[] inputFields)
    {
        this.inputFields = inputFields;
        inputFields[0].gameObject.SetActive(true);
        numberOfInputFields = inputFields.Length;
    }

    public void ChangeInputField(int dir)
    {
        inputFields[currentIndex].gameObject.SetActive(false);
        currentIndex += dir;
        if(currentIndex < 0)
        {
            currentIndex = numberOfInputFields - 1;
        }
        else if(currentIndex > numberOfInputFields - 1)
        {
            currentIndex = 0;
        }
        inputFields[currentIndex].gameObject.SetActive(true);
    }
}
