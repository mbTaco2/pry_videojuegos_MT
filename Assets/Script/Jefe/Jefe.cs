using UnityEngine;

public class Jefe : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirDer = false;

    [SerializeField] private float vida;


    //Ataque
    [SerializeField] private Transform controladorAtak;
    [SerializeField] private float rdAtak;
    [SerializeField] private int dañoAtak;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<Transform>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if(vida <= 0)
        {
            animator.SetTrigger("Muerte");
        }
    }

    private void Muerte()
    {
        Destroy(animator);
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirDer) || (jugador.position.x < transform.position.x && mirDer)) {
            Girar();
        }
    }

    private void Girar()
    {
        // Invertir la dirección del jefe
        mirDer = !mirDer;

        // Invertir la escala en el eje X para voltear el sprite
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManagerBoss.instance.start && !GameManagerBoss.instance.GameOver)
        {
            float distJG = Vector2.Distance(transform.position, jugador.position);
            animator.SetFloat("distJG", distJG);
        }
    }

    public void Atak()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtak.position, rdAtak);
        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Jugador"))
            {
                colision.GetComponent<VidaJotem>().TomarDaño(dañoAtak);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtak.position, rdAtak);
    }
}
