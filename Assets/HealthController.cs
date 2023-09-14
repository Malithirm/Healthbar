using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HeartController hpController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hurtbox"))
        {
            hpController.health--;
            hpController.DrawHearts();
        }
    }

    private void Update()
    {
        if (hpController.health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reseting the scene, simulating player's death
        }
    }
}
