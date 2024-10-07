using System.Collections;
using UnityEngine;
using TMPro; 

public class Planet : MonoBehaviour
{
    public float maxScale = 0.1589f;
    public float scalingSpeed = 0.01f;
    private bool isScaling = false;
    private Transform player;

    [SerializeField] private TMP_Text planetNameText; 
    private bool nameDisplayed = false; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        planetNameText.gameObject.SetActive(false); 
    }

    public void StartScaling()
    {
        if (!isScaling)
        {
            StartCoroutine(ScalePlanet());
        }
    }

    private IEnumerator ScalePlanet()
    {
        isScaling = true;

        while (transform.localScale.x < maxScale && player.GetComponent<PlayerController>().IsAlive)
        {
            transform.localScale += Vector3.one * scalingSpeed * Time.deltaTime;
            yield return null;
        }

        if (!nameDisplayed)
        {
            ShowPlanetName();
        }

        isScaling = false;
    }

    private void ShowPlanetName()
    {
        planetNameText.gameObject.SetActive(true); 
        planetNameText.text = "Proxima Centauri b"; 
        StartCoroutine(HidePlanetName());
    }

    private IEnumerator HidePlanetName()
    {
        yield return new WaitForSeconds(8f); 
        planetNameText.gameObject.SetActive(false); 
        nameDisplayed = true; 
        StartCoroutine(TransitionToNextScene()); 
    }

    private IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(1f); 
    }
}
