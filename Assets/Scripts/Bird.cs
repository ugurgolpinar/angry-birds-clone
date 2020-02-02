using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private float timeSittingAround;
    private bool birdWasLaunched;

    public float forceRate;

    private void Awake()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, startPosition);

        if (birdWasLaunched && rb.velocity.magnitude < 0.1f)
        {
            timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 7f || transform.position.y < -10f || timeSittingAround > 3f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnMouseUp()
    {
        Vector2 directionToStartPosition = startPosition - transform.position;
        rb.AddForce(directionToStartPosition * forceRate);

        rb.gravityScale = 1f;
        birdWasLaunched = true;
        lineRenderer.enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);

        lineRenderer.enabled = true;
    }

}
