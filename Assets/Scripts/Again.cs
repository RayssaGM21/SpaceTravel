using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneController : MonoBehaviour
{
    public void LoadMainScene()
    {
        Debug.Log("OI");
        SceneManager.LoadScene("Scenes/SampleScene"); 
    }
}
