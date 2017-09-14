public enum SkillDisplayType
{
    Single,    // 单个技能
    Scatter,   // 散射技能
    Scene, // 场景技能
    Buff, // BUFF
    RangeRandom,  // 范围随机技能
    PointRandom,  // 固定点随机技能
    Hit  // 受击特效
}

public enum SkillPlay
{
    Instant,    // 立即表现
    Unit,   // 跟随实体单位
    Point    // 移向点
}

public enum SkillPosition
{
    Self,   // 自己身上
    Target // 目标身上
}

public enum SkillRotate
{
    None,   // 不旋转
    Target  // 转向目标
}