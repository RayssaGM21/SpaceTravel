using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassSceneAgain : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    private void OnContinueButtonClicked()
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("End"); 
    }
}
