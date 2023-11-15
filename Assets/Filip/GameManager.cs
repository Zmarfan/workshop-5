using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _self;
    
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private TMP_Text _coinsText;
    private int _coinsToPickup;

    private void Awake()
    {
        if (_self != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _self = this;
            _coinsToPickup = FindObjectsOfType<Coin>().Length;
            UpdateCoinsText();
        }
    }

    public static void PickUpCoin()
    {
        _self._coinsToPickup--;
        _self.UpdateCoinsText();
        if (_self._coinsToPickup == 0)
        {
            _self._winScreen.SetActive(true);
        }
    }

    private void UpdateCoinsText()
    {
        _coinsText.text = $"{_coinsToPickup} Coins left to pickup!";
    }
}
