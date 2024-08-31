using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

    public class PlayerController : MonoBehaviour
    {

        public LayerMask groundMask;
        public Material skybox;



        private ICharacterMovement character;

        private AudioController audioController ;


        // Start is called before the first frame update
        void Start()
        {
            character = new Character.Character(GetComponent<CharacterController>(), groundMask);
            audioController = GetComponentInChildren<AudioController>();
        }

        // Update is called once per frame
        float temp = 0;
        void Update()
        {
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (movementDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    
                    //aumentar la velocidad del personaje por intervalos hasta un maximo de 2

                    if (temp < 2)
                    {
                        temp += Time.deltaTime;
                    }
                    else
                    {
                        temp = 2;
                    }
                    character.Move(movementDirection * temp);
                }
                else
                {
                    if (temp > 1)
                    {
                        temp -= Time.deltaTime;
                    }
                    else
                    {
                        temp = 1;
                    }
                    character.Move(movementDirection * temp);
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                character.Jump();
            }

            // Ground character
            character.GroundCharacter();

        }

        private void OnTriggerEnter(Collider other)
        {

            
            if( other.CompareTag("cancion"))
            {
                //cambio el color del skybox
                RenderSettings.skybox = skybox;
                

                //Reproducir o detener la cancion

                var actcancion = GetComponentInChildren<AudioSource>();
                if (actcancion.isPlaying)
                {
                    actcancion.Stop();
                }
                else
                {
                    actcancion.Play();
                }
            }
                
            if (other.CompareTag("ActvTime"))
            {
                ControladorTimeline controlador = other.GetComponent<ControladorTimeline>();
                controlador.PlayTimeline();
            }

            if(other.CompareTag("Arena"))
            {
                audioController.groundType = 0;
            }
            if (other.CompareTag("Pasto"))
            {
                audioController.groundType = 1;
            }
            if (other.CompareTag("Grava"))
            {
                audioController.groundType = 2;
            }
            if (other.CompareTag("Agua"))
            {
                audioController.groundType = 3;
            }
        }




    }


