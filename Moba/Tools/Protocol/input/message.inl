MSGTYPE_BEGIN_BLOCK

MSGTYPE_DECLARE_ASSIGN(MSG_ECHO_REQUEST, 5),
MSGTYPE_DECLARE_ASSIGN(MSG_ECHO_RESPONSE, 6),
MSGTYPE_DECLARE_ASSIGN(MSG_LICENSE_NOTIFY, 7),
MSGTYPE_DECLARE_ASSIGN(MSG_SOCKET_EVENT, 8),
MSGTYPE_DECLARE_ASSIGN(MSG_SYSTEM_TIME_IMPLUS, 9),
MSGTYPE_DECLARE_ASSIGN(MSG_CLIENT_MANAGE_START,10), // reserve 10-19 for client management
// server internal
// net layer -> app layer
MSGTYPE_DECLARE(MSG_CLIENT_MANAGE_CONNECT_INDICATE),
MSGTYPE_DECLARE(MSG_CLIENT_MANAGE_DISCONNECT_INDICATE),
// app layer -> net layer
MSGTYPE_DECLARE(MSG_CLIENT_MANAGE_DISCONNECT_COMMAND),
MSGTYPE_DECLARE(MSG_CLIENT_MANAGE_RECONNECT_COMMAND),

// app layer -> net layer
// open a connection, used by npc server
MSGTYPE_DECLARE(MSG_CLIENT_MANAGE_OPENCONNECT_COMMAND),
// net layer -> app lay
MSGTYPE_DECLARE(MSG_CLIENT_MANAGE_OPENFAILED_INDICATE),

// client -> server
MSGTYPE_DECLARE(MSG_CLIENT_REQUEST_RECONNECT),
// server -> client
MSGTYPE_DECLARE(MSG_CLIENT_REJECT_RECONNECT),
MSGTYPE_DECLARE(MSG_CLIENT_APPROVE_RECONNECT),

// -----------------------------------------------------------------------/
/*   由客户端可以发送的消息                                                */
// --------------------------------------------------------------------—--/
MSGTYPE_DECLARE_ASSIGN(MSG_CLIENT_START, 50),
// -----------------------------------------------------------------------/
/*   不需要gate转发的消息                                                  */
// --------------------------------------------------------------------—--/
//第零部分：认证服务器消息
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_AUTH_LOGIN),       //向认证前端服务器请求密码验证
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_PROTOCOL_VERSION), //向认证服务器验证协议版本
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_REGION_SESSION),   //向认证服务器请求登录到区服网关
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_SERVER_LOGIN),     //向网关服务器请求登录
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_SERVER_LOGOUT),    //向网关服务器请求退出登录
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_WORLD_ENTER),      //客户端在选取角色，载入地图之后，发送给服务器
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_WORLD_LOGOUT),     //离开游戏，再进入需要在认证服务器重新认证
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_CANCEL_LOGOUT),    //打断正在离开游戏的请求
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_SWITCH_LINE),      //请求切换分线

// 系统协议
MSGTYPE_DECLARE(MSG_SYSTEM_HEARTBEAT),              // 心跳消息
MSGTYPE_DECLARE(MSG_REQUEST_PING),                  // 客户端向服务端请求ping值
MSGTYPE_DECLARE(MSG_GM_COMMAND),                    // GM指令 gate
MSGTYPE_DECLARE(MSG_GM_GAME_COMMAND),               // GM指令 gate->game

// 角色创建
MSGTYPE_DECLARE(MSG_CHARCREATE_REQUEST),            // 请求进行角色创建
MSGTYPE_DECLARE(MSG_CHAR_NAME_UNIQUE_REQUEST),            // 名称唯一性检测
MSGTYPE_DECLARE(MSG_CHAR_CURRENCY_REQUEST_RMB_TRANSER),     // 请求进行RMB兑换
MSGTYPE_DECLARE(MSG_CHAR_CURRENCY_REQUEST_RMB),     		// 请求RMB的数量
MSGTYPE_DECLARE(MSG_REQUEST_CREATE_TEAM),                   // 创建战队
MSGTYPE_DECLARE(MSG_REQUEST_CREATE_GUILD),              // 请求创建军团
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_GIFT),                    // 请求领取军团礼包
MSGTYPE_DECLARE(MSG_REQUEST_TRANSFER_TEAM_COIN),        // 请求转移战队的资金到军团
MSGTYPE_DECLARE(MSG_CLIENT_DATA_STAT),                      // 客户端数据采集
MSGTYPE_DECLARE(MSG_REQUEST_USE_SPRAY),                     // 请求更换喷图
MSGTYPE_DECLARE(MSG_REQUEST_STAGE_REAP_REWARD),			// 请求领取阶段性奖励
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_NAME),           	// 请求修改角色名
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_TEAM_NAME),          // 请求修改战队名
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_GUILD_NAME),         // 请求修改军团名
MSGTYPE_DECLARE(MSG_REQUEST_BUY_THEW),                  // 请求购买体力
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_SETTING),            // 请求保存系统设置
MSGTYPE_DECLARE(MSG_REQUEST_PICK_CASHBACK),             // 请求领取礼券月卡的返点
MSGTYPE_DECLARE(MSG_NOTIFY_CASHBACK_INFO),              // 返回礼券月卡的更新信息
MSGTYPE_DECLARE(MSG_REQUEST_PICK_PRENTICE_CASHBACK),    // 请求领取徒弟充值返利
MSGTYPE_DECLARE(MSG_NOTIFY_PRENTICE_CASHBACK_INFO),     // 返回徒弟充值返利信息
MSGTYPE_DECLARE(MSG_REQUEST_PAYMENT_RMB),               // 请求充值
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_CHAR_DATA),           // 通知同步角色数据
MSGTYPE_DECLARE(MSG_REQUEST_OBSERVER_LOGIN),       			// 请求附身登陆
MSGTYPE_DECLARE(MSG_REQUEST_PROTECT_PWD_OP),    				///<请求2级密保相关操作
MSGTYPE_DECLARE(MSG_REQUEST_SET_CHAR_OPTION),    				// 请求更新系统设置
MSGTYPE_DECLARE(MSG_REQUEST_SUPER_VIP_CHARGE_INFO), 		// 请求超级VIP充值信息
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_SUPER_VIP_CHARGE_BACK),        // 请求领取超级VIP返还
MSGTYPE_DECLARE(MSG_APEX_SEND2SERVER),          				///< 由 game client 发送给 gate server 的 Apex 消息
MSGTYPE_DECLARE(MSG_APEX_SENDRETVAL2SERVER),    				///< 由 game client 发送给 gate server 的关于chcstart的返回值消息

// 物品相关协议
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_SWAP_ITEM, 150),     // 移动物品
MSGTYPE_DECLARE(MSG_REQUEST_SALE_ITEM),                 // 请求出售物品
MSGTYPE_DECLARE(MSG_REQUEST_CONT_CLEANUP),              // 请求整理包裹
MSGTYPE_DECLARE(MSG_REQUEST_USE_ITEM),                  // 请求使用物品
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_AWARD),                // 请求领取奖励
MSGTYPE_DECLARE(MSG_REQUEST_CONVERT_ITEM),              // 请求兑换物品
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_PLANT),             // 请求培养助手
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_STTH),              // 请求强化助手
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMPOSE),           // 请求合成助手
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_TRANS),             // 请求助手转换
MSGTYPE_DECLARE(MSG_REQUEST_READ_ITEM),                 // 请求查看物品
MSGTYPE_DECLARE(MSG_REQUEST_ROULETTE),                  // 请求轮盘赌
MSGTYPE_DECLARE(MSG_REQUEST_SPLIT_ITEM),                // 请求拆解物品
MSGTYPE_DECLARE(MSG_REQUEST_EXPAND_CONTAINER),          // 请求扩展容器
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GIFT),                 // 请求领取礼包
MSGTYPE_DECLARE(MSG_REQUEST_CONTAINER_ITEM),            // 请求获取容器物品
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_BATTLE_BOOSTER),     // 请求切换主战助手
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GOLDEN_POOL),          // 请求领取金币池内的金币
MSGTYPE_DECLARE(MSG_REQUEST_BIND_ITEM_ADDRESS),         // 请求绑定物品的邮寄地址
MSGTYPE_DECLARE(MSG_REQUEST_ITEM_ROULETTE),             // 请求使用物品轮盘赌
MSGTYPE_DECLARE(MSG_REQUEST_SEL_AWARD_USE_ITEM),        // 请求使用物品获取选择奖励

// 坦克相关
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_TANK_BATTLE, 200),   // 请求坦克出战
MSGTYPE_DECLARE(MSG_REQUEST_TANK_DELETE),               // 请求删除坦克
MSGTYPE_DECLARE(MSG_REQUEST_TANK_HIRE),                 // 请求租用坦克
MSGTYPE_DECLARE(MSG_REQUEST_TANK_UP),                   // 请求坦克升级
MSGTYPE_DECLARE(MSG_REQUEST_TANK_STTH),                 // 请求坦克强化
MSGTYPE_DECLARE(MSG_REQUEST_TANK_SKILL_UP),             // 请求坦克技能升级
MSGTYPE_DECLARE(MSG_REQUEST_TANK_TRY),                  // 请求试用坦克(废弃)
MSGTYPE_DECLARE(MSG_REQUEST_TANK_CHANGE_SKIN),          // 请求更换坦克皮肤
MSGTYPE_DECLARE(MSG_REQUEST_TANK_SKILL_UPGRADE),        // 请求坦克技能树升级
MSGTYPE_DECLARE(MSG_REQUEST_TANK_QUICK_UP),             // 请求坦克一键升级
MSGTYPE_DECLARE(MSG_REQUEST_PRESENT_HIRE_TANK),         // 请求赠送租用坦克
MSGTYPE_DECLARE(MSG_REQUEST_USE_TANK_HALO),             // 请求使用坦克光环
MSGTYPE_DECLARE(MSG_REQUEST_USE_FREE_WEEK_TANK),        // 请求使用周免坦克（客户端没有周免坦克实例时，调用该协议）
MSGTYPE_DECLARE(MSG_REQUEST_BUY_TANK_SKIN_CHIP),        // 请求购买坦克皮肤碎片
MSGTYPE_DECLARE(MSG_REQUEST_GET_TANK_SKIN),             // 请求将坦克皮肤碎片兑换成坦克皮肤
MSGTYPE_DECLARE(MSG_REQUEST_GET_RARE_TANK),             // 请求领取稀有坦克奖励
MSGTYPE_DECLARE(MSG_REQUEST_SELECT_USE_TANK),           // 选坦克阶段请求切换坦克
MSGTYPE_DECLARE(MSG_REQUEST_TANK_RESEARCH_INFO),        // 请求坦克研究信息
MSGTYPE_DECLARE(MSG_REQUEST_TANK_RESEARCH),             // 请求研究坦克
MSGTYPE_DECLARE(MSG_REQUEST_RECYCLE_TANK_RESEARCH),     // 请求兑换研究进度为经验
MSGTYPE_DECLARE(MSG_REQUEST_GET_RESEARCH_TANK),         // 请求换取已研究完成的坦克
MSGTYPE_DECLARE(MSG_REQUEST_OPERATE_TANKPART),          // 请求操作坦克部件
MSGTYPE_DECLARE(MSG_REQUEST_START_TREASURE),            // 请求一元夺宝
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_TREASURE_AWARD),       // 请求领取夺宝奖励

//商城相关
MSGTYPE_DECLARE_ASSIGN(MSG_GOODS_SHOP_BUY, 250),        // 购买商城物品
MSGTYPE_DECLARE(MSG_GOODS_SHOP_BUY_MULTI),              // 商城购买物品
MSGTYPE_DECLARE(MSG_GOODS_SHOP_LARGESS),                // 商城赠送物品
MSGTYPE_DECLARE(MSG_GOODS_SHOP_LARGESS_MULTI),          // 商城赠送物品
MSGTYPE_DECLARE(MSG_REQUEST_SCENE_SHOP_BUY),            // 请求游戏币购买道具
MSGTYPE_DECLARE(MSG_REQUEST_CLIP_BUY),                  // 请求购买弹夹道具
MSGTYPE_DECLARE(MSG_REQUEST_STORE_MERCHANDISE),         // 请求打开商店(会检查刷新)
MSGTYPE_DECLARE(MSG_REQUEST_REFRESH_STORE),             // 请求主动刷新商店
MSGTYPE_DECLARE(MSG_REQUEST_STORE_PURCHASE),            // 请求购买商店物品
MSGTYPE_DECLARE(MSG_REQUEST_BUY_MYSTICAL_SHOP_GOODS),   // 请求购买神秘商店商品
MSGTYPE_DECLARE(MSG_REQUEST_STORE_ENABLE),              // 请求开通商店进入权限

// 邮件相关
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_MAIL_SEND, 270),     // 请求发送邮件
MSGTYPE_DECLARE(MSG_REQUEST_MAIL_OPERATE),              // 请求邮件操作
MSGTYPE_DECLARE(MSG_REQUEST_PICKUP_MAIL_ITEM),          // 请求提取邮件物品

// 任务成就相关
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_COMPLETE_QUEST, 280),// 请求完成任务，领取任务奖励
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_UI),                   // 请求打开界面
MSGTYPE_DECLARE(MSG_REQUEST_SHARE_ENJOYMENT),           // 分享快乐
MSGTYPE_DECLARE(MSG_REQUEST_SET_DESKTOP),               // 收藏桌面
MSGTYPE_DECLARE(MSG_REQUEST_READ_QUEST),                // 请求读取任务信息（全服任务使用）
MSGTYPE_DECLARE(MSG_REQUEST_SWITCH_QUEST),              // 请求切换任务
MSGTYPE_DECLARE(MSG_REQUEST_LIKE_US),                   // 赞
MSGTYPE_DECLARE(MSG_REQUEST_GET_ITEM_QUEST),            // 请求获得物品任务

