using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject meteor;
    public float meteroCount;

    void Start()
    {
        for (int i = 0; i < meteroCount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 pos = transform.position;
        while (pos.x <= 1.5f && pos.x >= -1.5f)
        {
            pos.x += Random.Range(-7f, 7f);
        }
        while (pos.y <= 1.5f && pos.y >= -1.5f)
        {
            pos.y += Random.Range(-3f, 3f);
        }
        var rot = Quaternion.Euler(0, 0, 0);

        Instantiate(meteor, pos, rot);
    }
}
