using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int pointValue = 1;
    public float spinSpeed = 90f;
    public GameObject collectEffect;
    public AudioClip collectSound;

    void Update()
    {
        // Spin on the Y axis so it reads as collectable
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Only react to the kart
        if (!other.CompareTag("Player")) return;

        ScoreManager.Instance.AddPoints(pointValue);

        if (collectEffect != null)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

        if (collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject);
    }
}