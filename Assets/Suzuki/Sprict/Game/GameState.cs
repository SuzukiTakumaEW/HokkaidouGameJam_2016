using UnityEngine;
using System.Collections;

public class GameState {

    private TGSEnum.GameState mGameState;

    public TGSEnum.GameState ChangeState(TGSEnum.GameState state)
    {
        mGameState = state;
        return state;
    }

    public TGSEnum.GameState GetState()
    {
        return mGameState;
    }

}
