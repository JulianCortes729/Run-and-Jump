using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // El personaje al que la cámara seguirá
    public float smoothSpeed = 0.125f;  // Velocidad de suavizado de la cámara
    public Vector3 offset;  // Desplazamiento de la cámara respecto al personaje

    public float minY;  // Altura mínima de la cámara (para no acercarse demasiado)
    public float maxY;  // Altura máxima de la cámara (para no alejarse demasiado)

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        // Restringir la posición de la cámara en el eje Y
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
