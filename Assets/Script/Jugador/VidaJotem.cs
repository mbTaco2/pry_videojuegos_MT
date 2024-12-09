using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class VidaJotem : MonoBehaviour
{
    public int vidaAct;
    public int vidaMax;
    public UnityEvent<int> cambioVida;
    public int da�oTrampa = 3;

    public GameManager gamemanager;


    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        vidaAct = vidaMax;
        cambioVida.Invoke(vidaAct);
        animator = GetComponent<Animator>();
    }

    public void TomarDa�o (int cantDa�o)
    {
        int vidaTmp = vidaAct - cantDa�o;

        if(vidaTmp < 0)
        {
            vidaAct = 0;
        }
        else
        {
            vidaAct = vidaTmp;
        }

        cambioVida.Invoke(vidaAct);

        if (vidaAct <= 0)
        {
            animator.SetBool("muerte", true);
            StartCoroutine(GameOverAnim());
        }
    }

    // Esto se llama cuando el objeto entra en colisi�n con otro objeto
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Aqu� se comprueba si el objeto con el que colisiona el jugador tiene un "tag" espec�fico,
        // lo cual es �til para definir qu� objetos deben hacer da�o.
        if (col.gameObject.tag == "Trampa")
        {

            TomarDa�o(da�oTrampa);
            
        }
        
    }

    private IEnumerator GameOverAnim()
    {
        // Esperar el tiempo que dura la animaci�n de muerte (por ejemplo, 2 segundos)
        yield return new WaitForSeconds(2f);  // Cambia el tiempo si tu animaci�n dura m�s o menos
        gamemanager.ActivarGameOver();

    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
