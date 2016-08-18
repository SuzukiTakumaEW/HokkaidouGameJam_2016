using UnityEngine;
using System.Collections;

public abstract class Factory  : MonoBehaviour{

    public abstract void Init();
    public abstract GameObject Create(ActorParam param);
    public abstract void Delete(GameObject target);
}
