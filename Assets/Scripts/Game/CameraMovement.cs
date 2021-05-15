using UnityEngine;
using Cinemachine;
using System;

public class CameraMovement : MonoBehaviour
{
    Vector3 mousePos;
    int screenHeight;
    int screenWidth;
    float lastPosX;
    CinemachineVirtualCamera gameCamera;

    [SerializeField] Transform rotationPivot = null;

    [Header("Terrain characteristics")]

    [SerializeField] float terrainSize = 120f;
    [SerializeField] float terrainLimitOffset = 20f;

    [Header("Movement characteristics")]

    [SerializeField] float moveSpeed = 20f;
    [SerializeField] int pixelMovementOffset = 20;

    [Header("Rotation characteristics")]

    [SerializeField] float keyRotationSpeed = 20f;
    [SerializeField] float mouseRotationSpeed = 5f;

    [Header("Zoom characteristics")]

    [SerializeField] float zoomSpeed = 20f;
    [SerializeField] float minFov = 25f;
    [SerializeField] float maxFov = 40f;

    private void Awake()
    {
        gameCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        getScreenSize();
        calculateMovement();
        calculateRotation();
        calculateZoom();
    }


    void getScreenSize()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    void calculateMovement()
    {
        mousePos = Input.mousePosition;
        Vector3 movement = Vector3.zero;

        if (mousePos.x >= screenWidth - pixelMovementOffset || Input.GetKey(KeyCode.D))
            movement.x = 1;
        else if (mousePos.x <= pixelMovementOffset || Input.GetKey(KeyCode.A))
            movement.x = -1;
        if (mousePos.y >= screenHeight - pixelMovementOffset || Input.GetKey(KeyCode.W))
            movement.z = 1;
        else if (mousePos.y <= pixelMovementOffset || Input.GetKey(KeyCode.S))
            movement.z = -1;

        Vector3 newPos = transform.localPosition + movement * moveSpeed * Time.unscaledDeltaTime;
        float halfTerrain = terrainSize / 2;
        newPos.x = Mathf.Clamp(newPos.x, terrainLimitOffset - halfTerrain, halfTerrain - terrainLimitOffset);
        newPos.z = Mathf.Clamp(newPos.z, -terrainLimitOffset * 1.5f - halfTerrain, halfTerrain - terrainLimitOffset * 3f);
        transform.localPosition = newPos;
    }

    void calculateRotation()
    {
        float posX = Input.mousePosition.x;
        float deltaPosx = lastPosX - posX;
        if (Input.GetKey(KeyCode.Q))
        {
            rotationPivot.Rotate(0f, keyRotationSpeed * Time.unscaledDeltaTime, 0f);
        }
        else if(Input.GetMouseButton(1) && deltaPosx < 0)
        {
            rotationPivot.Rotate(0f, -mouseRotationSpeed * deltaPosx * Time.unscaledDeltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotationPivot.Rotate(0f, -keyRotationSpeed * Time.unscaledDeltaTime, 0f);
        }
        else if (Input.GetMouseButton(1) && deltaPosx > 0)
        {
            rotationPivot.Rotate(0f, -mouseRotationSpeed * deltaPosx * Time.unscaledDeltaTime, 0f);
        }
        lastPosX = Input.mousePosition.x;
    }

    private void calculateZoom()
    {
        float wheelAxis = Input.GetAxis("Mouse ScrollWheel");
        gameCamera.m_Lens.FieldOfView = Mathf.Clamp(gameCamera.m_Lens.FieldOfView - wheelAxis * zoomSpeed * Time.unscaledDeltaTime, minFov, maxFov);
    }
}