using UnityEngine;

[ExecuteInEditMode]
public class SkillDisplay : MonoBehaviour
{
    [SerializeField] private SkillDisplayType _displayType = SkillDisplayType.Single;  // 技能类型：单技能、散射技能
    [SerializeField] private SkillPlay _playType = SkillPlay.Instant;    // 播放类型：立即表现、移向目标
    [SerializeField] private SkillPosition _positionType = SkillPosition.Self;    // 起点类型：自身、目标
    [SerializeField] private SkillRotate _rotateType = SkillRotate.None;    // 旋转类型：不旋转、转向目标

    public void ApplyModifiedProperties()
    {
    }

    public SkillDisplayType DisplayType
    {
        get { return _displayType; }
    }

    public SkillPlay PlayType
    {
        get { return _playType; }
    }

    public SkillPosition PositionType
    {
        get { return _positionType; }
    }

    public SkillRotate RotateType
    {
        get { return _rotateType; }
    }
}