using UnityEngine;
using System.Collections;

public class TysonFactory : Factory {

    public override void Init()
    {
        Tyson.Log("初期化");
    }

    public override GameObject Create(ActorParam param)
    {
        //適当に生成するべき
        GameObject target = Instantiate(ResouceLoader.Getinstance.GetLoadObject("Image")) as GameObject;
        DebugActor actor = target.AddComponent<DebugActor>();
        actor.Init(param);
        return null;
    }

    public override void Delete(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
