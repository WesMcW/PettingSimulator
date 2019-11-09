using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject arrowPref;

    [Header("Bow")]
    public float grabThreshold = 0.15F;
    public Transform start;
    public Transform end;
    public Transform spawnPoint;

    private Transform pullingHand;
    private Arrow currentArrow;
    //animator

    private float pullValue;

    private void Awake()
    {
        //set anim

    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0));
    }

    private IEnumerator CreateArrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject arrowObj = Instantiate(arrowPref, spawnPoint);
        arrowObj.transform.localPosition = Vector3.zero;
        arrowObj.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObj.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {

    }

    public void Release()
    {

    }
}
