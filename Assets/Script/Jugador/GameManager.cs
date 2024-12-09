using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public GameObject MenuPrincipal;
    public GameObject MenuGameOver;

    public bool start = false;
    public bool GameOver = false;

    private void Awake()
    {
        // Singleton para asegurar que solo haya un GameManager en la escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
                MenuPrincipal.SetActive(false); //Se usa para activar y desactivar los canvas.
            }
        }

        if (start && GameOver)
        {
            MenuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                ReiniciarNivel();
            }
        }
    }

    public void ActivarGameOver()
    {
        GameOver = true;
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene("SELVA");//Llama a las escenas
        GameOver = false;
        start = false;
        MenuGameOver.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
}
