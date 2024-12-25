using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private House _house;

    private AudioSource _audioSource;
    private bool _isSignalingWork;
    private float _speed = .5f;
    private float maxVolume = 1f;
    private float minValue = 0f;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _house.WentHouse += OnWentHouse;
    }

    private void Update()
    {
        if (_isSignalingWork)
            SetVolume(maxVolume);
        else
            SetVolume(minValue);
    }

    private void OnDisable()
    {
        _house.WentHouse -= OnWentHouse;
    }

    private void OnWentHouse(bool isEnable)
    {
        _isSignalingWork = isEnable;
    }

    private void SetVolume(float targetValueVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValueVolume,_speed * Time.deltaTime);
    }
}
