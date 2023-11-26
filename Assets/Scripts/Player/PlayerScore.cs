using UnityEngine;

namespace Player
{
    public class PlayerScore : MonoBehaviour
    {
        private int _scoreValue;
        private int _score
        {
            get => _scoreValue;
            set
            {
                _scoreValue = value;
                PlayerEvents.UpdateScore(value);
            }
        }

        private void Awake()
        {
            PlayerEvents.OnOrderComplete += IncreaseScore;
        }

        private void Start()
        {
            _score = 0;
        }

        private void OnDestroy()
        {
            PlayerEvents.OnOrderComplete -= IncreaseScore;
        }

        private void IncreaseScore()
        {
            _score += 10;
        }
    }
}
