using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title_Scaling : MonoBehaviour
{
    //=====================================================================
    //                             メンバ変数
    //=====================================================================
    // 外部入力値
    [SerializeField, Range(0.0f, 1.0f)]
    private float           m_fSizeChangeSpeed;             // フェード速度

    // 変数
    private TextMeshPro     m_pTextMeshProComponent;        // テキストメッシュプロコンポーネント
    private float           m_fDefaultFontSize;             // 通常のフォントサイズ
    private float           m_fFontSize;                    // フォントサイズ
    private float           m_fChangeSizeSpeed;             // サイズ切り替え速度
    private bool            m_bSizeOut;                     // フォントが最小
    private bool            m_bSizeIn;                      // フォントが最大
    private bool            m_bSizeSwitch;                  // フェードスイッチ(縮小 が False, 拡大 が true)


    //=====================================================================
    //                             メンバ関数
    //=====================================================================
    // サイズアウトしたか状態を渡す
    public bool GetSizeOut()
    {
        return m_bSizeOut;
    }

    // サイズインしたか状態を渡す
    public bool GetSizeIn()
    {
        return m_bSizeIn;
    }

    // サイズ変化スイッチ(true で 拡大, false で縮小)
    public void ChangeFadeSwitch(bool bFadeSwitch)
    {
        // 切り替え時のみ更新
        if (m_bSizeSwitch != bFadeSwitch)
        {
            m_bSizeSwitch = bFadeSwitch;
        }
    }

    // フェード値変化
    private void ChangeFontSize()
    {
        // フォントが消えたかフラグ と 出たかフラグ を初期化
        m_bSizeOut = false;
        m_bSizeIn = false;

        // スイッチで切り替え
        // 縮小
        if (!m_bSizeSwitch)
        {
            // フォントサイズ縮小
            m_fFontSize -= m_fChangeSizeSpeed;

            // 制限
            if (m_fFontSize < 0.0f)
            {
                m_fFontSize = 0.0f;

                // 完全にフォントが消えたことを伝える
                m_bSizeOut = true;
            }
        }
        // 拡大
        else
        {
            // フォントサイズ拡大
            m_fFontSize += m_fChangeSizeSpeed;

            // 制限
            if (m_fFontSize > m_fDefaultFontSize)
            {
                m_fFontSize = m_fDefaultFontSize;

                // 完全にフォントが大きくなったことを伝える
                m_bSizeIn = true;
            }
        }
    }

    // テキストフェード
    private void ChangeSIzeFunction()
    {
        // 色更新
        m_pTextMeshProComponent.fontSize = m_fFontSize;
    }


    //=====================================================================
    //                              基本関数
    //=====================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        m_pTextMeshProComponent = GetComponent<TextMeshPro>();

        // テキスト拡縮速度確定処理
        m_fDefaultFontSize = m_fFontSize = m_pTextMeshProComponent.fontSize;
        m_fChangeSizeSpeed = m_fDefaultFontSize * m_fSizeChangeSpeed;

        // 変数初期化
        m_bSizeSwitch = true;
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // サイズ切り替え処理
        ChangeFontSize();

        // サイズ変更処理
        ChangeSIzeFunction();
    }
}
