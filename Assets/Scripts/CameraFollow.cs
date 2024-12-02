using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // El personaje al que la cámara seguirá

    void Update()
    {
        if (target != null){

            // La cámara sigue al jugador solo en el eje X, manteniendo su altura y profundidad originales
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}
