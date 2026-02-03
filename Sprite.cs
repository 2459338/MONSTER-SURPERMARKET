using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class RandomSprite:MonoBehaviour
{
    //画像一覧の配列
    public GameObject[] sprite;

    public GameObject currentSprite;
    public Vector3 spawnPosition; //出現位置

    public int i; //ランダムで選ばれるインデックス

    //private void Start()
    //{
    //    i = Random.Range(0, sprite.Length); //配列からランダムなインデックスを選ぶ
    //    Instantiate(sprite[i], spawnPosition, Quaternion.identity); //ランダムなオブジェクトを生成
    //    Debug.Log("ランダムなスプライトを表示");
    //}

    public void Random_Sprite()
    {
      
        if(currentSprite!=null)
        {
            Destroy(currentSprite);
            //Debug.Log("前の画像を消します");
        }
        i = Random.Range(0, sprite.Length); //配列からランダムなインデックスを選ぶ
        //Debug.Log($"{i}");
        currentSprite=Instantiate(sprite[i], spawnPosition, Quaternion.identity); //ランダムなオブジェクトを生成
        //Debug.Log("ランダムなスプライトを表示");
    }

    //public void SpriteHidden()
    //{
        
    //    foreach(GameObject obj in sprite)
    //    {
    //        obj.SetActive(false);
    //        Debug.Log("オブジェクトを消します");
    //    }
    //}

}
