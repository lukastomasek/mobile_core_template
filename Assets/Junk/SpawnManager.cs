using UnityEngine;
using NaughtyAttributes;

namespace Mobile_Test
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField, Required, ShowAssetPreview(60, 60)] GameObject coinPrefab;
        [SerializeField, Required, ShowAssetPreview(60, 60)] GameObject obstaclePrefabs;

        [HorizontalLine(color: EColor.Green), Header("SETTINGS"), AllowNesting]
        [SerializeField] Gradient obstacleGradient;
        [SerializeField, Range(1f, 10f)] float gradientSpeed = 0.25f;
        [SerializeField] float minX, maxX;
        [SerializeField, MinMaxSlider(1f, 10f)] Vector2 randomSpawnTimer;

        float _currentTimer = 0f;
        float _colorTimer = 0f;
        float _randTimer = 0f;
        int _percantage = 0;
        bool _isPercentage = false;

        private void Awake()
        {
            RandomizeSpawnTimer();

        }

        private void Update()
        {


            _currentTimer += Time.deltaTime;
            //Debug.Log($"timer is : {_currentTimer}");

            if (_currentTimer > _randTimer)
            {
                _currentTimer = 0f;
                RandomizeSpawnTimer();


                _colorTimer += Time.deltaTime * gradientSpeed;

                if (_colorTimer > 1)
                    _colorTimer = 0;

                if (_isPercentage == false)
                {
                    _percantage = Random.Range(0, 100);
                    _isPercentage = true;
                    //Debug.Log($"<b>percantage :{_percantage}</b>");
                }

                if (_percantage <= 50)
                {
                    float randomXPos = Random.Range(minX, maxX);
                    GameObject coin = Instantiate(coinPrefab, new Vector3(randomXPos, 3, -5), Quaternion.identity);
                    coin.transform.SetParent(transform);

                    _isPercentage = false;

                }
                else if (_percantage >= 50)
                {        

                    float randomXPos = Random.Range(minX, maxX);
                    GameObject obstacle = Instantiate(obstaclePrefabs, new Vector3(randomXPos, 3, -5), Quaternion.identity);
                    obstacle.transform.SetParent(transform);

                    MeshRenderer renderer = obstacle.GetComponent<MeshRenderer>();
                    var color = obstacleGradient.Evaluate(_colorTimer);
                    renderer.sharedMaterial.color = color;

                    _isPercentage = false;
                }

            }
        }


        void RandomizeSpawnTimer()
        {
            _randTimer = Random.Range(randomSpawnTimer.x, randomSpawnTimer.y);
            //Debug.Log($"<color=orange>random timer :{_randTimer}</color>");
        }
    }

}