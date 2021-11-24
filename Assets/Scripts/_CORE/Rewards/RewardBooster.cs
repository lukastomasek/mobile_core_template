using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mobile_Rewards
{
    public class RewardBooster : MonoBehaviour
    {
        [SerializeField] Image slider;
        [SerializeField] float rotatingSpeed = 1f;
        [SerializeField] float movingSpeed = 1f;

        [SerializeField] RewardSlider changeDir;
        [SerializeField] bool shouldRotate = true;
        [SerializeField] TextMeshProUGUI btnTxt;


        private void OnEnable()
        {
            RewardSlider.OnRewardChanged += UpdateButtonTxt;
        }

        private void OnDisable()
        {
            RewardSlider.OnRewardChanged -= UpdateButtonTxt;
        }

        private void Start()
        {
            if (Random.Range(0, 2) > 0)
            {
                rotatingSpeed *= -1;
                movingSpeed *= -1;
            }
        }

        public void UpdateButtonTxt(int booster)
        {
            btnTxt.SetText($"{booster}x");
        }

        private void Update()
        {

            if (changeDir.moveToOppositeDir)
            {
                rotatingSpeed *= -1;
                movingSpeed *= -1;
                changeDir.moveToOppositeDir = false;
            }

            if (shouldRotate)
            {

                slider.transform.Rotate(new Vector3(slider.transform.rotation.x, slider.transform.rotation.y,
                      slider.transform.rotation.z + rotatingSpeed * Time.deltaTime));
            }
            else
            {
                
                slider.transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
            }
        }
    }

}