using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 0.0f;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;

            Vector3 player_pos = GameObject.FindWithTag("Player").transform.position;
            randX = Random.Range(player_pos.x - 8.4f,player_pos.x +8.4f);
            randY = Random.Range(player_pos.y-8.4f,player_pos.x+8.4f);

            whereToSpawn = new Vector2(randX , randY);
            Instantiate(Enemy, whereToSpawn, Quaternion.identity);
            if(spawnRate > 1f) {
                spawnRate -= 0.3f;}
            


        }
    
    }
}
