using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorFactory {

    private List<Factory> mFactory = new List<Factory>();

    public ActorFactory()
    {
        GameObject parent = new GameObject();
        parent.name = "ActorFactory";
        mFactory.Add(parent.AddComponent<TysonFactory>());
    }

    public GameObject CreateTarget(ActorParam param)
    {
        return mFactory[(int)param.mActorType].Create(param);
    }

}
