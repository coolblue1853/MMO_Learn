using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    //ΩÃ±€≈œ ∆–≈œ
    static Managers s_instance;
    public static Managers Instance { get { Init(); return s_instance; } }

    DataManager _Data = new DataManager();
    InputManager _input = new InputManager(); 
    ResourceManager _resource = new ResourceManager();
    PoolManager _pool = new PoolManager();
    UIManager _ui = new UIManager();
    SoundManager _sound = new SoundManager();
    SceneManagerEx _scene = new SceneManagerEx();
    public static DataManager Data { get { return Instance._Data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("Managers");
            if(go == null)
            {
                go = new GameObject { name = "Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._Data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
        }
    }
    // æ¿ ¿ÃµøΩ√ ªË¡¶«ÿ¡‡æﬂ «œ¥¬ ≥‡ºÆµÈ
    public static void Clear()
    {
        Sound.Clear();
        Input.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
    }
}
