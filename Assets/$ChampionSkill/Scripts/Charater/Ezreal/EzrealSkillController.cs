namespace Charater.Ezreal
{
    using KeyControl;
    using UnityEngine;
    public class EzrealSkillController : BaseSkillController
    {
        public override void SkillFirst()
        {
            Debug.Log($"1");
        }

        public override void SkillSecond()
        {
            Debug.Log($"2");
        }

        public override void SkillThird()
        {
            Debug.Log($"3");
        }

        public override void SkillUltimate()
        {
            Debug.Log($"4");
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[0]))
                SkillFirst();
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[1]))
                SkillSecond();            
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[2]))
                SkillThird();            
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[3]))
                SkillUltimate();
        }
    }
}
