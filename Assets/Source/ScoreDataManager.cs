using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// スコアデータテーブル管理
public class ScoreDataManager : SingletonMonoBehavior<ScoreDataManager>
{
    // =======================================================================
    //                              メンバ変数
    // =======================================================================
    // 定数
    // 的の種類
    public enum TARGET_TYPE
    {
        LOW,
        MIDDLE,
        HIGH,
        MAX
    };

    // 外部入力値
    [SerializeField]
    private int         m_nHighScoreTargetPoint = 5;    // 高得点の的一枚当たりの得点
    [SerializeField]
    private int         m_nMiddleScoreTargetPoint = 3;  // 中得点の的一枚当たりの得点
    [SerializeField]
    private int         m_nLowScoreTargetPoint = 1;     // 小得点の的一枚当たりの得点

    [SerializeField]
    private ScoreData   m_pScoreDataObject;         // スコアデータテーブル

    // =======================================================================
    //                              メンバ関数
    // =======================================================================
    // 初期化
    void InitializeScoreData()
    {
        m_pScoreDataObject = new ScoreData();

        // 単位当たりの得点を保存
        m_pScoreDataObject.m_nHighRateTargetHitScore = m_nHighScoreTargetPoint;
        m_pScoreDataObject.m_nMiddleRateTargetHitScore = m_nMiddleScoreTargetPoint;
        m_pScoreDataObject.m_nLowRateTargetHitScore = m_nLowScoreTargetPoint;

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
            case TARGET_TYPE.MIDDLE:
                {
                    m_pScoreDataObject.m_nTotalScore += m_pScoreDataObject.m_nMiddleRateTargetHitScore;
                    break;
                }

            // 低得点
            case TARGET_TYPE.LOW:
                {
                    m_pScoreDataObject.m_nTotalScore += m_pScoreDataObject.m_nLowRateTargetHitScore;
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
    void Awake()
    {
        SetInstance(this);
    }
    // 初期化
    void Start()
    {
        InitializeScoreData();
    }

    // 更新
    void Update()
    {
    }
}
