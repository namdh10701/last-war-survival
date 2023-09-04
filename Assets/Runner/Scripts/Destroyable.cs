using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual.Runner
{
    public class Destroyable : Spawnable
    {
        public enum DestroyableID
        {
            None, Extra_Unit, Zombie
        }
        Canvas canvas;
        [SerializeField] private float _totalHp;
        [SerializeField] private float _currentHp;
        public DestroyableID ID = DestroyableID.None;
        private bool _destroyed;
        Renderer[] _renderers;

        protected override void Awake()
        {
            base.Awake();
            canvas = GetComponentInChildren<Canvas>();
            canvas.worldCamera = Camera.main;
            _renderers = GetComponentsInChildren<Renderer>();

        }
        //TODO: Separate hp bar logic
        public Image _hpBar;
        const string _SHOT_TAG = "Shot";
        public void TakeHit(float dmg)
        {
            if (_currentHp > 0 && !_destroyed)
            {
                _currentHp -= dmg;
                _hpBar.fillAmount = _currentHp / _totalHp;
                if (_currentHp < 0)
                {
                    _destroyed = true;
                    OnDestroyed();
                    GameManager.Instance.OnDestroyed(this);
                }
            }
        }

        public void OnDestroyed()
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = false;
            }
        }
        public override void ResetSpawnable()
        {
            _destroyed = false;

            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_SHOT_TAG))
            {
                ShotBehaviour shotBehavior = other.GetComponent<ShotBehaviour>();
                shotBehavior.OnHit();
                TakeHit(shotBehavior.Dmg);
            }
        }
    }
}
