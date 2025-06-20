using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
   
    void Start()
    {
        
    }


    public static event Action<AudioType> OnHitEvent;
    public static event Action<AudioType, Vector3> OnHitVFXEvent;
    public PlayerData playerData;
    public AudioType myType;

    public float JumpForce { get; internal set; }

    public virtual void OnTriggerEnter(Collider other)
    {
        OnHitEvent?.Invoke(myType);
        OnHitVFXEvent.Invoke(myType, transform.position);

    }
}

