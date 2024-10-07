using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public InputManager InputManager { get; private set; }

    public TMP_Text countdownText; // Texto da contagem regressiva
    public float countdownTime = 3f; // Tempo da contagem regressiva
    public bool isGameActive = false; // Indica se o jogo está ativo

    public event System.Action OnGameStart; // Evento que será chamado quando o jogo começar

    private void Awake()
    {
        if (instance != null) Destroy(this.gameObject);
        instance = this;
        InputManager = new InputManager();
    }

    private void Start()
    {
        StartCountdown(); // Inicia a contagem regressiva quando o jogo começa
    }

    public void StartCountdown()
    {
        isGameActive = false; // Garante que o jogo não está ativo
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        countdownText.gameObject.SetActive(true); // Certifique-se de que o texto está visível
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false); // Oculta o texto após a contagem
        StartGame(); // Inicia o jogo
    }

    public void StartGame()
    {
        isGameActive = true; // Ativa o jogo após a contagem regressiva
        OnGameStart?.Invoke(); // Aciona o evento para iniciar o spawn de asteroides
        FindObjectOfType<PlayerBehavior>().StartMovement(); // Permite movimento após a contagem
        FindObjectOfType<PlayerController>().StartRocketAnimation(); // Chama a animação do foguete
    }
}
