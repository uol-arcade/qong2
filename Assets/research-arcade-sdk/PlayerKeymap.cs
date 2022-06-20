using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResearchArcade
{
    /// <summary>
    /// Represents a list of bindings for a particular player.
    /// </summary>
    public class PlayerKeymap
    {
        /// <summary>
        /// The A button for this player
        /// </summary>
        public Binding A = default;

        /// <summary>
        /// The B button for this player
        /// </summary>
        public Binding B = default;

        /// <summary>
        /// The C button for this player
        /// </summary>
        public Binding C = default;

        /// <summary>
        /// The D button for this player
        /// </summary>
        public Binding D = default;

        /// <summary>
        /// The E button for this player
        /// </summary>
        public Binding E = default;

        /// <summary>
        /// The F button for this player
        /// </summary>
        public Binding F = default;


        //-------------


        /// <summary>
        /// The button pressed when the joystick is moved up
        /// </summary>
        public Binding JoyUp = default;

        /// <summary>
        /// The button pressed when the joystick is moved down
        /// </summary>
        public Binding JoyDown = default;

        /// <summary>
        /// The button pressed when the joystick is moved left
        /// </summary>
        public Binding JoyLeft = default;

        /// <summary>
        /// The button pressed when the joystick is moved right
        /// </summary>
        public Binding JoyRight = default;


        //-------------
        

        /// <summary>
        /// The start button for this player.
        /// </summary>
        public Binding Start = default;
    }
}