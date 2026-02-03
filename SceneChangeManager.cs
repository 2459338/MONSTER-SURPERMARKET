using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class SceneChangeManager:MonoBehaviour
{
    //Mainシーンに遷移するメソッド
    public void MainSceneChange()
    {
        SceneManager.LoadScene("Main");
        DontDestroyOnLoad(gameObject);
    }
    //Resultシーンに遷移するメソッド
    public void ResultSceneChange()
    {
        SceneManager.LoadScene("Result");
        DontDestroyOnLoad(gameObject);
    }
    //Titleシーンに遷移するメソッド
    public void TitleSceneChange()
    {
        SceneManager.LoadScene("Title");
        DontDestroyOnLoad(gameObject);
    }
}
