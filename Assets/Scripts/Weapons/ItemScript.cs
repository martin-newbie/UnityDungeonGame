using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public GameObject weapon;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            GameObject curWeapon = GameObject.FindGameObjectWithTag("CurWeapon");
            if (curWeapon != null)
            {
                curWeapon.GetComponent<WeaponScript>().Itemization();
            }

            GameObject point = GameObject.FindGameObjectWithTag("WeaponPoint");
            GameObject.Instantiate(weapon, point.transform.position, Quaternion.identity).transform.parent = point.transform;
            Destroy(this.gameObject);
        }
    }
}
