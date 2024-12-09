using UnityEngine;

public class MovShuriken : MonoBehaviour
{
    [SerializeField] private Transform[] puntmov;// Puntos de movimiento base.
    [SerializeField] private float velMov; // Velcoidad el movimiento
    private int sigMov = 1; //Al siguiente punto al que se movera
    private bool OrdMov = true; //Orden en el que se movera

    private void Update()
    {
        if(OrdMov && sigMov + 1 >= puntmov.Length)
        {
            OrdMov = false;
        }

        if (!OrdMov && sigMov <= 0)
        {
            OrdMov = true;
        }

        if (Vector2.Distance(transform.position, puntmov[sigMov].position) < 0.1f) {
            if (OrdMov) { 
                sigMov += 1;
            }
            else
            {
                sigMov -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, puntmov[sigMov].position, 
         velMov * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador")){
            velMov = 0;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
