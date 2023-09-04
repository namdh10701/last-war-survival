using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using HyperCasual.Gameplay;
using UnityEngine;

namespace HyperCasual.Runner
{
    /// <summary>
    /// A simple inventory class that listens to game events and keeps track of the amount of in-game currencies
    /// collected by the player
    /// </summary>
    public class Inventory : AbstractSingleton<Inventory>
    {
        [SerializeField] GenericGameEventListener m_WinEventListener;
        [SerializeField] GenericGameEventListener m_LoseEventListener;

        int m_TempGold;
        float m_TempXp;

        Hud m_Hud;
        LevelCompleteScreen m_LevelCompleteScreen;

        void Start()
        {
            m_WinEventListener.EventHandler = OnWin;
            m_LoseEventListener.EventHandler = OnLose;
            m_TempGold = 0;
            m_TempXp = 0;
            //TODO: Progess
            /*m_TotalGold = SaveManager.Instance.Currency;
            m_TotalXp = SaveManager.Instance.XP;*/

            m_LevelCompleteScreen = UIManager.Instance.GetView<LevelCompleteScreen>();
            m_Hud = UIManager.Instance.GetView<Hud>();
            UIManager.Instance.Show<Hud>();
        }

        void OnEnable()
        {
            m_WinEventListener.Subscribe();
            m_LoseEventListener.Subscribe();
        }

        void OnDisable()
        {
            m_WinEventListener.Unsubscribe();
            m_LoseEventListener.Unsubscribe();
        }

        public void OnGoldPicked(Collectable collectables)
        {
            m_TempGold += 1;
            m_Hud.GoldValue = m_TempGold;
        }
        void OnWin()
        {
            //TODO: Progess
            m_LevelCompleteScreen.GoldValue = m_TempGold;
            m_LevelCompleteScreen.XpValue = m_TempXp;
        }

        void OnLose()
        {
            //TODO: Progess
            m_TempGold = 0;
        }
    }
}
