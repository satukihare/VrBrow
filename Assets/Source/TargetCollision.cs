using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject collisionObj = other.gameObject;
        if (!collisionObj.CompareTag("Arrow")) return;

        Rigidbody[] rigs = collisionObj.GetComponentsInChildren<Rigidbody>();
        BoxCollider[] cols = collisionObj.GetComponentsInChildren<BoxCollider>();
        foreach(Rigidbody rig in rigs)
        {
            rig.velocity = Vector3.zero;
            rig.useGravity = false;
            rig.isKinematic = true;
        }
        foreach(BoxCollider col in cols)
        {
            col.enabled = false;
        }

        collisionObj.transform.parent = this.transform;
    }
}
