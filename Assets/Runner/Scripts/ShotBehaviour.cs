using UnityEngine;

namespace HyperCasual.Runner
{
    public abstract class ShotBehaviour : MonoBehaviour
    {
        [SerializeField] private float dmg;
        public float Dmg => dmg;
        public abstract void OnHit();
    }
}
