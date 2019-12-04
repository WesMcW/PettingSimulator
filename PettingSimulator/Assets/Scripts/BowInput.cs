using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowInput : MonoBehaviour
{
    public Bow m_Bow;
    public GameObject m_OppositeController;
    public OVRInput.Controller m_Controller;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller)) m_Bow.Pull(m_OppositeController.transform);
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller)) m_Bow.Release();
    }
}
