using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator Anim;
    private SpriteRenderer spriteRend;

    [Header("FireSound")]
    [SerializeField] private AudioClip firetrapSound;

    private bool triggered; //when trigger activated
    private bool active; //when trap hurts

    private Health playerHealth;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            if (!triggered)
    
                StartCoroutine(ActivateFiretrap());
                
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }
    private IEnumerator ActivateFiretrap()
    {
        //turn sprite red when trap triggered
        triggered = true;
        spriteRend.color = Color.red;

        //wait for delay, activate trap, turn on animation, return color to normal
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(firetrapSound);
        spriteRend.color = Color.white; //turn sprite back to initial color
        active = true;
        Anim.SetBool("activated", true);

        //Wait X seconds, deactivate trap and reset
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        Anim.SetBool("activated", false);
    }
}
