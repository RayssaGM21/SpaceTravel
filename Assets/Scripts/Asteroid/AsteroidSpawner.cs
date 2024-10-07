using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidPool asteroidPool; 
    public GameObject asteroidPrefab; 
    public float spawnInterval = 1.5f; 
    public float spawnDuration = 60f; 

    private void Start()
    {
        GameManager.instance.OnGameStart += StartSpawning; 
    }

    private void StartSpawning()
    {
        StartCoroutine(SpawnAsteroids()); 
    }

    private IEnumerator SpawnAsteroids()
    {
        float elapsedTime = 0f; 

        while (elapsedTime < spawnDuration)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(spawnInterval); 
            elapsedTime += spawnInterval; 

            if (elapsedTime >= spawnDuration - 10f) 
            {
                GameObject.FindGameObjectWithTag("Planet").GetComponent<Planet>().StartScaling();
            }
        }
    }

    private void SpawnAsteroid()
    {
        GameObject newAsteroid = asteroidPool.GetAsteroid(); 
        if (newAsteroid != null)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(); 
            newAsteroid.GetComponent<Asteroid>().ActivateAsteroid(spawnPosition); 
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Camera mainCamera = Camera.main;

        float cameraHeight = mainCamera.orthographicSize * 2; 
        float cameraWidth = cameraHeight * mainCamera.aspect; 

        float xPosition = Random.Range(-cameraWidth / 2, cameraWidth / 2); 
        float yPosition = Random.Range(mainCamera.transform.position.y + mainCamera.orthographicSize,
                                       mainCamera.transform.position.y + mainCamera.orthographicSize + 1f); 

        return new Vector3(xPosition, yPosition, 0); 
    }
}
