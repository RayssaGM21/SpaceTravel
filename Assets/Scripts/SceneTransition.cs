using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Button continueButton; // Referência ao botão de continuar

    void Start()
    {
        // Adiciona um listener ao botão para chamar a função quando for clicado
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    private void OnContinueButtonClicked()
    {
        Debug.Log("Botão Continue pressionado. Carregando a cena Quiz...");
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Quiz"); // Nome da próxima cena
    }
}
