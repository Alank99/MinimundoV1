using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;


namespace Character
{
    public class Character : ICharacterMovement
    {
        private Vector3 playerVelocity;
        private float playerSpeed = 4.0f;
        private float jumpHeight = 3f;
        private float gravityValue = -9.81f;


        //animacion para el personaje

        private readonly AnimatorController _animator;

        //nombre de los parametros de la animacion
        private const string FrontWalkAnimation = "Forward";
        private const string SideWalkAnimation = "side";
        private const string RandomAnimation = "Jump";


        //Hashes de las animaciones

        private readonly int _randomAnimationHash = Animator.StringToHash(name:"(JUMP01)");


        public CharacterController controller { get; set; }
        public LayerMask groundMask; // Assign in Inspector to the layers that are considered ground

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="characterController"></param>
        public Character(CharacterController characterController, LayerMask groundLayerMask)
        {
            controller = characterController;
            groundMask = groundLayerMask;

            //Nuevo animador
            _animator = new AnimatorController();
            _animator.Animator = controller.GetComponentInChildren<Animator>();
        }

        protected Character()
        {
        }

        public void Move(Vector3 direction)
        {

            var localDirection =controller.transform.TransformDirection(direction);

            controller.Move(localDirection * Time.deltaTime * playerSpeed);

            controller.transform.Rotate(Vector3.up,direction.x* 2,Space.World);
            // Rotates character to the movment direction
           //if (direction != Vector3.zero)
            //{
             //   controller.transform.forward = direction;
           // }


            _animator.SetFloat(FrontWalkAnimation, direction.z);
            _animator.SetFloat(SideWalkAnimation, direction.x);

        }

        public void Jump()
        {   
            // If is already jumping, return
            if (!IsGrounded() || playerVelocity.y > 0)
                return;

            // Moves the character in the given direction
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            controller.Move(playerVelocity * Time.deltaTime);


            _animator.SetBool("Jump", true);

        }

        
        public void GroundCharacter()
        {
            if (IsGrounded() && playerVelocity.y < 0)
            {
                // Moves the player down
                playerVelocity.y = 0f;
                return;
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            
        }
        
        public bool IsGrounded()
        {
            // This offers innacurate results
            // return controller.isGrounded;

            // Implement a raycast to check if the character is grounded
            // Draw a raycast from the player's position to the ground to check the distance
            Debug.DrawRay(controller.transform.position, Vector3.down * 0.15f, Color.red);

            // Check if the raycast hits the ground layer
            return Physics.Raycast(controller.transform.position, Vector3.down, out RaycastHit hit, 0.15f, groundMask);
            
        }
    }
}
