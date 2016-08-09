using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager mInstance;

    public static GameManager GetInstance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<GameManager>();
            }
            return mInstance; 
        }
    }

}
