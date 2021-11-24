using UnityEngine;
using Mobile_Core;

namespace Mobile_Test
{
    public class Coin : MonoBehaviour
    {
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
                _score.IncreaseScore(5);
                _particle.Play();
                Destroy(gameObject, 2);

            }
        }

    }

}