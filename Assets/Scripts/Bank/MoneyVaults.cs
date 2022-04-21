using UnityEngine;
using System;

[Serializable]
public class MoneyVaults
{
    [SerializeField] private int _money;
    public int Money => _money;

    public MoneyVaults() { }

    public MoneyVaults(int money) => _money = money;
}
