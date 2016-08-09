using UnityEngine;
using System.Collections;

/// <summary>
/// 仲介者クラス(メディエーター)
/// </summary>
public interface SystemInterface {

    ActorManager GetActorManager();
    WorldState GetGameState();

}
