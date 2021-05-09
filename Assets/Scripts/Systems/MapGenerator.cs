using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Map;
    public GameObject horizontalWay;
    public GameObject verticalWay;

    public int[,] mapArray = new int[10, 10];
    private int mapCnt;
    private int curMapCnt;

    public GameObject curMap;

    void Start()
    {
        curMapCnt = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                mapArray[y,x] = 0;
            }
        }
        mapCnt = Random.Range(10, 12);
        MapGenerate(0, 0, 0);
    }

    public void MapGenerate(int x, int y, int ch)
    {
        if (mapArray[y, x] == 0)
        {
            float mapX = x * 70;
            float mapY = y * 70;
            Vector3 spawnPoint = new Vector3(mapX, mapY, 0);
            curMap = null;
            curMap = Instantiate(Map, spawnPoint, Quaternion.identity);
            curMapCnt += 1;
            mapArray[y, x] = 1;
        }

        switch(ch)
        {
            case 0:
                break;
            case 1:
                curMap.GetComponent<Map>().right.SetActive(false);
                break;
            case 2:
                curMap.GetComponent<Map>().left.SetActive(false);
                break;
            case 3:
                curMap.GetComponent<Map>().up.SetActive(false);
                break;
            case 4:
                curMap.GetComponent<Map>().down.SetActive(false);
                break;
        }

        int rand = (int)Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                if (curMapCnt > mapCnt) break;
                if (x - 1 > -1 && mapArray[y, x - 1] == 0)
                {
                    float mapX = x * 70 ;
                    float mapY = y * 70 ;
                    Vector3 vTemp = new Vector3(mapX - 35, mapY, 0);
                    Instantiate(horizontalWay, vTemp, Quaternion.identity);
                    curMap.GetComponent<Map>().left.SetActive(false);
                    MapGenerate(x - 1, y, 1);
                }
                else MapGenerate(x, y, 0);
                break;
            case 1:
                if (curMapCnt > mapCnt) break;
                if (x + 1 < 10 && mapArray[y, x + 1] == 0)
                {
                    float mapX = x * 70 ;
                    float mapY = y * 70 ;
                    Vector3 vTemp = new Vector3(mapX + 35, mapY, 0);
                    Instantiate(horizontalWay, vTemp, Quaternion.identity);
                    curMap.GetComponent<Map>().right.SetActive(false);
                    MapGenerate(x + 1, y, 2);
                }
                else MapGenerate(x, y, 0);
                break;
            case 2:
                if (curMapCnt > mapCnt) break;
                if (y - 1 > -1 && mapArray[y - 1, x] == 0)
                {
                    float mapX = x * 70 ;
                    float mapY = y * 70 ;
                    Vector3 vTemp = new Vector3(mapX, mapY - 35, 0);
                    Instantiate(verticalWay, vTemp, Quaternion.identity);
                    curMap.GetComponent<Map>().down.SetActive(false);
                    MapGenerate(x, y - 1, 3);
                }
                else MapGenerate(x, y, 0);
                break;
            case 3:
                if (curMapCnt > mapCnt) break;
                if (y + 1 < 10 && mapArray[y + 1, x] == 0)
                {
                    float mapX = x * 70 ;
                    float mapY = y * 70 ;
                    Vector3 vTemp = new Vector3(mapX, mapY + 35, 0);
                    Instantiate(verticalWay, vTemp, Quaternion.identity);
                    curMap.GetComponent<Map>().up.SetActive(false);
                    MapGenerate(x, y + 1, 4);
                }
                else MapGenerate(x, y, 0);
                break;
        }
    }
}
