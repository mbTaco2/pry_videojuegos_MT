using UnityEngine;

public class Eliminar_Chakana : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            Destroy(gameObject);
        }
    }
}
