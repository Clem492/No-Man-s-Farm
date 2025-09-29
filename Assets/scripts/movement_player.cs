using UnityEngine;

public class movement_player : MonoBehaviour
{
  [SerializeField]  float player_speed;
    // fonction pour pouvoir déplacer le joueur 
    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, player_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -(player_speed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(player_speed) * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(player_speed * Time.deltaTime, 0, 0);
        }
    }

    private void Update()
    {
        movement();
    }
}
