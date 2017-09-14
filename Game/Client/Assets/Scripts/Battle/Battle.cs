using Battle;
using Common.Network;
using GameProtocol;
using UnityEngine;

namespace Assets.Scripts.Battle
{
    public class Battle : MonoBehaviour
    {
        public static Battlefield Battlefield;

        // Use this for initialization
        public void Start()
        {
            if (NetMessage.Connection != null)
                NetMessage.Send(MessageType.RequestBattle, new RequestBattle(), this);

            WindowManager.Add((int)WindowId.Battle, "Battle", typeof(BattleWindow), typeof(BattleBinder), typeof(UIBattle));

            WindowManager.Open((int)WindowId.Battle);
        }

        // Update is called once per frame
        public void Update()
        {
            if (Battlefield != null)
                Battlefield.Process();
        }

        public void FixedUpdate()
        {
            KeyboardHandler();
        }

        private void KeyboardHandler()
        {
            float xDelta = Input.GetAxis("Horizontal");
            float yDelta = Input.GetAxis("Vertical");
            if (!xDelta.Equals(0) || !yDelta.Equals(0))
            {
                float radian = Mathf.Atan2(xDelta, yDelta);
                BattleEvent.Inst.AddEvent(BattleEventType.MoveJoystick, radian);
            }
        }
    }

}
