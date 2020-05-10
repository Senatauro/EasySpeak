using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDePlateia : MonoBehaviour
{
    public ControleDeBancos banqueta;
    public Instanciador inst;

    /// <summary>
    /// Lista de pessoas que podem ser instanciadas na plateia
    /// </summary>
    public List<GameObject> pessoasDaPlateia = new List<GameObject>();

    void Awake()
    {
        banqueta = GetComponent<ControleDeBancos>();
        inst = GetComponent<Instanciador>();
    }

    public bool debug1 = false;
    public Localizacao l;
    public QuantidadePlateia q;
    public Animo a;
    public VariacaoAnimo v;
    void Update()
    {
        if(debug1 == true)
        {
            debug1 = false;
            CriarPlateia(l, q, a, v);
        }
    }

    /// <summary>
    /// Função que será utilizada para criar a plateia
    /// </summary>
    /// <param name="focoEm">Onde se deve ter a maioria das pessoas</param>
    /// <param name="quant">A quantidade média de pessoas que deve estar na plateia</param>
    /// <param name="animacaoDaPlateia">A animação média da plateia</param>
    public void CriarPlateia(Localizacao focoEm, QuantidadePlateia quant, Animo animacaoDaPlateia, VariacaoAnimo variacao)
    {
        List<Posicao> posicoesParaInstanciar;
        inst.EliminarPlateia();
        //Matemagica aqui; Valor base é usado para determinar a quantidade de pessoas que vai ter na posição em foco
        //E também vai ser utilizado para determinar a quantidade de pessoas em outras posições
        float valorBase = 0;
        RetornarPorcentagem(quant, out valorBase);
        if(valorBase == 0)
            return;
        else if(valorBase == 1)
            posicoesParaInstanciar = banqueta.RetornarPosicoes(1,1,1,1,1);
        else    //Momento da matemagica. Aqui tem que dar um jeito de retornar aleatorizar as posições de sentar dos avatares
        {
            float[] por = RetornarPorcentagemNasPosicoes(focoEm, valorBase);
            posicoesParaInstanciar = banqueta.RetornarPosicoes(por[0], por[1], por[2], por[3], por[4]);
        }
        float[] porAnimo = RetornarPorcentagemDeAnimo(animacaoDaPlateia, variacao);
        Debug.Log("Porcentagem dos animos:\n");
        for(int i = 0; i < 6; i++)
            Debug.Log(porAnimo[i] + "\n");
        inst.InstanciarPlateia(pessoasDaPlateia, posicoesParaInstanciar, porAnimo);
    }

    

    void RetornarPorcentagem(QuantidadePlateia quant, out float valorBase)
    {
        valorBase = 0;
        switch(quant)
        {
            case QuantidadePlateia.VAZIO:
                valorBase = 0;
                break;
            case QuantidadePlateia.QUASE_VAZIO:
                valorBase = 0.15f;
                break;
            case QuantidadePlateia.MUITO_POUCO:
                valorBase = 0.25f;
                break;
            case QuantidadePlateia.POUCO:
                valorBase = 0.4f;
                break;
            case QuantidadePlateia.MEDIO:
                valorBase = 0.5f;
                break;
            case QuantidadePlateia.BASTANTE:
                valorBase = 0.7f;
                break;
            case QuantidadePlateia.QUASE_LOTADO:
                valorBase = 0.85f;
                break;
            case QuantidadePlateia.LOTADO:
                valorBase = 1;
                break;            
        }
    }

    float[] RetornarPorcentagemNasPosicoes(Localizacao focoEm, float valorBase)
    {
        float[] valorPosicoes = new float[5];
        switch(focoEm)
        {
            case Localizacao.MUITO_FRENTE:
                valorPosicoes[0] = valorBase;
                valorPosicoes[1] = valorBase/1.25f;
                valorPosicoes[2] = valorBase/1.5f;
                valorPosicoes[3] = valorBase/1.75f;
                valorPosicoes[4] = valorBase/2f;
                break;
            case Localizacao.FRENTE:
                valorPosicoes[0] = valorBase/1.25f;
                valorPosicoes[1] = valorBase;
                valorPosicoes[2] = valorBase/1.25f;
                valorPosicoes[3] = valorBase/1.5f;
                valorPosicoes[4] = valorBase/1.75f;
                break;
            case Localizacao.MEIO:
                valorPosicoes[0] = valorBase/1.5f;
                valorPosicoes[1] = valorBase/1.25f;
                valorPosicoes[2] = valorBase;
                valorPosicoes[3] = valorBase/1.25f;
                valorPosicoes[4] = valorBase/1.5f;
                break;
            case Localizacao.TRAS:
                valorPosicoes[0] = valorBase/1.75f;
                valorPosicoes[1] = valorBase/1.5f;
                valorPosicoes[2] = valorBase/1.25f;
                valorPosicoes[3] = valorBase;
                valorPosicoes[4] = valorBase/1.25f;
                break;  
            case Localizacao.MUITO_ATRAS:
                valorPosicoes[0] = valorBase/2f;
                valorPosicoes[1] = valorBase/1.75f;
                valorPosicoes[2] = valorBase/1.5f;
                valorPosicoes[3] = valorBase/1.25f;
                valorPosicoes[4] = valorBase;
                break;
        }
        return valorPosicoes;
    }

/*  CONCENTRADA,
    POUCO_CONCENTRADA,
    NORMAL,
    DISTRAIDA,
    ENTEDIADA,
    BAGUNCANDO,
    SAINDO  //Animo saindo é especial, não entra nessa contagem
    porcentagem para o animo escolhido = 50%
    porcentagem para os outros animos = 10%
*/
/// <summary>
/// Função utilizada para retornar o animo da plateia utilizando presets. Facilita a utilização rapida do app
/// </summary>
/// <param name="an">Animo base a ser entrado</param>
/// <param name="var">Quantidade de variação entre o animo da plateia</param>
/// <returns></returns>
    float[] RetornarPorcentagemDeAnimo(Animo an, VariacaoAnimo var)
    {
        float[] pa = new float[6];  //porcentagemDosAnimos
        float variacao = RetornarPorcentagemDeVariacao(var);
        switch(an)
        {
            case Animo.CONCENTRADA:
                pa[0] = 0.5f - variacao;
                pa[1] = 0.1f + variacao/5;
                pa[2] = 0.1f + variacao/5;
                pa[3] = 0.1f + variacao/5;
                pa[4] = 0.1f + variacao/5;
                pa[5] = 0.1f + variacao/5;
                break;
            
            case Animo.POUCO_CONCENTRADA:
                pa[0] = 0.1f + variacao/5;
                pa[1] = 0.5f - variacao;
                pa[2] = 0.1f + variacao/5;
                pa[3] = 0.1f + variacao/5;
                pa[4] = 0.1f + variacao/5;
                pa[5] = 0.1f + variacao/5;
                break;

            case Animo.NORMAL:
                pa[0] = 0.1f + variacao/5;
                pa[1] = 0.1f + variacao/5;
                pa[2] = 0.5f - variacao;
                pa[3] = 0.1f + variacao/5;
                pa[4] = 0.1f + variacao/5;
                pa[5] = 0.1f + variacao/5;
                break;
            
            case Animo.DISTRAIDA:
                pa[0] = 0.1f + variacao/5;
                pa[1] = 0.1f + variacao/5;
                pa[2] = 0.1f + variacao/5;
                pa[3] = 0.5f - variacao;
                pa[4] = 0.1f + variacao/5;
                pa[5] = 0.1f + variacao/5;
                break;
            
            case Animo.ENTEDIADA:
                pa[0] = 0.1f + variacao/5;
                pa[1] = 0.1f + variacao/5;
                pa[2] = 0.1f + variacao/5;
                pa[3] = 0.1f + variacao/5;
                pa[4] = 0.5f - variacao;
                pa[5] = 0.1f + variacao/5;
                break;

            case Animo.BAGUNCANDO:
                pa[0] = 0.1f + variacao/5;
                pa[1] = 0.1f + variacao/5;
                pa[2] = 0.1f + variacao/5;
                pa[3] = 0.1f + variacao/5;
                pa[4] = 0.1f + variacao/5;
                pa[5] = 0.5f - variacao;
                break;
        }
        return pa;
    }

    float RetornarPorcentagemDeVariacao(VariacaoAnimo var)
    {
        switch(var)
        {
            case VariacaoAnimo.NENHUM:
                return -0.5f;

            case VariacaoAnimo.POUCO:
                return 0.05f;
            
            case VariacaoAnimo.MEDIO:
                return 0.15f;
            
            case VariacaoAnimo.BASTANTE:
                return 0.25f;
            
            case VariacaoAnimo.ALEATORIO:
                return 0.33f;

            default:
                return 0f;
        }
    }
}
