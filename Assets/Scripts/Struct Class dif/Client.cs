using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private StructSample classSample = new();

    void Update()
    {
        classSample.hogeTransform = transform;

        transform.position += Vector3.one;

        Debug.Log(classSample.hogeTransform.position);
    }
}
