namespace Charater.Ezreal.Skill
{
    using System.Collections;
    using UnityEngine;
    public class ArcaneShift : BaseSkill
    {
        public ParticleSystem firstAura, secondAura;
        [HideInInspector] public Vector3 pointPos;
        [HideInInspector] public Transform player;
        void Awake()
        {
            firstAura.Stop();
            StartCoroutine(IEMove());
        }
        IEnumerator IEMove()
        {
            float _time = .1f;
            while (_time > 0)
            {
                _time -= Time.deltaTime * 1;
                yield return null;
            }
            player.position = pointPos;
            secondAura.transform.position = pointPos;
            secondAura.Stop();
        }
    }
}
