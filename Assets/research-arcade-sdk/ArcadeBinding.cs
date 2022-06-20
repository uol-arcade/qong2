using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResearchArcade
{
    /// <summary>
    /// Represents a single arcade mapping/binding.
    /// </summary>
    public class Binding
    {
        private KeyCode keycode;

        /// <summary>
        /// Uses GetKey to check if this binding is held down.
        /// </summary>
        /// <returns></returns>
        public bool HeldDown => Input.GetKey(this.keycode);

        /// <summary>
        /// Uses GetKeyDown to check if this binding has just been pressed.
        /// </summary>
        /// <returns></returns>
        public bool Down     => Input.GetKeyDown(this.keycode);

        /// <summary>
        /// Uses GetKeyUp to check if this binding has just been released.
        /// </summary>
        /// <returns></returns>
        public bool Up       => Input.GetKeyUp(this.keycode);

        /// <summary>
        /// Constructs a new binding with a given KeyCode. 
        /// </summary>
        /// <param name="keycode"></param>
        public Binding(KeyCode keycode)
        {
            this.keycode = keycode;
        }
    }
}