// 客户端请求的单人副本相关消息
MSGTYPE_DECLARE_ASSIGN(MSG_PVE_SELECT_SCENE, 300),      // 请求选择开始某个章节内的关卡
MSGTYPE_DECLARE(MSG_PVE_REQUEST_REFRESH_REWARD),        // 请求刷新PVE副本的结算信息
MSGTYPE_DECLARE(MSG_PVE_REQUEST_GATHER_REWARD),         // 请求收获某个PVE副本的产出
MSGTYPE_DECLARE(MSG_PVE_REQUEST_SMASH_EGG),             // 请求收获章节的彩蛋
MSGTYPE_DECLARE(MSG_PVE_REQUEST_TUTOR_MAP),             // 请求参加对应的训练关卡
MSGTYPE_DECLARE(MSG_PVE_REQUEST_TANK_TRIAL_MAP),        // 请求选择坦克开始试玩副本
MSGTYPE_DECLARE(MSG_REQUEST_RESET_MAP_ENTER_COUNT),     // 请求重置副本进入次数
MSGTYPE_DECLARE(MSG_SOLO_REQUEST_SWEEP_MAP),            // 请求地图扫荡
MSGTYPE_DECLARE(MSG_REQUEST_SOLO_PVE_INFO),             // 请求副本信息


// 军团相关消息
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_LEARN_GUILD_SKILL, 320), //角色请求学习军团技能
MSGTYPE_DECLARE(MSG_REQUEST_UNLOCK_SKILL_SLOT),             ///< 角色请求解锁军团技能格
MSGTYPE_DECLARE(MSG_REQUEST_SET_GUILD_SKILL),               ///< 请求设定角色军团技能
MSGTYPE_DECLARE(MSG_REQUEST_START_GUILD_BOSS),              ///< 请求参加军团BOSS战斗
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GUILD_BOSS_AWARD),         ///< 请求领取军团BOSS奖励

// 指挥官技能
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_SET_COMMANDER_SKILL, 340),   ///< 请求设定指挥官技能

// 活动相关
MSGTYPE_DECLARE_ASSIGN(MSG_ACTIVITY_ENTER_BOSS, 350),       ///< 请求参加世界boss活动
MSGTYPE_DECLARE(MSG_REQUEST_PRESENT_VALENTINE_FLAUNT),      ///< 请求七夕送花
MSGTYPE_DECLARE(MSG_REQUEST_RAND_STEP_SUPPORT),             ///< 请求夺宝排行点赞
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_STAGE_WEEK_FIZZ_AWARD),    ///< 请求领取阶段周活跃奖励
MSGTYPE_DECLARE(MSG_OPEN_FUNC_NOTIFY_UI),                   ///< 通知打开功能通知界面
MSGTYPE_DECLARE(MSG_CLOSE_FUNC_NOTIFY_UI),                  ///< 通知关闭功能通知界面
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMP_INFO),             ///< 请求角色助手竞技场信息
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMP_RANK_AWARD),       ///< 请求领取助手挑战赛每日排行奖励
MSGTYPE_DECLARE(MSG_REQUEST_CLR_BST_COMP_COOL_TIME),        ///< 请求清除助手挑战赛冷却时间
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_BATTLE),                ///< 请求进行助手对战
MSGTYPE_DECLARE(MSG_REQUEST_SIGN_IN),                       ///< 请求签到
MSGTYPE_DECLARE(MSG_REQUEST_STAGE_SIGN_IN_AWARD),           ///< 请求累计签到奖励
MSGTYPE_DECLARE(MSG_REQUEST_VIP_DOUBLE_AWARD),          // 请求获取vip双倍的另外一份奖励
MSGTYPE_DECLARE(MSG_REQ_SERVER_LOGIN_CONFIG),           // 请求服务端登陆配置信
MSGTYPE_DECLARE(MSG_REQUEST_SEND_REDPACKET),        						// 请求发红包
MSGTYPE_DECLARE(MSG_REQUEST_ROB_REDPACKET),                     // 请求抢红包
MSGTYPE_DECLARE(MSG_REQUEST_REDPACKET_LOG),                     // 请求查看红包历史记录
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_CHEST),                     		// 请求开宝箱
MSGTYPE_DECLARE(MSG_REQUEST_CLOUD_PURCHASE_BUY),     						// 请求云购购买
MSGTYPE_DECLARE(MSG_REQUEST_GET_CLOUD_PURCHASE_BUY_INFO),        // 请求获取云购购买信息
MSGTYPE_DECLARE(MSG_REQUEST_BIND_INVITE_SPREAD_PLAYER),  					// 请求绑定邀请推广玩家
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_BIND_INVITE_SPREAD_AWARD),        	// 请求领取军团BOSS奖励
MSGTYPE_DECLARE(MSG_REQUEST_RAND_STEP),     						// 请求冒险夺宝
MSGTYPE_DECLARE(MSG_REQUEST_BUY_FUND),     					// 请求购买成长基金
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_FUND),             // 请求领取基金
MSGTYPE_DECLARE(MSG_REQUEST_MAKE_TANK),     				// 请求制造坦克
MSGTYPE_DECLARE(MSG_REQUEST_EXPEDITION),               			// 请求远征
MSGTYPE_DECLARE(MSG_REQUEST_CANCEL_EXPEDITION),             // 请求取消远征
MSGTYPE_DECLARE(MSG_REQUEST_GET_EXPEDITION_AWARD),          // 请求远征领取奖励
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_INVITE_GIFT_AWARD),            // 请求领取邀请好礼奖励
MSGTYPE_DECLARE(MSG_REQUEST_NEW_SIGN_IN),       				// 请求新版签到
MSGTYPE_DECLARE(MSG_REQUEST_NEW_STAGE_SIGN_IN_AWARD),       // 请求新版累计签到奖励

// 角色社交相关
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_ELIMINATE_REL, 400),     ///< 请求解除关系
MSGTYPE_DECLARE(MSG_REQUEST_ESTABLISH_REL),                 ///< 请求建立社交关系
MSGTYPE_DECLARE(MSG_REQUEST_QQ_GIFT_OP),                    ///< 请求qq好友礼物操作
MSGTYPE_DECLARE(MSG_REQUEST_SET_INVITER_ACCTID),            ///< 请求填写邀请者账号id
//新手引导以及师徒系统相关
MSGTYPE_DECLARE(MSG_CHAR_GUIDE_UPDATE),						// 更新角色完成新手引导的进度
MSGTYPE_DECLARE(MSG_REQUEST_SOCIAL_TICKET),				// 申请临时师徒的邀请码
MSGTYPE_DECLARE(MSG_CONFIRM_SOCIAL_TICKET),				// 确认使用临时师徒的邀请码
MSGTYPE_DECLARE(MSG_REQUEST_SOCIAL_AWARD),				// 领取临时师徒的奖励


//属性相关
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_ADD_TALENT_PAGE, 420),   		// 请求添加天赋页
MSGTYPE_DECLARE(MSG_REQUEST_SAVE_TALENT_PAGE),              		// 请求保存天赋页
MSGTYPE_DECLARE(MSG_REQUEST_OP_TALENT_PAGE),                		// 请求天赋页操作
MSGTYPE_DECLARE(MSG_REQUEST_CRYSTAL_SCHEME_INFO),    						// 请求获取晶片组合信息
MSGTYPE_DECLARE(MSG_REQUEST_SAVE_CRYSTAL_SCHEME_INFO),           // 请求保存晶片组合信息
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_CRYSTAL_SCHEME_NAME),         // 请求改变晶片组合方案名
MSGTYPE_DECLARE(MSG_REQUEST_UPGRADE_CRYSTAL),                    // 请求升阶晶片
MSGTYPE_DECLARE(MSG_REQUEST_SET_CUR_CRYSTAL_SCHEME_ID),          // 请求设置当前晶片方案ID
MSGTYPE_DECLARE(MSG_REQUEST_LEVELUP_YCARD),     								// 请求佣兵卡升级
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_HONOR),											//< 请求更换荣誉




//////////////////////////////////////////////////////////////////////////
// 发给聊天服务器的消息
MSGTYPE_DECLARE_ASSIGN(MSG_CHAT_MESSAGE, 450),          //聊天消息
MSGTYPE_DECLARE(MSG_REQUEST_QUESTION),                  //玩家提问
MSGTYPE_DECLARE(MSG_QUESTION_CLOSED),                   //玩家关闭问题
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_QUESTION),             //玩家打开问题反馈界面
MSGTYPE_DECLARE(MSG_CHAT_TEST_PING),                  	//聊天测试协议

//////////////////////////////////////////////////////////////////////////
// -----------------------------------------------------------------------/
/* client -> server, report to server                                     */
/* 需要gate转发的消息                                                      */
// --------------------------------------------------------------------—--/
MSGTYPE_DECLARE_ASSIGN(MSG_NEED_GATE_TRANSFER, 500),
// 需要转发给GAME的消息
MSGTYPE_DECLARE(MSG_REQUEST_MOVE_FORWARD),          // 移动
MSGTYPE_DECLARE(MSG_REQUEST_STOP_MOVE),             // 停止移动
MSGTYPE_DECLARE(MSG_REQUEST_VALIDATE_POS),
MSGTYPE_DECLARE(MSG_REQUEST_USE_SKILL),             // 请求使用技能
MSGTYPE_DECLARE(MSG_REQUEST_TANK_RELIVE),           // 请求坦克复活
MSGTYPE_DECLARE(MSG_REQUEST_STAT_LIST),             // 客户端请求坦克技术统计列表
MSGTYPE_DECLARE(MSG_REQUEST_BUY_LIFE),              // 客户端请求买活
MSGTYPE_DECLARE(MSG_REQUEST_OP_SPRAY),              // 请求喷图
MSGTYPE_DECLARE(MSG_REQUEST_TRY_BOOSTER),           // 请求试用小助手
MSGTYPE_DECLARE(MSG_REQUEST_EXIT_BATTLE),           // 客户端请求退出战场
MSGTYPE_DECLARE(MSG_REQUEST_AUTO_BULLET),           // 请求对鼠标指针方向自动释放一个子弹
MSGTYPE_DECLARE(MSG_REQUEST_SIGNAL_INFO),           // 客户端请求信号机制
MSGTYPE_DECLARE(MSG_REQUEST_SURRENDER_VOTATION),    // 请求发起投降表决
MSGTYPE_DECLARE(MSG_SET_SURRENDER_DECISION),        // 设置玩家自己的投降信息
MSGTYPE_DECLARE(MSG_ROUTE_TO_GAME_END),             // 发给GAME的消息结束

//////////////////////////////////////////////////////////////////////////
// 需要转发给TRACK的消息
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_TRACK, 550),
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_TURNUP),           // 请求翻牌
MSGTYPE_DECLARE(MSG_REQUEST_ENTER_BATTLE),          // 客户端数据加载完成请求进入战场
MSGTYPE_DECLARE(MSG_IMPEACH_BAD_PLAYER),            // 举报玩家
MSGTYPE_DECLARE(MSG_REQUEST_RLTE_AWARD_LIST),       // 请求轮盘赌的近期获奖列表
MSGTYPE_DECLARE(MSG_REQUEST_SERVER_CHARGE_INFO),    // 请求每日充值信息
MSGTYPE_DECLARE(MSG_ACTIVITY_BOSS_OPEN_UI),         // 打开世界boss活动UI
MSGTYPE_DECLARE(MSG_ACTIVITY_BOSS_CLOSE_UI),        // 关闭世界boss活动UI
MSGTYPE_DECLARE(MSG_REQUEST_PVE_RECORD),                // 请求PVE通关记录信息
MSGTYPE_DECLARE(MSG_REQUEST_SET_BATTLE_MODE),       // 请求设置匹配模式
MSGTYPE_DECLARE(MSG_REQUEST_SVR_AWARD_LIST),       // 请求svr_award的近期获奖列表

// 联赛相关消息
MSGTYPE_DECLARE(MSG_SELECT_MATCH_RACE),                 // 战队选择参战赛事
MSGTYPE_DECLARE(MSG_REQUEST_CHALLENGE_LIST),            // 请求约战列表
MSGTYPE_DECLARE(MSG_REQUEST_CHALLENGE_TEAM),            // 请求约战
MSGTYPE_DECLARE(MSG_REQUEST_TEAM_MATCH_START),          // 请求开始战队排位赛
MSGTYPE_DECLARE(MSG_LEAGUE_START_PAIR),                 // 请求开始联赛匹配
MSGTYPE_DECLARE(MSG_LEAGUE_STOP_PAIR),                  // 请求停止联赛匹配
MSGTYPE_DECLARE(MSG_TEAM_MATCH_START_PAIR),             // 请求开始战队赛匹配
MSGTYPE_DECLARE(MSG_TEAM_MATCH_STOP_PAIR),              // 请求停止战队赛匹配
MSGTYPE_DECLARE(MSG_REQUEST_LEAGUE_TEAM_QUIZ),          // 请求押注邀请赛队伍
MSGTYPE_DECLARE(MSG_REQUEST_DECIDE_MATCH_WINNER),       // 请求设定邀请赛比赛结果

// 军团赛相关
MSGTYPE_DECLARE(MSG_GUILD_MATCH_START_PAIR),            // 请求开始军团赛匹配
MSGTYPE_DECLARE(MSG_GUILD_MATCH_STOP_PAIR),             // 请求停止军团赛匹配

// 助手挑战赛相关
MSGTYPE_DECLARE(MSG_REQUEST_CLEAR_BOOSTER_COOL_TIME),    ///< 请求清空助手挑战赛冷却时间
MSGTYPE_DECLARE(MSG_REQUEST_BUY_BST_ENTER),              ///< 请求购买助手赛进入次数


