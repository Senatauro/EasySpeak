using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicionar_Posicoes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pos;
    public Localizacao loc;
    public int mult;
    public int contador = 6;
    void Start()
    {
        var m_Collider = GetComponentInChildren<Collider>();
        var size = m_Collider.bounds.size;
        for(float i = -7.5f; i < 8.5f; i += 2.5f)
        {
            Debug.Log("Executou");
            GameObject obj = new GameObject();
            obj.transform.parent = m_Collider.transform;
            obj.transform.localPosition = new Vector3((size.x/15f) * i, -size.y/2, size.z/2);
            obj.AddComponent<Posicao>();
            obj.GetComponent<Posicao>().numeradorDePosicao += mult * 7 + contador;
            obj.GetComponent<Posicao>().local = loc;
            contador--;
            obj.transform.parent = pos.transform;
        }
    }
}
