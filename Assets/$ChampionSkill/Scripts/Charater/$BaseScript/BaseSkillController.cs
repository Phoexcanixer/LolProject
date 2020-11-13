namespace Charater
{
    using System.Collections.Generic;
    using UnityEngine;
    public abstract class BaseSkillController : MonoBehaviour,ISide
    {
        public Transform spawnPointSkill;
        public List<BaseSkill> allEffectSkills;
        public ESidePlayer eSidePlayer { get; set; }

        protected abstract void Update();
        public abstract void SkillPassive();
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
