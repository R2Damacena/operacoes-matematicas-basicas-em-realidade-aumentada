using UnityEngine;

public class NumberManager : MonoBehaviour
{
    public GameObject[] numberObjects; // Array de GameObjects para os diferentes números
    private int currentNumberIndex = 0; // Índice do número atual

    // Método para trocar o número exibido
    public void ChangeNumber()
    {
        // Desativa o número atual
        numberObjects[currentNumberIndex].SetActive(false);

        // Atualiza o índice para o próximo número
        currentNumberIndex = (currentNumberIndex + 1) % numberObjects.Length;

        // Ativa o novo número
        numberObjects[currentNumberIndex].SetActive(true);

        // Atualiza o nome do ImageTarget para o novo número
        UpdateImageTargetName();
    }

    // Método para definir um número específico
    public void SetNumber(int index)
    {
        if (index >= 0 && index < numberObjects.Length)
        {
            // Desativa o número atual
            numberObjects[currentNumberIndex].SetActive(false);

            // Ativa o novo número
            currentNumberIndex = index;
            numberObjects[currentNumberIndex].SetActive(true);

            // Atualiza o nome do ImageTarget para refletir o novo número
            UpdateImageTargetName();
        }
    }

    // Atualiza o nome do ImageTarget para que o script PlusManager funcione corretamente
    void UpdateImageTargetName()
    {
        this.gameObject.name = (currentNumberIndex + 1).ToString(); // Define o nome do GameObject para o número atual
    }
}
