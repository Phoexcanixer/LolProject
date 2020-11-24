namespace Charater
{
    using Common.Cast;
    using State;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using View;

    public abstract class BaseStatusCharaterController : MonoBehaviour, ISide, ICaster
    {
        public BaseStatus baseStatus;
        public GameObject atkObject;
        public Transform spawnPointSkill;

        public Status TotalStatus { get => baseStatusChar + increaseStatus + decreaseStatus; }
        public Status decreaseStatus, increaseStatus, baseStatusChar;

        public Abillity abillity;
        public SkillStatus skillStatus;

        public List<BaseSkill> allSkills;
        public ESidePlayer eSidePlayer { get; set; }
        public MonoBehaviour caster => this;
        public float timeCaster => .1f;

        protected virtual void Awake()
        {
            baseStatusChar += baseStatus.baseStatusCharater;
            skillStatus += baseStatus.skillStatus;
        }
        protected abstract void Update();
        public abstract void AutoAtk();
        public abstract void SkillPassive(int slot = 5);
        public abstract void SkillFirst(int slot = 0);
        public abstract void SkillSecond(int slot = 1);
        public abstract void SkillThird(int slot = 2);
        public abstract void SkillUltimate(int slot = 3);
        public void SpellFirst()
        {

        }
        public void SpellSecond()
        {

        }
        public void Recall()
        {

        }

        protected void CountDown(int slot)
        {
            StartCoroutine(IECountDown());
            IEnumerator IECountDown()
            {
                abillity.coundDownSkills[slot] = skillStatus.detailSkills[slot].countDown;
                yield return new WaitWhile(() =>
                {
                    abillity.coundDownSkills[slot] -= Time.deltaTime * 1;
                    UIManage.instant.CallBackCountDown?.Invoke(slot, abillity.coundDownSkills[slot] / skillStatus.detailSkills[slot].countDown, $"{abillity.coundDownSkills[slot]:#}");
                    return abillity.coundDownSkills[slot] >= 0;
                });
            }
        }
        protected void CastSkill(int slot, float timeCast, float mpCost)
        {
            decreaseStatus -= new Status { mp = mpCost };
            UIManage.instant.uiCharater.SetCastSkill(timeCast, skillStatus.detailSkills[slot].nameSkill, TotalStatus.mp);
        }

        protected void UpdateCastSkill(float timeCast) => UIManage.instant.uiCharater.SetCountCastSkill(timeCast);
        protected Vector3 CheckRotate()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, 1 << 8))
            {
                if (hit.collider != null)
                {
                    transform.LookAt(hit.point);
                    CharacterControllers.CallBackCancleMove?.Invoke();
                    return hit.point;
                }
            }
            return default;
        }
    }
}
