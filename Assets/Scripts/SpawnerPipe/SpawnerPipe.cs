using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;
    [SerializeField]
    private GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(SpawnerCloud());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(4);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-3f, 3f);
        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }

    IEnumerator SpawnerCloud()
    {
        yield return new WaitForSeconds(6);
        Vector3 tempc = pipeHolder.transform.position;
        tempc.y = Random.Range(-5f, 6f);
        tempc.x = 20f;
        Instantiate(cloud, tempc, Quaternion.identity);
        StartCoroutine(SpawnerCloud());
    }


}
