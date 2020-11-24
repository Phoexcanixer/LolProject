namespace Dummy
{
    using UnityEngine;

    public class DummyManage : MonoBehaviour, ISide
    {
        public ESidePlayer eSidePlayer { get; set; }
        void Awake()
        {
            eSidePlayer = ESidePlayer.AllEnemy;
        }
        //protected void OnParticleCollision(GameObject other)
        //{
        //    Debug.Log($"other: {other.name}");
        //}
    }
}
