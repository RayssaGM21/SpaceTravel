using UnityEngine;
using UnityEngine.SceneManagement; // Para gerenciamento de cenas

public class SceneManagerController : MonoBehaviour
{
    // Método para carregar uma cena pelo nome
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Método para carregar a próxima cena
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Método para voltar à cena anterior
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0) // Garante que não saia do índice
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }
}
