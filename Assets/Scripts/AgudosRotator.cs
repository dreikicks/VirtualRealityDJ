using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AgudosRotator : MonoBehaviour
{
    public float speed = 10f; // Velocidad de rotación del cilindro
    public XRController controller; // Controlador de Oculus Quest 2

    void Update()
    {
        if (controller)
        {
            float rotation = controller.transform.rotation.eulerAngles.y; // Obtiene la rotación del controlador en el eje Y
            transform.rotation = Quaternion.Euler(0f, rotation, 0f); // Aplica la rotación del controlador al objeto Cilindro en el eje Y
        }
        else
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime); // Rota el objeto Cilindro en torno al eje Y si no hay controlador agarrando el objeto
        }
    }
}

