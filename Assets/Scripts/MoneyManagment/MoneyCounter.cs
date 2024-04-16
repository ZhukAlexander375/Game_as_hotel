using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCounterText;

    private float _moneyCounter;
    

    private void OnEnable()
    {
        MoneyPayment.PaymentMoneyCollecter.AddListener(OnMoneyPickUp);
    }

    private void Start()
    {
        //_totalStars = FindObjectsOfType<Star>().Length;
        _moneyCounter = 0f;
        UpdateMoneyCounterText();
    }

    private void OnMoneyPickUp(float payment)
    {
        _moneyCounter += payment;
        UpdateMoneyCounterText();
    }

    private void UpdateMoneyCounterText() => _moneyCounterText.text = $"Money: {_moneyCounter}";
}
