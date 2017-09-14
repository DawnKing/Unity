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
/*   �ɿͻ��˿��Է��͵���Ϣ                                                */
// --------------------------------------------------------------------��--/
MSGTYPE_DECLARE_ASSIGN(MSG_CLIENT_START, 50),
// -----------------------------------------------------------------------/
/*   ����Ҫgateת������Ϣ                                                  */
// --------------------------------------------------------------------��--/
//���㲿�֣���֤��������Ϣ
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_AUTH_LOGIN),       //����֤ǰ�˷���������������֤
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_PROTOCOL_VERSION), //����֤��������֤Э��汾
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_REGION_SESSION),   //����֤�����������¼����������
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_SERVER_LOGIN),     //�����ط����������¼
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_SERVER_LOGOUT),    //�����ط����������˳���¼
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_WORLD_ENTER),      //�ͻ�����ѡȡ��ɫ�������ͼ֮�󣬷��͸�������
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_WORLD_LOGOUT),     //�뿪��Ϸ���ٽ�����Ҫ����֤������������֤
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_CANCEL_LOGOUT),    //��������뿪��Ϸ������
MSGTYPE_DECLARE(MSG_AUTH_REQUEST_SWITCH_LINE),      //�����л�����

// ϵͳЭ��
MSGTYPE_DECLARE(MSG_SYSTEM_HEARTBEAT),              // ������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_PING),                  // �ͻ�������������pingֵ
MSGTYPE_DECLARE(MSG_GM_COMMAND),                    // GMָ�� gate
MSGTYPE_DECLARE(MSG_GM_GAME_COMMAND),               // GMָ�� gate->game

// ��ɫ����
MSGTYPE_DECLARE(MSG_CHARCREATE_REQUEST),            // ������н�ɫ����
MSGTYPE_DECLARE(MSG_CHAR_NAME_UNIQUE_REQUEST),            // ����Ψһ�Լ��
MSGTYPE_DECLARE(MSG_CHAR_CURRENCY_REQUEST_RMB_TRANSER),     // �������RMB�һ�
MSGTYPE_DECLARE(MSG_CHAR_CURRENCY_REQUEST_RMB),     		// ����RMB������
MSGTYPE_DECLARE(MSG_REQUEST_CREATE_TEAM),                   // ����ս��
MSGTYPE_DECLARE(MSG_REQUEST_CREATE_GUILD),              // ���󴴽�����
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_GIFT),                    // ������ȡ�������
MSGTYPE_DECLARE(MSG_REQUEST_TRANSFER_TEAM_COIN),        // ����ת��ս�ӵ��ʽ𵽾���
MSGTYPE_DECLARE(MSG_CLIENT_DATA_STAT),                      // �ͻ������ݲɼ�
MSGTYPE_DECLARE(MSG_REQUEST_USE_SPRAY),                     // ���������ͼ
MSGTYPE_DECLARE(MSG_REQUEST_STAGE_REAP_REWARD),			// ������ȡ�׶��Խ���
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_NAME),           	// �����޸Ľ�ɫ��
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_TEAM_NAME),          // �����޸�ս����
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_GUILD_NAME),         // �����޸ľ�����
MSGTYPE_DECLARE(MSG_REQUEST_BUY_THEW),                  // ����������
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_SETTING),            // ���󱣴�ϵͳ����
MSGTYPE_DECLARE(MSG_REQUEST_PICK_CASHBACK),             // ������ȡ��ȯ�¿��ķ���
MSGTYPE_DECLARE(MSG_NOTIFY_CASHBACK_INFO),              // ������ȯ�¿��ĸ�����Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_PICK_PRENTICE_CASHBACK),    // ������ȡͽ�ܳ�ֵ����
MSGTYPE_DECLARE(MSG_NOTIFY_PRENTICE_CASHBACK_INFO),     // ����ͽ�ܳ�ֵ������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_PAYMENT_RMB),               // �����ֵ
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_CHAR_DATA),           // ֪ͨͬ����ɫ����
MSGTYPE_DECLARE(MSG_REQUEST_OBSERVER_LOGIN),       			// �������½
MSGTYPE_DECLARE(MSG_REQUEST_PROTECT_PWD_OP),    				///<����2���ܱ���ز���
MSGTYPE_DECLARE(MSG_REQUEST_SET_CHAR_OPTION),    				// �������ϵͳ����
MSGTYPE_DECLARE(MSG_REQUEST_SUPER_VIP_CHARGE_INFO), 		// ���󳬼�VIP��ֵ��Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_SUPER_VIP_CHARGE_BACK),        // ������ȡ����VIP����
MSGTYPE_DECLARE(MSG_APEX_SEND2SERVER),          				///< �� game client ���͸� gate server �� Apex ��Ϣ
MSGTYPE_DECLARE(MSG_APEX_SENDRETVAL2SERVER),    				///< �� game client ���͸� gate server �Ĺ���chcstart�ķ���ֵ��Ϣ

// ��Ʒ���Э��
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_SWAP_ITEM, 150),     // �ƶ���Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_SALE_ITEM),                 // ���������Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_CONT_CLEANUP),              // �����������
MSGTYPE_DECLARE(MSG_REQUEST_USE_ITEM),                  // ����ʹ����Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_AWARD),                // ������ȡ����
MSGTYPE_DECLARE(MSG_REQUEST_CONVERT_ITEM),              // ����һ���Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_PLANT),             // ������������
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_STTH),              // ����ǿ������
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMPOSE),           // ����ϳ�����
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_TRANS),             // ��������ת��
MSGTYPE_DECLARE(MSG_REQUEST_READ_ITEM),                 // ����鿴��Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_ROULETTE),                  // �������̶�
MSGTYPE_DECLARE(MSG_REQUEST_SPLIT_ITEM),                // ��������Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_EXPAND_CONTAINER),          // ������չ����
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GIFT),                 // ������ȡ���
MSGTYPE_DECLARE(MSG_REQUEST_CONTAINER_ITEM),            // �����ȡ������Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_BATTLE_BOOSTER),     // �����л���ս����
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GOLDEN_POOL),          // ������ȡ��ҳ��ڵĽ��
MSGTYPE_DECLARE(MSG_REQUEST_BIND_ITEM_ADDRESS),         // �������Ʒ���ʼĵ�ַ
MSGTYPE_DECLARE(MSG_REQUEST_ITEM_ROULETTE),             // ����ʹ����Ʒ���̶�
MSGTYPE_DECLARE(MSG_REQUEST_SEL_AWARD_USE_ITEM),        // ����ʹ����Ʒ��ȡѡ����

// ̹�����
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_TANK_BATTLE, 200),   // ����̹�˳�ս
MSGTYPE_DECLARE(MSG_REQUEST_TANK_DELETE),               // ����ɾ��̹��
MSGTYPE_DECLARE(MSG_REQUEST_TANK_HIRE),                 // ��������̹��
MSGTYPE_DECLARE(MSG_REQUEST_TANK_UP),                   // ����̹������
MSGTYPE_DECLARE(MSG_REQUEST_TANK_STTH),                 // ����̹��ǿ��
MSGTYPE_DECLARE(MSG_REQUEST_TANK_SKILL_UP),             // ����̹�˼�������
MSGTYPE_DECLARE(MSG_REQUEST_TANK_TRY),                  // ��������̹��(����)
MSGTYPE_DECLARE(MSG_REQUEST_TANK_CHANGE_SKIN),          // �������̹��Ƥ��
MSGTYPE_DECLARE(MSG_REQUEST_TANK_SKILL_UPGRADE),        // ����̹�˼���������
MSGTYPE_DECLARE(MSG_REQUEST_TANK_QUICK_UP),             // ����̹��һ������
MSGTYPE_DECLARE(MSG_REQUEST_PRESENT_HIRE_TANK),         // ������������̹��
MSGTYPE_DECLARE(MSG_REQUEST_USE_TANK_HALO),             // ����ʹ��̹�˹⻷
MSGTYPE_DECLARE(MSG_REQUEST_USE_FREE_WEEK_TANK),        // ����ʹ������̹�ˣ��ͻ���û������̹��ʵ��ʱ�����ø�Э�飩
MSGTYPE_DECLARE(MSG_REQUEST_BUY_TANK_SKIN_CHIP),        // ������̹��Ƥ����Ƭ
MSGTYPE_DECLARE(MSG_REQUEST_GET_TANK_SKIN),             // ����̹��Ƥ����Ƭ�һ���̹��Ƥ��
MSGTYPE_DECLARE(MSG_REQUEST_GET_RARE_TANK),             // ������ȡϡ��̹�˽���
MSGTYPE_DECLARE(MSG_REQUEST_SELECT_USE_TANK),           // ѡ̹�˽׶������л�̹��
MSGTYPE_DECLARE(MSG_REQUEST_TANK_RESEARCH_INFO),        // ����̹���о���Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_TANK_RESEARCH),             // �����о�̹��
MSGTYPE_DECLARE(MSG_REQUEST_RECYCLE_TANK_RESEARCH),     // ����һ��о�����Ϊ����
MSGTYPE_DECLARE(MSG_REQUEST_GET_RESEARCH_TANK),         // ����ȡ���о���ɵ�̹��
MSGTYPE_DECLARE(MSG_REQUEST_OPERATE_TANKPART),          // �������̹�˲���
MSGTYPE_DECLARE(MSG_REQUEST_START_TREASURE),            // ����һԪ�ᱦ
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_TREASURE_AWARD),       // ������ȡ�ᱦ����

//�̳����
MSGTYPE_DECLARE_ASSIGN(MSG_GOODS_SHOP_BUY, 250),        // �����̳���Ʒ
MSGTYPE_DECLARE(MSG_GOODS_SHOP_BUY_MULTI),              // �̳ǹ�����Ʒ
MSGTYPE_DECLARE(MSG_GOODS_SHOP_LARGESS),                // �̳�������Ʒ
MSGTYPE_DECLARE(MSG_GOODS_SHOP_LARGESS_MULTI),          // �̳�������Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_SCENE_SHOP_BUY),            // ������Ϸ�ҹ������
MSGTYPE_DECLARE(MSG_REQUEST_CLIP_BUY),                  // �����򵯼е���
MSGTYPE_DECLARE(MSG_REQUEST_STORE_MERCHANDISE),         // ������̵�(����ˢ��)
MSGTYPE_DECLARE(MSG_REQUEST_REFRESH_STORE),             // ��������ˢ���̵�
MSGTYPE_DECLARE(MSG_REQUEST_STORE_PURCHASE),            // �������̵���Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_BUY_MYSTICAL_SHOP_GOODS),   // �����������̵���Ʒ
MSGTYPE_DECLARE(MSG_REQUEST_STORE_ENABLE),              // ����ͨ�̵����Ȩ��

// �ʼ����
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_MAIL_SEND, 270),     // �������ʼ�
MSGTYPE_DECLARE(MSG_REQUEST_MAIL_OPERATE),              // �����ʼ�����
MSGTYPE_DECLARE(MSG_REQUEST_PICKUP_MAIL_ITEM),          // ������ȡ�ʼ���Ʒ

// ����ɾ����
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_COMPLETE_QUEST, 280),// �������������ȡ������
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_UI),                   // ����򿪽���
MSGTYPE_DECLARE(MSG_REQUEST_SHARE_ENJOYMENT),           // �������
MSGTYPE_DECLARE(MSG_REQUEST_SET_DESKTOP),               // �ղ�����
MSGTYPE_DECLARE(MSG_REQUEST_READ_QUEST),                // �����ȡ������Ϣ��ȫ������ʹ�ã�
MSGTYPE_DECLARE(MSG_REQUEST_SWITCH_QUEST),              // �����л�����
MSGTYPE_DECLARE(MSG_REQUEST_LIKE_US),                   // ��
MSGTYPE_DECLARE(MSG_REQUEST_GET_ITEM_QUEST),            // ��������Ʒ����

// �ͻ�������ĵ��˸��������Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_PVE_SELECT_SCENE, 300),      // ����ѡ��ʼĳ���½��ڵĹؿ�
MSGTYPE_DECLARE(MSG_PVE_REQUEST_REFRESH_REWARD),        // ����ˢ��PVE�����Ľ�����Ϣ
MSGTYPE_DECLARE(MSG_PVE_REQUEST_GATHER_REWARD),         // �����ջ�ĳ��PVE�����Ĳ���
MSGTYPE_DECLARE(MSG_PVE_REQUEST_SMASH_EGG),             // �����ջ��½ڵĲʵ�
MSGTYPE_DECLARE(MSG_PVE_REQUEST_TUTOR_MAP),             // ����μӶ�Ӧ��ѵ���ؿ�
MSGTYPE_DECLARE(MSG_PVE_REQUEST_TANK_TRIAL_MAP),        // ����ѡ��̹�˿�ʼ���渱��
MSGTYPE_DECLARE(MSG_REQUEST_RESET_MAP_ENTER_COUNT),     // �������ø����������
MSGTYPE_DECLARE(MSG_SOLO_REQUEST_SWEEP_MAP),            // �����ͼɨ��
MSGTYPE_DECLARE(MSG_REQUEST_SOLO_PVE_INFO),             // ���󸱱���Ϣ


// ���������Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_LEARN_GUILD_SKILL, 320), //��ɫ����ѧϰ���ż���
MSGTYPE_DECLARE(MSG_REQUEST_UNLOCK_SKILL_SLOT),             ///< ��ɫ����������ż��ܸ�
MSGTYPE_DECLARE(MSG_REQUEST_SET_GUILD_SKILL),               ///< �����趨��ɫ���ż���
MSGTYPE_DECLARE(MSG_REQUEST_START_GUILD_BOSS),              ///< ����μӾ���BOSSս��
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GUILD_BOSS_AWARD),         ///< ������ȡ����BOSS����

// ָ�ӹټ���
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_SET_COMMANDER_SKILL, 340),   ///< �����趨ָ�ӹټ���

