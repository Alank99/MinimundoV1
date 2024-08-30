using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoTimeline : MonoBehaviour
{
    [SerializeField] public GameObject desactivar;
    [SerializeField] public GameObject activar;

    public void Activar()
    {
        if (desactivar != null)
        {
            desactivar.SetActive(false);
        }
        if (activar != null)
        {
            activar.SetActive(true);
        }
    }
}
