namespace Charater.Ezreal.Skill
{
    using System.Collections;
    using UnityEngine;

    public class MyticShort : BaseSkill
    {
        void Awake() => StartCoroutine(IEMove());
        IEnumerator IEMove()
        {
            float _time = .2f;
            while (_time > 0)
            {
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * 30;
                _time -= Time.deltaTime * 1;
                yield return null;
            }
            Destroy(gameObject);
            
        }
        protected override void OnParticleCollision(GameObject other)
        {
            if (other.GetComponent<ISide>() != null)
            {
                ISide _iSide = other.GetComponent<ISide>();
                if (_iSide.eSidePlayer != eSidePlayer)
                {
                    Debug.Log($"other: {other.name}");
                    Destroy(gameObject);
                }
            }
        }
    }
}
