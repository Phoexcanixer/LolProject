namespace Charater.Ezreal
{
    using KeyControl;
    using System;
    using UnityEngine;
    public class EzrealSkillController : BaseSkillController
    {
        public static Action callRoutine;
        void Awake() => eSidePlayer = ESidePlayer.RedSide;
        public override void SkillPassive()
        {
            Debug.Log($"Pass");
        }

        public override void SkillFirst()
        {
            CheckRotate();
            Instantiate(allEffectSkills[0], spawnPointSkill.position, spawnPointSkill.rotation).eSidePlayer = eSidePlayer;
        }

        public override void SkillSecond()
        {
            CheckRotate();
            Instantiate(allEffectSkills[1], spawnPointSkill.position, spawnPointSkill.rotation).eSidePlayer = eSidePlayer;
        }

        public override void SkillThird()
        {
            Vector3 _pos = CheckRotate();
            var _skill = (Skill.ArcaneShift)Instantiate(allEffectSkills[2], transform.position, transform.rotation);
            _skill.eSidePlayer = eSidePlayer;
            _skill.pointPos = _pos;
            _skill.player = transform;
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
        Vector3 CheckRotate()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    transform.LookAt(hit.point);
                    callRoutine?.Invoke();
                    return hit.point;
                }
            }
            return default;
        }
    }
}
