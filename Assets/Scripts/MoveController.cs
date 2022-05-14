using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class MoveController  : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rb;
    [SerializeField]
    float _moveSpeed = 10;
    [SerializeField] 
    Camera _camera;
    public void Move(Vector2 vectar2)
    {
        Vector3 dir = Vector3.forward * vectar2.y + Vector3.right * vectar2.x;

        if (dir == Vector3.zero)
        {
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;

            Vector3 velo = dir.normalized * _moveSpeed;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
    }
    public void Rotate(Vector2 vectar2)
    {
        Vector3 vec3 = _camera.transform.rotation.eulerAngles;
        vec3.x = 0;
        vec3.z = 0;
        this.transform.rotation = Quaternion.Euler(vec3);
    }
}
