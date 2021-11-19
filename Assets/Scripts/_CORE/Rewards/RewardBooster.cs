using UnityEngine;
using UnityEngine.UI;


namespace Mobile_Rewards
{
    public class RewardBooster : MonoBehaviour
    {
        [SerializeField] Image slider;
        [SerializeField] float speed = 1f;

        [SerializeField] RewardSlider changeDir;


        private void Start()
        {
            if (Random.Range(0, 2) > 0)
            {
                speed *= -1;
            }
        }

        private void Update()
        {

            if (changeDir.moveToOppositeDir)
            {
                speed *= -1;
                changeDir.moveToOppositeDir = false;
            }
        

            slider.transform.Rotate(new Vector3(slider.transform.rotation.x, slider.transform.rotation.y,
                  slider.transform.rotation.z + speed * Time.deltaTime));
        }
    }

}