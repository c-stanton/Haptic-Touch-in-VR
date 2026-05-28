using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    [Header("Audio Config")]
    public AudioClip popSound;

    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null) {

            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.spatialBlend = 1.0f;

        if (audioSource != null)
        {
            audioSource.enabled = false;
        }

        StartCoroutine(spawnDelay(5f));
    }

    private IEnumerator spawnDelay(float duration)
    {
        yield return new WaitForSeconds(duration);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (audioSource != null)
        {
            audioSource.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HapticPen"))
        {
            if (audioSource != null && audioSource.enabled && popSound != null)
            {
                audioSource.PlayOneShot(popSound, 10.0f);
            }

            AssignRandomColor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("HapticPen"))
            
        {
            return;
        }

        if (audioSource != null && audioSource.enabled && popSound != null)
        {
            audioSource.PlayOneShot(popSound, 3.0f);
        }

        AssignRandomColor();
    }

    private void AssignRandomColor()
    {
        meshRenderer.material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    }
}