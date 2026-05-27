using UnityEngine;

public class ChangeAppleColor : MonoBehaviour
{
    [Header("Apple Materials")]
    public Material[] appleMaterials;

    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Stylus") || other.gameObject.CompareTag("Player"))
        {
            AppleInteractions();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Stylus") || collision.gameObject.CompareTag("Player"))
        {
            AppleInteractions();
        }
    }

    private void AppleInteractions()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (appleMaterials.Length > 0)
        {
            int randomIndex = Random.Range(0, appleMaterials.Length);
            meshRenderer.material = appleMaterials[randomIndex];
        }
    }
}