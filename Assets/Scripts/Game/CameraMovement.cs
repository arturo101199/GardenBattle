using UnityEngine;
using Cinemachine;
using System;

public class CameraMovement : MonoBehaviour
{
    Vector3 mousePos;
    int screenHeight;
    int screenWidth;
    CinemachineVirtualCamera camera;

    [SerializeField] float terrainSize = 120f;
    [SerializeField] float terrainLimitOffset = 20f;
    
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] int pixelMovementOffset = 20;

    [SerializeField] float zoomSpeed = 20f;
    [SerializeField] float minFov = 25f;
    [SerializeField] float maxFov = 40f;

    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        getScreenSize();
        calculateMovement();
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

        if (mousePos.x >= screenWidth - pixelMovementOffset)
            movement.x = 1;
        else if (mousePos.x <= pixelMovementOffset)
            movement.x = -1;
        if (mousePos.y >= screenHeight - pixelMovementOffset)
            movement.z = 1;
        else if (mousePos.y <= pixelMovementOffset)
            movement.z = -1;

        Vector3 newPos = transform.localPosition + movement * moveSpeed * Time.deltaTime;
        float halfTerrain = terrainSize / 2;
        newPos.x = Mathf.Clamp(newPos.x, terrainLimitOffset - halfTerrain, halfTerrain - terrainLimitOffset);
        newPos.z = Mathf.Clamp(newPos.z, -terrainLimitOffset * 1.5f - halfTerrain, halfTerrain - terrainLimitOffset * 3f);
        transform.localPosition = newPos;
    }

    private void calculateZoom()
    {
        float wheelAxis = Input.GetAxis("Mouse ScrollWheel");
        camera.m_Lens.FieldOfView = Mathf.Clamp(camera.m_Lens.FieldOfView - wheelAxis * zoomSpeed, minFov, maxFov);
    }
}