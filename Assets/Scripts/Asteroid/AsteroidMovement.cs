using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] asteroidSprites; 
    public float speed = 5.2f; 
    public float detectionTime = 0f; 
    private Vector3 targetDirection; 
    private bool isFollowing = false;
    private Transform player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    public void ActivateAsteroid(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;

        
        Sprite randomSprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        GetComponent<SpriteRenderer>().sprite = randomSprite; 

        isFollowing = false;

        StartCoroutine(FindPlayer());
    }

    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(detectionTime); 
        targetDirection = (player.position - transform.position).normalized;
        isFollowing = true;
    }

    void Update()
    {
        if (isFollowing)
        {
            transform.position += targetDirection * speed * Time.deltaTime;

            if (transform.position.x < -10 || transform.position.x > 10 ||
                transform.position.y < -10 || transform.position.y > 10)
            {
                gameObject.SetActive(false); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = false;

            if (collision.TryGetComponent(out Health playerHealth))
            {
                playerHealth.TakeDamage(); 
            }
            gameObject.SetActive(false);
        }
    }
}
