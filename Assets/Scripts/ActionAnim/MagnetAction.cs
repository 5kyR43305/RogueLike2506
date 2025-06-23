using System;
using UnityEngine;

public class MagnetAction : MonoBehaviour
{
    public static event Action OnMagnetSpinEvent;
    public static event Action OnMagnetAnimEvent;
    

    public void MagnetSpinEnd()
    {
        OnMagnetSpinEvent?.Invoke();
        Debug.Log("MagnetSpinEnd");
    
    }
    public void MagnetAnimEne()
    {
        OnMagnetAnimEvent?.Invoke();
        Debug.Log("MagnetAnimEnd");
    }
}