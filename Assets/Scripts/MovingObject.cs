using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Despawn")
        {
            Destroy(gameObject);
        }
    }

}