// ����
MSGTYPE_DECLARE_ASSIGN(MSG_ACTIVITY_ENTER_BOSS, 350),       ///< ����μ�����boss�
MSGTYPE_DECLARE(MSG_REQUEST_PRESENT_VALENTINE_FLAUNT),      ///< ������Ϧ�ͻ�
MSGTYPE_DECLARE(MSG_REQUEST_RAND_STEP_SUPPORT),             ///< ����ᱦ���е���
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_STAGE_WEEK_FIZZ_AWARD),    ///< ������ȡ�׶��ܻ�Ծ����
MSGTYPE_DECLARE(MSG_OPEN_FUNC_NOTIFY_UI),                   ///< ֪ͨ�򿪹���֪ͨ����
MSGTYPE_DECLARE(MSG_CLOSE_FUNC_NOTIFY_UI),                  ///< ֪ͨ�رչ���֪ͨ����
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMP_INFO),             ///< �����ɫ���־�������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMP_RANK_AWARD),       ///< ������ȡ������ս��ÿ�����н���
MSGTYPE_DECLARE(MSG_REQUEST_CLR_BST_COMP_COOL_TIME),        ///< �������������ս����ȴʱ��
MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_BATTLE),                ///< ����������ֶ�ս
MSGTYPE_DECLARE(MSG_REQUEST_SIGN_IN),                       ///< ����ǩ��
MSGTYPE_DECLARE(MSG_REQUEST_STAGE_SIGN_IN_AWARD),           ///< �����ۼ�ǩ������
MSGTYPE_DECLARE(MSG_REQUEST_VIP_DOUBLE_AWARD),          // �����ȡvip˫��������һ�ݽ���
MSGTYPE_DECLARE(MSG_REQ_SERVER_LOGIN_CONFIG),           // �������˵�½������
MSGTYPE_DECLARE(MSG_REQUEST_SEND_REDPACKET),        						// ���󷢺��
MSGTYPE_DECLARE(MSG_REQUEST_ROB_REDPACKET),                     // ���������
MSGTYPE_DECLARE(MSG_REQUEST_REDPACKET_LOG),                     // ����鿴�����ʷ��¼
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_CHEST),                     		// ���󿪱���
MSGTYPE_DECLARE(MSG_REQUEST_CLOUD_PURCHASE_BUY),     						// �����ƹ�����
MSGTYPE_DECLARE(MSG_REQUEST_GET_CLOUD_PURCHASE_BUY_INFO),        // �����ȡ�ƹ�������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_BIND_INVITE_SPREAD_PLAYER),  					// ����������ƹ����
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_BIND_INVITE_SPREAD_AWARD),        	// ������ȡ����BOSS����
MSGTYPE_DECLARE(MSG_REQUEST_RAND_STEP),     						// ����ð�նᱦ
MSGTYPE_DECLARE(MSG_REQUEST_BUY_FUND),     					// ������ɳ�����
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_FUND),             // ������ȡ����
MSGTYPE_DECLARE(MSG_REQUEST_MAKE_TANK),     				// ��������̹��
MSGTYPE_DECLARE(MSG_REQUEST_EXPEDITION),               			// ����Զ��
MSGTYPE_DECLARE(MSG_REQUEST_CANCEL_EXPEDITION),             // ����ȡ��Զ��
MSGTYPE_DECLARE(MSG_REQUEST_GET_EXPEDITION_AWARD),          // ����Զ����ȡ����
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_INVITE_GIFT_AWARD),            // ������ȡ���������
MSGTYPE_DECLARE(MSG_REQUEST_NEW_SIGN_IN),       				// �����°�ǩ��
MSGTYPE_DECLARE(MSG_REQUEST_NEW_STAGE_SIGN_IN_AWARD),       // �����°��ۼ�ǩ������

// ��ɫ�罻���
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_ELIMINATE_REL, 400),     ///< ��������ϵ
MSGTYPE_DECLARE(MSG_REQUEST_ESTABLISH_REL),                 ///< �������罻��ϵ
MSGTYPE_DECLARE(MSG_REQUEST_QQ_GIFT_OP),                    ///< ����qq�����������
MSGTYPE_DECLARE(MSG_REQUEST_SET_INVITER_ACCTID),            ///< ������д�������˺�id
//���������Լ�ʦͽϵͳ���
MSGTYPE_DECLARE(MSG_CHAR_GUIDE_UPDATE),						// ���½�ɫ������������Ľ���
MSGTYPE_DECLARE(MSG_REQUEST_SOCIAL_TICKET),				// ������ʱʦͽ��������
MSGTYPE_DECLARE(MSG_CONFIRM_SOCIAL_TICKET),				// ȷ��ʹ����ʱʦͽ��������
MSGTYPE_DECLARE(MSG_REQUEST_SOCIAL_AWARD),				// ��ȡ��ʱʦͽ�Ľ���


//�������
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_ADD_TALENT_PAGE, 420),   		// ��������츳ҳ
MSGTYPE_DECLARE(MSG_REQUEST_SAVE_TALENT_PAGE),              		// ���󱣴��츳ҳ
MSGTYPE_DECLARE(MSG_REQUEST_OP_TALENT_PAGE),                		// �����츳ҳ����
MSGTYPE_DECLARE(MSG_REQUEST_CRYSTAL_SCHEME_INFO),    						// �����ȡ��Ƭ�����Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_SAVE_CRYSTAL_SCHEME_INFO),           // ���󱣴澧Ƭ�����Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_CRYSTAL_SCHEME_NAME),         // ����ı侧Ƭ��Ϸ�����
MSGTYPE_DECLARE(MSG_REQUEST_UPGRADE_CRYSTAL),                    // �������׾�Ƭ
MSGTYPE_DECLARE(MSG_REQUEST_SET_CUR_CRYSTAL_SCHEME_ID),          // �������õ�ǰ��Ƭ����ID
MSGTYPE_DECLARE(MSG_REQUEST_LEVELUP_YCARD),     								// ����Ӷ��������
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_HONOR),											//< �����������




//////////////////////////////////////////////////////////////////////////
// �����������������Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_CHAT_MESSAGE, 450),          //������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_QUESTION),                  //�������
MSGTYPE_DECLARE(MSG_QUESTION_CLOSED),                   //��ҹر�����
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_QUESTION),             //��Ҵ����ⷴ������
MSGTYPE_DECLARE(MSG_CHAT_TEST_PING),                  	//�������Э��

//////////////////////////////////////////////////////////////////////////
// -----------------------------------------------------------------------/
/* client -> server, report to server                                     */
/* ��Ҫgateת������Ϣ                                                      */
// --------------------------------------------------------------------��--/
MSGTYPE_DECLARE_ASSIGN(MSG_NEED_GATE_TRANSFER, 500),
// ��Ҫת����GAME����Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_MOVE_FORWARD),          // �ƶ�
MSGTYPE_DECLARE(MSG_REQUEST_STOP_MOVE),             // ֹͣ�ƶ�
MSGTYPE_DECLARE(MSG_REQUEST_VALIDATE_POS),
MSGTYPE_DECLARE(MSG_REQUEST_USE_SKILL),             // ����ʹ�ü���
MSGTYPE_DECLARE(MSG_REQUEST_TANK_RELIVE),           // ����̹�˸���
MSGTYPE_DECLARE(MSG_REQUEST_STAT_LIST),             // �ͻ�������̹�˼���ͳ���б�
MSGTYPE_DECLARE(MSG_REQUEST_BUY_LIFE),              // �ͻ����������
MSGTYPE_DECLARE(MSG_REQUEST_OP_SPRAY),              // ������ͼ
MSGTYPE_DECLARE(MSG_REQUEST_TRY_BOOSTER),           // ��������С����
MSGTYPE_DECLARE(MSG_REQUEST_EXIT_BATTLE),           // �ͻ��������˳�ս��
MSGTYPE_DECLARE(MSG_REQUEST_AUTO_BULLET),           // ��������ָ�뷽���Զ��ͷ�һ���ӵ�
MSGTYPE_DECLARE(MSG_REQUEST_SIGNAL_INFO),           // �ͻ��������źŻ���
MSGTYPE_DECLARE(MSG_REQUEST_SURRENDER_VOTATION),    // ������Ͷ�����
MSGTYPE_DECLARE(MSG_SET_SURRENDER_DECISION),        // ��������Լ���Ͷ����Ϣ
MSGTYPE_DECLARE(MSG_ROUTE_TO_GAME_END),             // ����GAME����Ϣ����

//////////////////////////////////////////////////////////////////////////
// ��Ҫת����TRACK����Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_TRACK, 550),
MSGTYPE_DECLARE(MSG_REQUEST_OPEN_TURNUP),           // ������
MSGTYPE_DECLARE(MSG_REQUEST_ENTER_BATTLE),          // �ͻ������ݼ�������������ս��
MSGTYPE_DECLARE(MSG_IMPEACH_BAD_PLAYER),            // �ٱ����
MSGTYPE_DECLARE(MSG_REQUEST_RLTE_AWARD_LIST),       // �������̶ĵĽ��ڻ��б�
MSGTYPE_DECLARE(MSG_REQUEST_SERVER_CHARGE_INFO),    // ����ÿ�ճ�ֵ��Ϣ
MSGTYPE_DECLARE(MSG_ACTIVITY_BOSS_OPEN_UI),         // ������boss�UI
MSGTYPE_DECLARE(MSG_ACTIVITY_BOSS_CLOSE_UI),        // �ر�����boss�UI
MSGTYPE_DECLARE(MSG_REQUEST_PVE_RECORD),                // ����PVEͨ�ؼ�¼��Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_SET_BATTLE_MODE),       // ��������ƥ��ģʽ
MSGTYPE_DECLARE(MSG_REQUEST_SVR_AWARD_LIST),       // ����svr_award�Ľ��ڻ��б�

// ���������Ϣ
MSGTYPE_DECLARE(MSG_SELECT_MATCH_RACE),                 // ս��ѡ���ս����
MSGTYPE_DECLARE(MSG_REQUEST_CHALLENGE_LIST),            // ����Լս�б�
MSGTYPE_DECLARE(MSG_REQUEST_CHALLENGE_TEAM),            // ����Լս
MSGTYPE_DECLARE(MSG_REQUEST_TEAM_MATCH_START),          // ����ʼս����λ��
MSGTYPE_DECLARE(MSG_LEAGUE_START_PAIR),                 // ����ʼ����ƥ��
MSGTYPE_DECLARE(MSG_LEAGUE_STOP_PAIR),                  // ����ֹͣ����ƥ��
MSGTYPE_DECLARE(MSG_TEAM_MATCH_START_PAIR),             // ����ʼս����ƥ��
MSGTYPE_DECLARE(MSG_TEAM_MATCH_STOP_PAIR),              // ����ֹͣս����ƥ��
MSGTYPE_DECLARE(MSG_REQUEST_LEAGUE_TEAM_QUIZ),          // ����Ѻע����������
MSGTYPE_DECLARE(MSG_REQUEST_DECIDE_MATCH_WINNER),       // �����趨�������������

// ���������
MSGTYPE_DECLARE(MSG_GUILD_MATCH_START_PAIR),            // ����ʼ������ƥ��
MSGTYPE_DECLARE(MSG_GUILD_MATCH_STOP_PAIR),             // ����ֹͣ������ƥ��

// ������ս�����
MSGTYPE_DECLARE(MSG_REQUEST_CLEAR_BOOSTER_COOL_TIME),    ///< �������������ս����ȴʱ��
MSGTYPE_DECLARE(MSG_REQUEST_BUY_BST_ENTER),              ///< �������������������


// �������Э��
MSGTYPE_DECLARE_ASSIGN(MSG_REQUEST_CREATE_ROOM, 600),   // ��������
MSGTYPE_DECLARE(MSG_REQUEST_JOIN_ROOM),                 // ���뷿��
MSGTYPE_DECLARE(MSG_REQUEST_ROOM_OP),                   // �ͻ������󷿼����
MSGTYPE_DECLARE(MSG_SET_ROOM_MAP),                      // �д�ģʽ����ѡ���ͼ
MSGTYPE_DECLARE(MSG_REQUEST_PLAYER_LIST),               // �ͻ�����������б�
MSGTYPE_DECLARE(MSG_SYNC_LOAD_DELAY),                   // ͬ���ͻ��˼��ؽ��Ⱥ������ӳ�
MSGTYPE_DECLARE(MSG_REQUEST_CHAR_STATE),                // �ͻ��˲�ѯ���״̬
MSGTYPE_DECLARE(MSG_REQUEST_IN_HALL),                   // ֪ͨ������Ϸ����
MSGTYPE_DECLARE(MSG_REQUEST_OUT_HALL),                  // ֪ͨ�뿪��Ϸ����
MSGTYPE_DECLARE(MSG_REJECT_ROOM_INVITE),                // �ܾ���������
MSGTYPE_DECLARE(MSG_REQUEST_START_MATCH),               // ����ʼ
MSGTYPE_DECLARE(MSG_REQUEST_STOP_MATCH),                // ����ֹͣ�����
MSGTYPE_DECLARE(MSG_REQUEST_LOOK_SCENE),                // ͨ��ս��id�����ս
MSGTYPE_DECLARE(MSG_REQUEST_EXIT_BATTLEEND),            // �����˳�ս������
MSGTYPE_DECLARE(MSG_REQUEST_LOCK_TANK),                 // ѡ̹�˽׶��������̹��
MSGTYPE_DECLARE(MSG_REQUEST_LOOK_ROOM),                 // ���뷿���ս
MSGTYPE_DECLARE(MSG_REQUEST_OTHER_GUILD_MATCH_ROOM_INFO), // �������������������������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_SWITCH_GUILD_ROOM),         // �����л�����������

