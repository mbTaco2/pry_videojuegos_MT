using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class chakana : MonoBehaviour
{
    public List<Image> listaChakana;
    public GameObject chakanaPrefab;
    public PuntosChakana puntos;
    public int indxAct;
    public Sprite chakanaLlena;
    public Sprite chakanaVacia;

    private void Awake()
    {
        puntos.cambioPunt.AddListener(CambiarPuntos);
    }

    private void CambiarPuntos(int puntAct)
    {
        if (!listaChakana.Any())
        {
            CrearChakana(puntAct);
        }
        else
        {
            Cambiarchakana(puntAct);
        }
    }

    private void Cambiarchakana(int puntAct)
    {
        if (puntAct <= indxAct) { 
            QuitarPunt(puntAct);
        }
    }

  
    private void QuitarPunt(int puntAct)
    {
        for (int i = indxAct; i >= puntAct; i--)
        {
            indxAct = i;
            listaChakana[indxAct].sprite = chakanaVacia;
        }
    }

    private void CrearChakana(int puntMax)
    {
        for (int i = 0; i < puntMax; i++) { 
            GameObject chakana = Instantiate(chakanaPrefab,transform);
            listaChakana.Add(chakana.GetComponent<Image>());
        }
        indxAct = puntMax - 1;
    }

    
}
