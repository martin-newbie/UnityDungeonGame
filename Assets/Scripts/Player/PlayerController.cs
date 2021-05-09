using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;

    private bool curPoint;

    void Start()
    {
        curPoint = true;
    }

    void Update()
    {
        point1.SetActive(curPoint);
        point2.SetActive(!curPoint);

        if (Input.GetKeyDown(KeyCode.Alpha1)) curPoint = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) curPoint = false;
        if (Input.GetKeyDown(KeyCode.LeftShift)) curPoint = !curPoint;
    }
}
