namespace Charater.Ezreal.Skill
{
    using System.Collections;
    using UnityEngine;

    public class EssenceFlux : BaseSkill
    {
        public GameObject EssenceFluxInCharater;
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
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ISide>() != null)
            {
                ISide _iSide = other.GetComponent<ISide>();
                if (_iSide.eSidePlayer != eSidePlayer)
                {
                    EssenceFluxInCharater _essent = other.GetComponentInChildren<EssenceFluxInCharater>();
                    if (_essent != null)
                        Destroy(_essent.gameObject);

                    Debug.Log($"other: {other.name}");
                    EzrealController.CallBackPassive?.Invoke();
                    Instantiate(EssenceFluxInCharater, other.transform).AddComponent<EssenceFluxInCharater>();
                    Destroy(gameObject);
                }
            }
        }

    }
    public class EssenceFluxInCharater : MonoBehaviour
    {
        void Awake() => StartCoroutine(IELifeTime());
        IEnumerator IELifeTime()
        {
            float _time = 5f;
            while (_time > 0)
            {
                _time -= Time.deltaTime * 1;
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
