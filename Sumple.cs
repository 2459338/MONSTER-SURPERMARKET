using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sumple : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_InputField resultField;

    private string currentInput = ""; // 数式を保持
    private bool isResultDisplayed = false;

    // ボタンを押したときの処理
    public void OnButtonClick(string value)
    {
        Debug.Log($"Button Pressed: {value}");

        // 直前に計算結果が表示されていた場合
        if (isResultDisplayed)
        {
            // 数字が押された場合は currentInput をリセット
            if (char.IsDigit(value[0]) || value == ".")
            {
                currentInput = value;
            }
            // 演算子が押された場合は、計算結果を継続
            else
            {
                currentInput += value;
            }
            isResultDisplayed = false;
        }
        else
        {
            currentInput += value;
        }

        inputField.text = currentInput;
        Debug.Log($"Updated Input: {currentInput}");
    }

    // クリアボタンの処理
    public void OnClearClick()
    {
        Debug.Log("Clear Pressed");
        currentInput = "";
        inputField.text = "";
        resultField.text = "";
        isResultDisplayed = false;
    }

    // 計算結果を表示
    public void OnEqualClick()
    {
        Debug.Log($"Evaluating: {currentInput}");

        try
        {
            float result = EvaluateExpression(currentInput);
            Debug.Log($"Final Result: {result}");

            // 計算結果を currentInput に保存（次の計算に使えるようにする）
            currentInput = result.ToString();
            inputField.text = currentInput; // 入力フィールドに結果を表示
            resultField.text = currentInput; // 結果フィールドにも表示

            isResultDisplayed = true; // 計算完了フラグをセット
        }
        catch
        {
            resultField.text = "Error";
            Debug.LogError("Calculation Error");
        }
    }

    // 数式の評価
    private float EvaluateExpression(string expression)
    {
        Debug.Log($"Computing: {expression}");

        try
        {
            expression = expression.Replace("\"", "");

            object result = new System.Data.DataTable().Compute(expression, "");
            Debug.Log($"Computed Result: {result}");
            return float.Parse(result.ToString());
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in computation: {ex.Message}");
            return 0;
        }
    }

    // +/- ボタンの処理
    private void ToggleSign()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            if (currentInput[0] == '-')
                currentInput = currentInput.Substring(1);
            else
                currentInput = "-" + currentInput;

            inputField.text = currentInput;
        }
    }

    // % ボタンの処理
    private void ApplyPercentage()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            try
            {
                float value = float.Parse(currentInput) / 100f;
                currentInput = value.ToString();
                inputField.text = currentInput;
            }
            catch
            {
                resultField.text = "Error";
            }
        }
    }
}
