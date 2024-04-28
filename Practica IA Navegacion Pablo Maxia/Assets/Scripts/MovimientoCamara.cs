using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float tiempoFreno = 0.15f;
    private Vector3 velocidad = Vector3.zero;
    public Transform objetivo;

    private Camera camara;
    private float altura;
    private float z;

    void Start()
    {
        camara = GetComponent<Camera>();

        altura = transform.position.y;
    }

    void Update()
    {
        if (objetivo)
        {
            float profundidad = Vector3.Dot(
                        objetivo.position - transform.position,
                        transform.forward
            );

            Vector3 focoVista = new Vector3(0.5f, 0.5f, profundidad);
            Vector3 focoMundo = camara.ViewportToWorldPoint(focoVista);

            Vector3 delta = objetivo.position - focoMundo;
            Vector3 destino = transform.position + delta;

            if(transform.position.y > altura)
            {
                destino.y -= altura / 2;
            }
            else
            {
                destino.y = altura;
            }

            transform.position = Vector3.SmoothDamp(
                                    transform.position,
                                    destino,
                                    ref velocidad,
                                    tiempoFreno
            );
        }
    }
}
