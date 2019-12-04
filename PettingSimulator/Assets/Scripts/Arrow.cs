using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Transform tip;

    Rigidbody rb;
    bool isStopped = true;
    Vector3 lastPos;

    private void Awake()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isStopped) return;

        rb.MoveRotation(Quaternion.LookRotation(rb.velocity, transform.up));
        if (Physics.Linecast(lastPos, tip.position))
        {
            Stop();
        }

        lastPos = tip.position;
    }

    void Stop()
    {
        isStopped = true;
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void Fire(float pullValue)
    {
        isStopped = false;
        transform.parent = null;

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(transform.forward * speed);

        Destroy(gameObject, 8F);
    }
}
