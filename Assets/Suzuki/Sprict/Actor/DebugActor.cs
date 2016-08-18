using UnityEngine;
using System.Collections;

public class DebugActor : Actor {

    /// <summary>
    /// GameObject型の拡張メソッドを管理するクラス
    /// </summary>
    public override void Init(ActorParam param)
    {
        base.Init(param);
        Tyson.Log(mActorParam.mActorType);
    }
}
