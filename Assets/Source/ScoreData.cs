﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// スコアデータテーブル
[CreateAssetMenu(menuName = "MyGame/ScoreData ScoreTable", fileName = "ScoreTable")]
public class ScoreData : ScriptableObject
{
    [SerializeField]
    public int m_nTotalScore;               // スコア合計
    [SerializeField]
    public int m_nHighRateTargetHitScore;   // 高得点的に当たった時のスコア
    [SerializeField]
    public int m_nNomalRateTargetHitScore;  // 中得点的に当たった時のスコア
    [SerializeField]
    public int m_nRowRateTargetHitScore;    // 低得点的に当たった時のスコア
}
