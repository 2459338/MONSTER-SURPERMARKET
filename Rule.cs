using UnityEngine;
using UnityEngine.UI;
public class Rule:MonoBehaviour
{
    //ルールブックUI
    public GameObject RuleUI;

    //ルールブック表示切替ボタン
    public GameObject RuleButton;

    //ルールブック日表示切替ボタン
    public Button RuleCloseButton;

    public void Start()
    {
        RuleUI.SetActive(false);
    }

    public void InputOpen()
    {
        RuleUI.SetActive(true);
        RuleButton.SetActive(false);
    }

    public void InputClose()
    {
        RuleUI.SetActive(false);
        RuleButton.SetActive(true);
    }
}
