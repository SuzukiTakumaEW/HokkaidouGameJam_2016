using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// 時間管理
/// </summary>
public class WorldTimer : GameSystem
{
    [SerializeField]
    private float mWorldTime;

    public override void Init(SystemInterface sysyem)
    {
        Tyson.Log(this);
        mSystem = sysyem;
        mWorldTime = Variables.LimitTime;
    }

    public override void SystemUpdate(float deltaTime)
    {
        if(IsUpdate())
        {
            AddTime(deltaTime);
        }

        //時間切れ
        if (IsTimeOver())
        {
            mSystem.GetGameState().ChangeState(TGSEnum.GameState.Stop);
            mWorldTime = 0;
        }
    }

    /// <summary>
    /// 現在の更新状態
    /// </summary>
    /// <returns></returns>
    private bool IsUpdate()
    {
        return mSystem.GetGameState().GetGameState() == TGSEnum.GameState.Update;
    }

    /// <summary>
    /// 時間切れか
    /// </summary>
    /// <returns></returns>
    public bool IsTimeOver()
    {
        return mWorldTime < 0;
    }

    /// <summary>
    /// 時間の減らす
    /// </summary>
    /// <param name="time"></param>
    private void AddTime(float time)
    {
        mWorldTime -= time;
    }


    public float GetTime()
    {
        return mWorldTime;
    }

}
