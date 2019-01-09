using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
//--------------------------------
public class PlayerControl : MonoBehaviour
{
    //--------------------------------
    public enum FACEDIRECTION { FACELEFT = -1, FACERIGHT = 1 };
    //Player对象面对的方向是左还是右？ 
    public FACEDIRECTION Facing = FACEDIRECTION.FACERIGHT;
    //哪些对象的tag被标记为ground 
    public LayerMask GroundLayer;
    //对刚体的引用
    private Rigidbody2D ThisBody = null;
    //对transform组件的引用
    private Transform ThisTransform = null;
    //对脚部碰撞体的引用
    public CircleCollider2D FeetCollider = null;
    //我们碰到地面了吗?
    public bool isGrounded = false;
    //主要输入轴
    public string HorzAxis = "Horizontal";
    public string JumpButton = "Jump";
    //速度变量
    public float MaxSpeed = 20f;
    public float JumpPower = 600;
    public float JumpTimeOut = 0.2f;
    //我们现在可以跳了吗
    private bool CanJump = true;

    public bool CanControl = true;
    public static PlayerControl PlayerInstance = null;
    //--------------------------------
    public static float Health
    {
        get
        {
            return _Health;
        }

        set
        {
            _Health = value;

            //如果死亡的话，游戏也就结束了
            if (_Health <= 0)
            {
                Die();
            }
        }
    }

    [SerializeField]
    private static float _Health = 100f;
    //--------------------------------
    // 初始化
    void Awake()
    {
        //获取transform组件和 rigid body组件
        ThisBody = GetComponent<Rigidbody2D>();
        ThisTransform = GetComponent<Transform>();

        //设置静态实例
        PlayerInstance = this;
    }
    //--------------------------------
    //返回一个布尔值，玩家在地面上吗?
    private bool GetGrounded()
    {
        //检测地面
        Vector2 CircleCenter = new Vector2(ThisTransform.position.x,
          ThisTransform.position.y) + FeetCollider.offset;
        Collider2D[] HitColliders =
          Physics2D.OverlapCircleAll(CircleCenter, FeetCollider.radius, GroundLayer);
        if (HitColliders.Length > 0) return true;
        return false;
    }
    //--------------------------------
    //调转角色方向
    private void FlipDirection()
    {
        Facing = (FACEDIRECTION)((int)Facing * -1);
        Vector3 LocalScale = ThisTransform.localScale;

        ThisTransform.localScale = new Vector3(LocalScale.x * -1, LocalScale.y, LocalScale.z); ;
    }
    //--------------------------------
    //跳跃
    private void Jump()
    {
        //如果我们在地面上的话，就跳跃
        if (!isGrounded || !CanJump) return;

        //跳跃
        ThisBody.AddForce(Vector2.up * JumpPower);
        CanJump = false;
        Invoke("ActivateJump", JumpTimeOut);
    }
    //--------------------------------
    //在指定时间结束后激活允许跳跃变量
    //禁止第一次跳跃未结束时就二次起跳
    private void ActivateJump()
    {
        CanJump = true;
    }
    //--------------------------------
    //private void Update()
    //{
    //    float Horz = CrossPlatformInputManager.GetAxis(HorzAxis);
    //    Vector2 pos = ThisBody.position;
    //    pos.x +=  0.1f * Horz;
    //    ThisBody.position = pos;
    //}
    // Update函数在每一帧调用一次
    void FixedUpdate()
    {
        //如果我们不能控制角色，就退出
        if (!CanControl || Health <= 0f)
        {
            return;
        }

        //更新 grounded 变量状态
        isGrounded = GetGrounded();
        float Horz = CrossPlatformInputManager.GetAxis(HorzAxis);
        //ThisBody.AddForce(Vector2.right * Horz * MaxSpeed);
        if (Horz > 0)
            ThisBody.AddForce(Vector2.right * 0.3f * MaxSpeed);
        else if(Horz < 0)
            ThisBody.AddForce(Vector2.right * -0.3f * MaxSpeed);

        if (CrossPlatformInputManager.GetButton(JumpButton))
            Jump();

        //对速度进行限制
        ThisBody.velocity = new
          Vector2(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed,
            MaxSpeed),
          Mathf.Clamp(ThisBody.velocity.y, -Mathf.Infinity,
            JumpPower));

        //如果需要的话就调转方向
        if ((Horz < 0f && Facing != FACEDIRECTION.FACELEFT) ||
          (Horz > 0f && Facing != FACEDIRECTION.FACERIGHT))
            FlipDirection();
    }
    //--------------------------------
    void OnDestroy()
    {
        PlayerInstance = null;
    }
    //--------------------------------
    //杀死玩家的功能
    static void Die()
    {
        Object.Destroy(PlayerControl.PlayerInstance.gameObject);
    }
    //--------------------------------
    //重置Player 
    public static void Reset()
    {
        Health = 100f;
    }
    //--------------------------------
}