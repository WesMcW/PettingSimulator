using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject arrowPref;
    public Text debug;

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

    private void Update()
    {
        if (!pullingHand || !currentArrow)
        {
            //debug.text = "broken";
            return;
        }
        pullValue = CalculatePull(pullingHand);
        pullValue = Mathf.Clamp(pullValue, 0, 1);
        //set anim "Blend"
    }

    private float CalculatePull(Transform pullHand)
    {
        Vector3 direction = end.position - start.position;
        float mag = direction.magnitude;

        direction.Normalize();
        Vector3 diff = pullHand.position - start.position;

        return Vector3.Dot(diff, direction) / mag;
    }

    private void FireArrow()
    {
        currentArrow = null;
    }

    private IEnumerator CreateArrow(float waitTime)
    {
        debug.text = "New arrow made";
        yield return new WaitForSeconds(waitTime);

        GameObject arrowObj = Instantiate(arrowPref, spawnPoint);
        arrowObj.transform.localPosition = Vector3.zero;
        arrowObj.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObj.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {
        debug.text = "Pulled arrow back";
        float dist = Vector3.Distance(hand.position, start.position);
        if (dist > grabThreshold)
        {
            debug.text = "nope";
            return;
        }
        pullingHand = hand;
    }

    public void Release()
    {
        debug.text = "Shot arrow";
        if (pullValue > 0.25F) FireArrow();
        pullingHand = null;
        pullValue = 0;
        // reset anim "Blend"

        if(!currentArrow) StartCoroutine(CreateArrow(0.25F));
    }
}
