using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GrassGenerator : MonoBehaviour
{
    public GameObject grassPrefab;    // 草模型的预制体
    public int grassCount;            // 生成的草的数量

    public float  timer=50;
    public float timercount=50;

    void Start()
    {
        GenerateGrass();
    }

    void GenerateGrass()
    {
        Boid.boid.faxianhaicao();
        for (int i = 0; i < grassCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            GameObject grass = Instantiate(grassPrefab, position, Quaternion.identity);
            grass.transform.SetParent(transform);    // Sets an object whose parent is the generated grass
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            StartCoroutine(segrassplay());
            timer = timercount;
        }

    }
    IEnumerator segrassplay()
    {
        yield return new WaitForSeconds(0f);
        GenerateGrass();
        Boid.boid.faxianhaicao();
    }
}