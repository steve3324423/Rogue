using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _defaultPosition;
    private float _speed = 5f;

    private void Awake()
    {
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        Moves();
    }

    private void Moves()
    {
        Vector3 offset = transform.position - _target.position;
        float minDistance = .01f;

        if (offset.sqrMagnitude <= minDistance * minDistance)
            _target.position = _defaultPosition;

        transform.position = Vector3.MoveTowards(transform.position,_target.position,_speed * Time.deltaTime);
    }
}
