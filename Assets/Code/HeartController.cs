using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject heartPrefab;
    public int maxHealth = 10;
    public int health = 7;

    List<HealthHearts> hearts =  new List<HealthHearts>();

    private void Start()
    {
        DrawHearts();
    }

    private void Update()   // For testing purposes
    {
        if (Input.GetKeyDown(KeyCode.Z) && health != 0)
        {
            health--;
            DrawHearts();
            Debug.Log(health);

        }
        if (Input.GetKeyDown(KeyCode.X) && health != 10)
        {
            health++;
            DrawHearts();
            Debug.Log(health);
        }
    }

    public void DrawHearts()
    {
        ClearHearts();

        float maxHealthRemainder = maxHealth % 2;
        int heartsToMake = (int)((maxHealth / 2) + maxHealthRemainder);
        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0;i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(health - (i*2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }

    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHearts heartComponent = newHeart.GetComponent<HealthHearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHearts>();
    }
}
