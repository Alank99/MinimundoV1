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


    
    // Start is called before the first frame update
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
