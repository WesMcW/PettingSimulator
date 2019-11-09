using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrower : MonoBehaviour
{
    public Transform spawn;
    public GameObject apple;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shootOut", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //shootOut();
    }

    void shootOut()
    {
        Instantiate(apple, spawn.transform.position, Quaternion.Euler(0, -90, 0));
    }
}
