using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovimientoObstaculo : MonoBehaviour
{
    public NavMeshObstacle obstacle;

    [SerializeField] Vector3 vectorMovimiento = new Vector3(0f, 0f, 2f);
    float factorMovimiento;

    [SerializeField] float duracion = 4f;

    Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();

        posicionInicial = transform.position;

        //StartCoroutine(MovementCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        OscilarMovimiento();
    }

    private void Movmiento(Vector3 vector, float velocidad)
    {
        transform.Translate(vector * velocidad * Time.deltaTime);
    }

    IEnumerator MovementCoroutine()
    {
        Movmiento(Vector3.forward, 2);

        Movmiento(Vector3.back, 2);

        yield return new WaitForSeconds(2);
    }

    private void OscilarMovimiento(){
        if (duracion <= 0f) { return; }
        float ciclos = Time.time / duracion;

        const float tau = Mathf.PI * 2;
        float ola = Mathf.Sin(ciclos * tau);

        factorMovimiento = ola / 2f + 0.5f;

        Vector3 offset = vectorMovimiento * factorMovimiento;
        transform.position = posicionInicial + offset;
    }

}
