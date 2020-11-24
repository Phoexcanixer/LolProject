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
        protected override void OnTriggerEnter(Collider other)
        {
            ISide _iSide = other.GetComponent<ISide>();
            if (_iSide != null)
            {
                if (_iSide.eSidePlayer != eSidePlayer)
                {
                    EssenceFluxInCharater _essent = other.GetComponentInChildren<EssenceFluxInCharater>();
                    if (_essent != null)
                        Destroy(_essent.gameObject);

                    Debug.Log($"other: {other.name}");
                    EzrealController.CallBackPassive?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
