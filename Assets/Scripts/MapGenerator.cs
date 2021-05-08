using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Map;

    public int[,] mapArray = new int[10, 10];
    private int mapCnt;
    private int curMapCnt;

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
        MapGenerate(0, 0);
    }

    public void MapGenerate(int x, int y)
    {
        if(mapArray[y, x] == 0)
        {
            float mapX = x * 50;
            float mapY = y * 50;
            Vector3 spawnPoint = new Vector3(mapX, mapY, 0);
            Instantiate(Map, spawnPoint, Quaternion.identity);
            curMapCnt += 1;
            mapArray[y, x] = 1;
        }

        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                if (curMapCnt > mapCnt) break;
                if (x - 1 > -1 && mapArray[y, x - 1] == 0) MapGenerate(x - 1, y);
                else MapGenerate(x, y);
                break;
            case 1:
                if (curMapCnt > mapCnt) break;
                if (x + 1 < 10 && mapArray[y, x + 1] == 0) MapGenerate(x + 1, y);
                else MapGenerate(x, y);
                break;
            case 2:
                if (curMapCnt > mapCnt) break;
                if (y - 1 > -1 && mapArray[y - 1, x] == 0) MapGenerate(x, y - 1);
                else MapGenerate(x, y);
                break;
            case 3:
                if (curMapCnt > mapCnt) break;
                if (y + 1 < 10 && mapArray[y + 1, x] == 0) MapGenerate(x, y + 1);
                else MapGenerate(x, y);
                break;
        }
    }
}
