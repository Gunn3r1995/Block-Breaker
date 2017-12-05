using UnityEngine;

namespace Assets.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        private static MusicPlayer _instance = null;

        private void Awake()
        {
            Debug.Log("Music Player Awake: " + GetInstanceID());
            if (_instance)
            {
                Destroy(gameObject);
                Debug.Log("Destroyed duplicate music player");
            }
            else
            {
                _instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
            }
        }
    }
}