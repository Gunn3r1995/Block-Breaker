using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LoseCollider : MonoBehaviour
    {
        private LevelManager _levelManager;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            print("Collision");
        }

        private void OnTriggerEnter2D(Collider2D trigger)
        {
            _levelManager = GameObject.FindObjectOfType<LevelManager>();
            _levelManager.LoadLevel("Lose Screen");
        }
    }
}
