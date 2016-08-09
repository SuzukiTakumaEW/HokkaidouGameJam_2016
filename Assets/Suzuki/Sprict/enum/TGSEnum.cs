using UnityEngine;
using System.Collections;

/// <summary>
/// 参照用enum
/// </summary>
public class TGSEnum {

    public enum ActorType
    {
        NULL = 0,
        House,      //家
        BlueHouse,
        Building,
        Mole,
        Count       //種類数
    }

    public enum ParticleType
    {
        NULL = 0,
        Wall = 50,              //壁
        BreakWall = 100,        //壊れる壁
        Maguma = 200,           //マグマ
        Actor = 300,            //Actor

        Count                   //種類数
    }

    public enum WallType
    {
        Standard = 0
    }

    public enum GameState
    {
        Stop = 0,
        Leady,
        Load,
        Update,

    }

    public enum MagumaType
    {
        Standard = 0,
        Strong,
        ActorPrice,
        Finger,
        Count
    }

    public enum ActorPrice
    {
        NULL = 0,
        Total,
        House,      //家
        BlueHouse,
        Building,
        Mole,
        Count       //種類数
    }

}
