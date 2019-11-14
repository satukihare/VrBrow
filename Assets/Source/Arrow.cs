using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public enum Status
    {
       NONE,
       HOLD,
       RELEASE,
       MAX,
    };

    Bow m_Bow;
    Rigidbody m_Rigidbody;
    CapsuleCollider m_CapsuleCollider;
    public Status m_Status;

    // Start is called before the first frame update
    void Start()
    {
        m_Status = Status.NONE;

        GameObject gameObject = GameObject.FindWithTag("Bow");
        m_Bow = gameObject.GetComponent<Bow>();

        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.isKinematic = true;

        m_CapsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_Status)
        {
            case Status.NONE:
                {
                    break;
                }
            case Status.HOLD:
                {
                    transform.localPosition = new Vector3(-m_Bow.GetDis() - transform.localScale.y, 0, -0.02f);
                    CheckLimit();

                    if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
                    {
                        m_Status = Status.RELEASE;
                    }
                    break;
                }
            case Status.RELEASE:
                {
                    Vector3 vForce;
                    vForce = m_Bow.GetForce();

                    transform.parent = null;

                    m_CapsuleCollider.isTrigger = false;

                    m_Rigidbody.isKinematic = false;
                    m_Rigidbody.AddForce(vForce);

                    m_Status = Status.NONE;

                    break;
                }
        }
    }

    void CheckLimit()
    {
        if (transform.localPosition.x > transform.localScale.y)
        {
            transform.localPosition = new Vector3(transform.localScale.y, 0, -0.02f);
        }
        else if (transform.localPosition.x < -transform.localScale.y)
        {
            transform.localPosition = new Vector3(-transform.localScale.y, 0, -0.02f);
        }
    }
}
