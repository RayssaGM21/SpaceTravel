using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private TMP_Text gameOverText;
    private Camera mainCamera;
    private Vector2 screenBounds;
    private bool canMove = false; 

    private void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.isGameActive && canMove)
        {
            float moveDirection = GameManager.instance.InputManager.Movement * Time.deltaTime * moveSpeed;
            transform.Translate(moveDirection, 0, 0);

            Vector3 playerPosition = transform.position;
            playerPosition.x = Mathf.Clamp(playerPosition.x, screenBounds.x * -1, screenBounds.x);
            playerPosition.y = Mathf.Clamp(playerPosition.y, screenBounds.y * -1, screenBounds.y);
            transform.position = playerPosition;
        }
    }

    public void StartMovement() 
    {
        canMove = true;
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        canMove = false; 
    }
}