MSGTYPE_DECLARE(MSG_ROUTE_TO_TRACK_END),                // ����TRACK����Ϣ����
//////////////////////////////////////////////////////////////////////////
// ��Ҫת����guild����Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_GUILD, 650),
// ս�����Э��
MSGTYPE_DECLARE(MSG_REQUEST_JOIN_GUILD),                // ����������
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_INVITE),              // ���;�������
MSGTYPE_DECLARE(MSG_REQUEST_LEAVE_GUILD),               // �����뿪����
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_KICKOUT),             // �����߳�����
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_POST),               // �������ְ��
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_OP),                  // ������Ų���
MSGTYPE_DECLARE(MSG_REQUEST_JOIN_GUILD_APPLY),          // �����ͼ����������
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_APPLY_LIST),          // ������������б�
MSGTYPE_DECLARE(MSG_REQUEST_APPROVE_APPLY),             // ����ͬ��ս������
MSGTYPE_DECLARE(MSG_REQUEST_REJECT_APPLY),              // ����ܾ�ս������
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_UPGRADE),             // �����������
MSGTYPE_DECLARE(MSG_REQUEST_SET_CHANNEL),               // ��������YYƵ����
MSGTYPE_DECLARE(MSG_REQUEST_SET_NOTICE),                // �������ù���
MSGTYPE_DECLARE(MSG_REQUEST_SET_RECRUIT_NOTICE),        // ����������ļ����
MSGTYPE_DECLARE(MSG_REQUEST_TEAM_MEMBER),               // ����ˢ�³�Ա��Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_DELETE_TEAM),               // �����ɢս��
MSGTYPE_DECLARE(MSG_REQUEST_IN_GUILD_UI),               // ���������Ž���
MSGTYPE_DECLARE(MSG_REQUEST_OUT_GUILD_UI),              // �����뿪���Ž���
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_MOVE_MEMBER),         // ������Ա�ƶ�
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_INVITE_MEMBER),       // ����������Ա
MSGTYPE_DECLARE(MSG_REQUEST_ACCEPT_CHANGE_TEAM),        // ����ת������
MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_TEAM_PVE_FLAG),      // ���������߹ر�ս�Ӹ���
MSGTYPE_DECLARE(MSG_REQUEST_RESEARCH_GUILD_SKILL),      // ������о��ż��ܵ��о�
MSGTYPE_DECLARE(MSG_LEAGUE_REQUEST_ENROLL),             // ��������ĳ������
MSGTYPE_DECLARE(MSG_LEAGUE_REQUEST_AWARD),              // ������ȡĳ���׶εĽ���

MSGTYPE_DECLARE(MSG_ROUTE_TO_GUILD_END),                // ����guild����Ϣ����
//////////////////////////////////////////////////////////////////////////
// ��Ҫת����buddy����Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_BUDDY, 700),
MSGTYPE_DECLARE(MSG_RELATION_REQUEST_ADD),              // ��������ϵ
MSGTYPE_DECLARE(MSG_RELATION_REQUEST_DELETE),           // �����Ƴ���ϵ
MSGTYPE_DECLARE(MSG_REQUEST_BUDDY_BRIEF),               // ��������brief��Ϣ
MSGTYPE_DECLARE(MSG_SEND_SNS_REQUEST_KEY),              // ����sns������key
MSGTYPE_DECLARE(MSG_REQUEST_FACEBOOK_INVITE),           // ��������facebook����
MSGTYPE_DECLARE(MSG_ACCEPT_FACEBOOK_INVITE),            // ����facebook���������Ϸ
MSGTYPE_DECLARE(MSG_REQUEST_QUICK_ADD_FRIEND),          // �������������
//ʦͽ���Э��
MSGTYPE_DECLARE(MSG_REQUEST_MP_SQUARE_LIST),            // ����㳡�б�
MSGTYPE_DECLARE(MSG_REQUEST_APPLY_MP_RELATION),         // ���뽨��ʦͽ��ϵ
MSGTYPE_DECLARE(MSG_APPROVE_MP_RELATION_APPLY),         // ͬ��ʦͽ����
MSGTYPE_DECLARE(MSG_REJECT_MP_RELATION_APPLY),          // �ܾ�ʦͽ����
MSGTYPE_DECLARE(MSG_REQUEST_DELETE_SOCIAL_REL),         // �������罻��ϵ
MSGTYPE_DECLARE(MSG_REQUEST_MASTER_PRENTICE_AWARD),     // ������ȡʦͽ������
MSGTYPE_DECLARE(MSG_REQUEST_GRADUATE),                  // �����ʦ
MSGTYPE_DECLARE(MSG_REQUEST_CLEAR_MP_APPLY_LIST),       // �������ʦͽ�����б�
MSGTYPE_DECLARE(MSG_REQUEST_MP_APPLY_LIST),              // ����ʦͽ�����б�
MSGTYPE_DECLARE(MSG_REQUEST_ROOM_INVITE),               // ���ͷ�������
MSGTYPE_DECLARE(MSG_REQUEST_INVITE_GIFT_PLAYER_INVITE),  // ������������������
MSGTYPE_DECLARE(MSG_RESPONSE_INVITE_GIFT_PLAYER_INVITE), // �ظ���������������
MSGTYPE_DECLARE(MSG_REQUEST_REMOVE_INVITE_GIFT_PLAYER),  // ���������������ҹ�ϵ

MSGTYPE_DECLARE(MSG_ROUTE_TO_BUDDY_END),                // ����buddy����Ϣ����

//////////////////////////////////////////////////////////////////////////
// ��Ҫת����activity����Ϣ
MSGTYPE_DECLARE_ASSIGN(MSG_ROUTE_TO_ACTIVITY,750),
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_ONLINE_PEAK_AWARD),     ///< ������ȡ���߷�ֵ�����
MSGTYPE_DECLARE(MSG_REQUEST_RAND_STEP_SUPPORT_INFO),     ///< ����ᱦ���е�����Ϣ

MSGTYPE_DECLARE(MSG_ROUTE_TO_ACTIVITY_END),                // ����activity����Ϣ����
MSGTYPE_DECLARE(MSG_CLIENT_END),

//--------------------------------------------------------------------------------------------------------
//��ع������
//--------------------------------------------------------------------------------------------------------
MSGTYPE_DECLARE_ASSIGN(MSG_SVR_MONITOR_START, 800),         // ������״̬������Э��
MSGTYPE_DECLARE(MSG_MONITOR_COMMAND),                       // ����ʹ�ã��������㱨ͳ������
MSGTYPE_DECLARE(MSG_RUN_ROMOTE_COMMAND),                    // Զ�����з�����ָ������
MSGTYPE_DECLARE(MSG_COMMAND_RESULT),                        // Զ�����з�����ָ����
MSGTYPE_DECLARE(MSG_ADMIN_REGISTER),                        // ������ע�ᵽ��غ��
MSGTYPE_DECLARE(MSG_ADMIN_RESPONSE),                        // ��غ��ע����

MSGTYPE_DECLARE(MSG_MANAGE_AUTH_REQUEST),                   // ������Ϣ����֤����
MSGTYPE_DECLARE(MSG_MANAGE_AUTH_RESULT),                    // ������Ϣ����֤���
MSGTYPE_DECLARE(MSG_MANAGE_REQUEST_OBJECT),                 // ������Ϣ����ȡ�������͵Ķ�����Ϣ
MSGTYPE_DECLARE(MSG_MANAGE_GROUPLIST),                      // ������Ϣ�����������б�
MSGTYPE_DECLARE(MSG_MANAGE_GROUPINFO),                      // ������Ϣ������������Ϣ
MSGTYPE_DECLARE(MSG_MANAGE_PROCLIST),                       // ������Ϣ������NODE�б�
MSGTYPE_DECLARE(MSG_MANAGE_PROCINFO),                       // ������Ϣ������NODE��Ϣ
MSGTYPE_DECLARE(MSG_MANAGE_REALMINFO),                      // ������Ϣ������ĳ����AC�е��ʺŵ���ϸ��Ϣ
MSGTYPE_DECLARE(MSG_MANAGE_CONTROLCMD),                     // ������Ϣ����������
MSGTYPE_DECLARE(MSG_MANAGE_ACCMDRESULT),                    // ������Ϣ�������������
MSGTYPE_DECLARE(MSG_NOTIFY_SVR_STARTUP_OK),                 // ֪ͨ���������, �����������ɹ�
MSGTYPE_DECLARE(MSG_ADMIN_REQUEST_LOGIN),                   // �������������汾��֤
MSGTYPE_DECLARE(MSG_ADMIN_LOGIN_RESULT),                    // ���ص�½������

/*#######################################################################
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_SERVER_START, 899),            //�����Э���ID��
// ----------------------------------------------------------------------/
/* ����֤���������ص���Ϣ LOGINSVR -> CLIENT                             */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_AUTH_SVR_START, 900),
MSGTYPE_DECLARE(MSG_AUTH_LOGIN_OK),                     //��֤ǰ��->�ͻ��ˣ�������֤�ɹ�
MSGTYPE_DECLARE(MSG_AUTH_LOGIN_FAIL),                   //��֤ǰ��->�ͻ��ˣ�������֤����
MSGTYPE_DECLARE(MSG_AUTH_VESION_OK),                    //��֤ǰ��->�ͻ��ˣ�Э��汾��ȷ
MSGTYPE_DECLARE(MSG_AUTH_VESION_FAILED),                //��֤ǰ��->�ͻ��ˣ�Э��汾����

MSGTYPE_DECLARE(MSG_AUTH_PLAY_FAIL),                    //��֤ǰ��->�ͻ��ˣ���¼����ʧ��
MSGTYPE_DECLARE(MSG_AUTH_SERVER_LIST),                  //��֤ǰ��->�ͻ��ˣ��������б�

MSGTYPE_DECLARE(MSG_AUTH_SESSION_REQUESTCONFIRM),       //��֤ǰ��->�ͻ��ˣ�Session��ʼ
MSGTYPE_DECLARE(MSG_AUTH_SESSION_REQUESTREJECT),        //��֤ǰ��->�ͻ��ˣ�Session��ʼ���ܾ�
MSGTYPE_DECLARE(MSG_AUTH_SESSION_CLOSECONFIRM),         //��֤ǰ��->�ͻ��ˣ�Session����
MSGTYPE_DECLARE(MSG_AUTH_SESSION_CLOSEREJECT),          //��֤ǰ��->�ͻ��ˣ�Session�������ܾ�

MSGTYPE_DECLARE(MSG_AUTH_SWITCH_LINE_RESULT),           //֪ͨ�л����߽��

// ----------------------------------------------------------------------/
/* ����GATESVR���������͵���ϢЭ�� GATESVR -> CLIENT                      */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_GATE_SVR_START, 1000),
MSGTYPE_DECLARE(MSG_AUTH_SESSION_INTERRUPTED),          //����->�ͻ��ˣ�Session���ж�
MSGTYPE_DECLARE(MSG_GATE_SYSTEM_HEARTBEAT),             //������Ϣ
MSGTYPE_DECLARE(MSG_GATE_NOTIFY_PING),                  // GATESVR����pingֵ
MSGTYPE_DECLARE(MSG_WORLD_LOGOUT_NOTIFY),               // ֪ͨ�ͻ�������ȡ
MSGTYPE_DECLARE(MSG_WORLD_ENTER_CONFIRM),               // ��ɫȷ�Ͻ�����Ϸ����
MSGTYPE_DECLARE(MSG_WORLD_ENTER_REJECTED),              // ��ɫ������Ϸ���类�ܾ�
MSGTYPE_DECLARE(MSG_WORLD_LOGOUT_CONFIRM),              // ��ɫ�˳���Ϸ����ȷ��
MSGTYPE_DECLARE(MSG_CHAR_PICKAPPROVED),                 // ѡ����ɫ����ɹ�
MSGTYPE_DECLARE(MSG_CHAR_PICKREJECTED),                 // ѡ����ɫ���ܾ�
MSGTYPE_DECLARE(MSG_SERVER_LOGOUT_CONFIRMED),             // GATE�˳�ȷ��

//��ɫ���
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_CREATE),                //��ɫ�����ڣ�֪ͨ�����½�ɫ
MSGTYPE_DECLARE(MSG_CHARCREATE_APPROVED),               //��ɫ�����ɹ�
MSGTYPE_DECLARE(MSG_CHARCREATE_REJECTED),               //��ɫ����ʧ��
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_LIST),                  // ֪ͨ��ɫ�б�
MSGTYPE_DECLARE(MSG_CHAR_NAME_UNIQUE_RESULT),           // ֪ͨ����Ψһ����֤�Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_DATA),                  // ���ؽ�ɫ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_BACK_TO_MAIN),               /// ֪ͨ�ͻ����˻�������
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_AWARD_RESULT),          /// ֪ͨ������ȡ���
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_LEVEL),                  // ֪ͨ����
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_EXP),                   // ���½�ɫ����
MSGTYPE_DECLARE(MSG_NOTIFY_OPTION_TIME),                // ���½�ɫ����ʱ���
MSGTYPE_DECLARE(MSG_NOTIFY_USE_SPRAY),                  // ֪ͨ������ͼ�ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_USE_AVATAR),                 // ֪ͨʹ��avatar
MSGTYPE_DECLARE(MSG_NOTIFY_FIZZ),                       // ֪ͨ��Ծ��
MSGTYPE_DECLARE(MSG_NOTIFY_DYNAMIC_CONFIG),             // ֪ͨ��̬������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_RENAME_RET),                 // ֪ͨ�����Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_THEW),                       // ֪ͨ��Ծ��
MSGTYPE_DECLARE(MSG_NOTIFY_HONOR),                      // ֪ͨ���ѡ��������
MSGTYPE_DECLARE(MSG_NOTIFY_HONOR_LIST),                 // ֪ͨ�����б�
MSGTYPE_DECLARE(MSG_NOTIFY_ROULETTE_COUNT),             // ֪ͨת���̵�����
MSGTYPE_DECLARE(MSG_NOTIFY_FIRST_CHARGE),               // ֪ͨ�Ƿ��Ѿ������׳�
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_GIFT_TIME),            // ֪ͨ��ȡ������������ʱ��
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_PROTECT_PWD),           // ֪ͨ��ɫ2���ܱ���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_PROTECT_PWD_OP_RESULT),      // ֪ͨ2���ܱ��������
MSGTYPE_DECLARE(MSG_NOTIFY_NEED_CHECK_PROTECT_PWD),     // ֪ͨ�ͻ�����Ҫ��֤2���ܱ�
MSGTYPE_DECLARE(MSG_NOTIFY_SYNC_SETTING),               // ֪ͨͬ��ϵͳ����
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_GROCERY_ADD),         // ֪ͨ�ӻ������������
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_GIFT_RESULT),           // ֪ͨ�����ȡ���
MSGTYPE_DECLARE(MSG_CHAR_CURRENCYACTION),               // Server->Client ֪ͨ��ɫ���Ҳ����Լ�������
MSGTYPE_DECLARE(MSG_CHAR_CURRENCY_NOTIFY_RMB_RATE),     // ֪ͨrmb�����Լ�����
MSGTYPE_DECLARE(MSG_BUY_GOODS_OK_NOTIFY),               // ֪ͨ�̳ǹ���ɹ�
MSGTYPE_DECLARE(MSG_BUY_GOODS_REJECT),                  // �ܾ�������Ʒ
MSGTYPE_DECLARE(MSG_CHARGE_DONE),						// ֪ͨ��ֵ����
MSGTYPE_DECLARE(MSG_CHAR_GUIDE_PROGRESS),				// ֪ͨ��ɫ���������ĵ�ǰ����
MSGTYPE_DECLARE(MSG_NOTIFY_LIMIT_INFO),				    // ֪ͨ��ʼ��������������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_GIFT),                  // ֪ͨ��������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_OPTION),                // ֪ͨ��ɫ�ͻ���ϵͳ����
MSGTYPE_DECLARE(MSG_NOTIFY_OBSERVER_PLAYER_GATE),       // ֪ͨ�������Gate��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_VIP_CHANGE),    							// ֪ͨVIP�仯��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_QQ_VIP),                     // ֪ͨqq����������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SHOW_QQ_BLUE_VIP_RENEW),     // ֪ͨ��ʾ��������ͼ��
MSGTYPE_DECLARE(MSG_NOTIFY_SUPER_VIP_CHARGE_INFO),      // ֪ͨ����VIP��ֵ��¼��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_SUPER_VIP_CHARGE_BACK), // ֪ͨ����VIP��ֵ��¼��Ϣ
MSGTYPE_DECLARE(MSG_APEX_SEND2CLIENT),                  ///< �� gate server ���͸� game client �� Apex ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_RELOAD_TEMPLATE),            ///< ֪ͨ�ͻ������¼���ģ������
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_BOOSTER),             ///< ֪ͨ��ɫ��ս����UUID

