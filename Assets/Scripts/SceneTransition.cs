using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Button continueButton; // Refer�ncia ao bot�o de continuar

    void Start()
    {
        // Adiciona um listener ao bot�o para chamar a fun��o quando for clicado
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    private void OnContinueButtonClicked()
    {
        Debug.Log("Bot�o Continue pressionado. Carregando a cena Quiz...");
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Quiz"); // Nome da pr�xima cena
    }
}
