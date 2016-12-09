using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTileManager : MonoBehaviour {
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
    private int index;
    private void RandomTileNumber()
    {
            tileNumber = Random.Range(0, 2);
    }

    //난수에 해당하는 타일 할당 및 생성
    private void MapInitialize()                                                 
    {
       
        
    }   

	// Use this for initialization
	void Awake ()
    {
        //스테이지 빌드인덱스 1~n
        index = SceneManager.GetActiveScene().buildIndex;
        //타일 최대값 (n^2) + 10
        maxTileNumber = 10 + (index * index);
        basePos = GameObject.Find("MapTiles");
        baseX = basePos.transform.position.x;
        SetMapsInStage(); 
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
        int smallCliff_tileNumber = Random.Range(1,index)*index;
        int bigCliff_tileNumber  = Random.Range(1, (index * index))*index;

        for (int i = 0; i < maxTileNumber; i++)
        {
            RandomTileNumber();
            Debug.Log(bigCliff_tileNumber);
            Debug.Log(smallCliff_tileNumber);
            if (tileNumber == 0)
            {
                if(smallCliff_tileNumber>0)
                {
                    tilePrefab = Resources.Load("Prefabs/smallCliff") as GameObject;
                    smallCliff_tileNumber--;
                }
                else
                {
                    tilePrefab = Resources.Load("Prefabs/grass") as GameObject;
                }
            }
            else if(tileNumber == 1)
            {
                if (bigCliff_tileNumber > 0)
                {
                    tilePrefab = Resources.Load("Prefabs/bigCliff") as GameObject;
                    bigCliff_tileNumber--;
                }
                else
                {
                    tilePrefab = Resources.Load("Prefabs/grass") as GameObject;
                }
            }
            else
            {
                tilePrefab = Resources.Load("Prefabs/grass") as GameObject;
            }

            //switch (tileNumber)
            //{
            //    case 0:
            //        if (smallCliff_tileNumber > 0)
            //        {
            //            tilePrefab = Resources.Load("Prefabs/smallCliff") as GameObject;
            //            smallCliff_tileNumber--;
            //        }
            //        break;
            //    case 1:
            //        tilePrefab = Resources.Load("Prefabs/grass") as GameObject;
            //        break;
            //    case 2:
            //        tilePrefab = Resources.Load("Prefabs/grass") as GameObject;
            //        break;
            //}
            Instantiate(tilePrefab, new Vector3(baseX + (i * 5), -4, 0), Quaternion.identity);
        }
    }
}
