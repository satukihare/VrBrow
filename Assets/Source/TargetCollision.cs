using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] GameObject target;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collisionObj = other.gameObject;
        if (!collisionObj.CompareTag("Arrow")) return;

        // ToDo : ArrowをTargetの子オブジェクトにして現在位置に固定
    }
}
