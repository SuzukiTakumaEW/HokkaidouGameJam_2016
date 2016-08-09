using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class ResouceLoader : MonoBehaviour {

    private static ResouceLoader mInstance = null;
    private static Dictionary<string,Object> mLoadObject=new Dictionary<string,Object>();

    private int mResouceItemCount = 0;

    #region

    public static ResouceLoader Getinstance
    {
        get { if (mInstance == null) { mInstance = FindObjectOfType<ResouceLoader>(); } return mInstance; }
    }

    private void Awake()
    {
        int width = 1920;
        int height = 1200;

        bool fullscreen = true;

        int preferredRefreshRate = 60;

        Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
    }

    /// <summary>
    /// 指定したフォルダー内に存在するAssetのパスを取得する。
    /// </summary>
    public string[] GetTargetFolderItemPaths(string path, string target = "*.prefab",bool nameonly = true)
    {
        //一文字以上のファイルのみ検索。"*.txt"
        string root = "";
#if UNITY_EDITOR
        root = Application.dataPath + "/Resources/";
#else
        root = Application.streamingAssetsPath  + "/Resources/";
# endif
        //string root = Application.dataPath + "/Resources/";
        //Application.persistentDataPath
        string[] names = Directory.GetFiles(root+path+"/", target);
        //.prefubを消して返す。
        if (nameonly)
        {
            for (int i = 0; i < names.Length; i++) {
                names[i] = names[i].Substring(root.Length);
                names[i] = names[i].Substring(0, names[i].Length - 7); 
            }
        }
        return names;
    }

    /// <summary>
    /// 非同期ロード
    /// </summary>
    /// <param name="path"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public IEnumerator LoadAnsy(string path, string name)
    {
        ResourceRequest res = Resources.LoadAsync(path, typeof(GameObject));
        mResouceItemCount++;
        while (res.isDone == false)
        {
            Tyson.Log(name + " : "+"ロード中 : " + res.progress.ToString(),"blue");
            yield return 0;
        }
        mLoadObject.Add(name,(Object)res.asset);
        Tyson.Log(name + " : " + "ロード完了","green");
    }

    public void LoadPathAll(string path)
    {
        foreach(var i in Resources.LoadAll(path+"/"))
        {
            if(!mLoadObject.ContainsKey(i.name))
            mLoadObject.Add(i.name,(Object)i);
        }
    }

    /// <summary>
    /// ロード
    /// </summary>
    /// <param name="path"></param>
    /// <param name="name"></param>
    public void Load(string path,string name)
    {
        if (IsLoad(path)) return;
        mResouceItemCount++;
        mLoadObject.Add(name,Resources.Load(path));
    }

    /// <summary>
    /// ロード済みオブジェクトの取得
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Object GetLoadObject(string name)
    {
        return mLoadObject[name];
    }

    /// <summary>
    /// 必要なリソースが揃っているか
    /// </summary>
    /// <returns></returns>
    public bool IsItemLoadComplete()
    {
        if (mLoadObject.Count >= mResouceItemCount) return true;
        return false;
    }

    /// <summary>
    /// ロードが済みか?
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool IsLoad(string name)
    {
        if (mLoadObject.ContainsKey(name)) return true;
        return false;
    }

    //public T GetComponent<T>() where T : Component

    [ContextMenu("LoadObjectName")]
    private void Print()
    {
        UnityEngine.Debug.Log("ロードコンテンツ : "+mLoadObject.Count);
        foreach (var i in mLoadObject)
        {
            Tyson.Log("Key : "+i.Key);
            Tyson.Log("Value : "+i.Value.name);
        }
    }

#endregion
}
