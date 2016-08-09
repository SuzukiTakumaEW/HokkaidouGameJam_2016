using UnityEngine;
using System.Collections;

public class WorldState  {

    private TGSEnum.GameState mGameState;

    public TGSEnum.GameState ChangeState(TGSEnum.GameState state)
    {
        mGameState = state;
        return mGameState;
    }

    public TGSEnum.GameState GetGameState()
    {
        return mGameState;
    }

}
