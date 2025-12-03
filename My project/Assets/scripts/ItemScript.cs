using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject objectToSpawn;       // Що спавнити
    public Transform[] spawnPoints;        // 4 порожніх об'єкти

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TrySpawn();
            //Destroy(gameObject);
        }
    }

    private void TrySpawn()
    {
        // Створюємо список вільних місць
        var freePoints = new System.Collections.Generic.List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            // Якщо в цьому місці НІЧОГО не прив'язано → воно вільне
            if (point.childCount == 0)
            {
                freePoints.Add(point);
            }
        }

        // Якщо вільних місць нема — виходимо
        if (freePoints.Count == 0)
        {
            Debug.Log("Немає вільних слотів для спавну!");
            return;
        }

        // Вибираємо рандомне вільне місце
        Transform chosenPoint = freePoints[Random.Range(0, freePoints.Count)];

        // Спавнимо
        GameObject newObj = Instantiate(objectToSpawn, chosenPoint.position, chosenPoint.rotation);

        // Прив'язуємо до цього місця
        newObj.transform.SetParent(chosenPoint);
    }
}
