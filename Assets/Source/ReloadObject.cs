using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////
//
// オブジェクト再設置スクリプト
//
////////////////////////////////////////////////////////////
// リロードしたいオブジェクトを子オブジェクトとして設置します

public class ReloadObject : MonoBehaviour
{
    public GameObject reloadObject;     // 設置するオブジェクト
    public Vector3 reloadObjectOffset;  // オブジェクトのオフセット
    public float reloadTime;            // 再設置までの時間

    GameObject holdObject;  // リロード済
    float timer;            // 再設置時間計測
    bool isTimerClear;

    // Start is called before the first frame update
    void Start()
    {
        // リセット
        holdObject = null;
        timer = 0;
        isTimerClear = false;

        Reload();
        TimerReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerClear)
        {
            Reload();
            TimerReset();
        }

        TimeManager();
    }

    bool ObjectCheck()
    {
        foreach (Transform child in transform)
        {
            if(child.name == reloadObject.name + "(Clone)")
            {
                return true;
            }
        }

        return false;
    }

    // オブジェクトを設置する
    void Reload()
    {
        if (ObjectCheck()) { return; }

        // 再設置オブジェクトのnullチェック
        if(reloadObject == null)
        {
            Debug.Log("reloadObject is null.");
            return;
        }

        // オブジェクト設置
        holdObject = Instantiate(reloadObject, transform);
        holdObject.transform.localPosition = reloadObjectOffset;
    }

    // 再設置時間計測
    void TimeManager()
    {
        // オブジェクトnull時のみ起動
        if (!ObjectCheck())
        {
            if(timer < reloadTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                isTimerClear = true;
            }
        }
    }

    // タイマーリセット
    void TimerReset()
    {
        timer = 0;
        isTimerClear = false;
    }
}
