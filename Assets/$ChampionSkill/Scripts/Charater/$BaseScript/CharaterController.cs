namespace Charater
{
    using KeyControl;
    using System.Collections;
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody), typeof(AnimationController))]
    public class CharaterController : MonoBehaviour
    {
        public float moveSpeed;

        AnimationController _animationController;
        Coroutine _moveCrt = null;
        void Awake() => _animationController = GetComponent<AnimationController>();
        void Update()
        {
            if (Input.GetKeyDown(DefaultKeyController.move))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        if (_moveCrt != null)
                            StopCoroutine(_moveCrt);

                        _moveCrt = StartCoroutine(IEMove(hit.point));
                    }
                }
            }
        }
        IEnumerator IEMove(Vector3 movePos)
        {
            _animationController.Move();
            transform.LookAt(movePos);
            while (!transform.position.Equals(movePos))
            {
                transform.position = Vector3.MoveTowards(transform.position, movePos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            _animationController.Idle();
        }
    }
}
