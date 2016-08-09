using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TransformUtility : MonoBehaviour {

    public static List<GameObject> SearchChild(GameObject parent)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Transform i in parent.transform)
        {
            list.Add(i.gameObject);
        }
        return list;
    }
}