// ��Ʒ���
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_ITEM_LIST, 1100),         // ֪ͨ��Ʒ��Ϣ
MSGTYPE_DECLARE(MSG_ITEM_SWAP_OK),                          // ��Ʒ�ƶ��ɹ�
MSGTYPE_DECLARE(MSG_UPDATE_ITEM_INSTANCE),                  // ������Ʒ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_ITEM_DELETE),                  	// ֪ͨɾ����Ʒ
MSGTYPE_DECLARE(MSG_NOTIFY_SETTLE_AWARD),                   // ֪ͨ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TICKET_ITEM_RET),                // ֪ͨʹ����Ʊ�ķ��ؽ��
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_OP_RET),                 // ֪ͨ���ֲ������
MSGTYPE_DECLARE(MSG_NOTIFY_ROULETTE_RET),                   // ֪ͨ���̶ĵĽ��
MSGTYPE_DECLARE(MSG_NOTIFY_STORE_MERCHANDISE),              // �̵���Ʒ��Ϣ
MSGTYPE_DECLARE(MSG_CONFIRM_STORE_PURCHASE),                // ȷ����Ʒ����ĳɹ�ȷ��
MSGTYPE_DECLARE(MSG_NOTIFY_QQ_BUY_GOODS),                   // ֪ͨqq�̳ǹ���
MSGTYPE_DECLARE(MSG_NOTIFY_STORE_BRIEF),                    // ֪ͨ�̵��Ҫ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_STORE_ENABLE_SUCCEED),           // ֪ͨ�̵꿪���ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_CLIENT_USE_ITEM_FAILED),         // ֪ͨ�ͻ���ʹ����Ʒʧ��

// ս����̹�����
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_TANK_LIST, 1150),             // ֪̹ͨ����Ϣ
MSGTYPE_DECLARE(MSG_UPDATE_TANK_INSTANCE),                      // ����̹����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_DELETE),                        // ֪ͨɾ��̹��
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_OP_FAIL),                       // ֪̹ͨ�˲���ʧ�ܣ���������ʧ�ܣ����ʳɹ���ʧ�ܣ�
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_TRY),                           // ֪ͨ����̹��(����)
MSGTYPE_DECLARE(MSG_TANK_SKILL_UPGRADE_OK),                     // ֪ͨ�ͷ���̹�˼��������ɹ�
MSGTYPE_DECLARE(MSG_TANK_SKILL_UPGRADE_FAIL),                   // ֪ͨ�ͻ���̹�˼�������ʧ��
MSGTYPE_DECLARE(MSG_NOTIFY_REFRESH_HIRE_TANK_CONFIG),           // ֪ͨ�ͻ��˸���̹����������
MSGTYPE_DECLARE(MSG_NOTIFY_RECEIVE_PRESENT_HIRE_TANK),          // ֪ͨ�ͻ��˻������������͵�����̹��
MSGTYPE_DECLARE(MSG_NOTIFY_PRESENT_HIRE_TANK_OK),               // ֪ͨ�ͻ��������������̹�˳ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_USE_TANK_HALO_RESULT),               // ֪ͨʹ��̹�˹⻷�Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_HALO_INFO),                     // ֪̹ͨ�˹⻷���ڻ��߻�õ���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_REPEAT_GIVE_TANK),                   // ֪ͨ�ͻ����ظ����̹��
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_SKIN_CHIP_INFO),                // ֪̹ͨ��Ƥ����Ƭ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_SKIN_CHIP_RESULT),              // ֪ͨ����̹��Ƥ����Ƭ�Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_GET_TANK_SKIN_RESULT),               // ֪ͨƤ����Ƭ�һ�̹��Ƥ���Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RESEARCH_INFO),                 // ֪̹ͨ���о���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RESEARCH_RESULT),               // ֪ͨ�о����
MSGTYPE_DECLARE(MSG_NOTIFY_RECYCLE_TANK_RESEARCH_RESULT),       // ֪ͨ�һ�̹���о��Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_GET_RESEARCH_TANK_RESULT),           // ֪ͨ��ȡ̹�˵Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_MAKE_TANK_INFO),                     // ֪̹ͨ��������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TANKPART_INFO),                      // ֪̹ͨ�˲�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TANKPART_SCORE),                     // ֪̹ͨ�˲���������
MSGTYPE_DECLARE(MSG_NOTIFY_TREASURE_RECOVERY_RESULT),           // ֪ͨһԪ�ᱦ���ս��


// �ʼ����
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_MAIL_NOREAD_COUNT, 1200),       // ֪ͨ��δ���ʼ�
MSGTYPE_DECLARE(MSG_NOTIFY_MAIL_LIST),       		// ֪ͨ�ʼ��б�
MSGTYPE_DECLARE(MSG_NOTIFY_MAIL_INSIDE_INFO),       // ֪ͨ�ʼ�����ϸ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_MAIL_OP_RET),       		// ֪ͨ�ʼ��������
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_MAIL_INFO),       // ֪ͨ�����ʼ���Ϣ

// ����ɾ����
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_QUEST_LIST, 1250),    // ֪ͨ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_QUEST_INFO),                 // ���µ������������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_DELETE_QUEST),       	    // ɾ��������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_COMPLETE_QUEST),       	    // ֪ͨ�������
MSGTYPE_DECLARE(MSG_NOTIFY_COMPLETE_QUEST_FAIL),       	// ֪ͨ�������ʧ��
MSGTYPE_DECLARE(MSG_NOTIFY_ACEM_INFO),       	        // ���µ����ɾ���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_ACEM_LIST),       	        // ֪ͨ�ɾ���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SWITCH_QUEST),               // ֪ͨ�л�����
MSGTYPE_DECLARE(MSG_NOTIFY_OPEN_UI),           				// ֪ͨ��Ҵ򿪽���

// PVE��ص�
MSGTYPE_DECLARE_ASSIGN(MSG_PVE_CHAPTER_SCENES, 1300), 		// ֪ͨ�ͻ��ˣ�������ҵ��½��б���Ϣ
MSGTYPE_DECLARE(MSG_REJECT_SELECT_SCENE),            		// ֪ͨ�ͻ��ˣ��ܾ���Ҵ�ĳ���ؿ�
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_SCORES),            		// ֪ͨ�ͻ��ˣ�ͨ�����۵ĳɼ�
MSGTYPE_DECLARE(MSG_NOTIFY_CITY_INIT),            	    	// ֪ͨ�ͻ��ˣ����г�ʼֵ
MSGTYPE_DECLARE(MSG_UPDATE_CITY_INFO),            	    	// ֪ͨ�ͻ��ˣ����³�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SOLO_SWEEP_AWARD),                    // ֪ͨ�ͻ��ˣ�ɨ�����
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_REWARD), 					// ֪ͨ�׶��Խ�����ȡ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_REAP_RESULT), 				// ֪ͨ������ȡ���
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_CLEARED), 					// ֪ͨ�����Ѿ�ȫ����ȡ���
MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_PROGRESS), 				// ֪ͨ�׶ν����Ľ���

// �������
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_GUILD_SKIL_SLOT_INFO, 1350),	// ֪ͨ��ɫ���ż��ܲ���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_GUILD_SKILL_INFO),     				//֪ͨ��ɫ�ľ��ż�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_AWARD),   							//֪ͨ����BOSS������Ϣ

// ����
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_SIGN_IN_INFO, 1400),       ///< ֪ͨ��ɫǩ����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_LOGIN_CONFIG),      ///< ֪ͨ��������½������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SEND_REDPACKET_SUCC),       // ֪ͨ������ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_ROB_REDPACKET_SUCC),                     // ֪ͨ������ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_REDPACKET_LOG),                          // ֪ͨ�����ʷ��¼
MSGTYPE_DECLARE(MSG_NOTIFY_OPEN_CHEST),                     // ֪ͨ������ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_CLIENT_FREE_WEEK_TANK),    // ֪ͨ�������̹����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_RECOMMEND_TANK),    										 // ֪ͨ����Ƽ�̹��
MSGTYPE_DECLARE(MSG_NOTIFY_RAND_STEP),     						// ֪ͨ�ᱦ
MSGTYPE_DECLARE(MSG_NOTIFY_EXPEDITION_INFO),                // ֪ͨԶ����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_SPREAD_PLAYER_INFO),   			// ֪ͨ�����ƹ���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_FUND_INFO),     										 // ֪ͨ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_ITEM_CLOUD_PURCHASE_TANK_INFO),     // ֪ͨ�ƹ�̹����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_COMP_INFO),  						///< ֪ͨ������ս����ɫ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_RESULT),           ///< ֪ͨ������ս����ս���
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_HISTORY),					 ///< ֪ͨ��������ʷ��¼
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_COMP_YESTERDAY_AWARD_INFO),///< ֪ͨ���������ս�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_COMP_NOW_AWARD_INFO),		 ///< ֪ͨ���־�����ʵʱ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_NEW_SIGN_IN_INFO),       ///< ֪ͨ�°��ɫǩ����Ϣ

//�������
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_UPDATE_TALENT_PAGE, 1450),  	// ֪ͨ�����츳ҳ
MSGTYPE_DECLARE(MSG_NOTIFY_OP_TALENT_PAGE),              				// ֪ͨ�츳ҳ����
MSGTYPE_DECLARE(MSG_NOTIFY_TALENT_INFO),                					// ֪ͨ�츳��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TALENT_TOTALPOINT),           				// ֪ͨ�츳�ܿ��õ���
MSGTYPE_DECLARE(MSG_NOTIFY_CRYSTAL_SCHEME_INFO),    						// ֪ͨ��Ƭ�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CRYSTAL_SCHEME_NAME),    						 // ֪ͨ��Ƭ����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SAVE_CRYSTAL_SCHEME_INFO_RESULT),     // ֪ͨ��Ƭ��Ƭ����޸���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_CRYSTAL_SCHEME_NAME_RESULT),   // ֪ͨ��Ƭ���޸Ľ��
MSGTYPE_DECLARE(MSG_NOTIFY_CUR_CRYSTAL_SCHEME_ID),   						 // ֪ͨ��ǰ��Ƭ����ID
MSGTYPE_DECLARE(MSG_NOTIFY_UPGRADE_CRYSTAL_RESULT),   					 // ֪ͨ��Ƭ���׽��
MSGTYPE_DECLARE(MSG_NOTIFY_YCARD_INFO),     										 // ֪ͨӶ������Ϣ



// ----------------------------------------------------------------------/
/* ��GATESVRת�����ͻ��˵�Э��  OTHERSVR -> GATESVR -> CLIENT            */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_GATE_TRANSFER_TO_CLIENT, 1500),

//ͨ�õ�ϵͳ��Ϣ
MSGTYPE_DECLARE(MSG_SYSTEM_ERRORMESSAGE),               // ϵͳ������Ϣ
MSGTYPE_DECLARE(MSG_WORLD_DISCONNECTED),                // ��Ϸ�����Ѿ��Ͽ�
MSGTYPE_DECLARE(MSG_WORLD_ENTER_TRACK_CONFIRM),         // tracksvrȷ�ϵ�����Ϸ�ɹ�

MSGTYPE_DECLARE(MSG_GAME_NOTIFY_PING),                  // GameSvr����pingֵ
MSGTYPE_DECLARE(MSG_NOTIFY_HOST_URL),                   // ֪ͨ��������url��ַ

