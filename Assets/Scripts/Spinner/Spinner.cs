using UnityEngine;

namespace Gallery.GUI
{
    public class Spinner : MonoBehaviour
    {
        [field: SerializeField]
        private float RotationSpeed { get; set; }

        protected virtual void Update ()
        {
            gameObject.transform.Rotate(Vector3.forward * RotationSpeed);
        }
    }

}