using System.Collections.Generic;
using UnityEngine;

public sealed class SkillModel
{
    private readonly Dictionary<uint, float> _skillCooling = new Dictionary<uint, float>();

    #region Inst
    private static readonly SkillModel Instant = new SkillModel();
    static SkillModel() { }
    private SkillModel() { }
    public static SkillModel Inst { get { return Instant; } }
    #endregion

    public bool IsSkillCooling(uint skillId)
    {
        if (!_skillCooling.ContainsKey(skillId))
            return false;
        float time = _skillCooling[skillId];
        return time > Time.time;
    }

    public void AddSkillCooling(uint skillId, float cooling)
    {
        if (cooling.Equals(0))
            return;
        _skillCooling[skillId] = Time.time + cooling;
    }
}