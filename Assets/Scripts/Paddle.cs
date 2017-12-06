using UnityEngine;

namespace Assets.Scripts
{
    public class Paddle : MonoBehaviour {

        public bool AutoPlay = false;
        public float MinX, MaxX;

        private Ball ball;

        private void Start()
        {
            ball = FindObjectOfType<Ball>();
        }

        // Update is called once per frame
        private void Update () {
            if (!AutoPlay)
            {
                MoveWithMouse();
            } else {
                MoveWithAutoPlay();
            }
        }

        private void MoveWithMouse(){
			var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
            this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, MinX, MaxX), this.transform.position.y, 0f);
        }

		private void MoveWithAutoPlay()
		{
            var ballPosition = ball.transform.position;
            this.transform.position = new Vector3(Mathf.Clamp(ballPosition.x, MinX, MaxX), this.transform.position.y, 0f);
		}
    }
}
