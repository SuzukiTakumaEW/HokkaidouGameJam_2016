using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameMain : MonoBehaviour{

    private static GameMain mInstance;

    private List<GameSystem> mSystem = new List<GameSystem>();
    private WorldState mGameState;

    public static GameMain GetInstance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<GameMain>();
            }
            return mInstance;
        }
    }

	// Use this for initialization
	void Awake () {

        mGameState = new WorldState();
        Init();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Init()
    {
        AppStartUp startup = GetComponent<AppStartUp>();
        startup.StartUp(() => { 
           StartUp(); 
        });
    }

    /// <summary>
    /// StartUp
    /// </summary>
    private void StartUp()
    {
        IGameSystem game = new IGameSystem(mGameState, new ActorManager());
        //とりあえずタイマーだけある。
        //GameSystemを継承したクラスを追加していく。
        Tyson.Log("ゲームシステム初期化");
        mSystem.Add(gameObject.AddComponent<WorldTimer>());
        foreach (var system in mSystem)
        {
            system.Init(game);
        }
    }

	
	// Update is called once per frame
	void Update () {
        if (GameMain.GetInstance.GetState().GetGameState() != TGSEnum.GameState.Update) return;
        foreach(var i in mSystem)
        {
            i.SystemUpdate(Time.deltaTime);
        }
	}

    public WorldState GetState()
    {
        return mGameState;
    }

    [ContextMenu("Change")]
    private void DebugChange()
    {
        GetState().ChangeState(TGSEnum.GameState.Update);
    }



    [ContextMenu("Log")]
    private void Print()
    {
        Tyson.Log(GetState().GetGameState());
    }



}
