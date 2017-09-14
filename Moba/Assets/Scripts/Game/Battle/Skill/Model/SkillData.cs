using UnityEngine;

public class SkillData : MovableData
{
    public Vector3 From { get { return Position; } }
    public Vector3 To { get { return _to; } }

    private Vector3 _to = new Vector3();

    public float Radian { get; private set; }

    public void UpdateData(float fromX, float fromZ, float toX, float toZ, float radian, float speed, float y)
    {
        UpdateData(new Vector3(fromX, y, fromZ), Quaternion.Euler(0, radian * Mathf.Rad2Deg, 0));
        _to.Set(toX, y, toZ);
        Speed = speed;
        Radian = radian;
    }
}
