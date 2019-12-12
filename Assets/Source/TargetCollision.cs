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

        ScoreDataManager.Instance.AddScore(ScoreDataManager.TARGET_TYPE.HIGH);

        //switch (collisionObj.GetComponent<Arrow>().colliders.Count)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        ScoreDataManager.Instance.AddScore(ScoreDataManager.TARGET_TYPE.LOW);
        //        break;
        //    case 2:
        //        ScoreDataManager.Instance.AddScore(ScoreDataManager.TARGET_TYPE.MIDDLE);
        //        break;
        //    case 3:
        //        ScoreDataManager.Instance.AddScore(ScoreDataManager.TARGET_TYPE.HIGH);
        //        break;
        //}

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
