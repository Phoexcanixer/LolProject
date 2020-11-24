using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public abstract class BaseSkill : MonoBehaviour, ISide
{
    public ESidePlayer eSidePlayer { get; set; }
    protected virtual void OnTriggerEnter(Collider other) { }
}
