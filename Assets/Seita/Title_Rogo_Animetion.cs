using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// タイトルロゴマネージャ
public class Title_Rogo_Animetion : MonoBehaviour
{
    //=====================================================================
    //                             メンバ変数
    //=====================================================================
    // 外部入力値
    [SerializeField]
    private float   m_fDistanceMove;            // 移動距離(揺れ幅)
    [SerializeField]
    private float   m_fAnimetionSpeed;          // 揺れる速さ

    // 変数
    private TextMeshPro     m_pTextMeshProComponent;        // テキストメッシュプロコンポーネント


    //=====================================================================
    //                             メンバ関数
    //=====================================================================
    // テキスト波打ち処理
    private void    TextWaveAnimation()
    {
        // テキストメッシュプロ内の情報を取得
        TMP_TextInfo    pTextMeshInfo = m_pTextMeshProComponent.textInfo;

        // もしテキスト数が0でないのなら...
        if(pTextMeshInfo.characterCount != 0)
        {
            // 一文字ごとに処理する
            for(int nCharCount = 0; nCharCount < pTextMeshInfo.characterCount; nCharCount++)
            {
                // 文字ごとの情報を取得
                TMP_CharacterInfo pCharInfoData = pTextMeshInfo.characterInfo[nCharCount];

                // 参照しているマテリアルのインデックスを受け取る
                int nMaterialIndex = pCharInfoData.materialReferenceIndex;

                // 参照している頂点のインデックスを受け取る
                int nVertexIndex = pCharInfoData.vertexIndex;

                // テキスト全体の頂点をもらう
                Vector3[]   pTextVertexes = pTextMeshInfo.meshInfo[nMaterialIndex].vertices;

                // 移動する分
                float   fMoveValue = Mathf.Sin(Time.time * m_fAnimetionSpeed + 10 * nCharCount);

                // メッシュ情報にアニメ―ション後の頂点情報を入れる
                pTextVertexes[nVertexIndex] += m_fDistanceMove * (Vector3.down * fMoveValue);
                pTextVertexes[nVertexIndex + 1] += m_fDistanceMove * (Vector3.down * fMoveValue);
                pTextVertexes[nVertexIndex + 2] += m_fDistanceMove * (Vector3.down * fMoveValue);
                pTextVertexes[nVertexIndex + 3] += m_fDistanceMove * (Vector3.down * fMoveValue);
            }

            // ジオメトリ情報更新
            for(int nMesh = 0; nMesh < pTextMeshInfo.meshInfo.Length; nMesh++)
            {
                // メッシュ情報を実際の頂点メッシュに反映する
                pTextMeshInfo.meshInfo[nMesh].mesh.vertices = pTextMeshInfo.meshInfo[nMesh].vertices;

                // ジオメトリを更新
                m_pTextMeshProComponent.UpdateGeometry(pTextMeshInfo.meshInfo[nMesh].mesh, nMesh);
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
        m_pTextMeshProComponent = GetComponent<TextMeshPro>();
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // 毎フレームメッシュを更新
        m_pTextMeshProComponent.ForceMeshUpdate();

        // テキストに波をつける
        TextWaveAnimation();
    }
}
