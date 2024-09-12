using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // Método para reiniciar a cena atual
    public void ReloadScene()
    {
        // Obtém o nome da cena atual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Recarrega a cena atual
        SceneManager.LoadScene(currentSceneName);
    }
}