// 房间相关协议
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_CREATE_ROOM, 600),   // 创建房间
MSGTYPE_DECLARE(MSG_REQUEST_JOIN_ROOM),                 // 加入房间
MSGTYPE_DECLARE(MSG_REQUEST_ROOM_OP),                   // 客户端请求房间操作
MSGTYPE_DECLARE(MSG_SET_ROOM_MAP),                      // 切磋模式请求选择地图
MSGTYPE_DECLARE(MSG_REQUEST_PLAYER_LIST),               // 客户端请求玩家列表
MSGTYPE_DECLARE(MSG_SYNC_LOAD_DELAY),                   // 同步客户端加载进度和网络延迟
MSGTYPE_DECLARE(MSG_REQUEST_CHAR_STATE),                // 客户端查询玩家状态
MSGTYPE_DECLARE(MSG_REQUEST_IN_HALL),                   // 通知进入游戏大厅
MSGTYPE_DECLARE(MSG_REQUEST_OUT_HALL),                  // 通知离开游戏大厅
MSGTYPE_DECLARE(MSG_REJECT_ROOM_INVITE),                // 拒绝房间邀请
MSGTYPE_DECLARE(MSG_REQUEST_START_MATCH),               // 请求开始
MSGTYPE_DECLARE(MSG_REQUEST_STOP_MATCH),                // 请求停止赛配对
MSGTYPE_DECLARE(MSG_REQUEST_LOOK_SCENE),                // 通过战场id请求观战
MSGTYPE_DECLARE(MSG_REQUEST_EXIT_BATTLEEND),            // 请求退出战斗结算
MSGTYPE_DECLARE(MSG_REQUEST_LOCK_TANK),                 // 选坦克阶段玩家锁定坦克
MSGTYPE_DECLARE(MSG_REQUEST_LOOK_ROOM),                 // 加入房间观战
MSGTYPE_DECLARE(MSG_REQUEST_OTHER_GUILD_MATCH_ROOM_INFO), // 请求军团赛本军团其他房间信息
MSGTYPE_DECLARE(MSG_REQUEST_SWITCH_GUILD_ROOM),         // 请求切换军团赛房间

MSGTYPE_DECLARE(MSG_ROUTE_TO_TRACK_END),                // 发给TRACK的消息结束
//////////////////////////////////////////////////////////////////////////
// 需要转发给guild的消息
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_GUILD, 650),
// 战队相关协议
MSGTYPE_DECLARE(MSG_REQUEST_JOIN_GUILD),                // 请求加入军团
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_INVITE),              // 发送军团邀请
MSGTYPE_DECLARE(MSG_REQUEST_LEAVE_GUILD),               // 请求离开军团
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_KICKOUT),             // 请求踢出军团
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_POST),               // 请求更换职务
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_OP),                  // 请求军团操作
MSGTYPE_DECLARE(MSG_REQUEST_JOIN_GUILD_APPLY),          // 请求发送加入军团申请
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_APPLY_LIST),          // 请求军团申请列表
MSGTYPE_DECLARE(MSG_REQUEST_APPROVE_APPLY),             // 请求同意战队申请
MSGTYPE_DECLARE(MSG_REQUEST_REJECT_APPLY),              // 请求拒绝战队申请
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_UPGRADE),             // 请求军团升级
MSGTYPE_DECLARE(MSG_REQUEST_SET_CHANNEL),               // 请求设置YY频道号
MSGTYPE_DECLARE(MSG_REQUEST_SET_NOTICE),                // 请求设置公告
MSGTYPE_DECLARE(MSG_REQUEST_SET_RECRUIT_NOTICE),        // 请求设置招募宣言
MSGTYPE_DECLARE(MSG_REQUEST_TEAM_MEMBER),               // 请求刷新成员信息
MSGTYPE_DECLARE(MSG_REQUEST_DELETE_TEAM),               // 请求解散战队
MSGTYPE_DECLARE(MSG_REQUEST_IN_GUILD_UI),               // 请求进入军团界面
MSGTYPE_DECLARE(MSG_REQUEST_OUT_GUILD_UI),              // 请求离开军团界面
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_MOVE_MEMBER),         // 请求团员移队
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_INVITE_MEMBER),       // 请求邀请团员
MSGTYPE_DECLARE(MSG_REQUEST_ACCEPT_CHANGE_TEAM),        // 接受转队邀请
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_TEAM_PVE_FLAG),      // 请求开启或者关闭战队副本
MSGTYPE_DECLARE(MSG_REQUEST_RESEARCH_GUILD_SKILL),      // 请求进行军团技能的研究
MSGTYPE_DECLARE(MSG_LEAGUE_REQUEST_ENROLL),             // 请求报名到某个赛事
MSGTYPE_DECLARE(MSG_LEAGUE_REQUEST_AWARD),              // 请求领取某个阶段的奖励

MSGTYPE_DECLARE(MSG_ROUTE_TO_GUILD_END),                // 发给guild的消息结束
//////////////////////////////////////////////////////////////////////////
// 需要转发给buddy的消息
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_BUDDY, 700),
MSGTYPE_DECLARE(MSG_RELATION_REQUEST_ADD),              // 请求建立关系
MSGTYPE_DECLARE(MSG_RELATION_REQUEST_DELETE),           // 请求移除关系
MSGTYPE_DECLARE(MSG_REQUEST_BUDDY_BRIEF),               // 主动请求brief信息
MSGTYPE_DECLARE(MSG_SEND_SNS_REQUEST_KEY),              // 发送sns的请求key
MSGTYPE_DECLARE(MSG_REQUEST_FACEBOOK_INVITE),           // 请求邀请facebook好友
MSGTYPE_DECLARE(MSG_ACCEPT_FACEBOOK_INVITE),            // 接受facebook邀请进入游戏
MSGTYPE_DECLARE(MSG_REQUEST_QUICK_ADD_FRIEND),          // 请求快捷邀请好友
//师徒相关协议
MSGTYPE_DECLARE(MSG_REQUEST_MP_SQUARE_LIST),            // 请求广场列表
MSGTYPE_DECLARE(MSG_REQUEST_APPLY_MP_RELATION),         // 申请建立师徒关系
MSGTYPE_DECLARE(MSG_APPROVE_MP_RELATION_APPLY),         // 同意师徒申请
MSGTYPE_DECLARE(MSG_REJECT_MP_RELATION_APPLY),          // 拒绝师徒申请
MSGTYPE_DECLARE(MSG_REQUEST_DELETE_SOCIAL_REL),         // 请求解除社交关系
MSGTYPE_DECLARE(MSG_REQUEST_MASTER_PRENTICE_AWARD),     // 请求领取师徒任务奖励
MSGTYPE_DECLARE(MSG_REQUEST_GRADUATE),                  // 请求出师
MSGTYPE_DECLARE(MSG_REQUEST_CLEAR_MP_APPLY_LIST),       // 请求清空师徒申请列表
MSGTYPE_DECLARE(MSG_REQUEST_MP_APPLY_LIST),              // 请求师徒申请列表
MSGTYPE_DECLARE(MSG_REQUEST_ROOM_INVITE),               // 发送房间邀请
MSGTYPE_DECLARE(MSG_REQUEST_INVITE_GIFT_PLAYER_INVITE),  // 发送邀请好友玩家邀请
MSGTYPE_DECLARE(MSG_RESPONSE_INVITE_GIFT_PLAYER_INVITE), // 回复邀请好友玩家邀请
MSGTYPE_DECLARE(MSG_REQUEST_REMOVE_INVITE_GIFT_PLAYER),  // 请求解除邀请好礼玩家关系

MSGTYPE_DECLARE(MSG_ROUTE_TO_BUDDY_END),                // 发给buddy的消息结束

//////////////////////////////////////////////////////////////////////////
// 需要转发给activity的消息
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_ACTIVITY,750),
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_ONLINE_PEAK_AWARD),     ///< 请求领取在线峰值活动奖励
MSGTYPE_DECLARE(MSG_REQUEST_RAND_STEP_SUPPORT_INFO),     ///< 请求夺宝排行点赞信息

MSGTYPE_DECLARE(MSG_ROUTE_TO_ACTIVITY_END),                // 发给activity的消息结束
MSGTYPE_DECLARE(MSG_CLIENT_END),

//--------------------------------------------------------------------------------------------------------
//监控工具相关
//--------------------------------------------------------------------------------------------------------
MSGTYPE_DECLARE_ASSIGN(MSG_SVR_MONITOR_START, 800),         // 服务器状态监控相关协议
MSGTYPE_DECLARE(MSG_MONITOR_COMMAND),                       // 本地使用，让网络层汇报统计数据
MSGTYPE_DECLARE(MSG_RUN_ROMOTE_COMMAND),                    // 远程运行服务器指令请求
MSGTYPE_DECLARE(MSG_COMMAND_RESULT),                        // 远程运行服务器指令结果
MSGTYPE_DECLARE(MSG_ADMIN_REGISTER),                        // 服务器注册到监控后端
MSGTYPE_DECLARE(MSG_ADMIN_RESPONSE),                        // 监控后端注册后答复

MSGTYPE_DECLARE(MSG_MANAGE_AUTH_REQUEST),                   // 管理消息，认证请求
MSGTYPE_DECLARE(MSG_MANAGE_AUTH_RESULT),                    // 管理消息，认证结果
MSGTYPE_DECLARE(MSG_MANAGE_REQUEST_OBJECT),                 // 管理消息，获取各种类型的对象信息
MSGTYPE_DECLARE(MSG_MANAGE_GROUPLIST),                      // 管理消息，返回区服列表
MSGTYPE_DECLARE(MSG_MANAGE_GROUPINFO),                      // 管理消息，返回区服信息
MSGTYPE_DECLARE(MSG_MANAGE_PROCLIST),                       // 管理消息，返回NODE列表
MSGTYPE_DECLARE(MSG_MANAGE_PROCINFO),                       // 管理消息，返回NODE信息
MSGTYPE_DECLARE(MSG_MANAGE_REALMINFO),                      // 管理消息，返回某个在AC中的帐号的详细信息
MSGTYPE_DECLARE(MSG_MANAGE_CONTROLCMD),                     // 管理消息，控制命令
MSGTYPE_DECLARE(MSG_MANAGE_ACCMDRESULT),                    // 管理消息，基本命令参数
MSGTYPE_DECLARE(MSG_NOTIFY_SVR_STARTUP_OK),                 // 通知管理服务器, 服务器启动成功
MSGTYPE_DECLARE(MSG_ADMIN_REQUEST_LOGIN),                   // 请求管理服务器版本验证
MSGTYPE_DECLARE(MSG_ADMIN_LOGIN_RESULT),                    // 返回登陆请求结果

/*#######################################################################
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_SERVER_START, 899),            //服务端协议的ID段
// ----------------------------------------------------------------------/
/* 由认证服务器返回的消息 LOGINSVR -> CLIENT                             */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_AUTH_SVR_START, 900),
MSGTYPE_DECLARE(MSG_AUTH_LOGIN_OK),                     //认证前端->客户端：密码验证成功
MSGTYPE_DECLARE(MSG_AUTH_LOGIN_FAIL),                   //认证前端->客户端：密码验证错误
MSGTYPE_DECLARE(MSG_AUTH_VESION_OK),                    //认证前端->客户端：协议版本正确
MSGTYPE_DECLARE(MSG_AUTH_VESION_FAILED),                //认证前端->客户端：协议版本错误

MSGTYPE_DECLARE(MSG_AUTH_PLAY_FAIL),                    //认证前端->客户端：登录区服失败
MSGTYPE_DECLARE(MSG_AUTH_SERVER_LIST),                  //认证前端->客户端：服务器列表

MSGTYPE_DECLARE(MSG_AUTH_SESSION_REQUESTCONFIRM),       //认证前端->客户端：Session开始
MSGTYPE_DECLARE(MSG_AUTH_SESSION_REQUESTREJECT),        //认证前端->客户端：Session开始被拒绝
MSGTYPE_DECLARE(MSG_AUTH_SESSION_CLOSECONFIRM),         //认证前端->客户端：Session结束
MSGTYPE_DECLARE(MSG_AUTH_SESSION_CLOSEREJECT),          //认证前端->客户端：Session结束被拒绝

MSGTYPE_DECLARE(MSG_AUTH_SWITCH_LINE_RESULT),           //通知切换分线结果

// ----------------------------------------------------------------------/
/* 网关GATESVR服务器发送的消息协议 GATESVR -> CLIENT                      */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_GATE_SVR_START, 1000),
MSGTYPE_DECLARE(MSG_AUTH_SESSION_INTERRUPTED),          //网关->客户端：Session被中断
MSGTYPE_DECLARE(MSG_GATE_SYSTEM_HEARTBEAT),             //心跳消息
MSGTYPE_DECLARE(MSG_GATE_NOTIFY_PING),                  // GATESVR返回ping值
MSGTYPE_DECLARE(MSG_WORLD_LOGOUT_NOTIFY),               // 通知客户端正在取
MSGTYPE_DECLARE(MSG_WORLD_ENTER_CONFIRM),               // 角色确认进入游戏世界
MSGTYPE_DECLARE(MSG_WORLD_ENTER_REJECTED),              // 角色进入游戏世界被拒绝
MSGTYPE_DECLARE(MSG_WORLD_LOGOUT_CONFIRM),              // 角色退出游戏世界确认
MSGTYPE_DECLARE(MSG_CHAR_PICKAPPROVED),                 // 选定角色进入成功
MSGTYPE_DECLARE(MSG_CHAR_PICKREJECTED),                 // 选定角色被拒绝
MSGTYPE_DECLARE(MSG_SERVER_LOGOUT_CONFIRMED),             // GATE退出确认

