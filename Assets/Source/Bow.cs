using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] GameObject m_GObjMainPart;
    [SerializeField] GameObject m_GObjString;

    [SerializeField] GameObject m_GObjLeftHand;
    [SerializeField] GameObject m_GObjRightHand;

    Vector3 m_vBasePoint;
    Vector3 m_vFront;

    float m_fDis = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_vBasePoint = m_GObjString.transform.position;
        m_vFront = m_GObjMainPart.transform.position - m_vBasePoint;

        m_fDis = Vector3.Dot(m_vFront.normalized, m_GObjRightHand.transform.position - m_GObjLeftHand.transform.position);

        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/Arrow"), this.transform) as GameObject;
            go.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1000));
        }
    }

    public float GetDis()
    {
        return m_fDis;
    }

    public Vector3 GetForce()
    {
        return m_vFront.normalized * m_fDis * -1000;
    }
}
