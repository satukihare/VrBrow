using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // =======================================================================
    //                              メンバ変数
    // =======================================================================
    // 変数
    private ScoreDataManager    m_pScoreDataManagerComponent;
    private Text                m_pTextComponent;


    // =======================================================================
    //                              メンバ関数
    // =======================================================================
    // スコアテキスト更新
    private void    UpdateText()
    {
        m_pTextComponent.text = "Score : " + m_pScoreDataManagerComponent.GetScore().ToString();
    }


    // =======================================================================
    //                               基本変数
    // =======================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        m_pTextComponent = GetComponent<Text>();
        m_pScoreDataManagerComponent = transform.parent.gameObject.GetComponent<ScoreDataManager>();

        // 初期化
        m_pTextComponent.text = null;
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
}
