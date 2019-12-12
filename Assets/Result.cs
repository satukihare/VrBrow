using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    RectTransform RectTransform;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        RectTransform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreDataManager.Instance.GetScore() >= 25)
        {
            RectTransform.localScale = new Vector3(1, 1, 1);
        }
    }
}
