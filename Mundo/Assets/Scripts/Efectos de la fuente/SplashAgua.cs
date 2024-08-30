using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAgua : MonoBehaviour
{

    public GameObject gota;
    public int limiteX, limiteZ;
    public int cantidadGotas = 10;

    public float velocidad = 10f;  // Velocidad del movimiento
    public float alturaMaxima = 10f;  // Altura máxima del tiro parabólico

    List<Agua> gotas = new List<Agua>();

    Vector3 origen;

    // Start is called before the first frame update
    void Start()
    {
        gotas = new List<Agua>();
        origen = gameObject.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        //instanciar de forma aleatoria las gotas relativas a la fuente
        if (gotas.Count < cantidadGotas)
        {
            for (int i = gotas.Count ; i < cantidadGotas; i++)
            {
                GameObject go = Instantiate(gota, gameObject.transform.position, Quaternion.identity);
                Agua a = go.GetComponent<Agua>();
                a.destino = new Vector3(origen.x + Random.Range(-limiteX, limiteX), 0, origen.z + Random.Range(-limiteZ, limiteZ));
                a.velocidad = velocidad;
                a.alturaMaxima = alturaMaxima;
                gotas.Add(a);
            }
        }

        
        for (int i = gotas.Count - 1; i >= 0; i--)
        {
            Agua a = gotas[i];
            if(a.transform.position.y <= 0)
            {
                Destroy(a.gameObject);
                gotas.RemoveAt(i);
            }
        }

    }


}
