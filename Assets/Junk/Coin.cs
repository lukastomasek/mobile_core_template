using UnityEngine;
using Mobile_Core;

namespace Mobile_Test
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] int score = 10;
        ParticleSystem _particle;
        ScoreManager _score;

        private void Awake()
        {
            _particle = GetComponentInChildren<ParticleSystem>();
            _score = FindObjectOfType<ScoreManager>();
        }

        private void OnTriggerEnter(Collider item)
        {
            if (item.CompareTag(TagManager.PLAYER))
            {
                GameManager.OnUpdateScore?.Invoke(score);
          
                _particle.Play();
                Destroy(gameObject, 2);

            }
        }

    }

}