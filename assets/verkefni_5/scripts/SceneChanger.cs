using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
// Strengur sem heldur utan um nafnið á næstu senu sem á að hlaða
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Vista stig í PlayerPrefs áður en sena er skipt
            PlayerPrefs.SetInt("Stig", PlayerMovement.stig);
            SceneManager.LoadScene(sceneToLoad); // Hlaða næstu senu
        }
    }
}
