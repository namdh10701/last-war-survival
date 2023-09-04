using UnityEngine;
namespace HyperCasual.Runner
{
    class Unit : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        [SerializeField]
        SkinnedMeshRenderer _skinnedMeshRenderer;
        public GameObject BulletPrefab;
        Transform _transform;


        public void Shoot()
        {
            GameObject o = Instantiate(BulletPrefab);
            o.transform.position = transform.position;
        }

        private bool _isShootCoolDown;
        private float rate = .5f;
        private float _cooldownTime = 0;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (_animator != null)
            {
                _animator.SetFloat("Speed", PlayerController.Instance.DistancePerSecond);
            }
            if (_isShootCoolDown)
            {
                _cooldownTime += Time.deltaTime;
            }
            if (_cooldownTime > rate)
            {
                _isShootCoolDown = false;
                _cooldownTime = 0;
            }
            if (!_isShootCoolDown)
            {
                Shoot();
                _isShootCoolDown = true;
            }

        }

    }
}
