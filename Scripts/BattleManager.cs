using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BattleManager : IActorManagerInterface {

    private BoxCollider2D defCol;

    void Start() {
        defCol = GetComponent<BoxCollider2D>();
        defCol.offset = new Vector2(0.02f, 0.0f);
        defCol.size = new Vector2(0.44f, 1.2f);
        defCol.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Weapon")
        {
            am.TryDoDamage();
        }
    }
}
