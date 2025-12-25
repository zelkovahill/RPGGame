using UnityEngine;

namespace RPGGame
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField, Tooltip("오디오의 피치 값을 랜덤으로 설정할 지를 결정하는 옵션")] private bool _isRandomizePitch = false;
        [SerializeField, Tooltip("피치를 랜덤으로 설정할 때 적용할 임의의 범의 값")] private float _pitchRandomRange = 0.2f;
        [SerializeField, Tooltip("재생 시점을 조금 뒤로 미룰 때 사용할 시간 값 (초)")] private float _playDelay = 0f;
        [SerializeField, Tooltip("재상할 오디오 클립 배열")] private AudioClip[] _audioClips;
        private AudioSource _audioPlayer;   // 오디오를 재생할 컴포넌트

        private void OnEnable()
        {
            if (_audioPlayer == null)
            {
                _audioPlayer = GetComponent<AudioSource>();
            }
        }

        public void Play()
        {
            AudioClip clip = _audioClips[Random.Range(0, _audioClips.Length)];

            _audioPlayer.pitch = _isRandomizePitch ? Random.Range(1.0f - _pitchRandomRange, 1.0f + _pitchRandomRange) : 1.0f;
            _audioPlayer.clip = clip;

            _audioPlayer.PlayDelayed(_playDelay);
        }
    }
}