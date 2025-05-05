using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float initialPosition, backgroundLength;

    [SerializeField] private float parallaxSpeed;
    [SerializeField] private Transform mainCamera;

    private void Start()
    {
        initialPosition = transform.position.x;
        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float mainCameraX = mainCamera.position.x;

        float distance = mainCameraX * parallaxSpeed;
        float movement = mainCameraX * (1 - parallaxSpeed);

        transform.position = new Vector3(initialPosition + distance, transform.position.y, transform.position.z);
        
        if (movement > initialPosition + backgroundLength)
        {
            initialPosition += backgroundLength;
        } else if (movement < initialPosition - backgroundLength)
        {
            initialPosition -= backgroundLength;
        }
    }
}
