using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour  //En este script controlamos cuando el jugador interactua contra un enemigo y le hace daño o lo destruye.
{
    public Collider2D enemyCollider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;
    public AudioSource hitSound;  
    public float jumpForce = 2.5f;
    public int lifes = 2;

    private bool isHitCooldown = false; 

    private void OnCollisionEnter2D(Collision2D collision) //Cuando el jugador contacta con el enemigo, le añadimos un salto hacia arriba, se reproduce un sonido de golpe, y el enemigo pierde una vida.
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!isHitCooldown)
            {
                isHitCooldown = true;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
                PlayHitSound();  
                LoseLifeAndHit();
                CheckLife();
                StartCoroutine(HitCooldown(2));  
            }
        }
    }

    public void LoseLifeAndHit() 
    {
        lifes--;
        animator.Play("Hit");
    }

    public void CheckLife() //Si el enemigo pierde todas sus vidas, se activa una animación de muerte, desaparece y se destruye.
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

    private void PlayHitSound()   //sonidos de golpe 
    {
        if (hitSound != null)
        {
            hitSound.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado un AudioSource para el sonido de golpe.");
        }
    }

    private IEnumerator HitCooldown(float cooldownTime) //y esto es para que no se buguee al tocar varias veces en poco tiempo.
    {
        yield return new WaitForSeconds(cooldownTime);
        isHitCooldown = false;
    }
}



