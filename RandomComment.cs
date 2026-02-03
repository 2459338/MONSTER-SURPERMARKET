using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RandomComment:MonoBehaviour
{
    //セリフ一覧(会計時)
    [SerializeField] private string[] randomTextsBone;

    //セリフ一覧(会計時)
    [SerializeField] private string[] randomTextsCat;
    
    //セリフ一覧(会計時)
    [SerializeField] private string[] randomTextsPumpkin;

    //セリフ一覧(会計時)
    [SerializeField] private string[] randomTextsGost;

    //セリフ一覧(会計時)
    [SerializeField] private string[] randomTextsWitch;

    public RandomSprite randomSprite;
   
    //セリフ表示用テキスト
    [SerializeField] private Text displayText;

    //表示するセリフUIパネル
    [SerializeField] public GameObject dialogWindow;

    [SerializeField] public GameObject Bone, Wicth, Pumpkin, Gost, Cat;
    private int index = 0;
    private void Start()
    {
        CommentDisplay();
    }

    public void CommentDisplay()
    {
        index = 0; //毎回初期化
        dialogWindow.SetActive(true);
        DisplayRandomText();
    }

    public void DisplayRandomText()
    {
        randomSprite = randomSprite.GetComponent<RandomSprite>();
        //Debug.Log(randomSprite.i);
        // ランダムなインデックスを取得
        
        switch (randomSprite.i)
        {
            case 0:
                index = Random.Range(0, randomTextsGost.Length);
                displayText.text = randomTextsGost[index];
                break;

            case 1:
                index = Random.Range(0, randomTextsBone.Length);
                displayText.text = randomTextsBone[index];
                break;

            case 2:
                index = Random.Range(0, randomTextsCat.Length);
                displayText.text = randomTextsCat[index];
                break;

            case 3:
                index = Random.Range(0, randomTextsPumpkin.Length);
                displayText.text = randomTextsPumpkin[index];
                break;

            case 4:
                index = Random.Range(0,randomTextsWitch.Length);
                displayText.text = randomTextsWitch[index];
                break;

        }

    }

    //正解時のセリフ
  
}
