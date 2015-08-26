﻿namespace EOLib
{
	public enum EOLanguage
	{
		English,
		Dutch,
		Swedish,
		Portuguese
	}

	public enum DataFiles
	{
		Credits = 1,
		Checksum,
		CurseFilter,
		JukeBoxSongs,
		EnglishStatus1,
		EnglishStatus2,
		DutchStatus1,
		DutchStatus2,
		SwedishStatus1,
		SwedishStatus2,
		PortugueseStatus1,
		PortugueseStatus2
	}

	/// <summary>
	/// Constants for resource string status messages in the first data file for the language
	/// </summary>
	public enum DATCONST1
	{
		CONNECTION_SERVER_BUSY = 0,
		CHARACTER_CREATE_NAME_TOO_SHORT = 2,
		ACCOUNT_CREATE_PASSWORD_MISMATCH = 4,
		ACCOUNT_CREATE_PASSWORD_TOO_SHORT = 6,
		ACCOUNT_CREATE_PASSWORD_TOO_OBVIOUS = 8,
		ACCOUNT_CREATE_NAME_TOO_SHORT = 10,
		ACCOUNT_CREATE_NAME_TOO_OBVIOUS = 12,
		ACCOUNT_CREATE_EMAIL_INVALID = 16,
		ACCOUNT_CREATE_FIELDS_STILL_EMPTY = 18,
		CONNECTION_CLIENT_OUT_OF_DATE = 20,
		LOGIN_BANNED_FROM_SERVER = 22,
		ACCOUNT_CREATE_NO_NEW_ACCOUNTS = 24,
		LOGIN_NO_NEW_LOGINS = 26,
		CONNECTION_LOST_CONNECTION = 28,
		CONNECTION_IP_BAN_PERM = 30,
		CONNECTION_IP_BAN_TEMP = 32,
		CONNECTION_SERVER_NOT_FOUND = 34,
		LOGIN_SERVER_COULD_NOT_PROCESS = 36,
		LOGIN_OTHER_CHARACTERS_IN_USE = 38,
		LOGIN_ACCOUNT_NAME_NOT_FOUND = 40,
		LOGIN_ACCOUNT_NAME_OR_PASSWORD_NOT_FOUND = 42,
		LOGIN_ACCOUNT_ALREADY_LOGGED_ON = 44,
		ACCOUNT_CREATE_NAME_EXISTS = 46,
		ACCOUNT_CREATE_NAME_NOT_APPROVED = 48,
		ACCOUNT_CREATE_SUCCESS_WELCOME = 50,
		CHANGE_PASSWORD_MISMATCH = 52,
		CHANGE_PASSWORD_SUCCESS = 54,
		ACCOUNT_CREATE_ACCEPTED = 56,
		CHARACTER_DELETE_CONFIRM = 58,
		CHARACTER_CREATE_NAME_EXISTS = 60,
		CHARACTER_CREATE_TOO_MANY_CHARS = 62,
		CHARACTER_CREATE_NAME_NOT_APPROVED = 64,
		CHARACTER_CREATE_SUCCESS = 66,
		CONNECTION_LOST_IN_GAME = 68,
		EXIT_GAME_ARE_YOU_SURE = 70,
		PARTY_GROUP_REQUEST_TO_JOIN = 72,
		PARTY_GROUP_SEND_INVITATION = 74,
		SETTINGS_SOUND_DISABLED = 76,
		SETTINGS_MUSIC_DISABLED = 78,
		TRADE_REQUEST = 80,
		TRADE_SUCCESS = 82,
		CHEST_LOCKED = 84,
		DOOR_LOCKED = 86,
		CHEST_BROKEN = 88,
		DOOR_BROKEN = 90,
		WARNING_KEEP_PASSWORD_SAFE = 92,
		TRADE_DO_YOU_AGREE = 94,
		TRADE_ABORTED_OFFER_CHANGED = 96,
		SHOP_BUY_ITEM_SOLD_OUT = 98, //???
		BANK_ACCOUNT_UNABLE_TO_WITHDRAW = 100,
		BANK_ACCOUNT_UNABLE_TO_DEPOSIT = 102,
		SHOP_NOTHING_IS_FOR_SALE = 104,
		//106: confirmed (AFAIK) that the client does not show this message separately from NOT_BUYING_YOUR_ITEMS message
// ReSharper disable once UnusedMember.Global
		SHOP_NOT_BUYING_USED_ITEMS = 106,
		SHOP_NOT_BUYING_YOUR_ITEMS = 108,
		WARNING_YOU_HAVE_NOT_ENOUGH = 110,
		SHOP_DOES_NOT_BUY = 112,
		LOCKER_FULL_SINGLE_ITEM_MAX = 114,
		//116: confirmed (AFAIK) that the client does not show a message when you hit the max (unless the server is missing a message for this)
// ReSharper disable once UnusedMember.Global
		LOCKER_FULL_DIFF_ITEMS_MAX = 116,
		LOCKER_DEPOSIT_GOLD_ERROR = 118,
		DROP_MANY_GOLD_ON_GROUND = 120,
		WARNING_FIRST_TIME_PLAYERS = 122,
		REMOVE_NOT_POSSIBLE_OFFER_MORE_ITEMS = 124, //??
		TRADE_OTHER_PLAYER_TRICK_YOU = 126,
		GUILD_CREATE_TAG_FIELD_EMPTY = 128,
		GUILD_CREATE_NAME_FIELD_EMPTY = 130,
		GUILD_CREATE_TAG_TOO_SHORT = 132,
		GUILD_CREATE_NAME_TOO_SHORT = 134,
		GUILD_CREATE_NAME_NOT_APPROVED = 136,
		GUILD_CREATE_NO_CANDIDATES = 138,
		GUILD_ALREADY_A_MEMBER = 140,
		GUILD_NOT_IN_GUILD = 142,
		GUILD_RANK_TOO_LOW = 144,
		GUILD_TAG_OR_NAME_ALREADY_EXISTS = 146,
		GUILD_WILL_BE_CREATED = 148,
		GUILD_MASTER_IS_BUSY = 150,
		GUILD_INVITES_YOU_TO_JOIN = 152,
		GUILD_TAG_NAME_LETTER_MUST_MATCH = 154,
		GUILD_PROMPT_FOR_RECRUITER = 156,
		GUILD_PROMPT_LEAVE_GUILD = 158,
		GUILD_RECRUITER_NOT_FOUND = 160,
		GUILD_RECRUITER_NOT_HERE = 162,
		GUILD_RECRUITER_NOT_MEMBER = 164,
		GUILD_RECRUITER_RANK_TOO_LOW = 166,
		GUILD_RECRUITER_INPUT_MISSING = 168,
		GUILD_PLAYER_WANTS_TO_JOIN = 170,
		GUILD_BANK_ACCOUNT_LOW = 172,
		GUILD_MEMBER_HAS_BEEN_ACCEPTED = 174,
		GUILD_DOES_NOT_EXIST = 176,
		GUILD_YOU_HAVE_BEEN_ACCEPTED = 178,
		GUILD_DETAILS_HAVE_BEEN_UPDATED = 180,
		GUILD_PROMPT_DISBAND_GUILD = 182,
		GUILD_REMOVE_MEMBER_WHO = 184,
		GUILD_REMOVE_PLAYER_NOT_MEMBER = 186,
		GUILD_REMOVE_PLAYER_IS_LEADER = 188,
		GUILD_REMOVE_SUCCESS = 190,
		GUILD_DEPOSIT_IS_1000 = 192,
		GUILD_DEPOSIT_NEW_BALANCE = 194,
		ITEM_IS_LORE_ITEM = 196,
		ITEM_IS_CURSED_ITEM = 198,
		BOARD_ERROR_NO_SUBJECT = 200,
		BOARD_ERROR_NO_MESSAGE = 202,
		BOARD_ERROR_MSG_NO_SUBJECT = 204,
		BOARD_ERROR_SUBJECT_NO_MSG = 206,
		BOARD_ERROR_TOO_MANY_MESSAGES = 208,
		ITEM_CURSE_REMOVE_PROMPT = 210,
		JUKEBOX_REQUESTED_RECENTLY = 212,
		CHARACTER_DELETE_FIRST_CHECK = 214,
		CONNECTION_SERVER_IS_FULL = 216,
		WEDDING_NEED_PROPER_CLOTHES = 218,
		WEDDING_NEED_HIGHER_LEVEL = 220,
		WEDDING_PRIEST_CAN_PERFORM = 222,
		WEDDING_PARTNER_NEED_CLOTHES = 224,
		WEDDING_PARTNER_IS_MISSING = 226,
		WEDDING_PRIEST_IS_BUSY = 228,
		WEDDING_DO_YOU_ACCEPT = 230,
		WEDDING_PARTNER_ALREADY_MARRIED = 232,
		NICE_TRY_HAXOR = 234,
		WEDDING_YOU_ALREADY_MARRIED = 236,
		WEDDING_CANNOT_DIVORCE_NO_PARTNER = 238,
		WEDDING_REGISTRATION_COMPLETE = 240,
		WEDDING_PARTNER_NOT_MATCH = 242,
		WEDDING_REGISTRATION_TOO_BUSY = 244,
		WEDDING_DIVORCE_NO_MORE_PARTNER = 246,
		WEDDING_NO_PERMISSION_TO_COMPLETE = 248,
		SKILL_NOTHING_MORE_TO_LEARN = 250,
		SKILL_PROMPT_TO_FORGET = 252,
		SKILL_FORGET_ERROR_NOT_LEARNED = 254,
		SKILL_FORGET_SUCCESS = 256,
		SKILL_LEARN_REQS_NOT_MET = 258,
		SKILL_LEARN_CONFIRMATION = 260,
		SKILL_RESET_CHARACTER_CONFIRMATION = 262,
		SKILL_RESET_CHARACTER_CLEAR_PAPERDOLL = 264,
		SKILL_RESET_CHARACTER_COMPLETE = 266,
		HELP_REQUEST_RECEIVED = 268,
		SKILL_LEARN_WRONG_CLASS = 270,
		LOCKER_UPGRADE_UNIT = 272,
		LOCKER_UPGRADE_IMPOSSIBLE = 274
	}

	/// <summary>
	/// Constants for resource string status messages in the second data file for the language
	/// </summary>
	public enum DATCONST2
	{
		//these are status labels, and dialog text for non-alert style dialogs

		//mouseover status label strings for buttons
		STATUS_LABEL_HUD_BUTTON_HOVER_FIRST = 3,
		STATUS_LABEL_HUD_BUTTON_HOVER_LAST = 13,


		YOUR_MIND_PREVENTS_YOU_TO_SAY = 14,

		STATUS_LABEL_CHAT_PANEL_NOW_VIEWED = 16,
		STATUS_LABEL_STATS_PANEL_NOW_VIEWED = 17,
		STATUS_LABEL_ONLINE_PLAYERS_NOW_VIEWED = 18,
		STATUS_LABEL_WILL_BE_IGNORED = 19,

		STATUS_LABEL_PARTY_IS_INVITED = 21,

		STATUS_LABEL_PARTY_REQUESTED_TO_JOIN = 23,

		STATUS_LABEL_MENU_BELONGS_TO_PLAYER = 26,
		STATUS_LABEL_PARTY_RECENTLY_REQUESTED = 27,
		STATUS_LABEL_NOT_READY_TO_USE_ENTRANCE = 28,
		STATUS_LABEL_PARTY_IS_ALREADY_MEMBER = 29,
		SYS_CHAT_PM_PLAYER_COULD_NOT_BE_FOUND = 30,
		STATUS_LABEL_YOU_ENTERED = 31,

		STATUS_LABEL_PARTY_YOU_JOINED = 33,
		STATUS_LABEL_PARTY_JOINED_YOUR = 34,

		STATUS_LABEL_PARTY_LEFT_YOUR = 36,
		STATUS_LABEL_TYPE_BUTTON = 37,
		STATUS_LABEL_TYPE_ACTION = 38,
		STATUS_LABEL_TYPE_WARNING = 39,
		STATUS_LABEL_TYPE_INFORMATION = 40,

		SETTING_ENABLED = 43,
		SETTING_DISABLED = 44,
		SETTING_NORMAL = 45,
		SETTING_EXCLUSIVE = 46,
		SETTING_LANG_CURRENT = 47,
		//48 - 49 match 47 in each localized file (which is language of curr file)
		SETTING_LANG_AZERTY = 50, //this is AZERTY in each file

		STATUS_LABEL_INVENTORY_DROP_BUTTON = 51,
		STATUS_LABEL_INVENTORY_JUNK_BUTTON = 52,
		STATUS_LABEL_SETTINGS_CLICK_TO_CHANGE = 53,
		STATUS_LABEL_TYPE_ITEM = 54,
		DIALOG_TRANSFER_HOW_MUCH = 55,
		DIALOG_TRANSFER_DROP = 56,
		DIALOG_TRANSFER_JUNK = 57,
		DIALOG_TRANSFER_GIVE = 58,
		STATUS_LABEL_ITEM_DROP_YOU_DROPPED = 59,
		STATUS_LABEL_ITEM_JUNK_YOU_JUNKED = 60,
		STATUS_LABEL_ITEM_PICKUP_YOU_PICKED_UP = 61,
		STATUS_LABEL_YOU_HAVE_NO_MORE = 62,
		STATUS_LABEL_ITEM_PICKUP_NO_SPACE_LEFT = 63,
		STATUS_LABEL_PAPERDOLL_HAT_EQUIPMENT = 64,
		STATUS_LABEL_PAPERDOLL_NECKLACE_EQUIPMENT = 65,
		STATUS_LABEL_PAPERDOLL_ARMOR_EQUIPMENT = 66,
		STATUS_LABEL_PAPERDOLL_WEAPON_EQUIPMENT = 67,
		STATUS_LABEL_PAPERDOLL_SHIELD_EQUIPMENT = 68,
		STATUS_LABEL_PAPERDOLL_BELT_EQUIPMENT = 69,
		STATUS_LABEL_PAPERDOLL_RING_EQUIPMENT = 70,
		STATUS_LABEL_PAPERDOLL_ARMLET_EQUIPMENT = 71,
		STATUS_LABEL_PAPERDOLL_BRACER_EQUIPMENT = 72,
		STATUS_LABEL_PAPERDOLL_GLOVES_EQUIPMENT = 73,
		STATUS_LABEL_PAPERDOLL_BOOTS_EQUIPMENT = 74,
		STATUS_LABEL_PAPERDOLL_MISC_EQUIPMENT = 75,
		STATUS_LABEL_ITEM_DROP_OUT_OF_RANGE = 76,
		STATUS_LABEL_INVENTORY_SHOW_YOUR_PAPERDOLL = 77,

		STATUS_LABEL_ITEM_EQUIP_DOES_NOT_FIT_GENDER = 79,
		STATUS_LABEL_ITEM_EQUIP_TYPE_ALREADY_EQUIPPED = 80,
		STATUS_LABEL_ITEM_UNEQUIP_NO_SPACE_LEFT = 81,

		CHAT_MESSAGE_MUTED_BY = 83,
		STATUS_LABEL_MINUTES_MUTED = 84,
		DIALOG_ITS_TOO_HEAVY_WEIGHT = 85,
		STATUS_LABEL_YOU_GAINED_EXP = 86,
		STATUS_LABEL_ITEM_PICKUP_PROTECTED = 87,
		STATUS_LABEL_ITEM_PICKUP_PROTECTED_BY = 88,
		STATUS_LABEL_NO_MAP_OF_AREA = 89,
		STATUS_LABEL_ITEM_USE_DRUNK = 90,

		STATUS_LABEL_CHEST_YOU_OPENED = 92,

		STATUS_LABEL_TRADE_REQUESTED_TO_TRADE = 96,
		STATUS_LABEL_TRADE_RECENTLY_REQUESTED = 97,
		STATUS_LABEL_TRADE_YOU_ARE_TRADING_WITH = 98,
		STATUS_LABEL_TRADE_OTHER_ACCEPT = 99,
		STATUS_LABEL_TRADE_YOU_ACCEPT = 100,
		STATUS_LABEL_TRADE_OTHER_CANCEL = 101,
		STATUS_LABEL_TRADE_YOU_CANCEL = 102,
		STATUS_LABEL_TRADE_ABORTED = 103,
		DIALOG_TRADE_WORD_AGREE = 104,
		DIALOG_TRADE_WORD_TRADING = 105,
		DIALOG_TRANSFER_OFFER = 106,
		DIALOG_TRANSFER_NOT_ENOUGH_SPACE = 107,
		DIALOG_TRANSFER_NOT_ENOUGH_WEIGHT = 108,
		STATUS_LABEL_TRADE_OTHER_PLAYER_CHANGED_OFFER = 109,
		//STATUS_LABEL_CHEST_YOU_OPENED = 110, //duplicate of 92?
		//chest seems broken - not sure when this is used
		//door seems broken - not sure when this is used
		STATUS_LABEL_THE_CHEST_IS_LOCKED_EXCLAMATION = 113,
		STATUS_LABEL_THE_DOOR_IS_LOCKED_EXCLAMATION = 114,
		STATUS_LABEL_DRAG_AND_DROP_ITEMS = 115,

		STRING_SERVER = 118,
		SERVER_MESSAGE_MAP_MUTATION = 119,
		STATUS_LABEL_NOTHING_HAPPENED = 120,

		DIALOG_SHOP_BUY_ITEMS = 122,
		DIALOG_SHOP_SELL_ITEMS = 123,
		DIALOG_SHOP_CRAFT_ITEMS = 124,
		DIALOG_BANK_WITHDRAW = 125,
		DIALOG_BANK_DEPOSIT = 126,
		DIALOG_SHOP_PRICE = 127,
		MALE = 128,
		FEMALE = 129,
		DIALOG_TRANSFER_BUY = 130,
		DIALOG_TRANSFER_SELL = 131,
		DIALOG_TRANSFER_WITHDRAW = 132,
		DIALOG_TRANSFER_DEPOSIT = 133,
		DIALOG_SHOP_ITEMS_IN_STORE = 134,
		DIALOG_SHOP_ITEMS_ACCEPTED = 135,
		DIALOG_BANK_TAKE = 136,
		DIALOG_BANK_FROM_ACCOUNT = 137,
		DIALOG_BANK_TRANSFER = 138,
		DIALOG_BANK_TO_ACCOUNT = 139,
		DIALOG_WORD_BUY = 140,
		DIALOG_WORD_SELL = 141,
		DIALOG_WORD_FOR = 142,
		STATUS_LABEL_YOU_SOLD = 143,
		STATUS_LABEL_YOU_BOUGHT = 144,
		DIALOG_TITLE_PRIVATE_LOCKER = 145,

		STATUS_LABEL_IGNORE_LIST = 149,
		STATUS_LABEL_FRIEND_LIST = 150,
		STATUS_LABEL_USE_RIGHT_MOUSE_CLICK_DELETE = 151,
		GLOBAL_CHAT_SERVER_MESSAGE_1 = 152,
		GLOBAL_CHAT_SERVER_MESSAGE_2 = 153,
		STATUS_LABEL_WILL_BE_YOUR_FRIEND = 154,
		DIALOG_WHO_TO_MAKE_IGNORE = 155,
		DIALOG_WHO_TO_MAKE_FRIEND = 156,
		DIALOG_SHOP_CRAFT_INGREDIENTS = 157,
		DIALOG_SHOP_CRAFT_MISSING_INGREDIENTS = 158,
		DIALOG_SHOP_CRAFT_PUT_INGREDIENTS_TOGETHER = 159,

		DIALOG_TRADE_BOTH_PLAYERS_OFFER_ONE_ITEM = 165,

		DIALOG_TRANSFER_TRANSFER = 176,

		SETTING_KEYBOARD_ENGLISH = 253,
		SETTING_KEYBOARD_DUTCH = 254,
		SETTING_KEYBOARD_SWEDISH = 255,
		SETTING_KEYBOARD_AZERTY = 256,

		JAIL_WARNING_CANNOT_DROP_ITEMS = 275,
		JAIL_WARNING_CANNOT_TRADE = 276,
		JAIL_WARNING_CANNOT_USE_GLOBAL = 277,

		STATUS_LABEL_KEEP_MOVING_THROUGH_PLAYER = 278,

		DIALOG_TITLE_PERFORMANCE = 286,
		DIALOG_PERFORMANCE_TOTALEXP = 287,
		DIALOG_PERFORMANCE_NEXT_LEVEL = 288,
		DIALOG_PERFORMANCE_EXP_NEEDED = 289,
		DIALOG_PERFORMANCE_TODAY_EXP = 290,
		DIALOG_PERFORMANCE_TOTAL_AVG = 291,
		DIALOG_PERFORMANCE_TODAY_AVG = 292,
		DIALOG_PERFORMANCE_BEST_KILL = 293,
		DIALOG_PERFORMANCE_LAST_KILL = 294,

		SKILLMASTER_WORD_SPELL = 297,
		SKILLMASTER_WORD_SKILL = 298,

		STATUS_LABEL_THE_NPC_DROPPED = 305,

		SKILLMASTER_WORD_LEARN = 334,
		SKILLMASTER_ITEMS_TO_LEARN = 335,
		SKILLMASTER_WORD_FORGET = 336,
		SKILLMASTER_ITEMS_LEARNED = 337,
		SKILLMASTER_WORD_REQUIREMENTS = 338,
		SKILLMASTER_WORD_LEVEL = 339,
		SKILLMASTER_WORD_STRENGTH = 340,
		SKILLMASTER_WORD_INTELLIGENCE = 341,
		SKILLMASTER_WORD_WISDOM = 342,
		SKILLMASTER_WORD_AGILITY = 343,
		SKILLMASTER_WORD_CONSTITUTION = 344,
		SKILLMASTER_WORD_CHARISMA = 345,
		STATUS_LABEL_CANNOT_ATTACK_OVERWEIGHT = 346,
		SKILLMASTER_FORGET_ALL = 347,
		SKILLMASTER_FORGET_ALL_MSG_1 = 348,
		SKILLMASTER_FORGET_ALL_MSG_2 = 349,
		SKILLMASTER_FORGET_ALL_MSG_3 = 350,
		SKILLMASTER_CLICK_HERE_TO_FORGET_ALL = 351,
		SKILLMASTER_RESET_YOUR_CHARACTER = 352,

		ACCOUNT_CREATE_WARNING_DIALOG_1 = 357,
		ACCOUNT_CREATE_WARNING_DIALOG_2 = 358,
		ACCOUNT_CREATE_WARNING_DIALOG_3 = 359,
		LOADING_GAME_UPDATING_MAP = 360,
		LOADING_GAME_UPDATING_ITEMS = 361,
		LOADING_GAME_UPDATING_NPCS = 362,
		LOADING_GAME_UPDATING_SKILLS = 363,
		LOADING_GAME_UPDATING_CLASSES = 364,
		LOADING_GAME_UPDATING_GUILDS = 365,
		LOADING_GAME_LOADING_GAME = 366,
		LOADING_GAME_PLEASE_WAIT = 367,
		LOADING_GAME_HINT_FIRST = 368,
		LOADING_GAME_HINT_LAST = 374,

		STATUS_LABEL_UNABLE_TO_ATTACK = 423,

		STATUS_LABEL_YOUR_LOCATION_IS_AT = 427,
		STATUS_LABEL_IS_ONLINE_IN_THIS_WORLD = 428,
		STATUS_LABEL_IS_ONLINE_SAME_MAP = 429,
		STATUS_LABEL_IS_ONLINE_NOT_FOUND = 430,
		DIALOG_BANK_LOCKER_UPGRADE = 431,
		DIALOG_BANK_MORE_SPACE = 432,
		STATUS_LABEL_LOCKER_SPACE_INCREASED = 433
	}
}
