using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.GhostHunter.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] 
        private Button _playButton;

        private void Start()
        {
            _playButton.onClick.AddListener(GoToPlayScene);
        }

        private void GoToPlayScene()
        {
            SceneManager.LoadScene("MainGameScene");
        }
    }
}
