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
    public bool isObjectHoldInStart;    // 最初にオブジェクトを持っているか

    GameObject holdObject;    // リロード済
    float timer;    // 再設置時間計測
    bool isTimerClear;

    // Start is called before the first frame update
    void Start()
    {
        // リセット
        holdObject = null;
        timer = 0;
        isTimerClear = false;

        // 初期設定によりオブジェクトの設置
        if (!isObjectHoldInStart)
        {
            Reload();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerClear)
        {
            Reload();
        }

        TimeManager();
    }

    bool ObjectCheck()
    {
        foreach (Transform child in transform)
        {
            if(child == reloadObject)
            {
                return true;
            }
        }

        return false;
    }

    // オブジェクトを設置する
    void Reload()
    {
        // 再設置オブジェクトのnullチェック
        if(reloadObject == null)
        {
            Debug.Log("reloadObject is null.");
            return;
        }

        // オブジェクト設置
        holdObject = Instantiate(reloadObject, transform);
        holdObject.transform.position = reloadObjectOffset;

        // タイマーリセット
        TimerReset();
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
