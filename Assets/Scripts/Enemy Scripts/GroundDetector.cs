using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // reference ke script enemycontroller di parent
    private EnemyController enemyControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyControllerScript = GetComponentInParent<EnemyController>();
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("ground"))
        {
            // menghadap ke arah sebaliknya
            enemyControllerScript.isFacingRight = !enemyControllerScript.isFacingRight;
            // kalau hadap kiri maka rotation y nya dibikin 180
            if (!enemyControllerScript.isFacingRight) // hadap kiri
            {
                // rotate juga hud nya
                // kenapa localEulerAngles?
                // karna kalau cuma eulerAngles ntar dia masih ketergantungan
                // ama parentnya
                // kalau mau ngubah value child, maka pakai local
                enemyControllerScript.healthBarHUD.localEulerAngles = Vector2.zero;
                enemyControllerScript.transform.eulerAngles = Vector2.up * 180;
            }
            else if (enemyControllerScript.isFacingRight) // hadap kanan
            {
                // dibalik lagi biar dia tetep posisinya
                enemyControllerScript.healthBarHUD.localEulerAngles = Vector2.up * 180;
                enemyControllerScript.transform.eulerAngles = Vector2.zero;
            }
        }
    }
}
