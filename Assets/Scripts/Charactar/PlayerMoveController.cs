using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController  : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rb;
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    float _moveSpeed = 10;
    [SerializeField] 
    Camera _camera;
    public void Move(Vector2 vectar2)
    {
        if (GameManager.Instance.InGame == false) return;

        //入力をxz平面のベクトルに変換
        Vector3 dir = Vector3.forward * vectar2.y + Vector3.right * vectar2.x;

        if (dir == Vector3.zero)
        {
            //入力が無い時は停止する
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            //カメラが向いている方向に変換
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;

            Vector3 velo = dir.normalized * _moveSpeed;
            if (_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
    }
    public void Rotate(Vector2 vectar2)
    {
        if (GameManager.Instance.InGame == false) return;
        Vector3 vec3 = _camera.transform.rotation.eulerAngles;
        vec3.x = 0;
        vec3.z = 0;
        this.transform.rotation = Quaternion.Euler(vec3);
    }
}
