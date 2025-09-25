using UnityEngine;

public class MissileControler : MonoBehaviour
{
    public float missileSpeed = 25f;
    void Update()
    {
        transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            Destroy(gm, 2f);
            GameManager.instance.AddScore(10);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
