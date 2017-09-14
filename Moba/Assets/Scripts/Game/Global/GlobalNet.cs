using UnityEngine;
// ReSharper disable ObjectCreationAsStatement

public class GlobalNet : MonoBehaviour
{
	public void Start ()
	{
	    new PlayerNet();
	    new MatchNet();
	    new BattleNet();

    }
}
