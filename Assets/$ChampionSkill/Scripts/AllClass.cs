using UnityEngine;
using System;
using System.Linq;

#region ClassAndStruct
[Serializable]
public struct Status
{
    // State //
    public float hp, mp;
    public float atk, matk, def, mdef, aspd, crd, cri, ms;
    public float hprgn, mprgn, defpen, defpenpercent, mdefpen, mdefpenpercent, liftstl, vampire, range, tenacity;
    public float gold;
    // Propoty //
    public float atkRate { get => 1 / aspd; }

    public static Status operator +(Status status, Status adjustStatus) => new Status()
    {
        hp = status.hp + adjustStatus.hp,
        mp = status.mp + adjustStatus.mp,
        atk = status.atk + adjustStatus.atk,
        matk = status.matk + adjustStatus.matk,
        def = status.def + adjustStatus.def,
        mdef = status.mdef + adjustStatus.mdef,
        aspd = status.aspd + adjustStatus.aspd,
        crd = status.crd + adjustStatus.crd,
        cri = status.cri + adjustStatus.cri,
        ms = status.ms + adjustStatus.ms,

        hprgn = status.hprgn + adjustStatus.hprgn,
        mprgn = status.mprgn + adjustStatus.mprgn,
        defpen = status.defpen + adjustStatus.defpen,
        defpenpercent = status.defpenpercent + adjustStatus.defpenpercent,
        mdefpen = status.mdefpen + adjustStatus.mdefpen,
        mdefpenpercent = status.mdefpenpercent + adjustStatus.mdefpenpercent,
        liftstl = status.liftstl + adjustStatus.liftstl,
        vampire = status.vampire + adjustStatus.vampire,
        range = status.range + adjustStatus.range,
        tenacity = status.tenacity + adjustStatus.tenacity
    };
    public static Status operator -(Status status, Status adjustStatus) => new Status()
    {
        hp = status.hp - adjustStatus.hp,
        mp = status.mp - adjustStatus.mp,
        atk = status.atk - adjustStatus.atk,
        matk = status.matk - adjustStatus.matk,
        def = status.def - adjustStatus.def,
        mdef = status.mdef - adjustStatus.mdef,
        aspd = status.aspd - adjustStatus.aspd,
        crd = status.crd - adjustStatus.crd,
        cri = status.cri - adjustStatus.cri,
        ms = status.ms - adjustStatus.ms,

        hprgn = status.hprgn - adjustStatus.hprgn,
        mprgn = status.mprgn - adjustStatus.mprgn,
        defpen = status.defpen - adjustStatus.defpen,
        defpenpercent = status.defpenpercent - adjustStatus.defpenpercent,
        mdefpen = status.mdefpen - adjustStatus.mdefpen,
        mdefpenpercent = status.mdefpenpercent - adjustStatus.mdefpenpercent,
        liftstl = status.liftstl - adjustStatus.liftstl,
        vampire = status.vampire - adjustStatus.vampire,
        range = status.range - adjustStatus.range,
        tenacity = status.tenacity - adjustStatus.tenacity
    };
}
[Serializable]
public struct Abillity
{
    public float delayAtk;
    public float delaySkill;
    public float[] coundDownSkills;
    public bool isAtk;
}
[Serializable]
public struct SkillStatus
{
    [Serializable] public struct DetailSkill 
    {
        public string nameSkill;
        public float castSkill;
        public float countDown;
        public float costSkills;
    }
    public DetailSkill[] detailSkills;
    public static SkillStatus operator +(SkillStatus skillStatus, SkillStatus adjustSkillStatus) => new SkillStatus() { detailSkills = skillStatus.detailSkills.Concat(adjustSkillStatus.detailSkills).ToArray() };
}
#endregion

#region Enum
public enum ESidePlayer { RedSide, BlueSide, AllEnemy }

#endregion

#region Interface
public interface ISide
{
    ESidePlayer eSidePlayer { get; }
}
public interface ICaster
{
    MonoBehaviour caster { get; }
    float timeCaster { get; }
}
#endregion
