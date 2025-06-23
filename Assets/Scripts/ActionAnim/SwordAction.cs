using System;
using UnityEngine;

public class SwordAction : MonoBehaviour
{
    public static event Action OnSwordSpinEvent;
    public static event Action OnSwordAnimEvent;

    public void MagnetSpinEnd()
    {
        OnSwordSpinEvent?.Invoke();
        Debug.Log("SwordSpinEnd");
    }
    public void MagnetAnimEne()
    {
        OnSwordAnimEvent?.Invoke();
        Debug.Log("SwordAnimEnd");
    }
}