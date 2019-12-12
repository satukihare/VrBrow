using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title_Fade : MonoBehaviour
{
    //=====================================================================
    //                             メンバ変数
    //=====================================================================
    // 外部入力値
    [SerializeField, Range(0.0f, 1.0f)]
    private float           m_fFadeSpeed;                   // フェード速度

    // 変数
    private TextMeshPro     m_pTextMeshProComponent;        // テキストメッシュプロコンポーネント
    private float           m_fFadeAlpha;                   // α値
    private bool            m_bFadeIn;                      // フェードイン
    private bool            m_bFadeOut;                     // フェードアウト
    private bool            m_bFadeSwitch;                  // フェードスイッチ(フェードインがFalse, フェードアウトがtrue)


    //=====================================================================
    //                             メンバ関数
    //=====================================================================
    // フェードアウトしたか状態を渡す
    public bool GetSizeOut()
    {
        return m_bFadeOut;
    }

    // フェードインしたか状態を渡す
    public bool GetSizeIn()
    {
        return m_bFadeIn;
    }

    // フェードスイッチ
    public  void    ChangeFadeSwitch(bool bFadeSwitch)
    {
        // 切り替え時のみ更新
        if(m_bFadeSwitch != bFadeSwitch)
        {
            m_bFadeSwitch = bFadeSwitch;
        }
    }

    // フェード値変化
    private void    ChangeAlphaValue()
    {
        // フェードアウトしたかフラグ と フェードインしたかフラグ を初期化
        m_bFadeOut = false;
        m_bFadeIn = true;

        // スイッチで切り替え
        // フェードイン
        if(!m_bFadeSwitch)
        {
            // α値加算
            m_fFadeAlpha += m_fFadeSpeed;

            // 制限
            if(m_fFadeAlpha > 1.0f)
            {
                m_fFadeAlpha = 1.0f;

                // 完全にフェードインしたことを伝える
                m_bFadeIn = true;
            }
        }
        // フェードアウト
        else
        {
            // α値加算
            m_fFadeAlpha -= m_fFadeSpeed;

            // 制限
            if (m_fFadeAlpha < 0.0f)
            {
                m_fFadeAlpha = 0.0f;

                // 完全にフェードアウトしたことを伝える
                m_bFadeOut = true;
            }
        }
    }

    // テキストフェード
    private void    FadeFunction()
    {
        // 色更新
        m_pTextMeshProComponent.color = new Color(m_pTextMeshProComponent.color.r, m_pTextMeshProComponent.color.g, m_pTextMeshProComponent.color.b, m_fFadeAlpha);
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

        // 変数初期化
        m_fFadeAlpha = 1.0f;
        m_bFadeOut = false;
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // フェード値変化
        ChangeAlphaValue();

        // フェード値更新
        FadeFunction();
    }
}
