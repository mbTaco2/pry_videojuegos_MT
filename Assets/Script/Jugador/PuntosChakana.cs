using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuntosChakana : MonoBehaviour
{
    public int puntAct;
    public int puntMax;
    public UnityEvent<int> cambioPunt;
    private Animator animator;
    public string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntAct = puntMax;
        cambioPunt.Invoke(puntAct);
        animator = GetComponent<Animator>();
    }

    public void TomarPuntos(int punt)
    {
        int puntTemp = puntAct - punt;


        if (puntTemp < 0)
        {
            puntAct = 0;

        }
        else
        {
            puntAct = puntTemp;

        }
        cambioPunt.Invoke(puntAct);


        if (puntAct <= 0)
        {
            animator.SetBool("item", true);
            Physics2D.IgnoreLayerCollision(6, 0, true);
            StartCoroutine(GameOverAnim());

        }
    }

    private IEnumerator GameOverAnim()
    {
        // Esperar el tiempo que dura la animaci�n de muerte (por ejemplo, 2 segundos)
        yield return new WaitForSeconds(1f);  // Cambia el tiempo si tu animaci�n dura m�s o menos
        SceneManager.LoadScene(sceneName);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Aqu� se comprueba si el objeto con el que colisiona el jugador tiene un "tag" espec�fico,
        // lo cual es �til para definir qu� objetos deben hacer da�o.
        if (col.gameObject.tag == "chakana")
        {
           
            TomarPuntos(1);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
