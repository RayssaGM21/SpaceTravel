using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class ButtonColorHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text answerText; 
    [SerializeField] private Button button; 

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        if (button.CompareTag("RespostaCorreta"))
        {
            answerText.color = Color.white; 
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = Color.green; 
            button.colors = colorBlock; 
        }
        if (button.CompareTag("RespostaErrada"))
        {
            answerText.color = Color.white; 
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = Color.red; 
            button.colors = colorBlock; 
        }
    }
}
