using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] Vector2 _direction;
    [SerializeField] float _length;
    [SerializeField] bool _moveAtStart;
    Vector3 _offset;
    float sinWave;

    float _currentTime;

    private void FixedUpdate()   // To prevent camera stuttering when player on the platform. Stuttering in Update()
    {

        sinWave = Mathf.Sin(Time.timeSinceLevelLoad* _moveSpeed);
        if (!_moveAtStart) return;
        
        _offset = _direction.normalized * _length * sinWave;
        transform.position += _offset * Time.deltaTime;
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !_moveAtStart)
        {
                _moveAtStart = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            collision.collider.transform.SetParent(null);
    }
    
}
