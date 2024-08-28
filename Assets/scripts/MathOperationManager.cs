using UnityEngine;

public class MathOperationManager : MonoBehaviour
{
    public ResultTextManager resultTextManager;

    private int? number1;
    private int? number2;
    private string operation;

    public Transform target1;
    public Transform target2;

    public void SetNumber1(int? num, Transform target)
    {
        number1 = num;
        target1 = target;
        Evaluate();
    }

    public void SetNumber2(int? num, Transform target)
    {
        number2 = num;
        target2 = target;
        Evaluate();
    }

    public void SetOperation(string op)
    {
        operation = op;
        Evaluate();
    }

    public void Evaluate()
    {
        if (number1.HasValue && number2.HasValue && !string.IsNullOrEmpty(operation))
        {
            int firstNumber = number1.Value;
            int secondNumber = number2.Value;

            // Determine the order based on positions
            if (target1.position.x > target2.position.x)
            {
                firstNumber = number2.Value;
                secondNumber = number1.Value;
            }

            int result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    break;
            }

            if (resultTextManager != null)
            {
                resultTextManager.UpdateResultText(result);
            }
        }
        else
        {
            if (resultTextManager != null)
            {
                resultTextManager.UpdateResultText(0);
            }
        }
    }
}
