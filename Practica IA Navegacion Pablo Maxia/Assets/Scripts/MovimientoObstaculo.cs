using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovimientoObstaculo : MonoBehaviour
{
    public NavMeshObstacle obstacle;
    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        Movmiento(0, 0, 2);
        Movmiento(0, 0, -2);
    }

    private void Movmiento(int x, int y, int z){
        transform.Translate(new Vector3(x, y, z));
    }
}
