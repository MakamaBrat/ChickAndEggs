using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float dragSpeed = 0.02f;
    public float minXLimit = -5f;
    public float maxXLimit = 5f;

    private Vector3 startPosition;
    private float lastMouseX;
    private bool isDragging = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Начало драга
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }

        // Конец драга
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Сам drag
        if (isDragging)
        {
            float deltaX = Input.mousePosition.x - lastMouseX;
            lastMouseX = Input.mousePosition.x;

            float newX = transform.position.x + deltaX * dragSpeed;

            newX = Mathf.Clamp(
                newX,
                startPosition.x + minXLimit,
                startPosition.x + maxXLimit
            );

            transform.position = new Vector3(
                newX,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
