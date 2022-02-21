using UnityEngine;

namespace Platformer.Scripts
{
    public class QuestionUVRotate : MonoBehaviour
    {
    
        private Material mat;
        private float timerMax = 0.2f;
        private float _timer;
        // Start is called before the first frame update
        void Start()
        {
            _timer = timerMax;
            mat = GetComponent<MeshRenderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                mat.mainTextureOffset += new Vector2(0f,0.2f);
                _timer = timerMax;
            }

      
        
        
        }
    }
}
