using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomControler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] float ZoomInFOV = 15f;
    [SerializeField] float ZoomOutFOV = 60f;

    private void Start()
    {
        camera.m_Lens.FieldOfView = ZoomOutFOV;
    }

    private void OnDisable()
    {
        camera.m_Lens.FieldOfView = ZoomOutFOV;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            if(camera.m_Lens.FieldOfView == ZoomOutFOV)
            {
                camera.m_Lens.FieldOfView = ZoomInFOV;
            }
            else
            {
                camera.m_Lens.FieldOfView = ZoomOutFOV;
            }
        }
    }
}
