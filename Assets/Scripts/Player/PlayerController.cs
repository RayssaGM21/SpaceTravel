using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public bool IsAlive { get; private set; } = true; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartRocketAnimation()
    {
        StartCoroutine(DelayedRocketAnimation(14f)); 
    }

    private IEnumerator DelayedRocketAnimation(float delay)
    {
        yield return new WaitForSeconds(delay); 
        animator.SetTrigger("TakeOff"); 
        StartCoroutine(ContinuousAnimation());
    }

    private IEnumerator ContinuousAnimation()
    {
        yield return new WaitForSeconds(2f); 
    }

    private void Update()
    {
        if (GameManager.instance.isGameActive && IsAlive) 
        {
            float moveInput = GameManager.instance.InputManager.Movement; 
            transform.Translate(moveInput * Time.deltaTime, 0, 0);
        }
    }

    public void Die() 
    {
        IsAlive = false;
    }
}
