using System.Collections;
using System.Collections.Generic;
using HyperCasual.Gameplay;
using UnityEngine;

namespace HyperCasual.Runner
{
    public class Collectable : Spawnable
    {
        public enum CollectableID
        {
            None, Bonus, Extra_Unit, Coin
        }

        [SerializeField] SoundID m_Sound = SoundID.None;
        public CollectableID ID = CollectableID.None;

        const string _PLAYER_TAG = "Player";

        //public ItemPickedEvent m_Event;
        public int m_Count;

        bool _collected;
        Renderer[] _renderers;

        public override void ResetSpawnable()
        {
            _collected = false;

            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = true;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _renderers = gameObject.GetComponentsInChildren<Renderer>();
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(_PLAYER_TAG) && !_collected)
            {
                Collect();
            }
        }

        void Collect()
        {
            /*if (m_Event != null)
            {
                m_Event.Count = m_Count;
                m_Event.Raise();
            }*/

            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = false;
            }

            _collected = true;
            AudioManager.Instance.PlayEffect(m_Sound);
            GameManager.Instance.OnCollect(this);
        }
    }
}