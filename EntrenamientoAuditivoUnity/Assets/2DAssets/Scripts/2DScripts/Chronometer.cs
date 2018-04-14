using UnityEngine;
using UnityEngine.UI;

namespace _2DAssets.Scripts._2DScripts
{
    public class Chronometer : MonoBehaviour
    {
        public float time;
        public Text txtTime;
	
        // Use this for initialization
        void Start () {
            txtTime.text = "0:00";
            time = 0;
        }
	
        void Update ()
        {
            TimeGame();
        }

        void TimeGame()
        {		
            time += Time.deltaTime;
            int minutes = (int) time / 60;
            int seconds = (int) time % 60;
            txtTime.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
        }
    }
}