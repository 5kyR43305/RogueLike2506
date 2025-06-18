using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] ParticleSystem psPrefab;
    

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
        ParticleSystem newParticle = Instantiate(psPrefab, pos, Quaternion.identity);

    
        newParticle.Play();

      
        Destroy(newParticle.gameObject, newParticle.main.duration + newParticle.main.startLifetime.constantMax);
    }


    void Update()
    {

    }
}
