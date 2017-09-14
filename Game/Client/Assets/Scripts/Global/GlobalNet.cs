using Assets.Scripts.Battle.Entity;
using Assets.Scripts.Battle.Player;
using Assets.Scripts.Login.Control;
using UnityEngine;

// ReSharper disable ObjectCreationAsStatement

namespace Assets.Scripts.Global
{
    public class GlobalNet : MonoBehaviour
    {
        public void Start ()
        {
            new PingNet();
            new LoginNet();
            new EntityNet();
            new PlayerNet();
        }
    }
}
