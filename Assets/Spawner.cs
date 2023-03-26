using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject meteor;
    public float meteorCount;
    public float nextSpawnTime;
    public float spawnTimeInterval;

    private void Start()
    {
        nextSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < meteorCount; i++)
            {
                Spawn();
            }
            nextSpawnTime += spawnTimeInterval;
        }
    }

    public void Spawn()
    {
        Vector3 pos = transform.position;
        while (pos.x <= 9f && pos.x >= -9f)
        {
            pos.x += Random.Range(-12f, 12f);
        }
        while (pos.y <= 6.5f && pos.y >= -6.5f)
        {
            pos.y += Random.Range(-10f, 10f);
        }
        var rot = Quaternion.Euler(0, 0, 0);

        Instantiate(meteor, pos, rot);
    }
}
