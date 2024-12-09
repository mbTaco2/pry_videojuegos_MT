using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBoss : MonoBehaviour
{
    public static GameManagerBoss instance;

    [Header("UI Elements")]
    public GameObject MenuPrincipal;
    public GameObject MenuGameOver;
    public GameObject MenuWin;

    public bool start = false;
    public bool GameOver = false;
    public bool Win = false;

    private void Awake()
    {
        // Singleton para asegurar que solo haya un GameManager en la escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Update()
    {
        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
                MenuPrincipal.SetActive(false);
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
        if (start && Win && !GameOver) { 
            MenuWin.SetActive(true);
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

    public void ActivarGanador()
    {
        Win = true;
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene("SELVA");
        GameOver = false;
        start = false;
        Win = false;
        MenuGameOver.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
}
