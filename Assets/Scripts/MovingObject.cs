using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = transform.CompareTag("Log") ? 3 * speed : speed;
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
        else if (transform.CompareTag("Log") && other.CompareTag("EdgeOfMap"))
        {
            ToggleSpeed();
        }
    }

    private void ToggleSpeed()
    {
        currentSpeed = (currentSpeed > speed) ? speed : 3 * speed;
    }
}
