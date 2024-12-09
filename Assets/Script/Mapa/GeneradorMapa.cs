using UnityEditor;
using UnityEngine;

public class GeneradorMapa : MonoBehaviour
{

    [SerializeField] private GameObject[] partesNivel;
    [SerializeField] private float distMin;
    [SerializeField] private Transform puntFinal;
    [SerializeField] private int cantInic;

    private Transform jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;

        for (int i = 0; i < cantInic; i++) {
            GenerarNivel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(jugador.position, puntFinal.position) < distMin)
        {
            GenerarNivel();
        }
    }

    private void GenerarNivel()
    {
        int numAlea = Random.Range(0, partesNivel.Length);
        GameObject nivel = Instantiate(partesNivel[numAlea],puntFinal.position,Quaternion.identity);
        puntFinal = BuscarPuntoFinal(nivel, "PuntoFinal");
    }

    private Transform BuscarPuntoFinal(GameObject partesNivel, string tag)
    {
        Transform punto = null;

        foreach (Transform t in partesNivel.transform)
        {
            if (t.CompareTag(tag))
            {
                punto = t;
                break;
            }
        }
        return punto;
    }
}
