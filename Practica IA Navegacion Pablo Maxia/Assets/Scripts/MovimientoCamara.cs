using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RotarCamara();
    }
   
    private void PosicionCamara()
    {
        transform.position = target.position + offset;
    }
    private void RotarCamara()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Gets mouse position to Unity World coordinate system
        Camera.main.transform.parent.transform.Rotate(mousePosition);
    }

}
