using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    [SerializeField] string sceneName;

    void Update() {
        if (keyCode == KeyCode.None) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene(sceneName);
            }
        }
        if (Input.GetKeyDown(keyCode)) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
