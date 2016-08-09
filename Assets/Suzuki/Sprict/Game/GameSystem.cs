using UnityEngine;
using System.Collections;

public abstract class GameSystem : MonoBehaviour {

    protected SystemInterface mSystem;

    public virtual void Init(SystemInterface sysyem)
    {
        mSystem = sysyem;
    }

    public abstract void SystemUpdate(float deltaTime);

    public virtual void Delete()
    {

    }

}