MSGTYPE_DECLARE(MSG_NOTIFY_TURNUP_RESULT),              /// ֪ͨ���ƽ��
MSGTYPE_DECLARE(MSG_NOTIFY_TURNUP_END),                 /// ֪ͨ���ƽ���
MSGTYPE_DECLARE(MSG_NOTIFY_BUDDY_BRIEF),                /// ֪ͨ��ص�brief��Ϣ
MSGTYPE_DECLARE(MSG_UPDATE_BUDDY_BRIEF),                /// ֪ͨ����brief��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_USE_ITEM),                   // ֪ͨʹ����Ʒ
MSGTYPE_DECLARE(MSG_NOTIFY_NOT_TYRO),                   // ֪ͨ����Ѿ�ͨ������
MSGTYPE_DECLARE(MSG_NOTIFY_IMPEACH_RET),                // ֪ͨ��Ҿٱ����
MSGTYPE_DECLARE(MSG_NOTIFY_IMPEACH_CHECK),              // ֪ͨ���ٱ��ˣ���Ҫ��֤
MSGTYPE_DECLARE(MSG_NOTIFY_ACTION_FLAG),                // ֪ͨ��Ϊ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_RLTE_AWARD_LIST),            // ֪ͨ���̶ĵĽ��ڻ��б�
MSGTYPE_DECLARE(MSG_NOTIFY_RENEW_ELO_TIME),             // ֪ͨ�ͻ���elo����ˢ��ʱ���
MSGTYPE_DECLARE(MSG_NOTIFY_PVE_RECORD),                 // ֪ͨ������¼
MSGTYPE_DECLARE(MSG_NOTIFY_PASS_PVE),                   // ֪ͨ����ͨ����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_HERO_ENTER_COUNT),           // ֪ͨ�ͻ���Ӣ�۸������������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_CHARGE_INFO),         // ֪ͨÿ�ճ�ֵ����
MSGTYPE_DECLARE(MSG_NOTIFY_AFK_STATUS),                 // ֪ͨ�һ����״̬
MSGTYPE_DECLARE(MSG_NOTIFY_SET_BATTLE_MODE),            // ֪ͨ����ƥ��ģʽ
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_GOLDEN_POOL_RESULT),    // ֪ͨ��ҳ���ȡ���
MSGTYPE_DECLARE(MSG_NOTIFY_AFK_WARNING),                // ֪ͨ����������¼��ʾ���
MSGTYPE_DECLARE(MSG_NOTIFY_SVR_AWARD_LIST),             // ֪ͨsvr_award���ڻ��б�

// ̹��/ս�����
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_SELF_DATA, 1550),     // ��������̹������
MSGTYPE_DECLARE(MSG_NOTIFY_OTHER_LIST),                 // ���������˵�̹������
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_TANK),                   // ֪ͨ�ͻ�������̹�˽���
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RELIVE),                // ֪̹ͨ�˸���ȴ�ʱ��
MSGTYPE_DECLARE(MSG_NOTIFY_STOP_MOVE),                  // ֹͣ�ƶ�
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_OBJECT),               // ֪ͨս����������
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_OBJECT),                 // ֪ͨ�½���������
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_OBJECT),              // ֪ͨɾ����������
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_BUFF),                   // ֪̹ͨ�˻��buff
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_BUFF),                // ֪̹ͨ��ʧȥbuff
MSGTYPE_DECLARE(MSG_UPDATE_TANK_ATTR),                  // ֪ͨ����̹������
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_STAT),                 // ֪̹ͨ��ս��ͳ������
MSGTYPE_DECLARE(MSG_UPDATE_BULLET_ORBIT),               // ͬ���ڵ��켣
MSGTYPE_DECLARE(MSG_NOTIFY_AIRDROP_PROP),               // ֪ͨ���ֿ�Ͷ��Ʒ
MSGTYPE_DECLARE(MSG_SYNC_SCENE_DATA),                   // ս������ͬ��
MSGTYPE_DECLARE(MSG_SYNC_OCCUPY_DATA),                  // ͬ�������ռ����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_KILL_INFO),                  // ֪ͨ��ɱ��Ϣ
MSGTYPE_DECLARE(MSG_UPDATE_TANK_COIN),                  // ֪ͨ����̹�˽�Ǯ�仯
MSGTYPE_DECLARE(MSG_UPDATE_TANK_STAT_INFO),             // �������¼���ͳ��
MSGTYPE_DECLARE(MSG_NOTIFY_OP_SPRAY),                   // ֪ͨ��ͼ�ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_OVERTIME_START),             // ֪ͨ��ʱ����ʼ
MSGTYPE_DECLARE(MSG_AWARD_NOTIFY_TURNUP_BEGIN),         // ֪ͨ���ƿ�ʼ
MSGTYPE_DECLARE(MSG_SYNC_SKILL_COOLTIME),               // ͬ��������ȴʱ��
MSGTYPE_DECLARE(MSG_UPDATE_SCENE_ONE_STAT),             // ����ս��������ͳ�ƣ�������̹�ˣ�
MSGTYPE_DECLARE(MSG_UPDATE_TANK_SCORE),                 // ����ĳ��̹�˵ĵ÷�
MSGTYPE_DECLARE(MSG_NOTIFY_DROP_ITEM),                  // ֪ͨ������Ʒ
MSGTYPE_DECLARE(MSG_NOTIFY_BUY_LIFE_INFO),              // ֪ͨ������������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_END_ONHAND),                 // ֪ͨս����������
MSGTYPE_DECLARE(MSG_NOTIFY_OBJ_THROW),                  // ֪ͨ����Ͷ��
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_SLOT_SKILL),          // ֪ͨ�л����ܲ۵ļ���
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_TALK),                 // ֪ͨ��ʾս����AINPC�ȣ��Ի�
MSGTYPE_DECLARE(MSG_NOTIFY_BUFF_UPDATE_TIME),           // ֪ͨ�������BUFFʱ��
MSGTYPE_DECLARE(MSG_NOTIFY_TEAMMATE_CD),                // ֪ͨ���Ѵ���CD����������ʱ��
MSGTYPE_DECLARE(MSG_NOTIFY_SKILL_STOP),                 // ֪ͨ�ͻ��˼���ֹͣ
MSGTYPE_DECLARE(MSG_NOTIFY_FORCE_DATA),                 // ֪ͨ�ͻ���ŭ��ֵ
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_EXP),                 // ֪ͨ�ͻ���ս������
MSGTYPE_DECLARE(MSG_NOTIFY_ENTER_BATTLE),               /// ֪ͨ����ս��
MSGTYPE_DECLARE(MSG_NOTIFY_AINPC_WAVE),                 // ֪ͨ�ͻ��ˣ���ɱAINPC�Ĳ���
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_DEAD),                  /// ֪̹ͨ������
MSGTYPE_DECLARE(MSG_SYNC_PORTAL_DATA),                  // ֪ͨ�ͻ��˴�������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_AUTO_BULLET),                //֪ͨ�ͻ��˶����ָ�뷽���Զ��ͷ�һ���ӵ�
MSGTYPE_DECLARE(MSG_NOTIFY_PLAY_YCARD_ANIMATION),       // ֪ͨ����Ӷ������������
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_QUEST_INFO),          // ֪ͨ���ս��������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_QUEST_BULLETIN),      // ֪ͨս�����񹫸�
MSGTYPE_DECLARE(MSG_NOTIFY_SIGNAL_INFO),                // ֪ͨս���ź���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_BATTLE_LEVEL),          // ֪ͨ�ͻ���̹��ս���ȼ�
MSGTYPE_DECLARE(MSG_UPDATE_AINPC_MAXHP),                // ֪ͨ�ͻ��˸���AINPCѪ����
MSGTYPE_DECLARE(MSG_NOTIFY_SHOW_SURRENDER_VOTATION),    // ֪ͨ����Ͷ�����
MSGTYPE_DECLARE(MSG_UPDATE_VOTATION_INFO),              // ֪ͨ����Ͷ�������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SURRENDER_VOTATION_COOL_TIME), // ֪ͨͶ����ȴʱ��

MSGTYPE_DECLARE(MSG_GAME_TO_CLIENT_END),                // ս�����Э��ν�β
// �������
MSGTYPE_DECLARE_ASSIGN(MSG_ENTER_ROOM_OK, 1700),        // �ɹ����뷿�䣬֪ͨ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_OP),                    // ֪ͨ����������
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_ADD),                   // ֪ͨ�ͻ��ˣ����½�ɫ���뷿��
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_LIST),                // ֪ͨ�ͻ��ˣ�����б�
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_MAP),                   // ֪ͨ�д��ͼ
MSGTYPE_DECLARE(MSG_NOTIFY_START_GAME),                 // �ɹ����뷿�䣬��ʼ��Ϸ
MSGTYPE_DECLARE(MSG_NOTIFY_MIDWAY_JOIN),                // ��;��ҽ���
MSGTYPE_DECLARE(MSG_NOTIFY_EXIT_BATTLE),                // ֪ͨ�˳�ս��
MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_END),                 // ֪ͨ�ͻ��ˣ�ս������
MSGTYPE_DECLARE(MSG_NOTIFY_LOADED_RATE),                // ֪ͨ�ͻ��ˣ����ؽ��Ⱥ��ӳ�
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_KILLNUM),               // ֪ͨ�ͻ��ˣ���Ӫ��ɱ����
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_CHAR_CHANGE),           // ֪ͨ�ͻ��ˣ�ͬ�������ڽ�ɫ��Ϣ�����仯
MSGTYPE_DECLARE(MSG_ADD_PLAYER_LIST),                   // ֪ͨ�ͻ��ˣ���Ϸ�����б����
MSGTYPE_DECLARE(MSG_DEL_PLAYER_LIST),                   // ֪ͨ�ͻ��ˣ���Ϸ�����б�ɾ��
MSGTYPE_DECLARE(MSG_UPDATE_PLAYER_LIST),                // ֪ͨ�ͻ��ˣ���Ϸ�����б�ȼ�����
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_INVITE),                // ֪ͨ�ͻ��ˣ���������
MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_STATE),                 // ֪ͨ��ҷ���״̬
MSGTYPE_DECLARE(MSG_NOTIFY_KICKOUT_COUNTDOWN),          // ֪ͨ��ҷ������˵���ʱ
MSGTYPE_DECLARE(MSG_CLEAR_KICKOUT_COUNTDOWN),           // ֪ͨ����������˵���ʱ
MSGTYPE_DECLARE(MSG_NOTIFY_START_MATCH),                // ֪ͨ��ʼ��Ե���ʱ
MSGTYPE_DECLARE(MSG_NOTIFY_STOP_MATCH),                 // ֹ֪ͨͣ��Ե���ʱ
MSGTYPE_DECLARE(MSG_NOTIFY_PAIR_SCENE),                 // ֪ͨ�ͻ��ˣ�֪ͨƥ������ʼ
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_CHANGE_CAMP),          // ֪ͨ�ͻ��ˣ��л���Ӫ
MSGTYPE_DECLARE(MSG_NOTIFY_EXIT_BATEND_COUNT),          // ֪ͨ�ͻ��ˣ�֪ͨ�˵����������
MSGTYPE_DECLARE(MSG_NOTIFY_HALL_DISPLAY_LIST),          // ֪ͨ�ͻ��˴�����ʾ�б�
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_BUFF),                  // ֪ͨ����buff��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_PAIR_OPTION),           // ֪ͨ����ƥ��ѡ��
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_SELECT),                // ֪ͨƥ��ѡ̹�˽׶Σ�̹�˱�ѡȡ
MSGTYPE_DECLARE(MSG_NOTIFY_TANK_LOCKED),                // ֪ͨ���ƥ��ѡ̹�˽׶Σ�̹�˱�����
MSGTYPE_DECLARE(MSG_NOTIFY_NEED_ROOM_PASSWORD),         // ֪ͨ�ͻ��ˣ����뷿����Ҫ����
MSGTYPE_DECLARE(MSG_CLEAR_ALL_TEAM_PLACE),              // guild->track ֪ͨ�������ս������
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_OCCUPY_SCORE),          // ֪ͨ�ͻ��ˣ�ռ���ܻ���
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_OCCUPY_ADD_SCORE),      // ֪ͨ�ͻ��ˣ�ռ�쵥�����ӻ���
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_WIN_ROUND),          		// ֪ͨ�ͻ��ˣ�ʤ���غ���
MSGTYPE_DECLARE(MSG_NOTIFY_NEW_ROUND_START),          	// ֪ͨ�ͻ��ˣ��»غϿ�ʼ
MSGTYPE_DECLARE(MSG_NOTIFY_CAMP_ADD_WIN_ROUND),         // ֪ͨ�ͻ��ˣ�ʤ���غ���������
MSGTYPE_DECLARE(MSG_NOTIFY_DEAD_MODE_ALIVE_CNT),        // ֪ͨ�ͻ��ˣ�����ģʽ˫���������
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_ROOM_IN_OTHER_LINE),    // ֪ͨ��ң�ս�ӷ�������������
MSGTYPE_DECLARE(MSG_NOTIFY_OTHER_GUILD_MATCH_ROOM_INFO),  // ֪ͨ����������������������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_PVE_MAP_ID),            // ֪ͨ��Ӹ�����ͼID
MSGTYPE_DECLARE(MSG_NOTIFY_COMMAND_SKILL_SELECT),       // ֪ͨѡ̹�˽׶�ָ�ӹټ��ܱ仯

