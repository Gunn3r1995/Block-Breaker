using UnityEngine;

namespace Assets.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        private static MusicPlayer _instance = null;

        // Use this for initialization
        void Start()
        {
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
