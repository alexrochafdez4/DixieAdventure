using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasic : MonoBehaviour //aqui controlamos el comportamiento de una IA muy basica para un enemigo.
{                                    // La IA se mueve entre diferentes puntos predefinidos en el escenario que he creado directamente en Unity.

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime = 2;

    private int i = 0;

    private Vector2 actualPos;

    void Start()
    {
        waitTime = startWaitTime;
        
    }

   //en resumen, creo unos puntos predefinidos de movimiento para el enemigo de forma que se mueva de un punto a y b y en el tiempo y velocidad que estime. Cuando el enemigo acaba vuelve a empezar el mismo moviemiento.
    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position)<0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length-1]) 
                {
                    i++;
                }
                else 
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        IEnumerator CheckEnemyMoving()
        {
            actualPos = transform.position;
            yield return new WaitForSeconds(0.5f);
            if (transform.position.x > actualPos.x)
            {
                spriteRenderer.flipX = true;
            }
            else if (transform.position.x < actualPos.x)
            {
                spriteRenderer.flipX = false;
            }





        }
        
    }
}
