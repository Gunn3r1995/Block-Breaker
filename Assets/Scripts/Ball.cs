using UnityEngine;

namespace Assets.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Paddle _paddle;
        private bool _hasStarted = false;
        private Vector3 _paddleToBallVector;

        // Use this for initialization
        private void Start()
        {
            _paddle = GameObject.FindObjectOfType<Paddle>();
            _paddleToBallVector = transform.position - _paddle.transform.position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var tweak = new Vector2(Random.Range(0f,0.3f), Random.Range(0f, 0.3f));

            if (_hasStarted)
            {
                GetComponent<Rigidbody2D>().velocity += tweak;
            }
            if (_hasStarted && collision.collider.tag == "Paddle")
            {
                GetComponent<AudioSource>().Play();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (_hasStarted) return;

            // Lock the ball to paddle
            transform.position = _paddle.transform.position + _paddleToBallVector;

            // Wait unti mouse button one pressed to launch the ball
            if (Input.GetMouseButtonDown(0))
            {
                _hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 10.0f);
            }
        }
    }
}
