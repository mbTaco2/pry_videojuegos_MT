using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class VidaJefe : MonoBehaviour
{
    public int vidaAct;
    public int vidaMax;
    public UnityEvent<int> cambioVida;

    public GameManagerBoss gamemanager;


    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        vidaAct = vidaMax;
        cambioVida.Invoke(vidaAct);
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(int cantDaño)
    {
        int vidaTmp = vidaAct - cantDaño;

        if (vidaTmp < 0)
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
            animator.SetTrigger("Muerte");
            gamemanager.ActivarGanador();
        }
    }


    // Update is called once per frame
    private void Update()
    {

    }
}
