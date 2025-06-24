using UnityEngine;

public class LifeStarAction : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ParticleSystem psPrefab;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private float volume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerData != null)
        {
            playerData.Life++;


            if (psPrefab != null)
            {
                ParticleSystem ps = Instantiate(psPrefab, transform.position, Quaternion.identity);
                ps.Play();
                Destroy(ps.gameObject, ps.main.duration);
            }


            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            }


            gameObject.SetActive(false);
        }
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
