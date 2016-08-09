using UnityEngine;
using System.Collections;

public class AppStartUp : MonoBehaviour {

    private GameMain mGameManager;
    private ResouceLoader mLoader;

    [SerializeField]
    private string[] mPaths;

	// Use this for initialization
	public void StartUp (UnityEngine.Events.UnityAction action) {

        mGameManager = GameMain.GetInstance;
        mLoader = ResouceLoader.Getinstance;
        StartCoroutine(StartUpReady(action));
	}

    /// <summary>
    /// 対象フォルダのリソースをロードしておく
    /// </summary>
    private void AppStartUpLoadObject()
    {
        foreach (var path in mPaths)
        {
            foreach (var i in mLoader.GetTargetFolderItemPaths(path))
            {
                StartCoroutine(mLoader.LoadAnsy(i,i.Substring(path.Length + 1)));
            }
        }
    }

    /// <summary>
    /// 必要なリソースのロード
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    private IEnumerator StartUpReady(UnityEngine.Events.UnityAction action)
    {
        mGameManager.GetState().ChangeState(TGSEnum.GameState.Leady);
#if UNITY_EDITOR
        yield return new WaitForEndOfFrame();
        mLoader.LoadPathAll(mPaths[0]);
        //AppStartUpLoadObject();
        //if (!mLoader.IsItemLoadComplete())
        //{
        //    //Load中の画面を出しておく
        //    mGameManager.GetState().ChangeState(TGSEnum.GameState.Load);
        //    yield return new WaitForEndOfFrame();
        //}
# else
        yield return new WaitForEndOfFrame();
        mLoader.LoadPathAll(mPaths[0]);
# endif

        Tyson.Log("ゲーム開始時に必要な全てのリソースのロード完了","green");
        action();
        yield return null;
    }

}
