using UnityEngine;

namespace Assets.Scripts
{
    public class Brick : MonoBehaviour
    {
        public AudioClip crack;
        public Sprite[] HitSprites;
        public static int BreakableCount = 0;
        public GameObject Smoke;

        private int _timesHits;
        private LevelManager _levelManager;
        private bool _isBreakable;

        // Use this for initialization
        private void Start()
        {
            _isBreakable = (this.tag == "Breakable");
            if (_isBreakable)
            {
                BreakableCount++;
                print(BreakableCount);
            }
            _timesHits = 0;
            _levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            if (_isBreakable)
            {
                HandleHits();
            }
        }

        private void HandleHits()
        {
            _timesHits++;
            var maxHits = HitSprites.Length + 1;
            if (_timesHits >= maxHits)
            {
                BreakableCount--;
                _levelManager.BrickDestroyed();
                PuffSmoke();
                Destroy(gameObject);
            }
            else
            {
                LoadSprites();
            }
        }

        private void PuffSmoke() {
            var smokePuff = Instantiate(Smoke, gameObject.transform.position, Quaternion.identity);
            var smokePuffStartColor = smokePuff.GetComponent<ParticleSystem>().main.startColor;
			smokePuffStartColor = gameObject.GetComponent<SpriteRenderer>().color;
        }

        private void LoadSprites()
        {
            var spriteIndex = _timesHits - 1;
            if (HitSprites[spriteIndex])
            {
                GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
            }
            else {
                Debug.LogError("Error Brick Sprite doesn't exist at index: " + spriteIndex);
            }
        }

        // TODO Remove this method once winning is implemented!
        private void SimulateWin()
        {
            _levelManager.LoadNextLevel();
        }
    }
}
