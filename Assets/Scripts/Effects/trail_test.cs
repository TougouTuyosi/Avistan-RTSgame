#region 脚本说明
/*----------------------------------------------------------------
// 脚本作用：实现LineRenderer正弦摆动
// 创建者：霜狼望月
//----------------------------------------------------------------*/
#endregion
using UnityEngine;
using System.Collections;

public class trail_test : MonoBehaviour {

    public int vertexCount = 6;
    public float startPhase = 0f;

    public float length = 10f;
    public float Anispeed=5f;
    public float ani_offset = 0.5f;
    public AnimationCurve ac;

    float ani_fudu = 0.2f;
    float a;
    float a_cycle;
    Transform helper;
    LineRenderer lineR;
    bool ishaveLineR;


    void Start ()
    {

        ishaveLineR = this.GetComponent<LineRenderer>() != null;
        if (ishaveLineR)
        {
            lineR = this.gameObject.GetComponent<LineRenderer>();
            lineR.SetVertexCount(vertexCount + 1);
        }
        else {Debug.Log(this.name + "需要添加一个<LineRenderer>组件！！！");}

        if (this.transform.Find("helper"))
        {
           // Debug.Log("已经有辅助挂点！");
            helper = this.transform.Find("helper").transform;
            helper.localPosition = Vector3.zero;
            helper.rotation = this.transform.rotation;
        }
        else
        {
            GameObject g = new GameObject();
            g.name = "helper";
            g.transform.parent = this.transform;
            g.transform.position = this.transform.position;
            g.transform.rotation = this.transform.rotation;

            helper = g.transform;
        }

        startPhase = startPhase%360f;
        a = startPhase;
        a_cycle = Mathf.PI * 3600f;


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ishaveLineR) { lineR_Ani(); }
     
    }


    void lineR_Ani()
    {

        for (int i=0;i< vertexCount+1;i++)
        {
            a += Time.deltaTime * Anispeed/(i + 2f);
            if (a>a_cycle) {
                a = 0f;
               //Debug.Log("sin周期！");
            }

            ani_fudu =ac.Evaluate(i*1f/((float)(vertexCount-1)));//用曲线控制飘带各节点摆动的幅度；

            Vector3 pos= new Vector3(0, Mathf.Sin(a - i * ani_offset) * (ani_fudu), i * (length / (float)vertexCount)) ;
            helper.localPosition = pos;

            lineR.SetPosition(i,helper.position);

         
        }
    }

 
}
