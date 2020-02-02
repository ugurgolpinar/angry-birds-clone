using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cloudParticleEffect;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Bird bird = other.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(cloudParticleEffect, new Vector3(transform.position.x, transform.position.y, -2f), Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.contacts[0].normal.y < -0.5f)
        {
            Instantiate(cloudParticleEffect, new Vector3(transform.position.x, transform.position.y, -2f), Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
