using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int poolSize = 10;

    private List<GameObject> asteroids;

    private void Awake()
    {
        asteroids = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject asteroid = Instantiate(asteroidPrefab);
            asteroid.SetActive(false);
            asteroids.Add(asteroid);
        }
    }

    public GameObject GetAsteroid()
    {
        foreach (var asteroid in asteroids)
        {
            if (!asteroid.activeInHierarchy)
            {
                asteroid.SetActive(true);
                return asteroid;
            }
        }

        return null;
    }
}
