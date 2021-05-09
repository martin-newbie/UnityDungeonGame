using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public GameObject weaponItem;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) Itemization();
    }

    public void Itemization()
    {
        Instantiate(weaponItem, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