//角色相关
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_CREATE),                //角色不存在，通知创建新角色
MSGTYPE_DECLARE(MSG_CHARCREATE_APPROVED),               //角色创建成功
MSGTYPE_DECLARE(MSG_CHARCREATE_REJECTED),               //角色创建失败
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_LIST),                  // 通知角色列表
MSGTYPE_DECLARE(MSG_CHAR_NAME_UNIQUE_RESULT),           // 通知名称唯一性验证的结果
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_DATA),                  // 返回角色基本信息
MSGTYPE_DECLARE(MSG_NOTIFY_BACK_TO_MAIN),               /// 通知客户端退回主界面
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_AWARD_RESULT),          /// 通知奖励领取结果
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_LEVEL),                  // 通知升级
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_EXP),                   // 更新角色经验
MSGTYPE_DECLARE(MSG_NOTIFY_OPTION_TIME),                // 更新角色功能时间戳
MSGTYPE_DECLARE(MSG_NOTIFY_USE_SPRAY),                  // 通知更换喷图成功
MSGTYPE_DECLARE(MSG_NOTIFY_USE_AVATAR),                 // 通知使用avatar
MSGTYPE_DECLARE(MSG_NOTIFY_FIZZ),                       // 通知活跃度
MSGTYPE_DECLARE(MSG_NOTIFY_DYNAMIC_CONFIG),             // 通知动态配置信息
MSGTYPE_DECLARE(MSG_NOTIFY_RENAME_RET),                 // 通知改名的结果
MSGTYPE_DECLARE(MSG_NOTIFY_THEW),                       // 通知活跃度
MSGTYPE_DECLARE(MSG_NOTIFY_HONOR),                      // 通知玩家选定的荣誉
MSGTYPE_DECLARE(MSG_NOTIFY_HONOR_LIST),                 // 通知荣誉列表
MSGTYPE_DECLARE(MSG_NOTIFY_ROULETTE_COUNT),             // 通知转轮盘的数量
MSGTYPE_DECLARE(MSG_NOTIFY_FIRST_CHARGE),               // 通知是否已经进行首充
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_GIFT_TIME),            // 通知领取军团礼包的最后时间
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_PROTECT_PWD),           // 通知角色2级密保信息
MSGTYPE_DECLARE(MSG_NOTIFY_PROTECT_PWD_OP_RESULT),      // 通知2级密保操作结果
MSGTYPE_DECLARE(MSG_NOTIFY_NEED_CHECK_PROTECT_PWD),     // 通知客户端需要验证2级密保
MSGTYPE_DECLARE(MSG_NOTIFY_SYNC_SETTING),               // 通知同步系统设置
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_GROCERY_ADD),         // 通知杂货栏额外格子数
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_GIFT_RESULT),           // 通知礼包领取结果
MSGTYPE_DECLARE(MSG_CHAR_CURRENCYACTION),               // Server->Client 通知角色货币操作以及余额情况
MSGTYPE_DECLARE(MSG_CHAR_CURRENCY_NOTIFY_RMB_RATE),     // 通知rmb数量以及汇率
MSGTYPE_DECLARE(MSG_BUY_GOODS_OK_NOTIFY),               // 通知商城购买成功
MSGTYPE_DECLARE(MSG_BUY_GOODS_REJECT),                  // 拒绝购买商品
MSGTYPE_DECLARE(MSG_CHARGE_DONE),						// 通知充值到帐
MSGTYPE_DECLARE(MSG_CHAR_GUIDE_PROGRESS),				// 通知角色新手引导的当前进度
MSGTYPE_DECLARE(MSG_NOTIFY_LIMIT_INFO),				    // 通知初始化、更新限制信息
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_GIFT),                  // 通知玩家礼包信息
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_OPTION),                // 通知角色客户端系统设置
MSGTYPE_DECLARE(MSG_NOTIFY_OBSERVER_PLAYER_GATE),       // 通知附身玩家Gate信息
MSGTYPE_DECLARE(MSG_NOTIFY_VIP_CHANGE),    							// 通知VIP变化信息
MSGTYPE_DECLARE(MSG_NOTIFY_QQ_VIP),                     // 通知qq黄钻蓝钻信息
MSGTYPE_DECLARE(MSG_NOTIFY_SHOW_QQ_BLUE_VIP_RENEW),     // 通知显示蓝钻续费图标
MSGTYPE_DECLARE(MSG_NOTIFY_SUPER_VIP_CHARGE_INFO),      // 通知超级VIP充值记录信息
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_SUPER_VIP_CHARGE_BACK), // 通知超级VIP充值记录信息
MSGTYPE_DECLARE(MSG_APEX_SEND2CLIENT),                  ///< 由 gate server 发送给 game client 的 Apex 消息
MSGTYPE_DECLARE(MSG_NOTIFY_RELOAD_TEMPLATE),            ///< 通知客户端重新加载模板数据
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_BOOSTER),             ///< 通知角色主战助手UUID

// 物品相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_ITEM_LIST, 1100),         // 通知物品信息
MSGTYPE_DECLARE(MSG_ITEM_SWAP_OK),                          // 物品移动成功
MSGTYPE_DECLARE(MSG_UPDATE_ITEM_INSTANCE),                  // 更新物品信息
MSGTYPE_DECLARE(MSG_NOTIFY_ITEM_DELETE),                  	// 通知删除物品
MSGTYPE_DECLARE(MSG_NOTIFY_SETTLE_AWARD),                   // 通知奖励信息
MSGTYPE_DECLARE(MSG_NOTIFY_TICKET_ITEM_RET),                // 通知使用月票的返回结果
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_OP_RET),                 // 通知助手操作结果
MSGTYPE_DECLARE(MSG_NOTIFY_ROULETTE_RET),                   // 通知轮盘赌的结果
MSGTYPE_DECLARE(MSG_NOTIFY_STORE_MERCHANDISE),              // 商店商品消息
MSGTYPE_DECLARE(MSG_CONFIRM_STORE_PURCHASE),                // 确认商品购买的成功确认
MSGTYPE_DECLARE(MSG_NOTIFY_QQ_BUY_GOODS),                   // 通知qq商城购买
MSGTYPE_DECLARE(MSG_NOTIFY_STORE_BRIEF),                    // 通知商店简要信息
MSGTYPE_DECLARE(MSG_NOTIFY_STORE_ENABLE_SUCCEED),           // 通知商店开启成功
MSGTYPE_DECLARE(MSG_NOTIFY_CLIENT_USE_ITEM_FAILED),         // 通知客户端使用物品失败

// 战斗外坦克相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_TANK_LIST, 1150),             // 通知坦克信息
MSGTYPE_DECLARE(MSG_UPDATE_TANK_INSTANCE),                      // 更新坦克信息
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_DELETE),                        // 通知删除坦克
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_OP_FAIL),                       // 通知坦克操作失败（不是条件失败，概率成功的失败）
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_TRY),                           // 通知试用坦克(废弃)
MSGTYPE_DECLARE(MSG_TANK_SKILL_UPGRADE_OK),                     // 通知客服端坦克技能升级成功
MSGTYPE_DECLARE(MSG_TANK_SKILL_UPGRADE_FAIL),                   // 通知客户端坦克技能升级失败
MSGTYPE_DECLARE(MSG_NOTIFY_REFRESH_HIRE_TANK_CONFIG),           // 通知客户端更新坦克租用配置
MSGTYPE_DECLARE(MSG_NOTIFY_RECEIVE_PRESENT_HIRE_TANK),          // 通知客户端获得其他玩家赠送的租用坦克
MSGTYPE_DECLARE(MSG_NOTIFY_PRESENT_HIRE_TANK_OK),               // 通知客户端赠送玩家租用坦克成功
MSGTYPE_DECLARE(MSG_NOTIFY_USE_TANK_HALO_RESULT),               // 通知使用坦克光环的结果
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_HALO_INFO),                     // 通知坦克光环过期或者获得的信息
MSGTYPE_DECLARE(MSG_NOTIFY_REPEAT_GIVE_TANK),                   // 通知客户端重复获得坦克
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_SKIN_CHIP_INFO),                // 通知坦克皮肤碎片进度信息
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_SKIN_CHIP_RESULT),              // 通知购买坦克皮肤碎片的结果
MSGTYPE_DECLARE(MSG_NOTIFY_GET_TANK_SKIN_RESULT),               // 通知皮肤碎片兑换坦克皮肤的结果
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RESEARCH_INFO),                 // 通知坦克研究信息
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RESEARCH_RESULT),               // 通知研究结果
MSGTYPE_DECLARE(MSG_NOTIFY_RECYCLE_TANK_RESEARCH_RESULT),       // 通知兑换坦克研究的结果
MSGTYPE_DECLARE(MSG_NOTIFY_GET_RESEARCH_TANK_RESULT),           // 通知换取坦克的结果
MSGTYPE_DECLARE(MSG_NOTIFY_MAKE_TANK_INFO),                     // 通知坦克制造信息
MSGTYPE_DECLARE(MSG_NOTIFY_TANKPART_INFO),                      // 通知坦克部件信息
MSGTYPE_DECLARE(MSG_NOTIFY_TANKPART_SCORE),                     // 通知坦克部件总评分
MSGTYPE_DECLARE(MSG_NOTIFY_TREASURE_RECOVERY_RESULT),           // 通知一元夺宝回收结果


// 邮件相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_MAIL_NOREAD_COUNT, 1200),       // 通知有未读邮件
MSGTYPE_DECLARE(MSG_NOTIFY_MAIL_LIST),       		// 通知邮件列表
MSGTYPE_DECLARE(MSG_NOTIFY_MAIL_INSIDE_INFO),       // 通知邮件的详细信息
MSGTYPE_DECLARE(MSG_NOTIFY_MAIL_OP_RET),       		// 通知邮件操作结果
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_MAIL_INFO),       // 通知更新邮件信息

// 任务成就相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_QUEST_LIST, 1250),    // 通知任务信息
MSGTYPE_DECLARE(MSG_NOTIFY_QUEST_INFO),                 // 更新单个玩家任务信息
MSGTYPE_DECLARE(MSG_NOTIFY_DELETE_QUEST),       	    // 删除任务信息
MSGTYPE_DECLARE(MSG_NOTIFY_COMPLETE_QUEST),       	    // 通知完成任务
MSGTYPE_DECLARE(MSG_NOTIFY_COMPLETE_QUEST_FAIL),       	// 通知完成任务失败
MSGTYPE_DECLARE(MSG_NOTIFY_ACEM_INFO),       	        // 更新单个成就信息
MSGTYPE_DECLARE(MSG_NOTIFY_ACEM_LIST),       	        // 通知成就信息
MSGTYPE_DECLARE(MSG_NOTIFY_SWITCH_QUEST),               // 通知切换任务
MSGTYPE_DECLARE(MSG_NOTIFY_OPEN_UI),           				// 通知玩家打开界面

// PVE相关的
MSGTYPE_DECLARE_ASSIGN(MSG_PVE_CHAPTER_SCENES, 1300), 		// 通知客户端，返回玩家的章节列表信息
MSGTYPE_DECLARE(MSG_REJECT_SELECT_SCENE),            		// 通知客户端，拒绝玩家打开某个关卡
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_SCORES),            		// 通知客户端，通关评价的成绩
MSGTYPE_DECLARE(MSG_NOTIFY_CITY_INIT),            	    	// 通知客户端，城市初始值
MSGTYPE_DECLARE(MSG_UPDATE_CITY_INFO),            	    	// 通知客户端，更新城市信息
MSGTYPE_DECLARE(MSG_NOTIFY_SOLO_SWEEP_AWARD),                    // 通知客户端，扫荡结果
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_REWARD), 					// 通知阶段性奖励领取信息
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_REAP_RESULT), 				// 通知奖励领取结果
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_CLEARED), 					// 通知奖励已经全部领取完成
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_PROGRESS), 				// 通知阶段奖励的进度

// 军团相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_GUILD_SKIL_SLOT_INFO, 1350),	// 通知角色军团技能槽信息
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_GUILD_SKILL_INFO),     				//通知角色的军团技能信息
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_AWARD),   							//通知军团BOSS奖励信息

// 活动相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_SIGN_IN_INFO, 1400),       ///< 通知角色签到信息
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_LOGIN_CONFIG),      ///< 通知服务器登陆配置信息
MSGTYPE_DECLARE(MSG_NOTIFY_SEND_REDPACKET_SUCC),       // 通知发红包成功
MSGTYPE_DECLARE(MSG_NOTIFY_ROB_REDPACKET_SUCC),                     // 通知抢红包成功
MSGTYPE_DECLARE(MSG_NOTIFY_REDPACKET_LOG),                          // 通知红包历史记录
MSGTYPE_DECLARE(MSG_NOTIFY_OPEN_CHEST),                     // 通知开宝箱成功
MSGTYPE_DECLARE(MSG_NOTIFY_CLIENT_FREE_WEEK_TANK),    // 通知玩家周免坦克信息
MSGTYPE_DECLARE(MSG_NOTIFY_RECOMMEND_TANK),    										 // 通知玩家推荐坦克
MSGTYPE_DECLARE(MSG_NOTIFY_RAND_STEP),     						// 通知夺宝
MSGTYPE_DECLARE(MSG_NOTIFY_EXPEDITION_INFO),                // 通知远征信息
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_SPREAD_PLAYER_INFO),   			// 通知邀请推广信息
MSGTYPE_DECLARE(MSG_NOTIFY_FUND_INFO),     										 // 通知基金信息
MSGTYPE_DECLARE(MSG_NOTIFY_ITEM_CLOUD_PURCHASE_TANK_INFO),     // 通知云购坦克信息
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_COMP_INFO),  						///< 通知助手挑战赛角色信息
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_RESULT),           ///< 通知助手挑战赛对战结果
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_HISTORY),					 ///< 通知助手赛历史记录
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_COMP_YESTERDAY_AWARD_INFO),///< 通知助手赛昨日奖励信息
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_COMP_NOW_AWARD_INFO),		 ///< 通知助手竞技赛实时奖励信息
MSGTYPE_DECLARE(MSG_NOTIFY_NEW_SIGN_IN_INFO),       ///< 通知新版角色签到信息

