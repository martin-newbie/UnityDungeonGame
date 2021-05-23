using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;

    private bool curPoint;

    private void Awake()
    {
        curPoint = true;
    }
    void Start()
    {

    }

    void Update()
    {
        point1.SetActive(curPoint);
        point2.SetActive(!curPoint);

        if (Input.GetKeyDown(KeyCode.Alpha1)) curPoint = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) curPoint = false;
        if (Input.GetKeyDown(KeyCode.LeftShift)) curPoint = !curPoint;

        if(GetComponent<PlayerStatus>().curHp <= 0)
        {
            StartCoroutine(GameFail());
        }
    }

    IEnumerator GameFail()
    {
        Debug.Log("Player dead");
        yield return new WaitForSeconds(3f);
        // SceneManager.Instance.ReSpawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyParent>())
        {
            collision.gameObject.GetComponent<EnemyParent>().isAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyParent>())
        {
            collision.gameObject.GetComponent<EnemyParent>().isAttack = false;
        }
    }
}
