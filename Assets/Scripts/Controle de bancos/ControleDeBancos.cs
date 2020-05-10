using System.Collections.Generic;
using UnityEngine;

public class ControleDeBancos : MonoBehaviour
{
    public List<List<Posicao>> bancos = new List<List<Posicao>>();

    [Tooltip("Numero maximo de bancos. Frente; Meio; Tras; Muito atras")]
    public int[] maxBancos = new int[5];

    public void Awake()
    {
        var banc = GameObject.FindObjectsOfType<Posicao>();
        bancos.Add(new List<Posicao>());
        bancos.Add(new List<Posicao>());
        bancos.Add(new List<Posicao>());
        bancos.Add(new List<Posicao>());
        bancos.Add(new List<Posicao>());
        foreach(Posicao p in banc)
        {
            //bancos.Add(p);
            switch(p.local)
            {
                case Localizacao.MUITO_FRENTE:
                    bancos[0].Add(p);
                    maxBancos[0]++;
                    break;
                case Localizacao.FRENTE:
                    bancos[1].Add(p);
                    maxBancos[1]++;
                    break;
                case Localizacao.MEIO:
                    bancos[2].Add(p);
                    maxBancos[2]++;
                    break;
                case Localizacao.TRAS:
                    bancos[3].Add(p);
                    maxBancos[3]++;
                    break;
                case Localizacao.MUITO_ATRAS:
                    bancos[4].Add(p);
                    maxBancos[4]++;
                    break;
            }
        }
    }

    /// <summary>
    /// Função que retorna posições para pessoas serem instanciadas. Ela recebe a porcentagem de pessoas que devem ficar em cada classificação de distancia.
    /// Valor de porcentagem deve ser 0 a 1
    /// A soma de todos os valores não precisa dar 1
    /// Ex de chamada: RetornarPosicoes(0.2, 0.1, 0.1, 0.5);
    /// </summary>
    /// <param name="p">Parametros de posição, deve receber no maximo 4.</param>
    /// <returns>Retorna as posições para serem instanciadas as pessoas</returns>
    public List<Posicao> RetornarPosicoes(params float[] p)
    {
        List<Posicao> posicoes = new List<Posicao>();
        float chance = 0;
        for(int i = 0; i < 5; i++)
        {
            if(p[i] > 0)
            {
                float aumentarChance = 0.01f;
                foreach(Posicao pos in bancos[i])
                {
                    chance = Random.Range(0f, 1f);
                    if(chance < p[i] - 0.01f + aumentarChance)
                    {
                        //Debug.Log("Instanciando banco na posicao " + i + " com a porcentagem de: " + chance + "\n Chance de cair: " + (p[i] - 0.0125f + aumentarChance) + "%");
                        aumentarChance = 0.01f;
                        posicoes.Add(pos);
                    }
                    else
                    {
                        aumentarChance *= 2;
                    }
                }
            }
        }
        return posicoes;
    }
}