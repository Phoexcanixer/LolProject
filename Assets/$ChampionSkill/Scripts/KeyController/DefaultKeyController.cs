namespace KeyControl
{
    using UnityEngine;
    public static class DefaultKeyController
    {
        // Keyboard //
        public static KeyCode[] allKeySkills = new KeyCode[4] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R };
        public static KeyCode[] allBasicCommands = new KeyCode[2] { KeyCode.A, KeyCode.S };
        public static KeyCode[] allKeySpells = new KeyCode[2] { KeyCode.D, KeyCode.F };
        public static KeyCode keyRecalll = KeyCode.B;

        // Mouse //
        public static KeyCode move = KeyCode.Mouse1;
    }
}
