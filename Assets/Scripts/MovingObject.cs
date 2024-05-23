using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentSpeed;

    private float speedAddition = 0;

    private void Start()
    {
        currentSpeed = transform.CompareTag("Log") ? 3 * speed : speed+speedAddition;
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
            Transform playerTransform = gameObject.transform.Find("Player");
            if (playerTransform != null)
            {
                playerTransform.SetParent(null);
            }
            Destroy(gameObject);
        }
        else if (transform.CompareTag("Log") && other.CompareTag("EdgeOfMap"))
        {
            ToggleSpeed();
        }
    }

    private void ToggleSpeed()
    {
        currentSpeed = (currentSpeed == speed*3) ? speed+speedAddition : 3 * speed;
    }

    public void SetAddtionalSpeed(float speedAdd) {
        speedAddition = speedAdd;
    }

}
