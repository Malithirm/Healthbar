using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HeartController : MonoBehaviour
{
    [SerializeField] private GameObject HeartLeft;
    [SerializeField] private GameObject HeartRight;
    public int currentHealth = 2;

    public UnityEvent heartSubstract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hurtbox"))
        {
            currentHealth--;
            heartSubstract.Invoke();
        }
    }

    public void heartSubstractionHandler()
    {
        if (currentHealth == 2)
        {
            HeartLeft.SetActive(true);
            HeartRight.SetActive(true);
        }
        else if (currentHealth == 1)
        {
            HeartLeft.SetActive(true);
            HeartRight.SetActive(false);
        }
        else
        {
            HeartLeft.SetActive(false);
            HeartRight.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
