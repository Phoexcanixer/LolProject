namespace Charater.Ezreal
{
    using Charater.Ezreal.Skill;
    using Common.Cast;
    using KeyControl;
    using System;
    using System.Collections;
    using System.Linq;
    using UnityEngine;
    using View;

    public class EzrealController : BaseStatusCharaterController
    {
        // EzrealIncrease //
        public static Action CallBackPassive { get; set; }
        public float IncreaseAspd { get => (3 * baseStatusChar.aspd) / 100; }
        public Coroutine TimePassiveCrt { get; set; }

        float _timePassive;
        int _passiveStack;
        protected override void Awake()
        {
            base.Awake();
            CallBackPassive = () => SkillPassive();
            eSidePlayer = ESidePlayer.RedSide;
        }
        public override void AutoAtk()
        {
            if (abillity.isAtk)
            {
                if (abillity.delayAtk <= 0 && abillity.delaySkill <= 0)
                {
                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5, 1 << 2);
                    if (hitColliders.Length > 0)
                    {
                        EzrealAuto _ezAuto = Instantiate(atkObject, spawnPointSkill.position, Quaternion.identity).AddComponent<EzrealAuto>();
                        _ezAuto.eSidePlayer = eSidePlayer;
                        float _minDist = hitColliders.Min(item => Vector3.Distance(item.transform.position, transform.position));
                        _ezAuto.target = hitColliders.Where(item => Vector3.Distance(item.transform.position, transform.position) <= _minDist).First().transform;
                        transform.LookAt(_ezAuto.target);
                        abillity.delayAtk = TotalStatus.atkRate;
                    }
                    else
                        abillity.isAtk = false;
                }
            }

            if (abillity.delayAtk > 0)
                abillity.delayAtk -= Time.deltaTime;
        }

        public override void SkillPassive(int slot = 5)
        {
            Status _status = new Status();
            if (_passiveStack + 1 <= 5)
            {
                _passiveStack++;
                _status = new Status { aspd = IncreaseAspd };
            }

            if (TimePassiveCrt != null)
                StopCoroutine(TimePassiveCrt);

            TimePassiveCrt = StartCoroutine(IEPassive());

            IEnumerator IEPassive()
            {
                temporaryStatus += _status;
                _timePassive = 10;
                var _buff = UIManage.instant.uiStatus.CheckBuff(baseStatus.imageCharater.allSkills.Last(), _passiveStack, "EzrealPassive");
                yield return new WaitWhile(() =>
                {
                    _timePassive -= Time.deltaTime * 1;
                    _buff.UpdateTImeBuff(_timePassive / 10);
                    return _timePassive > 0;
                });
                UIManage.instant.uiStatus.DeleteBuff(_buff);
                temporaryStatus -= new Status { aspd = IncreaseAspd * _passiveStack };
                _passiveStack = 0;
            }
        }

        public override void SkillFirst(int slot = 0)
        {
            if (skillStatus.detailSkills[slot].costSkills <= TotalStatus.mp && abillity.coundDownSkills[slot] <= 0)
            {
                this.CastSkill(skillStatus.detailSkills[slot].castSkill, () =>
                {
                    CheckRotate();
                    abillity.delaySkill = timeCaster + skillStatus.detailSkills[slot].castSkill;
                    CountDown(slot);
                    CastSkill(slot, abillity.delaySkill, skillStatus.detailSkills[slot].costSkills);
                }, () => Instantiate(allSkills[slot], spawnPointSkill.position, spawnPointSkill.rotation).eSidePlayer = eSidePlayer, t => UpdateCastSkill(t));
            }
            else
                Debug.Log($"No MP");
        }

        public override void SkillSecond(int slot = 1)
        {
            if (skillStatus.detailSkills[slot].costSkills <= TotalStatus.mp && abillity.coundDownSkills[slot] <= 0)
            {
                this.CastSkill(skillStatus.detailSkills[slot].castSkill, () =>
                {
                    CheckRotate();
                    abillity.delaySkill = timeCaster + skillStatus.detailSkills[slot].castSkill;
                    CountDown(slot);
                    CastSkill(slot, abillity.delaySkill, skillStatus.detailSkills[slot].costSkills);
                }, () => Instantiate(allSkills[slot], spawnPointSkill.position, spawnPointSkill.rotation).eSidePlayer = eSidePlayer, t => UpdateCastSkill(t));
            }
            else
                Debug.Log($"No MP");
        }

        public override void SkillThird(int slot = 2)
        {
            if (skillStatus.detailSkills[slot].costSkills <= TotalStatus.mp && abillity.coundDownSkills[slot] <= 0)
            {
                this.CastSkill(skillStatus.detailSkills[slot].castSkill, () =>
                {
                    abillity.delaySkill = timeCaster + skillStatus.detailSkills[slot].castSkill;
                    CountDown(slot);
                    CastSkill(slot, abillity.delaySkill, skillStatus.detailSkills[slot].costSkills);
                }, () =>
                {
                    Vector3 _pos = CheckRotate();
                    var _skill = (Skill.ArcaneShift)Instantiate(allSkills[slot], transform.position, transform.rotation);
                    _skill.eSidePlayer = eSidePlayer;
                    _skill.pointPos = _pos;
                    _skill.player = transform;
                    _skill.spawnPointSkill = spawnPointSkill;
                    abillity.delaySkill = timeCaster;
                }, t => UpdateCastSkill(t));
            }
            else
                Debug.Log($"No MP");
        }

        public override void SkillUltimate(int slot = 3)
        {
            if (skillStatus.detailSkills[slot].costSkills <= TotalStatus.mp && abillity.coundDownSkills[slot] <= 0)
            {
                this.CastSkill(skillStatus.detailSkills[slot].castSkill, () =>
                {
                    CheckRotate();
                    abillity.delaySkill = timeCaster + skillStatus.detailSkills[slot].castSkill;
                    CountDown(slot);
                    CastSkill(slot, abillity.delaySkill, skillStatus.detailSkills[slot].costSkills);
                }, () => Instantiate(allSkills[slot], spawnPointSkill.position, spawnPointSkill.rotation).eSidePlayer = eSidePlayer, t => UpdateCastSkill(t));
            }
            else
                Debug.Log($"No MP");
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[0]) && abillity.delaySkill <= 0)
                SkillFirst();
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[1]) && abillity.delaySkill <= 0)
                SkillSecond();
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[2]) && abillity.delaySkill <= 0)
                SkillThird();
            if (Input.GetKeyDown(DefaultKeyController.allKeySkills[3]) && abillity.delaySkill <= 0)
                SkillUltimate();

            AutoAtk();

            if (abillity.delaySkill > 0)
                abillity.delaySkill -= Time.deltaTime;

        }
    }

    public class EzrealAuto : AutoAtk
    {
        public override void OnTriggerEnter(Collider other)
        {
            ISide _iSide = other.GetComponent<ISide>();
            if (_iSide != null)
            {
                if (_iSide.eSidePlayer != eSidePlayer)
                {
                    EssenceFluxInCharater _essent = other.GetComponentInChildren<EssenceFluxInCharater>();
                    if (_essent != null)
                        Destroy(_essent.gameObject);

                    Destroy(gameObject);
                }
            }
        }
    }
}