//属性相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_UPDATE_TALENT_PAGE, 1450),  	// 通知更新天赋页
MSGTYPE_DECLARE(MSG_NOTIFY_OP_TALENT_PAGE),              				// 通知天赋页操作
MSGTYPE_DECLARE(MSG_NOTIFY_TALENT_INFO),                					// 通知天赋信息
MSGTYPE_DECLARE(MSG_NOTIFY_TALENT_TOTALPOINT),           				// 通知天赋总可用点数
MSGTYPE_DECLARE(MSG_NOTIFY_CRYSTAL_SCHEME_INFO),    						// 通知晶片组合信息
MSGTYPE_DECLARE(MSG_NOTIFY_CRYSTAL_SCHEME_NAME),    						 // 通知晶片名信息
MSGTYPE_DECLARE(MSG_NOTIFY_SAVE_CRYSTAL_SCHEME_INFO_RESULT),     // 通知晶片晶片组合修改信息
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_CRYSTAL_SCHEME_NAME_RESULT),   // 通知晶片名修改结果
MSGTYPE_DECLARE(MSG_NOTIFY_CUR_CRYSTAL_SCHEME_ID),   						 // 通知当前晶片方案ID
MSGTYPE_DECLARE(MSG_NOTIFY_UPGRADE_CRYSTAL_RESULT),   					 // 通知晶片升阶结果
MSGTYPE_DECLARE(MSG_NOTIFY_YCARD_INFO),     										 // 通知佣兵卡信息



// ----------------------------------------------------------------------/
/* 由GATESVR转发给客户端的协议  OTHERSVR -> GATESVR -> CLIENT            */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_GATE_TRANSFER_TO_CLIENT, 1500),

//通用的系统消息
MSGTYPE_DECLARE(MSG_SYSTEM_ERRORMESSAGE),               // 系统错误消息
MSGTYPE_DECLARE(MSG_WORLD_DISCONNECTED),                // 游戏世界已经断开
MSGTYPE_DECLARE(MSG_WORLD_ENTER_TRACK_CONFIRM),         // tracksvr确认登入游戏成功

MSGTYPE_DECLARE(MSG_GAME_NOTIFY_PING),                  // GameSvr返回ping值
MSGTYPE_DECLARE(MSG_NOTIFY_HOST_URL),                   // 通知服务器的url地址

MSGTYPE_DECLARE(MSG_NOTIFY_TURNUP_RESULT),              /// 通知翻牌结果
MSGTYPE_DECLARE(MSG_NOTIFY_TURNUP_END),                 /// 通知翻牌结束
MSGTYPE_DECLARE(MSG_NOTIFY_BUDDY_BRIEF),                /// 通知相关的brief信息
MSGTYPE_DECLARE(MSG_UPDATE_BUDDY_BRIEF),                /// 通知更新brief信息
MSGTYPE_DECLARE(MSG_NOTIFY_USE_ITEM),                   // 通知使用物品
MSGTYPE_DECLARE(MSG_NOTIFY_NOT_TYRO),                   // 通知玩家已经通过新手
MSGTYPE_DECLARE(MSG_NOTIFY_IMPEACH_RET),                // 通知玩家举报结果
MSGTYPE_DECLARE(MSG_NOTIFY_IMPEACH_CHECK),              // 通知被举报了，需要验证
MSGTYPE_DECLARE(MSG_NOTIFY_ACTION_FLAG),                // 通知行为开启信息
MSGTYPE_DECLARE(MSG_NOTIFY_RLTE_AWARD_LIST),            // 通知轮盘赌的近期获奖列表
MSGTYPE_DECLARE(MSG_NOTIFY_RENEW_ELO_TIME),             // 通知客户端elo赛季刷新时间戳
MSGTYPE_DECLARE(MSG_NOTIFY_PVE_RECORD),                 // 通知副本记录
MSGTYPE_DECLARE(MSG_NOTIFY_PASS_PVE),                   // 通知副本通关信息
MSGTYPE_DECLARE(MSG_NOTIFY_HERO_ENTER_COUNT),           // 通知客户端英雄副本进入次数信息
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_CHARGE_INFO),         // 通知每日充值数额
MSGTYPE_DECLARE(MSG_NOTIFY_AFK_STATUS),                 // 通知挂机检测状态
MSGTYPE_DECLARE(MSG_NOTIFY_SET_BATTLE_MODE),            // 通知设置匹配模式
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_GOLDEN_POOL_RESULT),    // 通知金币池领取结果
MSGTYPE_DECLARE(MSG_NOTIFY_AFK_WARNING),                // 通知触发不良记录提示玩家
MSGTYPE_DECLARE(MSG_NOTIFY_SVR_AWARD_LIST),             // 通知svr_award近期获奖列表

// 坦克/战斗相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_SELF_DATA, 1550),     // 返回自身坦克数据
MSGTYPE_DECLARE(MSG_NOTIFY_OTHER_LIST),                 // 返回其他人的坦克数据
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_TANK),                   // 通知客户端有新坦克进入
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RELIVE),                // 通知坦克复活等待时间
MSGTYPE_DECLARE(MSG_NOTIFY_STOP_MOVE),                  // 停止移动
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_OBJECT),               // 通知战场对象数据
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_OBJECT),                 // 通知新建对象数据
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_OBJECT),              // 通知删除对象数据
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_BUFF),                   // 通知坦克获得buff
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_BUFF),                // 通知坦克失去buff
MSGTYPE_DECLARE(MSG_UPDATE_TANK_ATTR),                  // 通知更新坦克数据
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_STAT),                 // 通知坦克战场统计数据
MSGTYPE_DECLARE(MSG_UPDATE_BULLET_ORBIT),               // 同步炮弹轨迹
MSGTYPE_DECLARE(MSG_NOTIFY_AIRDROP_PROP),               // 通知表现空投物品
MSGTYPE_DECLARE(MSG_SYNC_SCENE_DATA),                   // 战场数据同步
MSGTYPE_DECLARE(MSG_SYNC_OCCUPY_DATA),                  // 同步争夺点占领信息
MSGTYPE_DECLARE(MSG_NOTIFY_KILL_INFO),                  // 通知击杀信息
MSGTYPE_DECLARE(MSG_UPDATE_TANK_COIN),                  // 通知更新坦克金钱变化
MSGTYPE_DECLARE(MSG_UPDATE_TANK_STAT_INFO),             // 主动更新技术统计
MSGTYPE_DECLARE(MSG_NOTIFY_OP_SPRAY),                   // 通知喷图成功
MSGTYPE_DECLARE(MSG_NOTIFY_OVERTIME_START),             // 通知加时赛开始
MSGTYPE_DECLARE(MSG_AWARD_NOTIFY_TURNUP_BEGIN),         // 通知翻牌开始
MSGTYPE_DECLARE(MSG_SYNC_SKILL_COOLTIME),               // 同步技能冷却时间
MSGTYPE_DECLARE(MSG_UPDATE_SCENE_ONE_STAT),             // 更新战场单向技术统计（含所有坦克）
MSGTYPE_DECLARE(MSG_UPDATE_TANK_SCORE),                 // 更新某辆坦克的得分
MSGTYPE_DECLARE(MSG_NOTIFY_DROP_ITEM),                  // 通知掉落物品
MSGTYPE_DECLARE(MSG_NOTIFY_BUY_LIFE_INFO),              // 通知买活或者买命信息
MSGTYPE_DECLARE(MSG_NOTIFY_END_ONHAND),                 // 通知战斗即将结算
MSGTYPE_DECLARE(MSG_NOTIFY_OBJ_THROW),                  // 通知对象被投掷
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_SLOT_SKILL),          // 通知切换技能槽的技能
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_TALK),                 // 通知显示战场（AINPC等）对话
MSGTYPE_DECLARE(MSG_NOTIFY_BUFF_UPDATE_TIME),           // 通知自身更新BUFF时间
MSGTYPE_DECLARE(MSG_NOTIFY_TEAMMATE_CD),                // 通知队友大招CD（断线重连时）
MSGTYPE_DECLARE(MSG_NOTIFY_SKILL_STOP),                 // 通知客户端技能停止
MSGTYPE_DECLARE(MSG_NOTIFY_FORCE_DATA),                 // 通知客户端怒气值
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_EXP),                 // 通知客户端战场经验
MSGTYPE_DECLARE(MSG_NOTIFY_ENTER_BATTLE),               /// 通知进入战场
MSGTYPE_DECLARE(MSG_NOTIFY_AINPC_WAVE),                 // 通知客户端，击杀AINPC的波次
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_DEAD),                  /// 通知坦克死亡
MSGTYPE_DECLARE(MSG_SYNC_PORTAL_DATA),                  // 通知客户端传送门信息
MSGTYPE_DECLARE(MSG_NOTIFY_AUTO_BULLET),                //通知客户端对鼠标指针方向自动释放一个子弹
MSGTYPE_DECLARE(MSG_NOTIFY_PLAY_YCARD_ANIMATION),       // 通知播放佣兵卡出场动画
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_QUEST_INFO),          // 通知玩家战场任务信息
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_QUEST_BULLETIN),      // 通知战场任务公告
MSGTYPE_DECLARE(MSG_NOTIFY_SIGNAL_INFO),                // 通知战场信号信息
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_BATTLE_LEVEL),          // 通知客户端坦克战场等级
MSGTYPE_DECLARE(MSG_UPDATE_AINPC_MAXHP),                // 通知客户端更新AINPC血上限
MSGTYPE_DECLARE(MSG_NOTIFY_SHOW_SURRENDER_VOTATION),    // 通知开启投降表决
MSGTYPE_DECLARE(MSG_UPDATE_VOTATION_INFO),              // 通知更新投降表决信息
MSGTYPE_DECLARE(MSG_NOTIFY_SURRENDER_VOTATION_COOL_TIME), // 通知投降冷却时间

MSGTYPE_DECLARE(MSG_GAME_TO_CLIENT_END),                // 战斗相关协议段结尾
// 房间相关
MSGTYPE_DECLARE_ASSIGN(MSG_ENTER_ROOM_OK, 1700),        // 成功进入房间，通知房间信息
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_OP),                    // 通知房间操作结果
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_ADD),                   // 通知客户端，有新角色加入房间
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_LIST),                // 通知客户端，玩家列表
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_MAP),                   // 通知切磋地图
MSGTYPE_DECLARE(MSG_NOTIFY_START_GAME),                 // 成功进入房间，开始游戏
MSGTYPE_DECLARE(MSG_NOTIFY_MIDWAY_JOIN),                // 中途玩家进入
MSGTYPE_DECLARE(MSG_NOTIFY_EXIT_BATTLE),                // 通知退出战场
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_END),                 // 通知客户端，战斗结束
MSGTYPE_DECLARE(MSG_NOTIFY_LOADED_RATE),                // 通知客户端，加载进度和延迟
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_KILLNUM),               // 通知客户端，阵营击杀数量
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_CHAR_CHANGE),           // 通知客户端，同步房间内角色信息发生变化
MSGTYPE_DECLARE(MSG_ADD_PLAYER_LIST),                   // 通知客户端，游戏大厅列表添加
MSGTYPE_DECLARE(MSG_DEL_PLAYER_LIST),                   // 通知客户端，游戏大厅列表删除
MSGTYPE_DECLARE(MSG_UPDATE_PLAYER_LIST),                // 通知客户端，游戏大厅列表等级更新
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_INVITE),                // 通知客户端，房间邀请
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_STATE),                 // 通知玩家房间状态
MSGTYPE_DECLARE(MSG_NOTIFY_KICKOUT_COUNTDOWN),          // 通知玩家房间踢人倒计时
MSGTYPE_DECLARE(MSG_CLEAR_KICKOUT_COUNTDOWN),           // 通知清除房间踢人倒计时
MSGTYPE_DECLARE(MSG_NOTIFY_START_MATCH),                // 通知开始配对倒计时
MSGTYPE_DECLARE(MSG_NOTIFY_STOP_MATCH),                 // 通知停止配对倒计时
MSGTYPE_DECLARE(MSG_NOTIFY_PAIR_SCENE),                 // 通知客户端，通知匹配赛开始
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_CHANGE_CAMP),          // 通知客户端，切换阵营
MSGTYPE_DECLARE(MSG_NOTIFY_EXIT_BATEND_COUNT),          // 通知客户端，通知退到队伍的人数
MSGTYPE_DECLARE(MSG_NOTIFY_HALL_DISPLAY_LIST),          // 通知客户端大厅显示列表
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_BUFF),                  // 通知房间buff信息
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_PAIR_OPTION),           // 通知房间匹配选项
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_SELECT),                // 通知匹配选坦克阶段，坦克被选取
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_LOCKED),                // 通知玩家匹配选坦克阶段，坦克被锁定
MSGTYPE_DECLARE(MSG_NOTIFY_NEED_ROOM_PASSWORD),         // 通知客户端，进入房间需要密码
MSGTYPE_DECLARE(MSG_CLEAR_ALL_TEAM_PLACE),              // guild->track 通知清除所有战队名次
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_OCCUPY_SCORE),          // 通知客户端，占领总积分
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_OCCUPY_ADD_SCORE),      // 通知客户端，占领单次增加积分
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_WIN_ROUND),          		// 通知客户端，胜利回合数
MSGTYPE_DECLARE(MSG_NOTIFY_NEW_ROUND_START),          	// 通知客户端，新回合开始
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_ADD_WIN_ROUND),         // 通知客户端，胜利回合数增加数
MSGTYPE_DECLARE(MSG_NOTIFY_DEAD_MODE_ALIVE_CNT),        // 通知客户端，死亡模式双方存活人数
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_ROOM_IN_OTHER_LINE),    // 通知玩家，战队房间在其他分线
MSGTYPE_DECLARE(MSG_NOTIFY_OTHER_GUILD_MATCH_ROOM_INFO),  // 通知军团赛本军团其他房间信息
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_PVE_MAP_ID),            // 通知组队副本地图ID
MSGTYPE_DECLARE(MSG_NOTIFY_COMMAND_SKILL_SELECT),       // 通知选坦克阶段指挥官技能变化

