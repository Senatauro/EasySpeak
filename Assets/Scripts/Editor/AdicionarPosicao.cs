using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AdicionarPosicao : MonoBehaviour
{
    public GameObject posicao;
    public bool executar = false;
    [Tooltip("Numero de vezes que o instanciador vai rodar sozinho antes de parar. qualquer numero negativo = infinitas vezes.")]
    public int numInstanciacoes = -1;

#if !UNITY_EDITOR_WIN
    void Awake()
    {
        GameObject.Destroy(this.GameObject);
    }
#endif

    void Update()
    {
        if(executar)
        {
            if(numInstanciacoes >= 1 || numInstanciacoes < 0)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    numInstanciacoes--;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(ray, out hit, Mathf.Infinity);
                    Instantiate(posicao, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
