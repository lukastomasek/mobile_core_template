using UnityEngine;
using NaughtyAttributes;

namespace Mobile_Test
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField, Required, ShowAssetPreview(60, 60)] GameObject coinPrefab;
        [SerializeField, Required, ShowAssetPreview(60, 60)] GameObject obstaclePrefabs;

        [HorizontalLine(color: EColor.Green), Header("SETTINGS")]
        [SerializeField] Gradient obstacleGradient;
        [SerializeField] float minX, maxX;
        [SerializeField, MinMaxSlider(1f, 10f)] Vector2 randomSpawnTimer;

        float _currentTimer = 0f;
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

                if (_isPercentage == false)
                {
                    _percantage = Random.Range(0, 100);
                    _isPercentage = true;
                    Debug.Log($"<b>percantage :{_percantage}</b>");
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
                    renderer.sharedMaterial.color = obstacleGradient.Evaluate(Random.Range(0, -1));

                    _isPercentage = false;
                }

            }
        }


        void RandomizeSpawnTimer()
        {
            _randTimer = Random.Range(randomSpawnTimer.x, randomSpawnTimer.y);
            Debug.Log($"<color=orange>random timer :{_randTimer}</color>");
        }
    }

}