// 战队相关
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_GUILD_INFO, 1800),    // 通知军团信息
MSGTYPE_DECLARE(MSG_NOTIFY_LEAVE_GUILD),                // 通知离开军团
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_KICKOUT),               // 通知踢出战队
MSGTYPE_DECLARE(MSG_NOTIFY_DESTROY_GUILD),              // 通知解散军团
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_INVITE),               // 通知军团邀请
MSGTYPE_DECLARE(MSG_NOTIFY_JOIN_GUILD),                 // 通知有玩家加入军团
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_POST),                // 通知职务变化
MSGTYPE_DECLARE(MSG_TEAM_GOTO_WAR),                     // 通知战队新出战成员信息
MSGTYPE_DECLARE(MSG_TEAM_RESET_WAR),                    // 通知战队成员休息
MSGTYPE_DECLARE(MSG_TEAM_WAR_ROOM_INFO),                // 通知战队作战室信息
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_STAND_TO),              // 战斗准备完成
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_OUT_WAR),               // 通知战队退出战斗
MSGTYPE_DECLARE(MSG_NOTIFY_RIVAL_INFO),                 // 通知对手战队信息
MSGTYPE_DECLARE(MSG_NOTIFY_RIVAL_OUT_WAR),              // 通知对手取消比赛准备
MSGTYPE_DECLARE(MSG_UPDATE_TEAM_INFO),                  // 更新战队信息
MSGTYPE_DECLARE(MSG_NOTIFY_SELECT_MATCH),               // 通知队长选择参加的联赛
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_APPLY_LIST),           // 通知军团申请数据
MSGTYPE_DECLARE(MSG_NOTIFY_CHALLENGE_FAIL),             // 通知约战失败
MSGTYPE_DECLARE(MSG_NOTIFY_CHALLENGE_LIST),             // 通知约战列表
MSGTYPE_DECLARE(MSG_NOTIFY_CHALLENGE_OK),               // 通知约战成功
MSGTYPE_DECLARE(MSG_NOTIFY_BE_CHALLENGE),               // 通知被挑战
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MATCH_INFO),            // 通知战队赛信息
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MATCH_RESULT),          // 通知战队赛结果
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_JOIN_APPLY),            // 通知有人申请加入战队
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_JOIN_APPLY_LOGIN),      // 登入时通知有多少人申请入战队
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_TEAM_NAME),           // 通知修改战队名称
MSGTYPE_DECLARE(MSG_NOTIFY_CREATE_TEAM),                // 通知创建战队
MSGTYPE_DECLARE(MSG_NOTIFY_DELETE_TEAM),                // 通知删除战队
MSGTYPE_DECLARE(MSG_UPDATE_GUILD_INFO),                 // 更新军团信息
MSGTYPE_DECLARE(MSG_UPDATE_GUILD_MEMBER_INFO),          // 更新团员信息
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_INVITE_MEMBER),        // 通知邀请团员
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MEMBER),                // 通知邀请团员
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_SKILL_INFO),           // 通知军团技能信息
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_INFO),            // 通知军团BOSS信息
MSGTYPE_DECLARE(MSG_LEAGUE_ENROLL_RESULT), 							// 通知客户端，联赛报名结果
MSGTYPE_DECLARE(MSG_LEAGUE_AWARD_RESULT), 							// 通知客户端，联赛领奖结果
MSGTYPE_DECLARE(MSG_LEAGUE_NOTIFY_CONFIG), 							// 通知客户端，联赛数据获取的远程地址
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_QUIZ_RESPONSE),       // 通知客户端，竞猜战队的反馈（是否竞猜成功）
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_ENEMY_LIST), 				// 通知助手挑战赛对手列表
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_CURTALENTPAGE),        // 通知场景内所有玩家的当前天赋页
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_KILL_INFO),       // 通知军团BOSS击杀信息


// 玩家关系相关
MSGTYPE_DECLARE_ASSIGN(MSG_RELATION_INIT_NOTIFY, 1900), // 通知初始化关系信息
MSGTYPE_DECLARE(MSG_RELATION_UPDATE_NOTIFY),            // 更新单个玩家的关系信息
MSGTYPE_DECLARE(MSG_RELATION_DELETE),                   // 通知删除关系
MSGTYPE_DECLARE(MSG_RELATION_ADD),                      // 通知添加关系信息
MSGTYPE_DECLARE(MSG_NOTIFY_SEARCH_RESULT), 							// 通知客户端，角色查询结果
MSGTYPE_DECLARE(MSG_NOTIFY_RECEIVE_MP_APPLY),           // 通知角色收到师徒申请
MSGTYPE_DECLARE(MSG_NOTIFY_MASTER_PRENTICE_INFO),       // 通知角色的师徒信息
MSGTYPE_DECLARE(MSG_NOTIFY_MP_RELATION_CREATED),        // 通知师徒关系建立
MSGTYPE_DECLARE(MSG_UPDATE_MASTER_PRENTICE_INFO),       // 通知更新师徒信息
MSGTYPE_DECLARE(MSG_NOTIFY_MP_QUEST_LIST),              ///< 通知师徒任务列表
MSGTYPE_DECLARE(MSG_NOTIFY_MP_QUEST_INFO),              ///< 通知师徒任务信息
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_SOCIAL_REL),          ///< 通知移除师徒关系
MSGTYPE_DECLARE(MSG_NOTIFY_MP_APPLY_LIST_CLEARED),      ///< 通知清空师徒列表
MSGTYPE_DECLARE(MSG_NOTIFY_MP_APPLY_LIST),              ///< 通知师徒申请列表
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_PLAYER_INVITE),  ///< 通知收到邀请好友的邀请
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_PLAYER_INFO),    ///< 通知邀请好友玩家信息
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_INVITE_GIFT_PLAYER),  ///< 通知解除邀请好礼玩家
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_INVITE_INFO),  	///< 通知邀请好礼邀请信息

//活动相关的
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_ACT_INFO_LIST, 1950),     // 通知客户端，当前开放的活动信息列表
MSGTYPE_DECLARE(MSG_ACTIVITY_NOTIFY_STATE_CHANGE),          // 通知客户端，活动的变化信息
MSGTYPE_DECLARE(MSG_ACTIVITY_NOTIFY_BOSS_DATA),             // 通知客户端, 世界boss活动信息
MSGTYPE_DECLARE(MSG_ACTIVITY_SYNC_BOSS_DATA),               // 通知客户端, 同步世界boss活动信息
MSGTYPE_DECLARE(MSG_NOTIFY_NEXT_ONLINE_PEAK_ACT_START),     // 通知客户端, 在线峰值下阶段开始
MSGTYPE_DECLARE(MSG_NOTIFY_ACT_INFO),                       // 通知单个活动信息
MSGTYPE_DECLARE(MSG_NOTIFY_STOP_ACT),                       // 通知停止活动
MSGTYPE_DECLARE(MSG_NOTIFY_LUCK_CONVERT_COUNT),             // 通知幸运活动兑换次数
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_GUILD_MATCH_SELECTED_TANK),           // 通知客户端，军团赛已选坦克信息
MSGTYPE_DECLARE(MSG_NOTIFY_CONQUER_CASTLE),                 //guild-> 通知玩家获得主城
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_MATCH_PAIR_GROUP),         // 通知军团赛显示对阵图
MSGTYPE_DECLARE(MSG_NOTIFY_RAND_STEP_SUPPORT_INFO),     ///< 通知客户端夺宝排行点赞信息
MSGTYPE_DECLARE(MSG_NOTIFY_FIRE_BALL_CAN_SEL_TANK),         // 通知火球赛可选坦克


MSGTYPE_DECLARE(MSG_GATE_SVR_END),          // 客户端允许接收的最后一条协议
/*#######################################################################
  #######################################################################*/

// ----------------------------------------------------------------------/
/* 以下是群集中服务器间数据通信的数据包                                         */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_COMMON_START, 3000),
MSGTYPE_DECLARE(MSG_SPACELOG_COMMON),                       //系统日志消息
MSGTYPE_DECLARE(MSG_CLUSTER_CONFIG_UPDATE),                 ///< 通知群组配置信息，Adminsvr到各个服务器
MSGTYPE_DECLARE(MSG_HUB_PROVIDER_REGISTER),                 ///< 通知路由节点服务器，注册某个服务
MSGTYPE_DECLARE(MSG_HUB_PROVIDER_REGISTER_RESULT),          ///< 通知节点，注册某个服务到路由的结果
MSGTYPE_DECLARE(MSG_HUB_SERVICE_REQUEST),                   ///< 发送到HUB节点的转发路由请求结果
MSGTYPE_DECLARE(MSG_HUB_SERVICE_RESULT),                    ///< 发送到HUB节点的转发路由请求结果
MSGTYPE_DECLARE(MSG_CLUSTER_SHUT_DOWN_INDICATE),          ///< 通知群组，系统即将关闭， Adminsvr到各个服务器
MSGTYPE_DECLARE(MSG_REQUEST_NET_PROFILE_DATA),          	///< 请求网络性能分析数据
MSGTYPE_DECLARE(MSG_NOTIFY_NET_PROFILE_DATA),          		///< 通知网络性能分析数据
MSGTYPE_DECLARE(MSG_REQUEST_DB_PROFILE_DATA),          	///< 请求数据库性能分析数据
MSGTYPE_DECLARE(MSG_NOTIFY_DB_PROFILE_DATA),          		///< 通知数据库性能分析数据
MSGTYPE_DECLARE(MSG_REQUEST_FUNC_PROFILE_DATA),          	///< 请求函数性能分析数据
MSGTYPE_DECLARE(MSG_NOTIFY_FUNC_PROFILE_DATA),          		///< 通知函数性能分析数据
MSGTYPE_DECLARE(MSG_CLIENT_BIND_GAME_CONNID),               ///< 客户端连接绑定目标gamesvr的连接id
MSGTYPE_DECLARE(MSG_CLIENT_UNBIND_GAME_CONNID),             ///< 客户端连接解除绑定目标gamesvr的连接id
MSGTYPE_DECLARE(MSG_OBSERVER_BIND_PLAYER_ACCOUNT),      	///< 绑定需要附身的玩家账号
MSGTYPE_DECLARE(MSG_OBSERVER_UNBIND_PLAYER_ACCOUNT),      	///< 解除需要附身的玩家账号
MSGTYPE_DECLARE(MSG_MARK_OBSERVER_NET_CONN),      					///< 标记玩家链接附身状态
MSGTYPE_DECLARE(MSG_UNMARK_OBSERVER_NET_CONN),      				///< 解除玩家链接附身状态

