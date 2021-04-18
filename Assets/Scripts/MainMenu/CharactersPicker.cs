using UnityEngine;

public class CharactersPicker : MonoBehaviour
{
    [SerializeField] InputFieldsController inputFieldsController;
    [SerializeField] Transform cameraPivot;
    [SerializeField] float rotationSpeed = 50f;

    bool isRotating;
    Quaternion lookRotation;

    private void Update()
    {
        if (isRotating)
        {
            if(cameraPivot.transform.rotation == lookRotation)
            {
                isRotating = false;
                return;
            }
            cameraPivot.transform.rotation = Quaternion.RotateTowards(cameraPivot.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if(horizontal != 0)
            {
                changeCharacter(horizontal);
            }
        }
    }

    void changeCharacter(float horizontal)
    {
        int direction = (int)horizontal;
        inputFieldsController.ChangeInputField(direction);
        isRotating = true;
        lookRotation = Quaternion.AngleAxis(-90f * direction, Vector3.up) * cameraPivot.transform.rotation;
    }
}