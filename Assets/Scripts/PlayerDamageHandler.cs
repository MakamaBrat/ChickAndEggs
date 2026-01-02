using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [Header("Settings")]
    public float damageWindow = 3f;

    private bool isInDamageWindow = false;
    private Coroutine damageCoroutine;
    public MenuTravel menuTravel;
    public Animator animator;
    public AudioSource au;
    public AudioSource bad;
    public void TakeDamage()
    {
        if (isInDamageWindow)
        {
            GameOver();
            return;
        }

        isInDamageWindow = true;
        animator.Play("PlayerWrongett");
        if (damageCoroutine != null)
            StopCoroutine(damageCoroutine);

        damageCoroutine = StartCoroutine(DamageTimer());
        au.Play();
    }

   

    IEnumerator DamageTimer()
    {
        yield return new WaitForSeconds(damageWindow);
        isInDamageWindow = false;
    }

    // --------------------
    // GAME OVER
    // --------------------

    void GameOver()
    {
        menuTravel.makeMenu(4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       if(collision.gameObject.tag=="Good")
        {
            StopAllCoroutines();
            isInDamageWindow = false;
            animator.Play("PlayerStateAnimation");
            damageCoroutine = StartCoroutine(DamageTimer());
            au.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bad")
        {
            TakeDamage();
            bad.Play();
            Destroy(collision.gameObject);
        }
        
    }
}
