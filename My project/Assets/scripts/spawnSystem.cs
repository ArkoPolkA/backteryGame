  using UnityEngine;

public class spawnSystem : MonoBehaviour
{
    public GameObject objectToSpawn;   
    public float spawnTime = 3f;       

    private float timer;

    private void Start()
    {
        timer = spawnTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            RandSpawn();
            timer = spawnTime; 
        }
    }

    private void RandSpawn()
    {
        Vector3 RandomPos = new Vector3(
            Random.Range(-95f, -86f),
            Random.Range(162f, 165f),
            Random.Range(-28f, -26f)
        );

        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(objectToSpawn, RandomPos, spawnRotation);
    }
}