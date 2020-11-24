namespace State
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "Status",menuName = "CreateStatus")]
    public class BaseStatus : ScriptableObject
    {
        [System.Serializable]public struct ImageCharater
        {
            public Sprite iconCharater;
            public Sprite[] allSkills;
        }

        public Status baseStatusCharater;
        public SkillStatus skillStatus;
        public ImageCharater imageCharater;
    }
}
