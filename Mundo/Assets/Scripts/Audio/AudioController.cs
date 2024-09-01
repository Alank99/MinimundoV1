using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> ArenaStep;
    public List<AudioClip> PastoStep;
    public List<AudioClip> GravaStep;
    public List<AudioClip> WaterStep;

    public AudioSource audioSource_step;




    public int groundType = 0;


    
    // Este método se encarga de reproducir el audio correspondiente al tipo de terreno en el que se encuentra el jugador y al tipo de animación que está realizando
    // Siendo que 1 es caminar, 2 es correr y 3 es saltar
    public void PlayAudio(int tipoAnimacion)
    {
        switch (groundType)
        {
            case 0:
                if(tipoAnimacion == 1)
                    audioSource_step.PlayOneShot(ArenaStep[0]);
                else if(tipoAnimacion == 2)
                    audioSource_step.PlayOneShot(ArenaStep[1]);
                else
                    audioSource_step.PlayOneShot(ArenaStep[2]);
                break;
            case 1:
                if(tipoAnimacion == 1)
                    audioSource_step.PlayOneShot(PastoStep[0]);
                else if(tipoAnimacion == 2)
                    audioSource_step.PlayOneShot(PastoStep[1]);
                else
                    audioSource_step.PlayOneShot(PastoStep[2]);
                break;
            case 2:
                if(tipoAnimacion == 1)
                    audioSource_step.PlayOneShot(GravaStep[0]);
                else if(tipoAnimacion == 2)
                    audioSource_step.PlayOneShot(GravaStep[1]);
                else
                    audioSource_step.PlayOneShot(GravaStep[2]);
                break;
            case 3:
                if(tipoAnimacion == 1)
                    audioSource_step.PlayOneShot(WaterStep[0]);
                else if(tipoAnimacion == 2)
                    audioSource_step.PlayOneShot(WaterStep[1]);
                else
                    audioSource_step.PlayOneShot(WaterStep[2]);
                break;
        }
    }


}
