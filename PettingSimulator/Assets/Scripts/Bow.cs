using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject arrowPref;
    public Text debug, debug2, debug3;
    public GameObject bowString;

    [Header("Bow")]
    public float grabThreshold = 0.15F;
    public Transform start;
    public Transform end;
    public Transform spawnPoint;
    public int count = 0;

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
        if (currentArrow) debug.text = "Arrows made: " + count;
        else debug.text = "currentArrow not null";

        if(pullingHand) debug2.text = "pullingHandNot null" + pullValue;
        else debug2.text = ":(";
        //debug3.text = "arrows: " + count;

        //debug2.text = pullValue.ToString();
        if (pullingHand && currentArrow)
        {
            debug3.text = "THING";
            pullValue = CalculatePull(pullingHand);
        }
        else debug3.text = "";
        //pullValue = Mathf.Clamp(pullValue, 0, 1);
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
        debug2.text = "pew";
        currentArrow.Fire(pullValue);
        currentArrow = null;
    }

    private IEnumerator CreateArrow(float waitTime)
    {
        count++;
        debug.text = "Arrows made: " + count;
        yield return new WaitForSeconds(waitTime);

        GameObject arrowObj = Instantiate(arrowPref, spawnPoint);
        arrowObj.transform.localPosition = Vector3.zero;
        arrowObj.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObj.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {
        //debug.text = "Pulled arrow back";
        float dist = Vector3.Distance(hand.position, start.position);
        //currentArrow.transform.position = new Vector3(start.position.x, start.position.y, end.position.z);
        if (dist > grabThreshold)
        {
            //debug.text = "nope";
            return;
        }
        else
        {
            //bowString.SetActive(false);
            //currentArrow.transform.SetParent(end);
            //currentArrow.transform.position = Vector3.zero;
        }
        pullingHand = hand;
    }

    public void Release()
    {
        //debug.text = "Shot arrow";
        if (pullValue > 0.25F) FireArrow();
        bowString.SetActive(true);
        pullingHand = null;
        pullValue = 0F;
        // reset anim "Blend"

        if(!currentArrow) StartCoroutine(CreateArrow(0.25F));
    }
}
