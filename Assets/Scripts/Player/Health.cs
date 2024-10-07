using System;
using UnityEngine;
using TMPro; 

public class Health : MonoBehaviour
{
    [SerializeField] private int lives = 3; 
    [SerializeField] private TMP_Text livesText; 
    private PlayerBehavior playerBehavior;

    public event Action OnDead;
    public event Action OnHurt;

    private void Start()
    {
        playerBehavior = GetComponent<PlayerBehavior>();
        UpdateLivesText(); 
    }

    public void TakeDamage()
    {
        lives--;
        HandleDamageTaken();
        UpdateLivesText(); 
    }

    private void HandleDamageTaken()
    {
        if (lives <= 0)
        {
            OnDead?.Invoke();
            playerBehavior.ShowGameOver();

            if (TryGetComponent<PlayerController>(out PlayerController playerController))
            {
                playerController.Die();
            }
        }
        else
        {
            OnHurt?.Invoke();
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives; 
        }
    }
}
