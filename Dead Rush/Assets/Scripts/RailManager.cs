using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    [SerializeField] List<GameObject> rails;
    [SerializeField] float speed;

    void Update()
    {
        for (int i = 0; i < rails.Count; i++)
        {
            rails[i].transform.Translate(speed * Vector3.back * Time.deltaTime);
        }
    }
}
