using UnityEngine;
using System.Collections;

public class Tyson : MonoBehaviour {

    public GameObject parent;

    public static void Log(object log,string color = "black")
    {
        UnityEngine.Debug.Log("<color="+color+">"+log+"</color>");
    }

    [ContextMenu("parent")]
    private void Parent()
    {
        transform.SetParent(parent.transform);
    }

}