// ս�����
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_GUILD_INFO, 1800),    // ֪ͨ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_LEAVE_GUILD),                // ֪ͨ�뿪����
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_KICKOUT),               // ֪ͨ�߳�ս��
MSGTYPE_DECLARE(MSG_NOTIFY_DESTROY_GUILD),              // ֪ͨ��ɢ����
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_INVITE),               // ֪ͨ��������
MSGTYPE_DECLARE(MSG_NOTIFY_JOIN_GUILD),                 // ֪ͨ����Ҽ������
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_POST),                // ְ֪ͨ��仯
MSGTYPE_DECLARE(MSG_TEAM_GOTO_WAR),                     // ֪ͨս���³�ս��Ա��Ϣ
MSGTYPE_DECLARE(MSG_TEAM_RESET_WAR),                    // ֪ͨս�ӳ�Ա��Ϣ
MSGTYPE_DECLARE(MSG_TEAM_WAR_ROOM_INFO),                // ֪ͨս����ս����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_STAND_TO),              // ս��׼�����
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_OUT_WAR),               // ֪ͨս���˳�ս��
MSGTYPE_DECLARE(MSG_NOTIFY_RIVAL_INFO),                 // ֪ͨ����ս����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_RIVAL_OUT_WAR),              // ֪ͨ����ȡ������׼��
MSGTYPE_DECLARE(MSG_UPDATE_TEAM_INFO),                  // ����ս����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SELECT_MATCH),               // ֪ͨ�ӳ�ѡ��μӵ�����
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_APPLY_LIST),           // ֪ͨ������������
MSGTYPE_DECLARE(MSG_NOTIFY_CHALLENGE_FAIL),             // ֪ͨԼսʧ��
MSGTYPE_DECLARE(MSG_NOTIFY_CHALLENGE_LIST),             // ֪ͨԼս�б�
MSGTYPE_DECLARE(MSG_NOTIFY_CHALLENGE_OK),               // ֪ͨԼս�ɹ�
MSGTYPE_DECLARE(MSG_NOTIFY_BE_CHALLENGE),               // ֪ͨ����ս
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MATCH_INFO),            // ֪ͨս������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MATCH_RESULT),          // ֪ͨս�������
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_JOIN_APPLY),            // ֪ͨ�����������ս��
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_JOIN_APPLY_LOGIN),      // ����ʱ֪ͨ�ж�����������ս��
MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_TEAM_NAME),           // ֪ͨ�޸�ս������
MSGTYPE_DECLARE(MSG_NOTIFY_CREATE_TEAM),                // ֪ͨ����ս��
MSGTYPE_DECLARE(MSG_NOTIFY_DELETE_TEAM),                // ֪ͨɾ��ս��
MSGTYPE_DECLARE(MSG_UPDATE_GUILD_INFO),                 // ���¾�����Ϣ
MSGTYPE_DECLARE(MSG_UPDATE_GUILD_MEMBER_INFO),          // ������Ա��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_INVITE_MEMBER),        // ֪ͨ������Ա
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MEMBER),                // ֪ͨ������Ա
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_SKILL_INFO),           // ֪ͨ���ż�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_INFO),            // ֪ͨ����BOSS��Ϣ
MSGTYPE_DECLARE(MSG_LEAGUE_ENROLL_RESULT), 							// ֪ͨ�ͻ��ˣ������������
MSGTYPE_DECLARE(MSG_LEAGUE_AWARD_RESULT), 							// ֪ͨ�ͻ��ˣ������콱���
MSGTYPE_DECLARE(MSG_LEAGUE_NOTIFY_CONFIG), 							// ֪ͨ�ͻ��ˣ��������ݻ�ȡ��Զ�̵�ַ
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_QUIZ_RESPONSE),       // ֪ͨ�ͻ��ˣ�����ս�ӵķ������Ƿ񾺲³ɹ���
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_ENEMY_LIST), 				// ֪ͨ������ս�������б�
MSGTYPE_DECLARE(MSG_NOTIFY_SCENE_CURTALENTPAGE),        // ֪ͨ������������ҵĵ�ǰ�츳ҳ
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_KILL_INFO),       // ֪ͨ����BOSS��ɱ��Ϣ


// ��ҹ�ϵ���
MSGTYPE_DECLARE_ASSIGN(MSG_RELATION_INIT_NOTIFY, 1900), // ֪ͨ��ʼ����ϵ��Ϣ
MSGTYPE_DECLARE(MSG_RELATION_UPDATE_NOTIFY),            // ���µ�����ҵĹ�ϵ��Ϣ
MSGTYPE_DECLARE(MSG_RELATION_DELETE),                   // ֪ͨɾ����ϵ
MSGTYPE_DECLARE(MSG_RELATION_ADD),                      // ֪ͨ��ӹ�ϵ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_SEARCH_RESULT), 							// ֪ͨ�ͻ��ˣ���ɫ��ѯ���
MSGTYPE_DECLARE(MSG_NOTIFY_RECEIVE_MP_APPLY),           // ֪ͨ��ɫ�յ�ʦͽ����
MSGTYPE_DECLARE(MSG_NOTIFY_MASTER_PRENTICE_INFO),       // ֪ͨ��ɫ��ʦͽ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_MP_RELATION_CREATED),        // ֪ͨʦͽ��ϵ����
MSGTYPE_DECLARE(MSG_UPDATE_MASTER_PRENTICE_INFO),       // ֪ͨ����ʦͽ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_MP_QUEST_LIST),              ///< ֪ͨʦͽ�����б�
MSGTYPE_DECLARE(MSG_NOTIFY_MP_QUEST_INFO),              ///< ֪ͨʦͽ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_SOCIAL_REL),          ///< ֪ͨ�Ƴ�ʦͽ��ϵ
MSGTYPE_DECLARE(MSG_NOTIFY_MP_APPLY_LIST_CLEARED),      ///< ֪ͨ���ʦͽ�б�
MSGTYPE_DECLARE(MSG_NOTIFY_MP_APPLY_LIST),              ///< ֪ͨʦͽ�����б�
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_PLAYER_INVITE),  ///< ֪ͨ�յ�������ѵ�����
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_PLAYER_INFO),    ///< ֪ͨ������������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_INVITE_GIFT_PLAYER),  ///< ֪ͨ�������������
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_INVITE_INFO),  	///< ֪ͨ�������������Ϣ

//���ص�
MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_ACT_INFO_LIST, 1950),     // ֪ͨ�ͻ��ˣ���ǰ���ŵĻ��Ϣ�б�
MSGTYPE_DECLARE(MSG_ACTIVITY_NOTIFY_STATE_CHANGE),          // ֪ͨ�ͻ��ˣ���ı仯��Ϣ
MSGTYPE_DECLARE(MSG_ACTIVITY_NOTIFY_BOSS_DATA),             // ֪ͨ�ͻ���, ����boss���Ϣ
MSGTYPE_DECLARE(MSG_ACTIVITY_SYNC_BOSS_DATA),               // ֪ͨ�ͻ���, ͬ������boss���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_NEXT_ONLINE_PEAK_ACT_START),     // ֪ͨ�ͻ���, ���߷�ֵ�½׶ο�ʼ
MSGTYPE_DECLARE(MSG_NOTIFY_ACT_INFO),                       // ֪ͨ�������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_STOP_ACT),                       // ֹ֪ͨͣ�
MSGTYPE_DECLARE(MSG_NOTIFY_LUCK_CONVERT_COUNT),             // ֪ͨ���˻�һ�����
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_GUILD_MATCH_SELECTED_TANK),           // ֪ͨ�ͻ��ˣ���������ѡ̹����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CONQUER_CASTLE),                 //guild-> ֪ͨ��һ������
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_MATCH_PAIR_GROUP),         // ֪ͨ��������ʾ����ͼ
MSGTYPE_DECLARE(MSG_NOTIFY_RAND_STEP_SUPPORT_INFO),     ///< ֪ͨ�ͻ��˶ᱦ���е�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_FIRE_BALL_CAN_SEL_TANK),         // ֪ͨ��������ѡ̹��


MSGTYPE_DECLARE(MSG_GATE_SVR_END),          // �ͻ���������յ����һ��Э��
/*#######################################################################
  #######################################################################*/

// ----------------------------------------------------------------------/
/* ������Ⱥ���з�����������ͨ�ŵ����ݰ�                                         */
// ----------------------------------------------------------------------/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_COMMON_START, 3000),
MSGTYPE_DECLARE(MSG_SPACELOG_COMMON),                       //ϵͳ��־��Ϣ
MSGTYPE_DECLARE(MSG_CLUSTER_CONFIG_UPDATE),                 ///< ֪ͨȺ��������Ϣ��Adminsvr������������
MSGTYPE_DECLARE(MSG_HUB_PROVIDER_REGISTER),                 ///< ֪ͨ·�ɽڵ��������ע��ĳ������
MSGTYPE_DECLARE(MSG_HUB_PROVIDER_REGISTER_RESULT),          ///< ֪ͨ�ڵ㣬ע��ĳ������·�ɵĽ��
MSGTYPE_DECLARE(MSG_HUB_SERVICE_REQUEST),                   ///< ���͵�HUB�ڵ��ת��·��������
MSGTYPE_DECLARE(MSG_HUB_SERVICE_RESULT),                    ///< ���͵�HUB�ڵ��ת��·��������
MSGTYPE_DECLARE(MSG_CLUSTER_SHUT_DOWN_INDICATE),          ///< ֪ͨȺ�飬ϵͳ�����رգ� Adminsvr������������
MSGTYPE_DECLARE(MSG_REQUEST_NET_PROFILE_DATA),          	///< �����������ܷ�������
MSGTYPE_DECLARE(MSG_NOTIFY_NET_PROFILE_DATA),          		///< ֪ͨ�������ܷ�������
MSGTYPE_DECLARE(MSG_REQUEST_DB_PROFILE_DATA),          	///< �������ݿ����ܷ�������
MSGTYPE_DECLARE(MSG_NOTIFY_DB_PROFILE_DATA),          		///< ֪ͨ���ݿ����ܷ�������
MSGTYPE_DECLARE(MSG_REQUEST_FUNC_PROFILE_DATA),          	///< ���������ܷ�������
MSGTYPE_DECLARE(MSG_NOTIFY_FUNC_PROFILE_DATA),          		///< ֪ͨ�������ܷ�������
MSGTYPE_DECLARE(MSG_CLIENT_BIND_GAME_CONNID),               ///< �ͻ������Ӱ�Ŀ��gamesvr������id
MSGTYPE_DECLARE(MSG_CLIENT_UNBIND_GAME_CONNID),             ///< �ͻ������ӽ����Ŀ��gamesvr������id
MSGTYPE_DECLARE(MSG_OBSERVER_BIND_PLAYER_ACCOUNT),      	///< ����Ҫ���������˺�
MSGTYPE_DECLARE(MSG_OBSERVER_UNBIND_PLAYER_ACCOUNT),      	///< �����Ҫ���������˺�
MSGTYPE_DECLARE(MSG_MARK_OBSERVER_NET_CONN),      					///< ���������Ӹ���״̬
MSGTYPE_DECLARE(MSG_UNMARK_OBSERVER_NET_CONN),      				///< ���������Ӹ���״̬

