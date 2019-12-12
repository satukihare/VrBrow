using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// タイトルマネージャー
public class Title_Manager : MonoBehaviour
{
    //=====================================================================
    //                             メンバ変数
    //=====================================================================
    // 外部入力値
    [SerializeField]
    private GameObject      m_pTitleRogoObject;             // タイトルロゴ
    private Title_Scaling   m_pTitleScalingComponent;       // タイトルロゴサイズ変化用コンポーネント
    [SerializeField]
    private GameObject      m_pCheckButtonRogoObject;       // ボタン確認ロゴ
    private Title_Fade      m_pCheckButtonFadeComponent;    // ボタン確認ロゴサイズ変化用コンポーネント

    // 変数
    private bool            m_bTitleSwitch;                 // タイトル表示スイッチ
    private bool            m_bTitleShow;                   // タイトルが出きったかフラグ
    private bool            m_bTitleHide;                   // タイトルが消え切ったかフラグ


    //=====================================================================
    //                             メンバ関数
    //=====================================================================
    // タイトルアニメーション制御
    public void TitleFlag(bool bTitleSwitchFlag)
    {
        // 表示
        if (m_pCheckButtonFadeComponent.GetSizeOut() && m_pTitleScalingComponent.GetSizeOut())
        {
            m_bTitleSwitch = bTitleSwitchFlag;
        }

        // 非表示
        if (m_pCheckButtonFadeComponent.GetSizeIn() && m_pTitleScalingComponent.GetSizeIn())
        {
            m_bTitleSwitch = bTitleSwitchFlag;
        }
    }

    // タイトルが出きったか渡す
    public bool TitleShowFlag()
    {
        return m_bTitleShow;
    }

    // タイトルが消え切ったか渡す
    public bool TitleHideFlag()
    {
        return m_bTitleHide;
    }

    // タイトルが出きったか消え切ったかフラグを切り替えていく
    private void HideShowCheck()
    {
        // 両フラグを初期化
        m_bTitleHide = m_bTitleShow = false;

        // 非表示
        if(m_pCheckButtonFadeComponent.GetSizeOut() && m_pTitleScalingComponent.GetSizeOut() && !m_pCheckButtonFadeComponent.GetSizeIn() && !m_pTitleScalingComponent.GetSizeIn())
        {
            m_bTitleHide = true;
        }

        // 表示
        if (!m_pCheckButtonFadeComponent.GetSizeOut() && !m_pTitleScalingComponent.GetSizeOut() && m_pCheckButtonFadeComponent.GetSizeIn() && m_pTitleScalingComponent.GetSizeIn())
        {
            m_bTitleShow = true;
        }
    }

    // タイトルアニメーション
    private void TitleAnimation()
    {
        // 表示
        if (m_bTitleSwitch)
        {
            // タイトルを表示
            m_pTitleScalingComponent.ChangeFadeSwitch(true);

            // もしタイトルが表示しきったら
            if (m_pTitleScalingComponent.GetSizeIn())
            {
                m_pCheckButtonFadeComponent.ChangeFadeSwitch(false);
            }
        }
        // 非表示
        else
        {
            // タイトルを表示
            m_pCheckButtonFadeComponent.ChangeFadeSwitch(true);

            // もしタイトルが消えたら
            if (m_pCheckButtonFadeComponent.GetSizeOut())
            {
                m_pTitleScalingComponent.ChangeFadeSwitch(false);
            }
        }
    }


    //=====================================================================
    //                              基本関数
    //=====================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        m_pTitleScalingComponent = m_pTitleRogoObject.GetComponent<Title_Scaling>();
        m_pCheckButtonFadeComponent = m_pCheckButtonRogoObject.GetComponent<Title_Fade>();

        // 変数初期化
        m_bTitleSwitch = true;
        m_bTitleShow = m_bTitleHide = false;
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // テスト
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(m_bTitleSwitch)
            {
                TitleFlag(false);
            }
            else
            {
                TitleFlag(true);
            }
        }

        // タイトルアニメーション
        TitleAnimation();

        // タイトルの状態確認
        HideShowCheck();
    }
}
