using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleprefab;
    private Vector3 spawnpos = new Vector3(30, 0, 0);
    private float startdelay = 2;
    private float repeatrate = 2.5f;
    private PlayerControl playercontrolscript;
    // Start is called before the first frame update
    void Start()
    {
        playercontrolscript = GameObject.Find("player").GetComponent<PlayerControl>();
        InvokeRepeating("SpawnObstacles", startdelay, repeatrate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacles()
    {
        if (playercontrolscript.gameover == false)
        {
            Instantiate(obstacleprefab, spawnpos, obstacleprefab.transform.rotation);
        }
    }
}
