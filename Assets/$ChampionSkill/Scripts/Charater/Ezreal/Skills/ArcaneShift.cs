namespace Charater.Ezreal.Skill
{
    using System.Collections;
    using UnityEngine;
    public class ArcaneShift : BaseSkill
    {
        public ParticleSystem firstAura, secondAura;
        public GameObject arcaneShiftMissile;
        [HideInInspector] public Vector3 pointPos;
        [HideInInspector] public Transform player, spawnPointSkill;
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
            FindingTarget();
            _time = .5f;
            while (_time > 0)
            {
                _time -= Time.deltaTime * 1;
                yield return null;
            }
            Destroy(gameObject);
        }
        void FindingTarget()
        {
            Collider[] hitColliders = Physics.OverlapSphere(player.position, 7, 1 << 2);
            if (hitColliders.Length > 0)
            {
                ArcaneShiftMissile _arcanMiss = Instantiate(arcaneShiftMissile, spawnPointSkill.position, Quaternion.identity).AddComponent<ArcaneShiftMissile>();
                _arcanMiss.eSidePlayer = eSidePlayer;
                _arcanMiss.target = hitColliders[0].transform;
            }
        }
    }
    public class ArcaneShiftMissile : AutoAtk
    {
        public override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ISide>() != null)
            {
                ISide _iSide = other.GetComponent<ISide>();
                if (_iSide.eSidePlayer != eSidePlayer)
                {
                    EssenceFluxInCharater _essent = other.GetComponentInChildren<EssenceFluxInCharater>();
                    if (_essent != null)
                        Destroy(_essent.gameObject);

                    EzrealController.CallBackPassive?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
