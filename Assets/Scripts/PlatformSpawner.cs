using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    Vector3 lastPos;
    float size;
    public GameObject platform;
    public GameObject diamonds;


    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i =0; i<20; i++)
        {
            SpawnPlatforms();
        }
        

    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

   

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        


        int rand = Random.Range(0, 6);

        if (rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform,pos, Quaternion.identity);

        int rand = Random.Range(0, 4);      //spawn Diamond
        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1,pos.z),diamonds.transform.rotation);
        }
        

    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);      //spawn Diamond
        if (rand < 1)
        {
            Instantiate(diamonds,  new Vector3(pos.x, pos.y + 1,pos.z),diamonds.transform.rotation);
        }

        

    }


}
