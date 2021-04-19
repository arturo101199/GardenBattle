using System.Collections;
using UnityEngine;

public class CharactersPicker : MonoBehaviour
{
    [SerializeField] InputFieldsController inputFieldsController;
    [SerializeField] Transform cameraPivot;
    [SerializeField] float rotationSpeed = 50f;

    float angleToRotate;

    bool isRotating;
    Quaternion lookRotation;

    private void Start()
    {
        angleToRotate = 360f / inputFieldsController.NumberOfInputFields;
    }

    private void Update()
    {
        if (isRotating)
        {
            if(cameraPivot.rotation == lookRotation)
            {
                cameraPivot.rotation = Quaternion.Euler(lookRotation.eulerAngles.x, lookRotation.eulerAngles.y, lookRotation.eulerAngles.z); //just to ensure that the final rotation is exacly the same than de lookRotation
                isRotating = false;
                return;
            }
            cameraPivot.transform.rotation = Quaternion.RotateTowards(cameraPivot.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if(horizontal != 0)
            {
                ChangeCharacter(horizontal);
            }
        }
    }

    public void ChangeCharacter(float horizontal)
    {
        if (isRotating) return;
        int direction = (int)horizontal;
        inputFieldsController.ChangeInputField(direction);
        isRotating = true;
        lookRotation = Quaternion.AngleAxis(-angleToRotate * direction, Vector3.up) * cameraPivot.transform.rotation;
    }

    public void ReachNextRotation()
    {
        if (lookRotation != null)
        {
            cameraPivot.rotation = Quaternion.Euler(lookRotation.eulerAngles.x, lookRotation.eulerAngles.y, lookRotation.eulerAngles.z);
        }
    }
}