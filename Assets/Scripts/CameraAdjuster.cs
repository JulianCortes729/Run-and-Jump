using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    // Referencia a la cámara ortográfica
    private Camera cam;

    // Valor base del tamaño ortográfico en una relación de aspecto específica (por ejemplo, 16:9)
    public float baseOrthographicSize = 5f;
    public float aspectRatioReference = 16f / 9f; // Relación de aspecto de referencia

    void Start()
    {
        // Obtener la cámara adjunta al script
        cam = GetComponent<Camera>();

        // Ajustar el tamaño ortográfico según la relación de aspecto actual
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        // Obtener el área segura del dispositivo
        Rect safeArea = Screen.safeArea;

        // Calcular la relación de aspecto del área segura
        float safeAreaAspectRatio = (safeArea.width / Screen.height);

        // Calcular el nuevo tamaño ortográfico basado en la relación de aspecto
        cam.orthographicSize = baseOrthographicSize * (aspectRatioReference / safeAreaAspectRatio);

        // Ajustar la posición de la cámara para centrarla en el área segura
        cam.transform.position = new Vector3(cam.transform.position.x, safeArea.y / Screen.height * baseOrthographicSize, cam.transform.position.z);
    }
}
