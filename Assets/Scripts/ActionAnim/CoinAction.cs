using System;
using UnityEngine;

public class CoinAction : MonoBehaviour
{
    public static event Action OnCoinSpinEvent;
    public static event Action OnCoinAnimEvent;

    public void CoinSpinEnd()
    {
        OnCoinSpinEvent?.Invoke();
        Debug.Log("CoinSpinEnd");
    }
    public void CoinAnimEne()
    {
        OnCoinAnimEvent?.Invoke();
        Debug.Log("CoinAnimEnd");
    }
}