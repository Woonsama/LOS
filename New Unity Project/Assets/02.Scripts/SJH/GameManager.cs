using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ObjectBase
{
    public GameObject bomb;

    public Transform playertr;

    public Player player;

    int bombcnt;

    protected override IEnumerator OnStartCoroutine()
    {
        
        yield break;
    }

    private void Update()
    {
        bombcnt = player.getbomb();

        if (Input.GetKeyDown(KeyCode.X)&&bombcnt>0)
        {
            Instantiate(bomb,player.getPos(),Quaternion.Euler(0,0,0));
            bombcnt--;
            player.setbomb(bombcnt);
        }

    }

    

}
