using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetRendererCheck : MonoBehaviour
{
    public Transform planet; 
    public float targetSize = 0.1589f; 
    public float timeThreshold = 5f; 
    private float timer = 0f; 
    private bool canProceed = false; 

    void Update()
    {
        if (CheckPlanetRendered())
        {
            timer += Time.deltaTime; 

            if (timer >= timeThreshold)
            {
                canProceed = true;
                LoadNextScene(); 
            }
        }
        else
        {
            timer = 0f;
            canProceed = false; 
        }

    }

    private bool CheckPlanetRendered()
    {
        return planet.localScale.x >= targetSize; 
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("InPlanet"); 
    }
}
