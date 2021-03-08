using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulha : MonoBehaviour
{
    public List<Transform> pontos = new List<Transform>();
    Transform fim;
    int ponto = 0;
    bool voltar;
    // Start is called before the first frame update
    void Start()
    {
        fim = pontos[ponto];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, fim.position) > 0.2f)
            transform.position += (fim.position - transform.position).normalized * 8f * Time.deltaTime;
        else
            ChangePatrolPoint();
    }
    void ChangePatrolPoint()
    {
        if (!voltar)
            ponto++;
        else
            ponto--;

        if (ponto >= pontos.Count)
        {
            ponto = (pontos.Count - 1);
            voltar = true;
        }
        else if (ponto < 0)
        {
            ponto = 0;
            voltar = false;
        }

        fim = pontos[ponto];
    }
}
