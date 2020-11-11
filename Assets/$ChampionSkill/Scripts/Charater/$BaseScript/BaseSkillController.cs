namespace Charater
{
    using UnityEngine;
    public abstract class BaseSkillController : MonoBehaviour
    {
        protected abstract void Update();
        public abstract void SkillFirst();
        public abstract void SkillSecond();
        public abstract void SkillThird();
        public abstract void SkillUltimate();
        public void SpellFirst()
        {
            
        }
        public void SpellSecond()
        {
            
        }
        public void Recall()
        {
            
        }
    }
}
