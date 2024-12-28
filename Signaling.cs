using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private House _house;

    private AudioSource _audioSource;
    private float _speed = .5f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _house.WentPremises += OnWentHouse;
        _house.ExitPremises += OnExitHouse;
    }

    private void OnDisable()
    {
        _house.WentPremises -= OnWentHouse;
        _house.ExitPremises -= OnExitHouse;
    }

    private void OnWentHouse()
    {
        float valueVolume = 1f;
        StartCoroutine(SetVolume(valueVolume));
    }

    private void OnExitHouse()
    {
        float valueVolume = 0f;
        StartCoroutine(SetVolume(valueVolume));
    }

    private IEnumerator SetVolume(float targetValueVolume)
    {
        float time = 1f;

        while(time > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValueVolume, _speed * Time.deltaTime);
            time -= Time.deltaTime;
            yield return null;
        }
    }
}
