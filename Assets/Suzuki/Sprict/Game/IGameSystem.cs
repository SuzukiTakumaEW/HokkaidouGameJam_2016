using UnityEngine;
using System.Collections;

public class IGameSystem : SystemInterface
{
    private WorldState mState;
    private ActorManager mActorManager;
    private int mlevel;

    public IGameSystem(WorldState state,ActorManager actor)
    {
        mState = state;
        mActorManager = actor;
    }

    public ActorManager GetActorManager()
    {
        return mActorManager;
    }

    public WorldState GetGameState()
    {
        return mState;
    }
}
