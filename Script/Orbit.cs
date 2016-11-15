using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{
    public float rotationSpeed = 5;

    void Start(){

    }

    void Update(){  
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}