/*#######################################################################
  ��֤��صĽ���Э��
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_AUTH_START, 3100),
//-----AUTH<->GATE֮��Э������
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_REGISTER),         //->��֤��������ע�����
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_REGISTERRESULT),   //->���ͻ��ˣ�����ע����

MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_SESSIONSTART),     //����->��֤���ģ��е�½���󼤻�
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_SESSIONCLOSE),     //��֤ǰ��->��֤���ģ�֪ͨ�е�¼SESSION�������

MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SREQUEST),  //��֤����->��֪ͨ�е�¼����
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SSTART),    //��֤����->��֪ͨ�е�¼��ʼ
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_WENTER),    //��֤����->��֪ͨ�н�ɫ������Ϸ����
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_WLEFT),     //��֤����->��֪ͨ�н�ɫ�뿪��Ϸ����
MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SCLOSE),    //��֤����->����SESSION�Ѿ�����

MSGTYPE_DECLARE(MSG_CLUSTER_RESYNC_SESSIONS),       //->��֤���ģ�ͬ���Ѿ���ɵĵ�½
MSGTYPE_DECLARE(MSG_CLUSTER_RESYNC_COMPLETE),       //Gate->��֤���ģ���¼ͬ������
MSGTYPE_DECLARE(MSG_CLUSTER_GATE_SESSION_READY),    ///< ���ط�����׼���ý��ܵ�½
MSGTYPE_DECLARE(MSG_BRIDGE_RESPONSE),               ///< �Žӷ�������Ӧ
MSGTYPE_DECLARE(MSG_HTTP_BRIDGE_RESPONSE),          ///< �Ž�HTTP��������Ӧ

/*#######################################################################
  �� GATE_SVR ��ص�Э��
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_GAME_START, 3200),
MSGTYPE_DECLARE(MSG_CLUSTER_GATE_CLIENTLOST),           //����->��Ϸ ��Ҷ���
MSGTYPE_DECLARE(MSG_CLUSTER_GATE_PLAYERSYNC),           //����->��Ϸ ���ͳ�ʼ��ɫ��Ϣ
MSGTYPE_DECLARE(MSG_CLUSTER_GAME_CLIENTLOSTCONFIRM),    //��Ϸ->���� ���ߴ������
MSGTYPE_DECLARE(MSG_CLUSTER_MULTICAST_PACKET),          //��Ϸ->���� �ಥ��Ϣ��
MSGTYPE_DECLARE(MSG_CLOSE_CLIENT_CONNECT),              //��Ϸ->���� �ر�һ���û�����
MSGTYPE_DECLARE(MSG_CLUSTER_SERVER_PROFILE),            //������������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_ENTER_SOLO_SCENE),          //����->λ�� ���󴴽����˳���
MSGTYPE_DECLARE(MSG_REQUEST_ENTER_TANK_TRIAL_SCENE),    //����->λ�� �������̹�����泡��
MSGTYPE_DECLARE(MSC_CREATE_SCENE_PROPS),                // ֪ͨ������������
MSGTYPE_DECLARE(MSG_SYNC_QUEST_ACEM_LIST_TOGAME),       // ͬ������ɾ���Ϣtogame
MSGTYPE_DECLARE(MSG_CHANGE_CHECK_COUNT),                // �ı�����ļ�������
MSGTYPE_DECLARE(MSG_RELIVE_SYNC_ATTR),                  // ̹�˸������ͬ��̹����ֵ
MSGTYPE_DECLARE(MSG_SYNC_ATTR_TOGAME),                  // ͬ��̹�����ݸ�gamesvr
MSGTYPE_DECLARE(MSG_SYNC_CHAR_INFO_TOGAME),             // ͬ����ɫ���ݸ�gamesvr
MSGTYPE_DECLARE(MSG_SYNC_ROULETTE_AWARD),               // ͬ�����̻���Ϣ��tracksvr
MSGTYPE_DECLARE(MSG_UPDATE_BATTLE_TECHNO),              // ���¼�����Ϣ
MSGTYPE_DECLARE(MSG_SYNC_CHAR_DAY_CHARGE_INFO),         // ͬ����ɫ��ֵ����tracksvr
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_CHARGE_NUM),          // ֪ͨȫ����ֵ�������������
MSGTYPE_DECLARE(MSG_NOTIFY_GATE_DRAW_SOCIAL_QUEST_AWARD),// ֪ͨGate�����罻������
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_SOCIAL_AWARD_RESULT),   // ֪ͨ�������Ž��
MSGTYPE_DECLARE(MSG_NOTIFY_RECORD_CHAR_LAST_INFO),      // game->gate ��¼��ɫ����ʱ�ĵ�ͼ������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_ADD_SELECTED_TANK),          // gate->activity֪ͨ���ѡ����ĳ̹�˽���ս��
MSGTYPE_DECLARE(MSG_SYNC_SVR_AWARD),               			// ͬ��svr_award����Ϣ��tracksvr

/*#######################################################################
  λ�÷����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_TRACK_START, 3300),
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_LOGIN),                   // gate->track,֪ͨ����ҵ�¼��Ϸ
MSGTYPE_DECLARE(MSG_GAME_CREATE_SCENE),                     // ֪ͨgame������ս��
MSGTYPE_DECLARE(MSG_GAME_REMOVE_SCENE),                     // ֪ͨtrack����ս��
MSGTYPE_DECLARE(MSG_GAME_CREATE_SCENE_OK),                  // ֪ͨtrack�����ɹ�
MSGTYPE_DECLARE(MSG_GATE_ENTER_SCENE),                      // ֪ͨgate̹�˽���ս��
MSGTYPE_DECLARE(MSG_GAME_JOIN_SCENE),                       // ֪ͨgame����Ҽ���ս��
MSGTYPE_DECLARE(MSG_GAME_ADD_LOOKER),                       // ֪ͨgame����ҽ���ս����ս
MSGTYPE_DECLARE(MSG_NOTIFY_TURNUP_RESULT_TOGATE),           // ֪ͨ���ƽ����gate
MSGTYPE_DECLARE(MSG_SYNC_LIMIT_INFO_BYGATE),                // ͬ����ҵ�������Ϣ
MSGTYPE_DECLARE(MSG_SYNC_CHAR_INFO_TOTRACK),                // ͬ����ɫ��Ϣ��tracksvr
MSGTYPE_DECLARE(MSG_GAME_START_CAMP_POISE),                 // ֪ͨgame��������ƽ��
MSGTYPE_DECLARE(MSG_GAME_UPDATE_TANK_CAMP),                 // ֪ͨgame�л���Ӫ
MSGTYPE_DECLARE(MSG_SYNC_CHAR_NAME),                        // ͬ����ɫ������Ϣ��tracksvr
MSGTYPE_DECLARE(MSG_LEAGUE_NOTIFY_BATTLE_RESULT),           // ����֪ͨ�ɼ���Ϣ
MSGTYPE_DECLARE(MSG_GATE_RENEW_ELO),                        // ֪ͨELOˢ��
MSGTYPE_DECLARE(MSG_GATE_CHANGE_CHAR_HONOR),                // ͨ����̨�޸���ҵ�������Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_TEAM_AWARD),              // ֪ͨ����������ս�ӽ���
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_MEMBER_AWARD),            // ֪ͨ����������ս�Ӹ��˽���
MSGTYPE_DECLARE(MSG_GAME_CHANGE_BATTLE_TECHNO),             // ֪ͨ���¼���ͳ��
MSGTYPE_DECLARE(MSG_GAME_EXIT_BATTLE),                      // game֪ͨ����˳�ս��
MSGTYPE_DECLARE(MSG_GAME_HARM_BOSS),                        // game֪ͨ��Ҷ�����boss����˺�
MSGTYPE_DECLARE(MSG_TRACK_BATTLE_END),                      // trakc֪ͨgameս������
MSGTYPE_DECLARE(MSG_SYNC_BUDDY_DATA),                       // ͬ����������
MSGTYPE_DECLARE(MSG_SYNC_GUILD_DATA),                       // ͬ����������
MSGTYPE_DECLARE(MSG_SYNC_TRACK_SELECTED_TANK),              // track->gateͬ��ѡ̹�˽׶η����̹��
MSGTYPE_DECLARE(MSG_SYNC_TANK_BRIEF),                       // gate->track ͬ��̹�˼�Ҫ��Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_PUNISH_ESCAPE),                 // track->gate ����ͷ��������
MSGTYPE_DECLARE(MSG_GAME_SCENE_RECORD_START),               // track->game ����ʼս��¼��
MSGTYPE_DECLARE(MSG_NOTIFY_REFRESH_NOTE),                   // track->gate ֪ͨˢ�¼�¼
MSGTYPE_DECLARE(MSG_NOTIFY_GRANT_ONLINE_PEAK_AWARD),        // track->gate ֪ͨ���ŷ�ֵ���߻����
MSGTYPE_DECLARE(MSG_REQUEST_CHECK_BATTLE_TANK),          // track->gate ��������ս��̹���Ƿ����
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_DAMAGE_HP),           // track->game ֪ͨ����BOSS�˺�Ѫ��
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_END_DAMAGE_INFO),     // game->track ֪ͨ����BOSSս���������˺���Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_UPDATE_3V3_INFO),                // track->gate ֪ͨgate����3V3��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_NO_SELECT_TANK_PUNISH),          // track->gate ֪ͨδѡ̹�˳ͷ�
MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_END), 						// track->gate ֪ͨ���ֶ�ս����
MSGTYPE_DECLARE(MSG_CLUSTER_SYSTEM_BULLETIN), 						  // ����->λ��,ϵͳ����֪ͨ
MSGTYPE_DECLARE(MSG_CHAT_PLAYER_INFO),                      // TrackSvr -> chatsvr, ֪ͨ�����������������Ϣ
MSGTYPE_DECLARE(MSG_SYNC_CHAR_GUILD_TOGATE),                // ͬ����ɫ������Ϣ��gate
MSGTYPE_DECLARE(MSG_SYNC_GUILD_SKILL_INFO_TOGATE),          // ͬ�����ż�����Ϣ��gate
MSGTYPE_DECLARE(MSG_CHAR_ADD_TEAM_MERIT),                   // track->guild,������Ҿ��Ź���
MSGTYPE_DECLARE(MSG_NOTIFY_CONSUME_VALENTINE_FLAUNT),       // track->gate֪ͨ�������˽��ʻ�
MSGTYPE_DECLARE(MSG_NOTIFY_CONSUME_HIRE_TANK_COIN),         // track->gate֪ͨ�۳���������̹�˵�����
MSGTYPE_DECLARE(MSG_ADD_HIRE_TANK_PRESENT_TIME),            // track->gate gate->track �������͵�����̹��ʱ��
MSGTYPE_DECLARE(MSG_TEAM_PVE_BATTLE_WIN),                   // track->guild , ս��ͨ��PVE��ͼ
MSGTYPE_DECLARE(MSG_CHAR_ADD_GUILD_ACTIVE),                 // gate->guild ������Ӿ��Ż�Ծ��


/*#######################################################################
  ��������������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CHAT_ERROR_INFO, 3500),      //���������Ϣ�ظ�
MSGTYPE_DECLARE(MSG_CHAT_BULLETIN),                     //������Ϣ֪ͨ
MSGTYPE_DECLARE(MSG_SYSTEM_BULLETIN_NOTIFY),            //ϵͳ����֪ͨ
MSGTYPE_DECLARE(MSG_QUESTION_NOTIFY_HAVE_ANSWER),       //֪ͨ����з���
MSGTYPE_DECLARE(MSG_SYNC_PVP_PAIR_INFO),                //ͬ��ƥ����Ϣ
MSGTYPE_DECLARE(MSG_SYSTEM_TEMPLATE_BULLETIN_NOTIFY),   //ģ��ϵͳ����֪ͨ

/*#######################################################################
  ���ݷ����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_SVR_DATASVR_START, 3600),        // ���ݷ�������Ϣ
MSGTYPE_DECLARE(MSG_PERSIST_REGISTER),                      // ����ע��Persist����
MSGTYPE_DECLARE(MSG_PERSIST_REGISTER_CONFIRM),              // ȷ��Persist����ע��ɹ�
MSGTYPE_DECLARE(MSG_PERSIST_REGISTER_REJECT),               // �ܾ�Persistע��
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_SIMPLE),                // ������Ϣ�����ͳ־û�����
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_COMPOSITE),             // ������Ϣ�����ͳ־û�����
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_TRANSACTION),           // ������Ϣ�����ͳ־û�����
MSGTYPE_DECLARE(MSG_PERSIST_RESPONSE_SIMPLE),               // ������Ϣ�����ͳ־û���Ӧ
MSGTYPE_DECLARE(MSG_PERSIST_RESPONSE_COMPOSITE),            // ������Ϣ�����ͳ־û���Ӧ
MSGTYPE_DECLARE(MSG_PERSIST_RESPONSE_TRANSACTION),          // ������Ϣ�����ͳ־û���Ӧ
MSGTYPE_DECLARE(MSG_PERSIST_TXN_RESULT),                    // �����ύ���ص�����
MSGTYPE_DECLARE(MSG_PERSIST_REQUEST_POOLSTATE),             // ����״̬��Ϣ
MSGTYPE_DECLARE(MSG_PERSIST_REPORT_POOLSTATE),              // ����POOL״̬
MSGTYPE_DECLARE(MSG_NOTIFY_TRACKSVR_PLAYERLOGIN),           // Game -> Track ֪ͨ�����������������½
MSGTYPE_DECLARE(MSG_NOTIFYGAMESVR_REMOVELEFTOVEROBJ),       // Track -> Game ֪ͨ�����������������½��ɾ����������


/*#######################################################################
  npc�����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_NPC_START, 3700),
//���㲿�� : NPC��ص���Ϣ
MSGTYPE_DECLARE(MSG_QUERY_ASK),                         // ������֮�以���ѯ����
MSGTYPE_DECLARE(MSG_QUERY_ANSWER),                      // ������֮�以���ѯӦ��
MSGTYPE_DECLARE(MSG_NPC_SERVER_REGISTER),               // NPC��������������֪��Ϸ������
MSGTYPE_DECLARE(MSG_NPC_SERVER_REG_RESPONE),            // ��Ϸ��������NPC������ע��Ļ�ӦMSG_NPC_SERVER_REG_RESPONE
MSGTYPE_DECLARE(MSG_NPC_SERVER_CLOSE),                  // npc->gamesvr ֪ͨnpcsvr�ر�
MSGTYPE_DECLARE(MSG_NPC_SCENE_INIT),                    // npc->gamesvr ֪ͨ����npc��ʼ��
MSGTYPE_DECLARE(MSG_NPC_TANK_ENTER),                    // gamesvr->npc ֪̹ͨ�˽���ս��
MSGTYPE_DECLARE(MSG_NPC_TANK_EXIT),                     // gamesvr->npc ֪̹ͨ���˳�ս��
MSGTYPE_DECLARE(MSG_NPC_CREATE_PROPS),                  // npc->gamesvr ֪ͨ������������
MSGTYPE_DECLARE(MSG_NPC_SYNC_ATTRS),                     // gamesvr->npc ֪ͨͬ����������
MSGTYPE_DECLARE(MSG_NPC_REPAIR_TANK),                   // npc->gamesvr ֪ͨ�������̹�˲�Ѫ
MSGTYPE_DECLARE(MSG_NPC_OBJ_MOVE),                      // gamesvr->npc npc->gamesvr ֪ͨ�����ƶ�
MSGTYPE_DECLARE(MSG_NPC_CREATE_OBJECT),                 // npc->gamesvr ֪ͨ���󴴽�
MSGTYPE_DECLARE(MSG_NPC_SYNC_ATTR),                    // gamesvr->npc ͬ����������
MSGTYPE_DECLARE(MSG_NPC_USE_SKILL),                     // npc->gamesvr ֪ͨAINPCʹ�ü���
MSGTYPE_DECLARE(MSG_NPC_BATTLE_END),                    // npc->gamesvr ֪ͨս������
MSGTYPE_DECLARE(MSG_NPC_REMOVE_OBJ),                    // npc->gamesvr ֪ͨ�Ƴ�����
MSGTYPE_DECLARE(MSG_NOTIFY_SEEK_PATH),                  // ֪ͨѰ�����
MSGTYPE_DECLARE(MSG_NPC_FROZEN),                        // npc->gamesvr ����
MSGTYPE_DECLARE(MSG_NOTIFY_NPC_CREATE_OBJ),             // game->npc ֪ͨNPC��������
MSGTYPE_DECLARE(MSG_GAME_OBJ_STATE_CHANGE),             // game->npc  ֪ͨNPC������״̬�仯
MSGTYPE_DECLARE(MSG_NPC_ADD_BUFF),                      // npc->Game ֪ͨ game ����BUFF
MSGTYPE_DECLARE(MSG_NPC_REMOVE_BUFF),                   // npc->Game ֪ͨ game ɾ��BUFF
MSGTYPE_DECLARE(MSG_NOTIFY_GIVE_BATTLE_EXP),            // npc->game ֪ͨ����ս������
MSGTYPE_DECLARE(MSG_NPC_SYNC_PORTAL_STATE),             // npc->Game֪ͨgamesvrͬ��������״̬
MSGTYPE_DECLARE(MSG_NOTIFY_NPC_EXEC_SCRIPT),            // game->npc ֪ͨNPCִ�е�ͼ�ű�
MSGTYPE_DECLARE(MSG_NPC_NOTIFY_PVE_STEP),               // npc->Game֪ͨgamesvr��������
MSGTYPE_DECLARE(MSG_NOTIFY_NPC_SVR_REMOVE_BUFF),        // game->npc ֪ͨ�����Ƴ�BUFF

/*#######################################################################
  guild �����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_GUILD_START, 3800),
MSGTYPE_DECLARE(MSG_QUERY_GUILD_CREATE_ROOM),           //track->guild����ѯ��������������Ƿ�ͨ��
MSGTYPE_DECLARE(MSG_GUILD_REQUEST_CREATE_ROOM),         //guild->track, ֪ͨtrack��������
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_DESTROY_ROOM),         //track->guild, ֪ͨguild���䱻����
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_PLAYER_ENTER_ROOM),    //track->guild, ֪ͨguild��ҽ��뷿��
MSGTYPE_DECLARE(MSG_MULTICAST_TEAM_ROOM_PACKET),        //guild->track, ֪ͨtrack��ս�ӷ�������
MSGTYPE_DECLARE(MSG_GUILD_REQUEST_CREATE_SCENE),        //guild->global,֪ͨglobal����ս��
MSGTYPE_DECLARE(MSG_MULTICAST_GUILD_MATCH_ROOM_PACKET), //guild->global,֪ͨtrack�ڵľ���ս��������
MSGTYPE_DECLARE(MSG_REQUEST_ROUNDPASS_ROOM_MEMBER_UUID),//guild->track,���󷿼��ڳ�ս���UUID
MSGTYPE_DECLARE(MSG_NOTIFY_ROUNDPASS_ROOM_MEMBER_UUID), //track->guild,֪ͨ�ֿշ���ĳ�Ա
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_MATCH_RANK_TO_GATE),   //guild->gate, ֪ͨ����������
MSGTYPE_DECLARE(MSG_NOTIFY_RESET_GUILD_MATCH_RANK_QUEST), // guild->gate, ֪ͨ���þ�����������
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_BATTLE_START),   //guild->track, ֪ͨ����BOSSս����ʼ
MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_BATTLE_END),     //track->guild, ֪ͨ����BOSSս������
MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_GET_GUILD_BOSS_AWARD),   //guild->gate,  ֪ͨ��þ���BOSS����
MSGTYPE_DECLARE(MSG_NOTIFY_CLEAR_GUILD_BOSS_BATTLE_TIME),   //guild->gate,  ֪ͨ�������BOSSս��ʱ��
MSGTYPE_DECLARE(MSG_REQUEST_START_3V3_PAIR),            // track->guild, ����ʼ3V3��������������
MSGTYPE_DECLARE(MSG_REQUEST_STOP_3V3_PAIR),             // track->guild, ����ȡ��3V3��������������
MSGTYPE_DECLARE(MSG_NOTIFY_3V3_DIRECT_WIN),                 // guild->track, ֪ͨ3V3�ֿ�ֱ�ӻ�ʤ

MSGTYPE_DECLARE_ASSIGN(MSG_TEST_START, 4000),
MSGTYPE_DECLARE(MSG_TEST_LATENCY_RECORD),                   //���� ��ʱ�ռ�
MSGTYPE_DECLARE(MSG_TEST_FULL_DATATYPE),                // ���Ը�����������

/*#######################################################################
  global�����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_GLOBAL_START, 4100),

MSGTYPE_DECLARE(MSG_GLOBAL_START_PAIR),                 // ��ʼ������
MSGTYPE_DECLARE(MSG_GLOBAL_STOP_PAIR),                  // ֹͣ������
MSGTYPE_DECLARE(MSG_GLOBAL_ASSIGN_GAMESVR),             // ֪ͨgateս�������gamesvr
MSGTYPE_DECLARE(MSG_GLOBAL_MIDWAY_JOIN),                // ������;����
MSGTYPE_DECLARE(MSG_GLOBAL_SCENE_LIST),                 // ֪ͨս���б���Ϣ
MSGTYPE_DECLARE(MSG_GLOBAL_DEL_SCENE_LIST),             // ֪ͨɾ��ս���б���Ϣ
MSGTYPE_DECLARE(MSG_GLOBAL_ROBOT_PAIR),                 // ֪ͨ��ʼ���л��������
MSGTYPE_DECLARE(MSG_GLOBAL_LOOK_SCENE),                 // ֪ͨ�����ս
MSGTYPE_DECLARE(MSG_GLOBAL_PAIR_OK),                    // ֪ͨ�����Գɹ�
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_RESULT),              // ֪ͨ�������ս�����
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_MIDWAY_JOIN_OK),      // ֪ͨtrack��;����ɹ�
MSGTYPE_DECLARE(MSG_GLOBAL_SYNC_TANK_BRIEF),            // ֪ͨ���ͬ��̹�˼�Ҫ��Ϣ
MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_JOIN_LEAGUE_ROOM),   // ��������������� track->global
MSGTYPE_DECLARE(MSG_GLOBAL_NOTIFY_JOIN_LEAGUE_ROOM_OK), // ֪ͨ������������ɹ� global->track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAVE_LEAGUE_ROOM),          // ֪ͨ�뿪�������� global->track
MSGTYPE_DECLARE(MSG_GLOBAL_REQ_ROOM_OP),                // ���������������
MSGTYPE_DECLARE(MSG_GLOBAL_PLAYER_LOGOUT),              // ֪ͨGLOBAL��ҵǳ�
MSGTYPE_DECLARE(MSG_GLOBAL_STAT_CHAR_DATA),             // ֪ͨͳ�ƽ�ɫ��Ϣ
MSGTYPE_DECLARE(MSG_GLOBAL_NOTIFY_USE_ITEM),            // ֪ͨglobalʹ����Ʒ
MSGTYPE_DECLARE(MSG_GLOBAL_SYNC_CHAR_INFO),             // ֪ͨglobal�����Ϣ���
MSGTYPE_DECLARE(MSG_GLOBAL_PUNISH_LADDER_ESCAPE_ON_WAIT),   // global->track, ���������������
MSGTYPE_DECLARE(MSG_GATE_GET_CURTALENTPAGE),                // global-->track-->gate ��Gate��ȡ��ҵ�ǰ�츳ҳ
MSGTYPE_DECLARE(MSG_SYNC_CURTALENTPAGE),                    // gate-->track-->global ��Trackͬ����ǰ�츳ҳ
MSGTYPE_DECLARE(MSG_GATE_UNLOCK_TALENTOP),                  // global-->track-->gate ֪ͨGame������ҵ��츳����
MSGTYPE_DECLARE(MSG_GLOBAL_REQ_LOOK_ROOM),                  // ������뷿���Ϊ�۲���
MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_SET_MAP),                // �������÷����ͼ
MSGTYPE_DECLARE(MSG_REQUEST_MATCH_ROOM_CHAR_DATA),          // global->track ������������Ա��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_MATCH_ROOM_CHAR_DATA),           // track->global ֪ͨս���������Ա��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_TEAM_MATCH_END),                 // global->guild ֪ͨս������������

MSGTYPE_DECLARE_ASSIGN(MSG_GLOBAL_SYNC_TEAM, 4200),             // ͬ��ս�����ݵ�GLOBAL
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_ENROLL_RESULT),               // �����������Global->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_REQ),               // ����������ս�б�Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_LIST),              // ����������ս�б�Global->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_REQUEST_AWARD),               // ���������콱Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_ACT_PREPARE),                 // �������ʼǰ��׼��Track->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_MEMEBER_AWARD),               // ����������ȡGlobal->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_TEAM),              // ��������ԼսTrack->Global
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_PLAYER_LOGIN),                // ��ҵ�¼
MSGTYPE_DECLARE(MSG_GLOBAL_TEAM_MESSAGE),                       // ����ս����ϢGlobal->Track
MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_GET_TO_WAR),                  // ��ȡ��ս����б�Global->Track
MSGTYPE_DECLARE(MSG_NOTIFY_REMOTE_PLATFORM_MATCH_RESULT),       // ֪ͨƽ̨���½ӿڱ������ global->track
MSGTYPE_DECLARE(MSG_NOTIFY_LEAGUE_AUTO_ENROLL),                 // ֪ͨ�����Զ�������ϢGlobal->Track
MSGTYPE_DECLARE(MSG_REQUEST_LEAGUE_BATCH_ENROLL),               // ����global������������
MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_SYNC_TEAM_MEMBER),           // ����ͬ��ս�ӳ�Ա��Ϣ global->track
MSGTYPE_DECLARE(MSG_SYNC_IMPEACH_INFO),                         // ͬ���ٱ���Ϣ global <-> track
MSGTYPE_DECLARE(MSG_NOTIFY_IMPEACH_RESULT_IN_SERVER),           // ֪ͨ�ٱ���� global <-> track
MSGTYPE_DECLARE(MSG_NOTIFY_SERVER_NEW_MAIL),                    // ֪ͨ���������������ʼ� now : track -> global -> tracks
MSGTYPE_DECLARE(MSG_NOTIFY_AFK_TRIGGER),                        // ֪ͨtrack����Ҵ����һ�  game -> track, game->global->track
MSGTYPE_DECLARE(MSG_NOTIFY_RELOAD_BAN_INFO),                    // ͨ��globalת����track���¼��ر��ٱ��˵ķ����Ϣ
MSGTYPE_DECLARE(MSG_GLOBAL_GM_RESULT),                          // GLOBAL��GM����ķ��ؽ��
MSGTYPE_DECLARE(MSG_ADD_GLOBAL_ROULETTE_GIFT),                  // ֪ͨ���ӿ��ת�̽��ص���ȯ
MSGTYPE_DECLARE(MSG_REQUEST_DRAW_GLOBAL_ROULETTE_GIFT),         // ������ȡ���ת�̽��ص���ȯ
MSGTYPE_DECLARE(MSG_NOTIFY_GET_GLOBAL_ROULETTE_GIFT),           // ֪ͨ��ÿ��ת�̽��ص���ȯ
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_ROULETTE_GIFT_NUM),           // ֪ͨ��ǰת�̽��ص���ȯ��
MSGTYPE_DECLARE(MSG_REQUEST_CHECK_ROULETTE_DROP_LIMIT),         // ����������Ƶ�����Ʒ
MSGTYPE_DECLARE(MSG_SYNC_ROULETTE_CHECKED_DROP_ITEM),           // ֪ͨgateת�̵�����Ʒ
MSGTYPE_DECLARE(MSG_SYNC_FREE_WEEK_TANK_CONFIG),                // ͬ������̹����Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_QUERY_GLOBAL_LIMIT_AWARD_INFO),     // ����ȫ����ѯ���ƽ�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_QUERY_GLOBAL_LIMIT_AWARD_INFO),      // ֪ͨȫ����ѯ���ƽ�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_CLOUD_PURCHASE_BUY_INFO),            // ֪ͨ�ƹ�������Ϣ
MSGTYPE_DECLARE(MSG_REQUEST_GLOBAL_CONVERT_ITEM),               // ����ȫ���һ���Ʒ
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_CONVERT_ITEM),                // ֪ͨȫ���һ���Ʒ
MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_NEW_MAIL),                    // ֪ͨ����������������ʼ�֪ͨ
MSGTYPE_DECLARE(MSG_NOTIFY_CLOUD_PURCHASE_AWARD_INFO),          // ֪ͨ�ƹ�����Ϣ global -> gate
MSGTYPE_DECLARE(MSG_REQUEST_GLOBAL_LOAD_PURCHASE_AWARD),        // ��������ƹ�����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_USE_COUNT_INFO),             // ֪ͨ�������ʹ����Ϣ global -> gate
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_USE),                        // ֪ͨ�������ʹ�� gate -> global
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_COMPLETE_QUEST),             // ֪ͨ������ȡ������ gate -> global
MSGTYPE_DECLARE(MSG_NOTIFY_BONFIRE_COMPLETE_QUEST_INFO),        // ֪ͨ������ȡ��������Ϣglobal -> gate
MSGTYPE_DECLARE(MSG_SYNC_TREASURE_TANK),                        // ֪ͨ�ᱦ̹����Ϣ global -> gate

/*#######################################################################
  robot�����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_ROBOT_START, 5000),
MSGTYPE_DECLARE(MSG_NOTIFY_ROBOT_CACHE_PATH),           //֪ͨԤ�����Ѱ�����

/*#######################################################################
  buddy�����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_BUDDY_START, 5100),
MSGTYPE_DECLARE(MSG_REQUEST_OBSERVER_OTHER_GATE_PLAYER),       ///< ��������ͬgate��
MSGTYPE_DECLARE(MSG_NOTIFY_OBSERVER_OTHER_GATE_PLAYER),       ///< ֪ͨ������ͬgate��
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_ITEM_DROP_INFO),       			///< ֪ͨ���뿨������Ϣ(gate -> buddy)
MSGTYPE_DECLARE(MSG_NOTIFY_FORBID_DROP_INVITE_ITEM),       		///< ֪ͨ��ֹ�������뿨(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_DRAW_INVITE_GIFT_AWARD),       		///< ֪ͨ��ȡ���������(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_CROSS_DAY),       			///< ֪ͨ��Ҹ��������������(gate -> buddy)
MSGTYPE_DECLARE(MSG_NOTIFY_REMOVE_INVITE_GIFT_ITEM),       		///< ֪ͨɾ���������(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_GIFT_ITEM_OVER_TIME),       ///< ֪ͨ��ҵ��߹���(gate -> buddy)
MSGTYPE_DECLARE(MSG_NOTIFY_CAN_SENDMAIL),                     ///< ֪ͨ���Է����ʼ�(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_CAN_PRESENT_GOODS),                ///< ֪ͨ����������Ʒ������(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_BIND_INVITE_SPREAD_PLAYER),   		  ///< ֪ͨ�����ƹ������Ϣ(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_SPREAD_BIND_LEVEL_INFO),    ///< ֪ͨ�����ƹ����ҵȼ�(buddy -> gate)
MSGTYPE_DECLARE(MSG_NOTIFY_INVITE_SPREAD_BIND_LEVEL_CHANGE),  ///< ֪ͨ�����ƹ����ҵȼ��仯(gate -> buddy)

/*#######################################################################
  activity�����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CLUSTER_ACTIVITY_START, 5200),
MSGTYPE_DECLARE(MSG_SYNC_RUNNING_ACTIVITY_TO_SVR),          ///< ֪ͨ����������ͬ���ѿ����Ļ��Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_START_ACT),                      ///< ֪ͨ����������ĳ�������
MSGTYPE_DECLARE(MSG_SEND_REDPKT_BULLETIN),                  // gate-->act ��ҷ�����Ĺ���
MSGTYPE_DECLARE(MSG_NOTIFY_LUCK_CONVERT_SUCCESS),           // gate-->act ֪ͨ���˻�һ��ɹ�
MSGTYPE_DECLARE(MSG_SYNC_GUILD_MATCH_SELECTED_TANK),      // act->track
MSGTYPE_DECLARE(MSG_REQUEST_GUILD_MATCH_SELECTED_TANK),   // �����ȡ���ѡ̹����Ϣ
MSGTYPE_DECLARE(MSG_NOTIFY_RAND_STEP_SUPPORT_SUCCESS),    // act->gate  ֪ͨ���޳ɹ�


/*#######################################################################
  cache�����������Ϣ
  #######################################################################*/
MSGTYPE_DECLARE_ASSIGN(MSG_CACHING_START, 5300),
MSGTYPE_DECLARE(MSG_CACHING_REFRESH_REQUEST),               ///< ����ˢ���ض��Ļ���
MSGTYPE_DECLARE(MSG_CACHING_REFRESH_RESULT),                ///< �����ض�����ˢ�µĽ��

//--------------------------------------------------------------------------
MSGTYPE_DECLARE_ASSIGN(MSG_LAST, 6000),                            //��ʶ���һ����Ϣ
//-------------------------------------------------------------------------
MSGTYPE_END_BLOCK


