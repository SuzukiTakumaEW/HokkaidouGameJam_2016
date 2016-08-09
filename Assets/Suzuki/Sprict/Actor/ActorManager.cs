using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// シングルトンにしない。TODO GameManagerに
/// </summary>
public class ActorManager {

    private List<Actor> mActors = new List<Actor>();

    /// <summary>
    /// 対象のActorのゲームオブジェクトの検索
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public List<GameObject> FindTargetActor(TGSEnum.ActorType type)
    {
        List<GameObject> list = new List<GameObject>();
        foreach(var i in mActors)
        {
            if (i.mActorParam.mActorType == type) list.Add(i.gameObject);
        }
        return list;
    }



    /// <summary>
    /// 指定されたレベル以下のものを返す。
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public List<GameObject> TargetActorLevelIndex(int level)
    {
        List<GameObject> list = new List<GameObject>();
        foreach(var i in mActors)
        {
            if(i.mActorParam.mActorLevel <= level)list.Add(i.gameObject);
        }
        return list;
    }

    public List<Actor> GetActors()
    {
        return mActors;
    }

    public void AddActor(Actor actor)
    {
        mActors.Add(actor);
    }

    public bool AllActorsDead()
    {
        foreach (var i in mActors)
        {
            if (i.mActorParam.mPrice > 0) return false;
        }
        return true;
    }
}
