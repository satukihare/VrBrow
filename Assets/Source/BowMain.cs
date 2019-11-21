using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMain : MonoBehaviour
{
    [SerializeField] GameObject m_GObjBows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Arrow"))
        {
            return;
        }
        if (!OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            return;
        }

        Arrow arrow = other.gameObject.GetComponent<Arrow>();

        if(arrow.m_Status == Arrow.Status.HOLD)
        {
            return;
        }
        arrow.m_Status = Arrow.Status.HOLD;
        other.gameObject.transform.parent = m_GObjBows.transform;
        other.gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
        other.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

}
