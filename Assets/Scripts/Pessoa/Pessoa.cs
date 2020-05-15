using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pessoa : MonoBehaviour
{

    public Animator animador;
    public Animo meuAnimo;
    public int numPosicao;

    void Start()
    {
        //transform.LookAt(GameObject.Find("Orador").transform, Vector3.up);
    }

    /// <summary>
    /// Função utilizada para determinar animação da pessoa a partir de um animo pré determinado. Olhar enum Animo
    /// </summary>
    /// <param name="comoEstou">Animo pré determinado</param>
    public void Animar(Animo comoEstou)
    {
        switch(comoEstou)
        {
            case Animo.CONCENTRADA:
                animador.SetFloat("interesse", 1f);
                animador.SetFloat("animacao", Random.Range(0f, 0.2f));
                animador.SetFloat("inquietude", Random.Range(0f, 0.5f));
                break;

            case Animo.POUCO_CONCENTRADA:
                animador.SetFloat("interesse", Random.Range(0f, 0.5f));
                animador.SetFloat("animacao", Random.Range(0f, 0.2f));
                animador.SetFloat("inquietude", Random.Range(0f, 0.5f));
                break;
            case Animo.NORMAL:
                animador.SetFloat("interesse", Random.Range(-0.5f, 0.5f));
                animador.SetFloat("animacao", Random.Range(0f, 0.2f));
                animador.SetFloat("inquietude", Random.Range(0f, 0.5f));
                break;
        }
    }

    public void FinalizarApresentação()
    {
        animador.SetFloat("animacao", 2f);
        animador.SetFloat("inquietude", 0f);
        animador.SetFloat("interesse", 1f);
    }

}
