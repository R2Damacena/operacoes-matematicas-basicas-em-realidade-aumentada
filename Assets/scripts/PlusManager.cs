using UnityEngine;

public class PlusManager : MonoBehaviour
{
    private int firstNumber = 0;
    private int secondNumber = 0;
    private bool isFirstSet = false;
    private bool isSecondSet = false;

    // Referência ao script ResultTextManager
    public ResultTextManager resultTextManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Number"))
        {
            int number = int.Parse(other.gameObject.name); // Supondo que o nome do GameObject seja o número em si (ex: "2", "5").

            if (!isFirstSet)
            {
                firstNumber = number;
                isFirstSet = true;
                Debug.Log("Primeiro número: " + firstNumber);

                // Exibe o primeiro número no resultado
                UpdateResultText(firstNumber.ToString());
            }
            else if (!isSecondSet)
            {
                secondNumber = number;
                isSecondSet = true;
                Debug.Log("Segundo número: " + secondNumber);

                // Calcula e exibe o resultado da subtração
                PerformSom();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Number"))
        {
            int number = int.Parse(other.gameObject.name);

            if (number == firstNumber)
            {
                firstNumber = 0;
                isFirstSet = false;
                Debug.Log("Primeiro número removido.");

                // Se o segundo número ainda estiver presente, exibe-o no resultado
                if (isSecondSet)
                {
                    UpdateResultText(secondNumber.ToString());
                }
                else
                {
                    ClearResult(); // Limpa o texto se nenhum número estiver presente
                }
            }
            else if (number == secondNumber)
            {
                secondNumber = 0;
                isSecondSet = false;
                Debug.Log("Segundo número removido.");

                // Se o primeiro número ainda estiver presente, exibe-o no resultado
                if (isFirstSet)
                {
                    UpdateResultText(firstNumber.ToString());
                }
                else
                {
                    ClearResult(); // Limpa o texto se nenhum número estiver presente
                }
            }
        }
    }

    void PerformSom()
    {
        if (isFirstSet && isSecondSet)
        {
            int result = firstNumber + secondNumber;
            Debug.Log("Resultado da soma: " + firstNumber + " + " + secondNumber + " = " + result);

            // Exibe o resultado da subtração
            UpdateResultText(result.ToString());
        }
    }

    void ClearResult()
    {
        if (resultTextManager != null)
        {
            resultTextManager.UpdateResultText(""); // Limpa o texto completamente
        }
    }

    void UpdateResultText(string text)
    {
        if (resultTextManager != null)
        {
            resultTextManager.UpdateResultText(text);
        }
    }
}
