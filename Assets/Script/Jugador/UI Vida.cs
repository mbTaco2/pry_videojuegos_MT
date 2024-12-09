using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
public class UIVida : MonoBehaviour
{
    public List<Image> listCora;
    public GameObject corazonPrefab;
    public VidaJotem jotem;
    public int indxAct;
    public Sprite coraLleno;
    public Sprite coraVacio;

    private void Awake()
    {
        jotem.cambioVida.AddListener(cambioCorazones);
    }

    private void cambioCorazones(int vidaActual)
    {
        if (!listCora.Any())
        {
            crearCora(vidaActual);
        }
        else
        {
            cambiaVida(vidaActual);
        }
    }

    private void cambiaVida(int vidaActual)
    {
        if(vidaActual <= indxAct)
        {
            QuitarVida(vidaActual);
        }

    }

    private void QuitarVida(int vidaActual)
    {
        for (int i = indxAct; i >= vidaActual; i--) { 
            indxAct = i;
            listCora[indxAct].sprite = coraVacio;
        }
    }

    private void crearCora(int cantMaxVid)
    {
        for (int i = 0; i < cantMaxVid; i++) { 
            GameObject cora = Instantiate(corazonPrefab,transform);
            listCora.Add(cora.GetComponent<Image>());
        }
        indxAct = cantMaxVid - 1;
    }
}
