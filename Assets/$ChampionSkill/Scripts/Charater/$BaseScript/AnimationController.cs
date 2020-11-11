namespace Charater
{
    using UnityEngine;
    public class AnimationController : MonoBehaviour
    {
        Animator _avatarAnim;
        void Awake() => _avatarAnim = GetComponentInChildren<Animator>();
        public void Idle() => _avatarAnim.Play("anim_Idle");
        public void Move() => _avatarAnim.Play("anim_Move");
    }
}
