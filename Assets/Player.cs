using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 speedZ;
    [SerializeField] private Vector3 speedX;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject aim;
    [SerializeField] private float upSpeed;
    public int Score = 0;
    [SerializeField] private Text text;

    [System.Obsolete]
    private void Start()
    {
        Screen.lockCursor = true;
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(speedZ * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-speedZ * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedX * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedX * Time.deltaTime, Space.Self);
        }
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * upSpeed), Space.Self);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shot(target, aim);
        }
        text.text = Score.ToString();
    }
    private void Shot(GameObject target, GameObject aim)
    {
        //сюда запишется инфо о пересечении луча, если оно будет
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = new Ray(aim.transform.position, aim.transform.forward);
        //пускаем луч
        Physics.Raycast(ray, out RaycastHit hit);

        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {
            if (hit.collider != null)
            {
                if (target.CompareTag(hit.collider.tag))
                {
                    hit.collider.transform.position = gameObject.transform.position + new Vector3(Random.Range(-15, 15), Random.Range(-1, 6), Random.Range(-15, 15));
                    Score += 1;
                }
            }
        }
    }
}
