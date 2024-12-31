
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <iostream>
#include <thread>
#include <atomic>
#include <chrono>
#include <unordered_map>
#include "common.h"

// window stuff
#include <commctrl.h>
#include "resource.h"

// raknet stuff
#include "PacketEnumerations.h"
#include "RakNetworkFactory.h"
#include "RakClientInterface.h"
#include "NetworkTypes.h"
#include "BitStream.h"
#include "StringCompressor.h"

#pragma warning(disable:4996)

#include "samp_netencr.h"
#include "samp_auth.h"
#include "SAMPRPC.h"

#include "netgame.h"
#include "netrpc.h"
#include "localplayer.h"
#include "misc_funcs.h"
#include "math_stuff.h"

#include "cmds.h"
#define ServerIp "185.112.33.99"
#define ServerPort 7777
struct stServer
{
	char szAddr[256];
	int iPort;
};

struct stSettings
{
	struct stServer server;
	int iClassID;
	int iUpdateStats;
	char szClientVersion[20];
	bool isConsole;
	char pin[5];
	bool bHaveUser;
	char userName[32];
	char userPassword[128];
};
extern struct stSettings settings;
struct stRakClient
{
	RakClientInterface* rakClient;
	char nickName[32];
	PLAYERID playerid;
	int drunkLevel;
	int lastDrunkLevel;
	int money;
	int lastMoney;
	unsigned long long lastStatsUpdate;
	float playerHealth;
	float playerArmour;
	float normalModePos[3];
	float currentPosition[3];
	float normalModeRot;
	PLAYER_SPAWN_INFO SpawnInfo;
	unsigned short dialogid;
	bool connectionRequested;
	bool callSampRequestClass;
	bool gameInited;
	bool areWeConnected;
	bool isConnected;
	bool isSpectating;
	bool spawned;
	bool logined;
	bool pin;
	unsigned long long sleepTime;
};
extern stRakClient client;
void Log(const char* fmt, ...);
bool isSubstring(const char* input, const char* substr);
