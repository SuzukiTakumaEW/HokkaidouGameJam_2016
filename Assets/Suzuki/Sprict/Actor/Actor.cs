using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;
using System.Runtime.InteropServices;
/// <summary>
/// 規定クラス
/// </summary>
public class Actor : MonoBehaviour
{
    public ActorParam mActorParam;

    /// <summary>
    /// GameObject型の拡張メソッドを管理するクラス
    /// </summary>
    public virtual void Init(ActorParam param)
    {
        mActorParam = param;
    }

    /// <summary>
    /// Actorの当たり判定時の処理
    /// </summary>
    /// <param name="partsysptr"></param>
    /// <param name="Indices"></param>
    /// <param name="position"></param>
    public virtual void CheckBodyColliderOnParticle(GameObject target)
    {

    }

}