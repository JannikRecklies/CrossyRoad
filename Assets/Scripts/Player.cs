using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isHopping;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.RoundToInt(transform.position.z) - transform.position.z;
            }
            transform.position = transform.position + new Vector3(1, 0, zDifference);
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping) {
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = transform.position + new Vector3(0, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping) {
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = transform.position + new Vector3(0, 0, -1);
        }
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}
