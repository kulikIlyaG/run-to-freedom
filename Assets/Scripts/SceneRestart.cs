using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneRestart : MonoBehaviour
    {
        void Update()
        {
            // Перезапускаем текущую сцену при нажатии клавиши "R"
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartScene();
            }
        }

        void RestartScene()
        {
            // Получаем индекс текущей активной сцены
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Загружаем сцену с тем же индексом, что и текущая сцена
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}