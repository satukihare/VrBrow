using UnityEngine;

public class RuntimeInitializer : MonoBehaviour
{
    //アプリケーション開始時に一度だけ初期化
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AppInitialize()
    {
    }
}
