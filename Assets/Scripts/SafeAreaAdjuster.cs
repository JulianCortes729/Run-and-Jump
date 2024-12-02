using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaAdjuster : MonoBehaviour
{
    public Camera mainCamera; // Arrastra la cámara principal aquí
    private Vector3 originalCameraPosition; // Guardar la posición original de la cámara
    private Rect lastSafeArea;

    void Start()
    {
        // Almacenar la posición inicial de la cámara
        if (mainCamera != null)
        {
            originalCameraPosition = mainCamera.transform.position;
        }

        ApplySafeAreaAdjustment();
    }

    void Update(){
        if (Screen.safeArea != lastSafeArea)
        {
            lastSafeArea = Screen.safeArea;
            ApplySafeAreaAdjustment();
        }
    }

    void ApplySafeAreaAdjustment()
    {
        Rect safeArea = Screen.safeArea;

        if (mainCamera != null)
        {
            // Calcular cuánto espacio está ocupado por la UI (fuera del área segura)
            float offsetY = safeArea.y / Screen.height;

            // Ajustar la posición vertical de la cámara, partiendo de su posición original
            mainCamera.transform.position = new Vector3(
                originalCameraPosition.x,
                originalCameraPosition.y + offsetY,
                originalCameraPosition.z
            );
        }
    }
}

