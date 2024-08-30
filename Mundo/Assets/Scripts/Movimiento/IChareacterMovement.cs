using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface ICharacterMovement
    {   
        public CharacterController controller { get; set; }

        /// <summary>
        /// Moves the character in the given direction
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector3 direction);

        /// <summary>
        /// Character jumps
        /// </summary>
        /// <returns></returns>
        public void Jump();

        /// <summary>
        /// Character is grounded
        /// </summary>
        public void GroundCharacter();

        /// <summary>
        /// Is my character grounded?
        /// </summary>
        /// <returns></returns>
        public bool IsGrounded();
    }

}