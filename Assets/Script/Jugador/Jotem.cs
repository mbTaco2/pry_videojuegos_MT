using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jotem : MonoBehaviour
{
    private Rigidbody2D rb2D;// Para gravedad 

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f; 
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento; //Range se usa para el scroll y haya un limite
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;// GameObject creado en la jerarquía
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    [Header("Animación")]
    private Animator animator;



    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.instance.start && !GameManager.instance.GameOver) {
            movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

            animator.SetFloat("MovH", Mathf.Abs(movimientoHorizontal));

            if (Input.GetButtonDown("Jump"))
            {
                salto = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.start && !GameManager.instance.GameOver)
        {
            enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
            animator.SetBool("enSuelo", enSuelo);

            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

            salto = false;
        }
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }


}
