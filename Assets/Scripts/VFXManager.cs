using UnityEngine;

public class VFXManager : MonoBehaviour
{
   
    

    void Start()
    {
        BaseMine.OnHitVFXEvent += BaseMine_OnHitEvent;
        Collectible.OnHitVFXEvent += BaseMine_OnHitEvent;

    }

    private void Collectible_OnHitEvent(AudioType obj)
    {
        
    }

    private void BaseMine_OnHitEvent(AudioType obj, Vector3 pos)
    {
       
    }


    void Update()
    {

    }
}
