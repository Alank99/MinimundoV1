using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script que se encarga de mover el objeto de forma tiro parabólico hacia un punto objetivo.
//Teniendo en cuenta la altura máxima que alcanzará el objeto y si limite en el eje Z y X

public class Agua : MonoBehaviour
{

public Vector3 destino;  // Punto objetivo en el espacio (X, Y, Z)
    public float velocidad = 10f;  // Velocidad del movimiento
    public float alturaMaxima = 10f;  // Altura máxima del tiro parabólico

    private Vector3 puntoInicio;
    private float distanciaTotal;
    private float distanciaRecorrida;

    void Start()
    {
        puntoInicio = transform.position;
        distanciaTotal = Vector3.Distance(puntoInicio, destino);
    }

    void Update()
    {
        // Calcular la distancia recorrida en esta actualización
        distanciaRecorrida += velocidad * Time.deltaTime;

        // Calcular el progreso como fracción de la distancia total
        float progreso = distanciaRecorrida / distanciaTotal;

        if (progreso > 1f)
        {
            progreso = 1f;
        }

        // Interpolación lineal para X y Z
        float x = Mathf.Lerp(puntoInicio.x, destino.x, progreso);
        float z = Mathf.Lerp(puntoInicio.z, destino.z, progreso);

        // Interpolación cuadrática para Y (altura parabólica)
        float y = Mathf.Lerp(puntoInicio.y, destino.y, progreso) + alturaMaxima * (1f - Mathf.Pow(2f * progreso - 1f, 2f));

        // Actualizar posición del objeto
        transform.position = new Vector3(x, y, z);

    }


}
