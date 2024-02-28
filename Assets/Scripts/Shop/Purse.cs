using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    [SerializeField] float startingBalance = 400f;

    float balance = 0;

    public Action onChange;

    private void Awake()
    {
        balance = startingBalance;
        //print($"Balance: {balance}");
    }

    public float GetBalance()
    {
        return balance;
    }

    public void UpdateBalance(float amount)
    {
        balance += amount;
        //print($"Balance: {balance}");
        onChange();
    }
}