using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// スコアデータテーブル管理
public class ScoreDataManager : MonoBehaviour
{
    // =======================================================================
    //                              メンバ変数
    // =======================================================================
    // 定数
    // 的の種類
    public enum TARGET_TYPE
    {
        ROW,
        NORMAL,
        HIGH,
        MAX
    };

    // 外部入力値
    [SerializeField]
    private int         m_nHighScoreTargetPoint;    // 高得点の的一枚当たりの得点
    [SerializeField]
    private int         m_nNormalScoreTargetPoint;  // 中得点の的一枚当たりの得点
    [SerializeField]
    private int         m_nRowScoreTargetPoint;     // 小得点の的一枚当たりの得点

    [SerializeField]
    private ScoreData   m_pScoreDataObject;         // スコアデータテーブル

    // =======================================================================
    //                              メンバ関数
    // =======================================================================
    // 初期化
    private void InitializeScoreData()
    {
        // 単位当たりの得点を保存
        m_pScoreDataObject.m_nHighRateTargetHitScore = m_nHighScoreTargetPoint;
        m_pScoreDataObject.m_nNomalRateTargetHitScore = m_nNormalScoreTargetPoint;
        m_pScoreDataObject.m_nRowRateTargetHitScore = m_nRowScoreTargetPoint;

        // 得点を初期化
        m_pScoreDataObject.m_nTotalScore = 0;
    }

    // スコア増加
    public  void AddScore(TARGET_TYPE   mTargetType)
    {
        // 的の得点別分岐
        switch (mTargetType)
        {
            // 高得点
            case TARGET_TYPE.HIGH:
                {
                    m_pScoreDataObject.m_nTotalScore += m_pScoreDataObject.m_nHighRateTargetHitScore;
                    break;
                }

            // 中得点
            case TARGET_TYPE.NORMAL:
                {
                    m_pScoreDataObject.m_nTotalScore += m_pScoreDataObject.m_nNomalRateTargetHitScore;
                    break;
                }

            // 低得点
            case TARGET_TYPE.ROW:
                {
                    m_pScoreDataObject.m_nTotalScore += m_pScoreDataObject.m_nRowRateTargetHitScore;
                    break;
                }
        }
    }

    // スコア渡し
    public  int  GetScore()
    {
        return m_pScoreDataObject.m_nTotalScore;
    }


    // =======================================================================
    //                               基本関数
    // =======================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // スコアデータ初期化
        InitializeScoreData();
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        
    }
}
