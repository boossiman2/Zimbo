using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTileManager : MonoBehaviour {

    public GameObject flowerPrefab;
    public GameObject tilePrefab;
    [SerializeField]
    private GameObject basePos;
    //기준 x 좌표
    [SerializeField]
    private float baseX;
    //타일 고유 번호
    private int tileNumber = 0;
    //타일 최대 수
    private int maxTileNumber;
    //현재 씬 인덱스
    private int index = 0;

    private static int flowerCount = 0;

    public static void FlowerCount()
    {
        flowerCount++;
    }
	public static void FlowerCountReset()
	{
		flowerCount = 0;
	}

    private void RandomTileNumber()
    {
            tileNumber = Random.Range(0, 99);
    }

    //난수에 해당하는 타일 할당 및 생성
    private void MapInitialize()                                                 
    {
        tilePrefab = Resources.Load("05.Prefabs/grass1") as GameObject;
        Vector3 scale = tilePrefab.transform.localScale;
        scale.x = scale.x * -1;
        tilePrefab.transform.localScale = scale;
        Instantiate(tilePrefab, new Vector3(baseX - 10, -4, 0), Quaternion.identity);
        Instantiate(tilePrefab, new Vector3(baseX - 5, -4, 0), Quaternion.identity);
        Instantiate(tilePrefab, new Vector3(baseX, -4, 0), Quaternion.identity);
        scale.x = scale.x * -1;
        tilePrefab.transform.localScale = scale;
    }   


    private void SetFlowerInLast()
    {
        Vector3 scale = tilePrefab.transform.localScale;
        scale.x = scale.x * -1;
        tilePrefab = Resources.Load("05.Prefabs/grass1") as GameObject;
        Instantiate(tilePrefab, new Vector3(baseX +5+ (5 * maxTileNumber), -4, 0), Quaternion.identity);
        scale.x = scale.x * -1;
        tilePrefab.transform.localScale = scale;
        float flowerPositionX = tilePrefab.transform.position.x / 2;
		Instantiate(flowerPrefab, new Vector3 (baseX  + 5+ (5 * maxTileNumber) + flowerPositionX, 0, 0), Quaternion.identity).name = "flower";
    }

	// Use this for initialization
	void Awake ()
    {
		index = flowerCount;
        //타일 최대값 (n^2) + 10
        maxTileNumber = 18 + 12*(index);
        basePos = GameObject.Find("MapTiles");
        baseX = basePos.transform.position.x;
        MapInitialize();
        SetMapsInStage();
        SetFlowerInLast();
    }

    /*
        smallCliff_tileNumber
        3 * random(1~2) * index

        bigCliff_titleNumber
        2 * random(1~index^2) * stage(num)

        normalTileNumber
        1 * random(1~2) * index
      */

    void SetMapsInStage()
    {

        for (int i = 0; i < maxTileNumber; i++)
        {
            RandomTileNumber();

            if (tileNumber >=0 && tileNumber <20)
            {
                    tilePrefab = Resources.Load("05.Prefabs/smallCliff") as GameObject;
            }
            else if(tileNumber >= 21 && tileNumber <= 94)
            {
                switch(Random.Range(0,2))
                {
                    case 0:
                        tilePrefab = Resources.Load("05.Prefabs/grass1") as GameObject;
                        break;
                    case 1:
                        tilePrefab = Resources.Load("05.Prefabs/grass2") as GameObject;
                        break;
                    case 2:
                        tilePrefab = Resources.Load("05.Prefabs/grass3") as GameObject;
                        break;
                }         
            }
            else  if(tileNumber >=99 && tileNumber <= 99)
            {
                tilePrefab = Resources.Load("05.Prefabs/bigCliff") as GameObject;
            }
            Instantiate(tilePrefab, new Vector3(baseX + 5+(i * 5), -4, 0), Quaternion.identity);
        }
    }
}
