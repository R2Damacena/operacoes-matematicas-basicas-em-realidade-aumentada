using UnityEngine;
using TMPro;

public class ResultTextManager : MonoBehaviour
{
    private TextMeshPro mTextMeshPro;

    void Start()
    {
        mTextMeshPro = GetComponent<TextMeshPro>();
    }

    public void UpdateResultText(string resultText)
    {
        mTextMeshPro.text = resultText;
    }
}
