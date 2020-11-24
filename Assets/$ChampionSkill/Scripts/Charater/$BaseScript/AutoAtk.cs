namespace Charater
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class AutoAtk : MonoBehaviour, ISide
    {
        public ESidePlayer eSidePlayer { get; set; }
        public Transform target;
        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(IEMove());
        }

       IEnumerator IEMove()
        {
            Vector3 _move = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(_move);
            while (!transform.position.Equals(target.position))
            {
                transform.position = Vector3.MoveTowards(transform.position, _move, 15 * Time.deltaTime);
                yield return null;
            }
        }
        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ISide>() != null)
            {
                ISide _iSide = other.GetComponent<ISide>();
                if (_iSide.eSidePlayer != eSidePlayer)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
