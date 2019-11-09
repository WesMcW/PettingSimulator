using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCut : MonoBehaviour
{
    public GameObject particles;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("canCut"))
        {
            Instantiate(particles, new Vector3(other.transform.position.x, other.transform.position.y + .2f, other.transform.position.z), Quaternion.Euler(-90, 0, 0));

            Destroy(other.gameObject);
        }
    }
}
