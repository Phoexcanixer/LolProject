namespace Charater
{
    using KeyControl;
    using System.Collections;
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody), typeof(AnimationController))]
    public class CharacterControllers : MonoBehaviour
    {
        public static System.Action CallBackCancleMove { get; private set; }

        AnimationController _animationController;
        BaseStatusCharaterController _baseStatusCharaterController;
        Coroutine _moveCrt = null;
        void Awake()
        {
            _animationController = GetComponent<AnimationController>();
            _baseStatusCharaterController = GetComponent<BaseStatusCharaterController>();

            CallBackCancleMove = () =>
            {
                if (_moveCrt != null)
                    StopCoroutine(_moveCrt);

                _animationController.Idle();
            };
        }
        void Start()
        {
            View.UIManage.instant.CallBackIconAnsSkills = () => (_baseStatusCharaterController.TotalStatus, _baseStatusCharaterController.baseStatus.imageCharater);

        }
        void Update()
        {
            if (Input.GetKeyDown(DefaultKeyController.move))
                AutoAtkMove();
        }
        void AutoAtkMove()
        {
            Move(() =>
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5, 1 << 2);
                _baseStatusCharaterController.abillity.isAtk = hitColliders.Length > 0;
            });
        }
        void Move(System.Action callFinishMove = null)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, 1 << 8))
            {
                if (hit.collider != null)
                {
                    if (_moveCrt != null)
                        StopCoroutine(_moveCrt);

                    _moveCrt = StartCoroutine(IEMove(hit.point, callFinishMove));
                }
            }
        }
        IEnumerator IEMove(Vector3 movePos, System.Action callFinishMove = null)
        {
            _animationController.Move();
            transform.LookAt(movePos);
            while (!transform.position.Equals(movePos))
            {
                transform.position = Vector3.MoveTowards(transform.position, movePos, _baseStatusCharaterController.baseStatusChar.ms * Time.deltaTime);
                yield return null;
            }
            callFinishMove?.Invoke();
            _animationController.Idle();
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 5);
        }
    }
}
