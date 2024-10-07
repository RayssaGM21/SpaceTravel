using UnityEngine;
using UnityEngine.SceneManagement; // Para gerenciamento de cenas

public class SceneManagerController : MonoBehaviour
{
    // M�todo para carregar uma cena pelo nome
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // M�todo para carregar a pr�xima cena
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // M�todo para voltar � cena anterior
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0) // Garante que n�o saia do �ndice
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }
}
