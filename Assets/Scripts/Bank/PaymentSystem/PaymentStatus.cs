using System;
using UnityEngine;

[Serializable]
public class PaymentStatus
{
    [SerializeField] private bool _paid;
    public bool Paid => _paid;

    public PaymentStatus() { }

    public PaymentStatus(bool paid) => _paid = paid;
}
