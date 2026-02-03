using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using Unity.Collections.LowLevel.Unsafe;

public class Calculator:MonoBehaviour
{
    //金額text
    public TextMeshProUGUI Amount;

    //出したお金
    public TextMeshProUGUI spent;

    //結果表示テキスト
    public TextMeshProUGUI Answer;

    //貯まったお金
    public TextMeshProUGUI Savings;

    public RandomSprite randomSprite;
    public SceneChangeManager sceneChangeManager;
    public RandomComment randomComment;

    //各数字ボタン
    public Button[] bNumber;

    //計算ボタン
    public Button bEqual;

    //クリアボタン
    public Button bClear;

    //スキップボタン
    public Button bSkip;

    //変数たち
    int cnt = 0;
    int empty = 0;
    int answer = 0;

    int goal = 10000; //目標金額
    int savings_now = 0; //貯金金額

    //音声
    public AudioSource audioSource;
    public AudioClip soundEffect;
    public AudioClip incorrectEffect;
    private void Start()
    {
        //初期化
        Amount.text = "";
        Answer.text = "";
        spent.text = "";
        Savings.text = "";
        if (Amount != null)
        {
            RandomNum();
        }
        randomSprite.Random_Sprite();

       
    }

    private void Update()
    {
        
    }
    //ランダムで数値を出す
    public void RandomNum()
    {
        //Debug.Log("Randomが呼ばれました");
        int randomInt = Random.Range(50, 10000); //お買い物金額
        int randomMoney = Random.Range(50, 10000);　//出した金額
        
        if (randomMoney < randomInt)
        {
            Amount.text = randomInt.ToString("$#,# - ");
            
            spent.text = randomMoney.ToString("$#,#");
            //Debug.Log(randomInt);
            answer = randomInt - randomMoney;
            Debug.Log($"Answer{answer}");
            
        }
        else
        {
            RandomNum();
            //Debug.Log("お買い物金額より出した金額が大きかったです");
        }

    }
    //各数字ボタン押下
    public void InputNumber(TMP_Text number)
    {
        Answer.text += number.text; //Answerにボタンに対応したテキストを入力して表示
        Conversion(number);
       
        
    }

    //計算ボタン押下
    public void InputEqual(TMP_Text divideButton)
    {
        //正解していたら貯金する
        if (empty == answer) 
        {
            //初期化
            Amount.text = "";
            Answer.text = "";
            spent.text = "";
            if (savings_now == 0)
            {
                savings_now = empty;
            }
            else
            {
                savings_now = savings_now + empty;
            }
            Savings.text = savings_now.ToString("$#,#");
            if (Amount != null)
            {
                RandomNum();
                cnt = 0;
            }
            Debug.Log("正解です！次の問題に移ります");
            
            if (savings_now > 100000)
            {
                sceneChangeManager.ResultSceneChange();
            }
            randomSprite.Random_Sprite();
            randomComment.DisplayRandomText();
            audioSource.clip = soundEffect;
            SettlementEffect();
        }
        else
        {
            
            if (savings_now <300)
            {
                Answer.text = "";
                cnt = 0;
            }
            else
            {
                savings_now = savings_now - 300;
                Debug.Log("300点引かれます");
                Answer.text = "";
                cnt = 0;
                Savings.text = savings_now.ToString("$#,#");
                //Debug.Log($"不正解後{savings_now}");
            }
            audioSource.clip = incorrectEffect;
            IncorrectEffect();
            Debug.Log("不正解です！もう一度解きなおしてください！");
        }
        
    }

    //クリアボタン押下
    public void InputClear(TMP_Text equal)
    {
        Debug.Log("初期化しました");
        //初期化
        Answer.text = "";
        cnt = 0;
    }

    //スキップボタン押下
    public void InputSkip(TMP_Text skip)
    {
        Debug.Log("スキップしました！");
        //初期化
        
        
        if (savings_now < 100)
        {
            Amount.text = "";
            Answer.text = "";
            spent.text = "";
            cnt = 0;
            if (Amount != null)
            {
                RandomNum();
            }
        }
        else
        {
            Amount.text = "";
            Answer.text = "";
            spent.text = "";
            cnt = 0;
            savings_now = savings_now - 100;
            Savings.text = savings_now.ToString("$#,#");
            if (Amount != null)
            {
                RandomNum();
            }
            Debug.Log("スキップペナルティで100点引かれます");
        }
        randomSprite.Random_Sprite();
        randomComment.DisplayRandomText();

    }
    //数値に変換
    public void Conversion(TMP_Text number_C)
    {
        
        int num = int.Parse(number_C.text); //テキストを数値にしてnumに代入
           
            switch (cnt)
            {
                case 0:
                    empty = num;
                    break;
                case 1: //10以上の数を作りたい
                empty = empty * 10 + num;
                    break;
                case 2: //100以上の数を作りたい
                    empty = empty * 10 + num;
                    break;
                case 3:
                    empty = empty * 10 + num;
                    break;
                case 4:
                    empty = empty * 10 + num;
                    break;
                case 5:
                    empty = empty * 10 + num;
                    break;
                case 6:
                    empty = empty * 10 + num;
                    break;
                case 7:
                    empty = empty * 10 + num;
                    break;
                case 8:
                    empty = empty * 10 + num;
                    break;
                case 9:
                    empty = empty * 10 + num;
                    break;
                case 10:
                    empty = empty * 10 + num;
                    break;
                 default:
                    break;
            
            
           
        }
        //Debug.Log($"number{number_C}");
        //Debug.Log($"answer{num}");
        //Debug.Log($"empty{empty}");
        cnt = cnt + 1;
        Answer.text = ("￥");
        Answer.text = empty.ToString("$#,#");
        //Debug.Log($"{cnt}回呼ばれました");
        
    }
    
    public void SettlementEffect()
    {
        //正解時の音声再生
        audioSource.Play();
    }
    public void IncorrectEffect()
    {
        //不正解時の音声再生
        audioSource.Play();
    }
}
