using UnityEngine;
using Variables;
using FishNet.Object;

namespace Bullet
{
    public class BulletMovement : NetworkBehaviour
    {
        [SerializeField]FloatVariable _movementSpeed;

        private void Update()
        {
            Vector3 moveNormal = new Vector3(1, 0, 0f).normalized;

            transform.position += moveNormal * Time.deltaTime * _movementSpeed.Value;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Destroy");
            ServerManager.Despawn(gameObject);
            Destroy(gameObject);
        }
    }
}
