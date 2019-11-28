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

    [SerializeField] float m_fLength;
    Bow m_Bow;
    Rigidbody m_Rigidbody;
    CapsuleCollider m_CapsuleCollider;
    public Status m_Status;
    public List<Collider> colliders { get; set; } = new List<Collider>();

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
                    transform.localPosition = new Vector3(-m_Bow.GetDis() - m_fLength, 0, -0.02f);

                    CheckLimit();

                    if (Random.Range(0, 3) == 0)
                    {
                        OculusControllerVibrate.SetVibrateR(0.03f, 0.8f, 0.5f);
                    }

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

        FallArrowTask();
    }

    void CheckLimit()
    {
        if (transform.localPosition.x > m_fLength)
        {
            transform.localPosition = new Vector3(m_fLength, 0, -0.02f);
        }
        else if (transform.localPosition.x < -m_fLength)
        {
            transform.localPosition = new Vector3(-m_fLength, 0, -0.02f);
        }
    }

    void FallArrowTask()
    {
        if (!m_Rigidbody.isKinematic)
        {
            var ver = m_Rigidbody.velocity;
            var falldir = ver.normalized;

            //落ちる方向を向くようにする
            m_Rigidbody.MoveRotation(Quaternion.LookRotation(falldir));
        }
    }
}
