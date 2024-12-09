using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private int daño;
    [SerializeField] private Vector2 dimenCaja;
    [SerializeField] private Transform posCaja;
    [SerializeField] private float tiempVida;

    private void Start()
    {
        Destroy(gameObject, tiempVida);
    }

    public void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posCaja.position, dimenCaja, 0f);

        foreach(Collider2D colisiones in objetos)
        {
            if (colisiones.CompareTag("Jugador"))
            {
                colisiones.GetComponent<VidaJotem>().TomarDaño(daño);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posCaja.position, dimenCaja);
    }
}
