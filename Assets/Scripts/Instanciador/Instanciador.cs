using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    public List<GameObject> pessoasNaPlateia = new List<GameObject>();
    public int quantosGrausRodar = 90;
    public Vector3 valorSomarPos;
    /// <summary>
    /// Função usada para instanciar um GameObject em determinada posição
    /// </summary>
    /// <param name="obj">Objeto para ser instanciado</param>
    /// <param name="pos">Posição para ser intanciado</param>
    public void InstanciarOuvinte(GameObject obj, Vector3 pos)
    {
        
    }
    
    /// <summary>
    /// Função usada para instanciar vários GameObjects em várias posições
    /// </summary>
    /// <param name="obj">Lista de objetos para ser instanciados</param>
    /// <param name="pos">Lista de posições onde os objetos serão instanciados</param>
    public void InstanciarPlateia(List<GameObject> obj, Vector3[] pos)
    {

    }

    /// <summary>
    /// Função usada para instanciar vários GameObjects em várias posições
    /// </summary>
    /// <param name="obj">Lista de objetos para ser instanciados</param>
    /// <param name="pos">Lista de gameobjects com as posições onde os objetos serão instanciados</param>
    public void InstanciarPlateia(List<GameObject> obj, List<Posicao> pos, float[] porcentagemDeAnimo)
    {
        int i = 0;
        GameObject o;
        Animo r;
        foreach(Posicao p in pos)
        {
            //j = p.gameObject;
            if(i >= obj.Count)
                i = 0;
            o = Instantiate(obj[i], p.transform.position + valorSomarPos, p.transform.rotation);
            o.transform.Rotate(new Vector3(0, quantosGrausRodar, 0));
            o.GetComponent<Pessoa>().numPosicao = p.numeradorDePosicao;
            r = AnimoEscolhido(porcentagemDeAnimo);
            Debug.Log("Chance do animo: " + r);
            o.GetComponent<Pessoa>().Animar(r);
            pessoasNaPlateia.Add(o);
            i++;
        }
    }

    Animo AnimoEscolhido(float[] per)
    {
        float r = Random.Range(0f, 1f);
        if(r < per[0])
            return Animo.CONCENTRADA;
        else if(r < per[0] + per[1])
            return Animo.POUCO_CONCENTRADA;
        else if(r < per[0] + per[1] + per[2])
            return Animo.NORMAL;
        else if(r < per[0] + per[1] + per[2] + per[3])
            return Animo.DISTRAIDA;
        else if(r < per[0] + per[1] + per[2] + per[3] + per[4])
            return Animo.ENTEDIADA;
        else if(r < per[0] + per[1] + per[2] + per[3] + per[4] + per[5])
            return Animo.BAGUNCANDO;
        return Animo.NORMAL;
    }

    public void EliminarPlateia()
    {
        foreach(GameObject obj in pessoasNaPlateia)
            Destroy(obj);
        pessoasNaPlateia.Clear();
    }
}
