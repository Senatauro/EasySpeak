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
    public void Animar(Animo comoEstou)
    {
        meuAnimo = comoEstou;
        animador.SetFloat("animacao", (float)comoEstou);
    }

    public void FinalizarApresentação()
    {
        
    }

}
