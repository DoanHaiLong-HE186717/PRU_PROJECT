using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using NaughtyAttributes;

using Random = UnityEngine.Random;
public class WaveTransitionManager : MonoBehaviour, IGameStateListener
{
    [Header(" Elements ")]
    [SerializeField]
    private Button[] upgradeContainers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState) 
        {
            case GameState.WAVETRANSITION:
                ConfigureUpgradeContainer();
                break;

        }
    }

    private void ConfigureUpgradeContainer()
    {
        for (int i = 0; i < upgradeContainers.Length; i++)
        {
            upgradeContainers[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Upgrade " + i;
        }
    }
}