/*#######################################################################
  认证相关的交互协议
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_AUTH_START, 3100),
//-----AUTH<->GATE之间协议往来
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_REGISTER),         //->认证服务器，注册服务
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_REGISTERRESULT),   //->各客户端，返回注册结果

MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_SESSIONSTART),     //网关->认证中心，有登陆请求激活
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_SESSIONCLOSE),     //认证前端->认证中心，通知有登录SESSION请求放弃

MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SREQUEST),  //认证中心->，通知有登录请求
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SSTART),    //认证中心->，通知有登录开始
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_WENTER),    //认证中心->，通知有角色进入游戏世界
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_WLEFT),     //认证中心->，通知有角色离开游戏世界
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SCLOSE),    //认证中心->，有SESSION已经放弃

MSGTYPE_DECLARE(MSG_CLUSTER_RESYNC_SESSIONS),       //->认证中心，同步已经完成的登陆
MSGTYPE_DECLARE(MSG_CLUSTER_RESYNC_COMPLETE),       //Gate->认证中心，登录同步结束
MSGTYPE_DECLARE(MSG_CLUSTER_GATE_SESSION_READY),    ///< 网关服务器准备好接受登陆
MSGTYPE_DECLARE(MSG_BRIDGE_RESPONSE),               ///< 桥接服务器响应
MSGTYPE_DECLARE(MSG_HTTP_BRIDGE_RESPONSE),          ///< 桥接HTTP服务器响应

/*#######################################################################
  在 GATE_SVR 相关的协议
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_GAME_START, 3200),
MSGTYPE_DECLARE(MSG_CLUSTER_GATE_CLIENTLOST),           //网关->游戏 玩家断线
MSGTYPE_DECLARE(MSG_CLUSTER_GATE_PLAYERSYNC),           //网关->游戏 发送初始角色信息
MSGTYPE_DECLARE(MSG_CLUSTER_GAME_CLIENTLOSTCONFIRM),    //游戏->网关 断线处理完毕
MSGTYPE_DECLARE(MSG_CLUSTER_MULTICAST_PACKET),          //游戏->网关 多播消息报
MSGTYPE_DECLARE(MSG_CLOSE_CLIENT_CONNECT),              //游戏->网关 关闭一个用户连接
MSGTYPE_DECLARE(MSG_CLUSTER_SERVER_PROFILE),            //服务器描述信息
MSGTYPE_DECLARE(MSG_REQUEST_ENTER_SOLO_SCENE),          //网关->位置 请求创建单人场景
MSGTYPE_DECLARE(MSG_REQUEST_ENTER_TANK_TRIAL_SCENE),    //网关->位置 请求进入坦克试玩场景
MSGTYPE_DECLARE(MSC_CREATE_SCENE_PROPS),                // 通知创建场景道具
MSGTYPE_DECLARE(MSG_SYNC_QUEST_ACEM_LIST_TOGAME),       // 同步任务成就信息togame
MSGTYPE_DECLARE(MSG_CHANGE_CHECK_COUNT),                // 改变任务的检查点数量
MSGTYPE_DECLARE(MSG_RELIVE_SYNC_ATTR),                  // 坦克复活，请求同步坦克数值
MSGTYPE_DECLARE(MSG_SYNC_ATTR_TOGAME),                  // 同步坦克数据给gamesvr
MSGTYPE_DECLARE(MSG_SYNC_CHAR_INFO_TOGAME),             // 同步角色数据给gamesvr
MSGTYPE_DECLARE(MSG_SYNC_ROULETTE_AWARD),               // 同步轮盘获奖信息给tracksvr
MSGTYPE_DECLARE(MSG_UPDATE_BATTLE_TECHNO),              // 更新技术信息
MSGTYPE_DECLARE(MSG_SYNC_CHAR_DAY_CHARGE_INFO),         // 同步角色充值数给tracksvr
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_CHARGE_NUM),          // 通知全服充值奖励任务的数额
MSGTYPE_DECLARE(MSG_NOTIFY_GATE_DRAW_SOCIAL_QUEST_AWARD),// 通知Gate发放社交任务奖励
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_SOCIAL_AWARD_RESULT),   // 通知奖励发放结果
MSGTYPE_DECLARE(MSG_NOTIFY_RECORD_CHAR_LAST_INFO),      // game->gate 记录角色下线时的地图坐标信息
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_SELECTED_TANK),          // gate->activity通知玩家选择了某坦克进入战场
MSGTYPE_DECLARE(MSG_SYNC_SVR_AWARD),               			// 同步svr_award获奖信息给tracksvr

/*#######################################################################
  位置服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_TRACK_START, 3300),
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_LOGIN),                   // gate->track,通知有玩家登录游戏
MSGTYPE_DECLARE(MSG_GAME_CREATE_SCENE),                     // 通知game创建新战场
MSGTYPE_DECLARE(MSG_GAME_REMOVE_SCENE),                     // 通知track销毁战场
MSGTYPE_DECLARE(MSG_GAME_CREATE_SCENE_OK),                  // 通知track创建成功
MSGTYPE_DECLARE(MSG_GATE_ENTER_SCENE),                      // 通知gate坦克进入战场
MSGTYPE_DECLARE(MSG_GAME_JOIN_SCENE),                       // 通知game有玩家加入战场
MSGTYPE_DECLARE(MSG_GAME_ADD_LOOKER),                       // 通知game有玩家进入战场观战
MSGTYPE_DECLARE(MSG_NOTIFY_TURNUP_RESULT_TOGATE),           // 通知翻牌结果给gate
MSGTYPE_DECLARE(MSG_SYNC_LIMIT_INFO_BYGATE),                // 同步玩家的限制信息
MSGTYPE_DECLARE(MSG_SYNC_CHAR_INFO_TOTRACK),                // 同步角色信息给tracksvr
MSGTYPE_DECLARE(MSG_GAME_START_CAMP_POISE),                 // 通知game开启人数平衡
MSGTYPE_DECLARE(MSG_GAME_UPDATE_TANK_CAMP),                 // 通知game切换阵营
MSGTYPE_DECLARE(MSG_SYNC_CHAR_NAME),                        // 同步角色改名信息给tracksvr
MSGTYPE_DECLARE(MSG_LEAGUE_NOTIFY_BATTLE_RESULT),           // 联赛通知成绩信息
MSGTYPE_DECLARE(MSG_GATE_RENEW_ELO),                        // 通知ELO刷新
MSGTYPE_DECLARE(MSG_GATE_CHANGE_CHAR_HONOR),                // 通过后台修改玩家的容易信息
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_TEAM_AWARD),              // 通知发放联赛的战队奖励
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_MEMBER_AWARD),            // 通知发放联赛的战队个人奖励
MSGTYPE_DECLARE(MSG_GAME_CHANGE_BATTLE_TECHNO),             // 通知更新技术统计
MSGTYPE_DECLARE(MSG_GAME_EXIT_BATTLE),                      // game通知玩家退出战斗
MSGTYPE_DECLARE(MSG_GAME_HARM_BOSS),                        // game通知玩家对世界boss造成伤害
MSGTYPE_DECLARE(MSG_TRACK_BATTLE_END),                      // trakc通知game战斗结束
MSGTYPE_DECLARE(MSG_SYNC_BUDDY_DATA),                       // 同步好友数据
MSGTYPE_DECLARE(MSG_SYNC_GUILD_DATA),                       // 同步军团数据
MSGTYPE_DECLARE(MSG_SYNC_TRACK_SELECTED_TANK),              // track->gate同步选坦克阶段分配的坦克
MSGTYPE_DECLARE(MSG_SYNC_TANK_BRIEF),                       // gate->track 同步坦克简要信息
MSGTYPE_DECLARE(MSG_REQUEST_PUNISH_ESCAPE),                 // track->gate 请求惩罚逃跑玩家
MSGTYPE_DECLARE(MSG_GAME_SCENE_RECORD_START),               // track->game 请求开始战斗录像
MSGTYPE_DECLARE(MSG_NOTIFY_REFRESH_NOTE),                   // track->gate 通知刷新纪录
MSGTYPE_DECLARE(MSG_NOTIFY_GRANT_ONLINE_PEAK_AWARD),        // track->gate 通知发放峰值在线活动奖励
MSGTYPE_DECLARE(MSG_REQUEST_CHECK_BATTLE_TANK),          // track->gate 请求检测主战的坦克是否可用
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_DAMAGE_HP),           // track->game 通知军团BOSS伤害血量
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_END_DAMAGE_INFO),     // game->track 通知军团BOSS战斗结束后伤害信息
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_3V3_INFO),                // track->gate 通知gate更新3V3信息
MSGTYPE_DECLARE(MSG_NOTIFY_NO_SELECT_TANK_PUNISH),          // track->gate 通知未选坦克惩罚
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_END), 						// track->gate 通知助手对战结束
MSGTYPE_DECLARE(MSG_CLUSTER_SYSTEM_BULLETIN), 						  // 其他->位置,系统公告通知
MSGTYPE_DECLARE(MSG_CHAT_PLAYER_INFO),                      // TrackSvr -> chatsvr, 通知聊天服务器相关玩家信息
MSGTYPE_DECLARE(MSG_SYNC_CHAR_GUILD_TOGATE),                // 同步角色军团信息到gate
MSGTYPE_DECLARE(MSG_SYNC_GUILD_SKILL_INFO_TOGATE),          // 同步军团技能信息到gate
MSGTYPE_DECLARE(MSG_CHAR_ADD_TEAM_MERIT),                   // track->guild,增加玩家军团贡献
MSGTYPE_DECLARE(MSG_NOTIFY_CONSUME_VALENTINE_FLAUNT),       // track->gate通知消耗情人节鲜花
MSGTYPE_DECLARE(MSG_NOTIFY_CONSUME_HIRE_TANK_COIN),         // track->gate通知扣除赠送租用坦克的消耗
MSGTYPE_DECLARE(MSG_ADD_HIRE_TANK_PRESENT_TIME),            // track->gate gate->track 增加赠送的租用坦克时间
MSGTYPE_DECLARE(MSG_TEAM_PVE_BATTLE_WIN),                   // track->guild , 战队通关PVE地图
MSGTYPE_DECLARE(MSG_CHAR_ADD_GUILD_ACTIVE),                 // gate->guild 玩家增加军团活跃度


/*#######################################################################
  聊天服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CHAT_ERROR_INFO, 3500),      //聊天错误信息回复
MSGTYPE_DECLARE(MSG_CHAT_BULLETIN),                     //公告信息通知
MSGTYPE_DECLARE(MSG_SYSTEM_BULLETIN_NOTIFY),            //系统公告通知
MSGTYPE_DECLARE(MSG_QUESTION_NOTIFY_HAVE_ANSWER),       //通知玩家有反馈
MSGTYPE_DECLARE(MSG_SYNC_PVP_PAIR_INFO),                //同步匹配信息
MSGTYPE_DECLARE(MSG_SYSTEM_TEMPLATE_BULLETIN_NOTIFY),   //模板系统公告通知

/*#######################################################################
  数据服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_SVR_DATASVR_START, 3600),        // 数据服务器消息
MSGTYPE_DECLARE(MSG_PERSIST_REGISTER),                      // 请求注册Persist服务
MSGTYPE_DECLARE(MSG_PERSIST_REGISTER_CONFIRM),              // 确认Persist服务注册成功
MSGTYPE_DECLARE(MSG_PERSIST_REGISTER_REJECT),               // 拒绝Persist注册
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_SIMPLE),                // 数据消息，发送持久化请求
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_COMPOSITE),             // 数据消息，发送持久化请求
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_TRANSACTION),           // 数据消息，发送持久化请求
MSGTYPE_DECLARE(MSG_PERSIST_RESPONSE_SIMPLE),               // 数据消息，发送持久化响应
MSGTYPE_DECLARE(MSG_PERSIST_RESPONSE_COMPOSITE),            // 数据消息，发送持久化响应
MSGTYPE_DECLARE(MSG_PERSIST_RESPONSE_TRANSACTION),          // 数据消息，发送持久化响应
MSGTYPE_DECLARE(MSG_PERSIST_TXN_RESULT),                    // 事务提交返回的数据
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_POOLSTATE),             // 请求状态信息
MSGTYPE_DECLARE(MSG_PERSIST_REPORT_POOLSTATE),              // 请求POOL状态
MSGTYPE_DECLARE(MSG_NOTIFY_TRACKSVR_PLAYERLOGIN),           // Game -> Track 通知玩家在其他服务器登陆
MSGTYPE_DECLARE(MSG_NOTIFYGAMESVR_REMOVELEFTOVEROBJ),       // Track -> Game 通知玩家在其他服务器登陆，删除残余数据


/*#######################################################################
  npc服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_NPC_START, 3700),
//第零部分 : NPC相关的消息
MSGTYPE_DECLARE(MSG_QUERY_ASK),                         // 服务器之间互相查询请求
MSGTYPE_DECLARE(MSG_QUERY_ANSWER),                      // 服务器之间互相查询应答
MSGTYPE_DECLARE(MSG_NPC_SERVER_REGISTER),               // NPC服务器启动，告知游戏服务器
MSGTYPE_DECLARE(MSG_NPC_SERVER_REG_RESPONE),            // 游戏服务器对NPC服务器注册的回应MSG_NPC_SERVER_REG_RESPONE
MSGTYPE_DECLARE(MSG_NPC_SERVER_CLOSE),                  // npc->gamesvr 通知npcsvr关闭
MSGTYPE_DECLARE(MSG_NPC_SCENE_INIT),                    // npc->gamesvr 通知场景npc初始化
MSGTYPE_DECLARE(MSG_NPC_TANK_ENTER),                    // gamesvr->npc 通知坦克进入战场
MSGTYPE_DECLARE(MSG_NPC_TANK_EXIT),                     // gamesvr->npc 通知坦克退出战场
MSGTYPE_DECLARE(MSG_NPC_CREATE_PROPS),                  // npc->gamesvr 通知创建场景道具
MSGTYPE_DECLARE(MSG_NPC_SYNC_ATTRS),                     // gamesvr->npc 通知同步属性数据
MSGTYPE_DECLARE(MSG_NPC_REPAIR_TANK),                   // npc->gamesvr 通知修理箱给坦克补血
MSGTYPE_DECLARE(MSG_NPC_OBJ_MOVE),                      // gamesvr->npc npc->gamesvr 通知对象移动
MSGTYPE_DECLARE(MSG_NPC_CREATE_OBJECT),                 // npc->gamesvr 通知对象创建
MSGTYPE_DECLARE(MSG_NPC_SYNC_ATTR),                    // gamesvr->npc 同步对象属性
MSGTYPE_DECLARE(MSG_NPC_USE_SKILL),                     // npc->gamesvr 通知AINPC使用技能
MSGTYPE_DECLARE(MSG_NPC_BATTLE_END),                    // npc->gamesvr 通知战斗结束
MSGTYPE_DECLARE(MSG_NPC_REMOVE_OBJ),                    // npc->gamesvr 通知移除对象
MSGTYPE_DECLARE(MSG_NOTIFY_SEEK_PATH),                  // 通知寻径结果
MSGTYPE_DECLARE(MSG_NPC_FROZEN),                        // npc->gamesvr 冻结
MSGTYPE_DECLARE(MSG_NOTIFY_NPC_CREATE_OBJ),             // game->npc 通知NPC创建对象
MSGTYPE_DECLARE(MSG_GAME_OBJ_STATE_CHANGE),             // game->npc  通知NPC，对象状态变化
MSGTYPE_DECLARE(MSG_NPC_ADD_BUFF),                      // npc->Game 通知 game 增加BUFF
MSGTYPE_DECLARE(MSG_NPC_REMOVE_BUFF),                   // npc->Game 通知 game 删除BUFF
MSGTYPE_DECLARE(MSG_NOTIFY_GIVE_BATTLE_EXP),            // npc->game 通知给予战场经验
MSGTYPE_DECLARE(MSG_NPC_SYNC_PORTAL_STATE),             // npc->Game通知gamesvr同步传送门状态
MSGTYPE_DECLARE(MSG_NOTIFY_NPC_EXEC_SCRIPT),            // game->npc 通知NPC执行地图脚本
MSGTYPE_DECLARE(MSG_NPC_NOTIFY_PVE_STEP),               // npc->Game通知gamesvr副本进度
MSGTYPE_DECLARE(MSG_NOTIFY_NPC_SVR_REMOVE_BUFF),        // game->npc 通知对象移除BUFF

/*#######################################################################
  guild 服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_GUILD_START, 3800),
MSGTYPE_DECLARE(MSG_QUERY_GUILD_CREATE_ROOM),           //track->guild，查询创建房间的请求是否通过
MSGTYPE_DECLARE(MSG_GUILD_REQUEST_CREATE_ROOM),         //guild->track, 通知track创建房间
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_DESTROY_ROOM),         //track->guild, 通知guild房间被销毁
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_PLAYER_ENTER_ROOM),    //track->guild, 通知guild玩家进入房间
MSGTYPE_DECLARE(MSG_MULTICAST_TEAM_ROOM_PACKET),        //guild->track, 通知track内战队房间的玩家
MSGTYPE_DECLARE(MSG_GUILD_REQUEST_CREATE_SCENE),        //guild->global,通知global创建战场
MSGTYPE_DECLARE(MSG_MULTICAST_GUILD_MATCH_ROOM_PACKET), //guild->global,通知track内的军团战房间的玩家
MSGTYPE_DECLARE(MSG_REQUEST_ROUNDPASS_ROOM_MEMBER_UUID),//guild->track,请求房间内出战玩家UUID
MSGTYPE_DECLARE(MSG_NOTIFY_ROUNDPASS_ROOM_MEMBER_UUID), //track->guild,通知轮空房间的成员
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_MATCH_RANK_TO_GATE),   //guild->gate, 通知军团赛名次
MSGTYPE_DECLARE(MSG_NOTIFY_RESET_GUILD_MATCH_RANK_QUEST), // guild->gate, 通知重置军团排名任务
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_BATTLE_START),   //guild->track, 通知军团BOSS战斗开始
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_BATTLE_END),     //track->guild, 通知军团BOSS战斗结束
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_GET_GUILD_BOSS_AWARD),   //guild->gate,  通知获得军团BOSS奖励
MSGTYPE_DECLARE(MSG_NOTIFY_CLEAR_GUILD_BOSS_BATTLE_TIME),   //guild->gate,  通知清除军团BOSS战斗时间
MSGTYPE_DECLARE(MSG_REQUEST_START_3V3_PAIR),            // track->guild, 请求开始3V3争霸赛报名参赛
MSGTYPE_DECLARE(MSG_REQUEST_STOP_3V3_PAIR),             // track->guild, 请求取消3V3争霸赛报名参赛
MSGTYPE_DECLARE(MSG_NOTIFY_3V3_DIRECT_WIN),                 // guild->track, 通知3V3轮空直接获胜

MSGTYPE_DECLARE_ASSIGN(MSG_TEST_START, 4000),
MSGTYPE_DECLARE(MSG_TEST_LATENCY_RECORD),                   //测试 延时收集
MSGTYPE_DECLARE(MSG_TEST_FULL_DATATYPE),                // 测试各种数据类型

/*#######################################################################
  global服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_GLOBAL_START, 4100),

MSGTYPE_DECLARE(MSG_GLOBAL_START_PAIR),                 // 开始跨服配对
MSGTYPE_DECLARE(MSG_GLOBAL_STOP_PAIR),                  // 停止跨服配对
MSGTYPE_DECLARE(MSG_GLOBAL_ASSIGN_GAMESVR),             // 通知gate战斗分配的gamesvr
MSGTYPE_DECLARE(MSG_GLOBAL_MIDWAY_JOIN),                // 请求中途加入
MSGTYPE_DECLARE(MSG_GLOBAL_SCENE_LIST),                 // 通知战场列表信息
MSGTYPE_DECLARE(MSG_GLOBAL_DEL_SCENE_LIST),             // 通知删除战场列表信息
MSGTYPE_DECLARE(MSG_GLOBAL_ROBOT_PAIR),                 // 通知开始进行机器人配对
MSGTYPE_DECLARE(MSG_GLOBAL_LOOK_SCENE),                 // 通知跨服观战
MSGTYPE_DECLARE(MSG_GLOBAL_PAIR_OK),                    // 通知跨服配对成功
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_RESULT),              // 通知跨服联赛战斗结果
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_MIDWAY_JOIN_OK),      // 通知track中途加入成功
MSGTYPE_DECLARE(MSG_GLOBAL_SYNC_TANK_BRIEF),            // 通知跨服同步坦克简要信息
MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_JOIN_LEAGUE_ROOM),   // 请求加入联赛房间 track->global
MSGTYPE_DECLARE(MSG_GLOBAL_NOTIFY_JOIN_LEAGUE_ROOM_OK), // 通知加入联赛房间成功 global->track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAVE_LEAGUE_ROOM),          // 通知离开联赛房间 global->track
MSGTYPE_DECLARE(MSG_GLOBAL_REQ_ROOM_OP),                // 请求联赛房间操作
MSGTYPE_DECLARE(MSG_GLOBAL_PLAYER_LOGOUT),              // 通知GLOBAL玩家登出
MSGTYPE_DECLARE(MSG_GLOBAL_STAT_CHAR_DATA),             // 通知统计角色信息
MSGTYPE_DECLARE(MSG_GLOBAL_NOTIFY_USE_ITEM),            // 通知global使用物品
MSGTYPE_DECLARE(MSG_GLOBAL_SYNC_CHAR_INFO),             // 通知global玩家信息变更
MSGTYPE_DECLARE(MSG_GLOBAL_PUNISH_LADDER_ESCAPE_ON_WAIT),   // global->track, 处罚天梯逃跑玩家
MSGTYPE_DECLARE(MSG_GATE_GET_CURTALENTPAGE),                // global-->track-->gate 从Gate获取玩家当前天赋页
MSGTYPE_DECLARE(MSG_SYNC_CURTALENTPAGE),                    // gate-->track-->global 向Track同步当前天赋页
MSGTYPE_DECLARE(MSG_GATE_UNLOCK_TALENTOP),                  // global-->track-->gate 通知Game解锁玩家的天赋操作
MSGTYPE_DECLARE(MSG_GLOBAL_REQ_LOOK_ROOM),                  // 请求加入房间成为观察者
MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_SET_MAP),                // 请求设置房间地图
MSGTYPE_DECLARE(MSG_REQUEST_MATCH_ROOM_CHAR_DATA),          // global->track 请求比赛房间成员信息
MSGTYPE_DECLARE(MSG_NOTIFY_MATCH_ROOM_CHAR_DATA),           // track->global 通知战队赛房间成员信息
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MATCH_END),                 // global->guild 通知战队赛比赛结束

MSGTYPE_DECLARE_ASSIGN(MSG_GLOBAL_SYNC_TEAM, 4200),             // 同步战队数据到GLOBAL
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_ENROLL_RESULT),               // 联赛报名结果Global->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_REQ),               // 联赛请求挑战列表Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_LIST),              // 联赛返回挑战列表Global->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_REQUEST_AWARD),               // 联赛请求领奖Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_ACT_PREPARE),                 // 联赛活动开始前的准备Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_MEMEBER_AWARD),               // 联赛奖励领取Global->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_TEAM),              // 联赛请求约战Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_PLAYER_LOGIN),                // 玩家登录
MSGTYPE_DECLARE(MSG_GLOBAL_TEAM_MESSAGE),                       // 发送战队消息Global->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_GET_TO_WAR),                  // 获取出战玩家列表Global->Track
MSGTYPE_DECLARE(MSG_NOTIFY_REMOTE_PLATFORM_MATCH_RESULT),       // 通知平台赛事接口比赛结果 global->track
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_AUTO_ENROLL),                 // 通知联赛自动报名信息Global->Track
MSGTYPE_DECLARE(MSG_REQUEST_LEAGUE_BATCH_ENROLL),               // 请求global批量报名联赛
MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_SYNC_TEAM_MEMBER),           // 请求同步战队成员信息 global->track
MSGTYPE_DECLARE(MSG_SYNC_IMPEACH_INFO),                         // 同步举报信息 global <-> track
MSGTYPE_DECLARE(MSG_NOTIFY_IMPEACH_RESULT_IN_SERVER),           // 通知举报结果 global <-> track
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_NEW_MAIL),                    // 通知其他服务器有新邮件 now : track -> global -> tracks
MSGTYPE_DECLARE(MSG_NOTIFY_AFK_TRIGGER),                        // 通知track有玩家触发挂机  game -> track, game->global->track
MSGTYPE_DECLARE(MSG_NOTIFY_RELOAD_BAN_INFO),                    // 通过global转发给track重新加载被举报人的封禁信息
MSGTYPE_DECLARE(MSG_GLOBAL_GM_RESULT),                          // GLOBAL的GM命令的返回结果
MSGTYPE_DECLARE(MSG_ADD_GLOBAL_ROULETTE_GIFT),                  // 通知增加跨服转盘奖池的礼券
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GLOBAL_ROULETTE_GIFT),         // 请求领取跨服转盘奖池的礼券
MSGTYPE_DECLARE(MSG_NOTIFY_GET_GLOBAL_ROULETTE_GIFT),           // 通知获得跨服转盘奖池的礼券
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_ROULETTE_GIFT_NUM),           // 通知当前转盘奖池的礼券数
MSGTYPE_DECLARE(MSG_REQUEST_CHECK_ROULETTE_DROP_LIMIT),         // 请求检验限制掉落物品
MSGTYPE_DECLARE(MSG_SYNC_ROULETTE_CHECKED_DROP_ITEM),           // 通知gate转盘掉落物品
MSGTYPE_DECLARE(MSG_SYNC_FREE_WEEK_TANK_CONFIG),                // 同步周免坦克信息
MSGTYPE_DECLARE(MSG_REQUEST_QUERY_GLOBAL_LIMIT_AWARD_INFO),     // 请求全服查询限制奖励信息
MSGTYPE_DECLARE(MSG_NOTIFY_QUERY_GLOBAL_LIMIT_AWARD_INFO),      // 通知全服查询限制奖励信息
MSGTYPE_DECLARE(MSG_NOTIFY_CLOUD_PURCHASE_BUY_INFO),            // 通知云购购买信息
MSGTYPE_DECLARE(MSG_REQUEST_GLOBAL_CONVERT_ITEM),               // 请求全服兑换物品
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_CONVERT_ITEM),                // 通知全服兑换物品
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_NEW_MAIL),                    // 通知跨服服务器发送新邮件通知
MSGTYPE_DECLARE(MSG_NOTIFY_CLOUD_PURCHASE_AWARD_INFO),          // 通知云购大奖信息 global -> gate
MSGTYPE_DECLARE(MSG_REQUEST_GLOBAL_LOAD_PURCHASE_AWARD),        // 请求加载云购大奖信息
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_USE_COUNT_INFO),             // 通知篝火活动柴火使用信息 global -> gate
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_USE),                        // 通知篝火活动柴火使用 gate -> global
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_COMPLETE_QUEST),             // 通知篝火活动领取任务奖励 gate -> global
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_COMPLETE_QUEST_INFO),        // 通知篝火活动领取任务奖励信息global -> gate
MSGTYPE_DECLARE(MSG_SYNC_TREASURE_TANK),                        // 通知夺宝坦克信息 global -> gate

/*#######################################################################
  robot服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_ROBOT_START, 5000),
MSGTYPE_DECLARE(MSG_NOTIFY_ROBOT_CACHE_PATH),           //通知预缓存的寻径结果

/*#######################################################################
  buddy服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_BUDDY_START, 5100),
MSGTYPE_DECLARE(MSG_REQUEST_OBSERVER_OTHER_GATE_PLAYER),       ///< 请求附身（不同gate）
MSGTYPE_DECLARE(MSG_NOTIFY_OBSERVER_OTHER_GATE_PLAYER),       ///< 通知附身（不同gate）
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_ITEM_DROP_INFO),       			///< 通知邀请卡掉落信息(gate -> buddy)
MSGTYPE_DECLARE(MSG_NOTIFY_FORBID_DROP_INVITE_ITEM),       		///< 通知禁止掉落邀请卡(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_INVITE_GIFT_AWARD),       		///< 通知领取邀请好礼奖励(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_CROSS_DAY),       			///< 通知玩家隔天计算在线天数(gate -> buddy)
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_INVITE_GIFT_ITEM),       		///< 通知删除邀请道具(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_ITEM_OVER_TIME),       ///< 通知玩家道具过期(gate -> buddy)
MSGTYPE_DECLARE(MSG_NOTIFY_CAN_SENDMAIL),                     ///< 通知可以发送邮件(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_CAN_PRESENT_GOODS),                ///< 通知可以赠送商品给他人(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_BIND_INVITE_SPREAD_PLAYER),   		  ///< 通知邀请推广玩家信息(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_SPREAD_BIND_LEVEL_INFO),    ///< 通知邀请推广绑定玩家等级(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_SPREAD_BIND_LEVEL_CHANGE),  ///< 通知邀请推广绑定玩家等级变化(gate -> buddy)

/*#######################################################################
  activity服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_ACTIVITY_START, 5200),
MSGTYPE_DECLARE(MSG_SYNC_RUNNING_ACTIVITY_TO_SVR),          ///< 通知其他服务器同步已开启的活动信息
MSGTYPE_DECLARE(MSG_NOTIFY_START_ACT),                      ///< 通知其他服务器某个活动开启
MSGTYPE_DECLARE(MSG_SEND_REDPKT_BULLETIN),                  // gate-->act 玩家发红包的公告
MSGTYPE_DECLARE(MSG_NOTIFY_LUCK_CONVERT_SUCCESS),           // gate-->act 通知幸运活动兑换成功
MSGTYPE_DECLARE(MSG_SYNC_GUILD_MATCH_SELECTED_TANK),      // act->track
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_MATCH_SELECTED_TANK),   // 请求获取玩家选坦克信息
MSGTYPE_DECLARE(MSG_NOTIFY_RAND_STEP_SUPPORT_SUCCESS),    // act->gate  通知点赞成功


/*#######################################################################
  cache服务器相关消息
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CACHING_START, 5300),
MSGTYPE_DECLARE(MSG_CACHING_REFRESH_REQUEST),               ///< 请求刷新特定的缓存
MSGTYPE_DECLARE(MSG_CACHING_REFRESH_RESULT),                ///< 返回特定缓存刷新的结果

//--------------------------------------------------------------------------
MSGTYPE_DECLARE_ASSIGN(MSG_LAST, 6000),                            //标识最后一条消息
//-------------------------------------------------------------------------
MSGTYPE_END_BLOCK


