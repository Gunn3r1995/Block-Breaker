using UnityEngine;

namespace Assets.Scripts
{
    public class Paddle : MonoBehaviour {

        // Use this for initialization
        private void Start () {
		
        }
	
        // Update is called once per frame
        private void Update () {
            var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
            this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);
        }
    }
}
