#include <string> 

#include "main.h"

stRakClient client{};
FILE* flLog = NULL;
stSettings settings{};
bool lg = false;
std::atomic<bool> running(true);
char szInputBuffer[512];
bool isEmpty(const char* str) {
	
	if (strlen(str) == 0) return true;

	
	for (size_t i = 0; i < strlen(str); i++) {
		if (str[i] != ' ') {
			return false;  
		}
	}

	return true;  
}
 


void processInput() {
	

	while (running) {
		
		std::cin.getline(szInputBuffer, 512); 
		RunCommand(szInputBuffer);
		Sleep(100);
	}
}
int main(int argc, char* argv[]) {
	srand((unsigned int)GetTickCount64());
	if (argc > 1) {
		for (int i = 1; i < argc; i++) {
			if (isSubstring(argv[i], "--log")) {
				lg = true;
				break;
			}
		}
		for (int i = 1; i < argc; i++) {
			if (isSubstring(argv[i], "--connect")) {
				
				if (i + 2 < argc) {
					strcpy(settings.userName, argv[i + 1]);
					strcpy(settings.userPassword, argv[i + 2]);
					if (i + 3 < argc) {
						strcpy(settings.pin, argv[i + 3]);
					}
					else {
						strcpy(settings.pin, "0"); 
					}
					break;
				}
			}
		}
		if (strlen(settings.userName) == 0 || strlen(settings.userPassword) == 0) {
			Log("Username and password is empty!");
			return 1;
		}
	}
	else {
		Log("Example: AGRak.exe --connect user pass pin");
		return 1;
	}
	settings.iClassID = 19;
	settings.iUpdateStats = 1;
	strcpy(settings.server.szAddr, ServerIp);
	settings.server.iPort = ServerPort;


	auto* rakClient = client.rakClient = RakNetworkFactory::GetRakClientInterface();
	if (rakClient == NULL) return 0;
	rakClient->SetMTUSize(576);
	RegisterRPCs();
	char szInfo[1024];
	int whileCounter = 20;
	std::thread inputThread(processInput);
	while (true)
	{
		if (!whileCounter)
		{
			sprintf_s(szInfo, sizeof szInfo, "AGRak %s - Username: %s", RAKSAMP_VERSION, settings.userName);
			if (client.logined)
			{
				strcat(szInfo, " (");
				strcat(szInfo, std::to_string(client.playerid).c_str());
				strcat(szInfo, ")");
			}
			SetConsoleTitle(szInfo);

			szInfo[0] = '\0';
		}

		UpdateNetwork();

		if (client.sleepTime)
		{
			if (GetTickCount64() > client.sleepTime)
			{
				client.connectionRequested = false;
				client.sleepTime = 0;
			}
		}
		else
		{
			if (!client.connectionRequested)
			{
				sampConnect();
				client.connectionRequested = true;
			}

			if (client.areWeConnected && client.gameInited)
			{
				if (!client.spawned)
				{
					if (!client.callSampRequestClass)
					{
						sampRequestClass();
						client.callSampRequestClass = 1;
					}
				}
				else
				{
					if (!client.isSpectating) onFootUpdateAtNormalPos();
					else spectatorUpdate();

					const auto tickCount = GetTickCount64();
					if (tickCount - client.lastStatsUpdate >= 1000 || client.money != client.lastMoney || client.drunkLevel != client.lastDrunkLevel)
					{
						RakNet::BitStream bsSend;
						bsSend.Write((BYTE)ID_STATS_UPDATE);
						client.drunkLevel -= (rand() % 90 + 20);
						if (client.drunkLevel < 0) client.drunkLevel = 0;
						bsSend.Write(client.money);
						bsSend.Write(client.drunkLevel);
						client.rakClient->Send(&bsSend, HIGH_PRIORITY, RELIABLE, 0);
						client.lastMoney = client.money;
						client.lastDrunkLevel = client.drunkLevel;
						client.lastStatsUpdate = tickCount;
					}
				}
			}
		}
		
		if (!whileCounter) whileCounter = 20;
		else --whileCounter;
		Sleep(50);

	}

	if (flLog != NULL)
	{
		fclose(flLog);
		flLog = NULL;
	}
	running = false;
	inputThread.join();
	return 0;
}

void Log(const char* fmt, ...)
{
	char buffer[512];
	memset(buffer, 0, 512);

	va_list args;
	va_start(args, fmt);
	vsprintf_s(buffer, 512, fmt, args);
	va_end(args);
	std::cout << buffer << std::endl;
	if (lg) {
		if (flLog == NULL)
		{
			char fileName[256];
			snprintf(fileName, sizeof(fileName), "AGFakeLog-%s.txt", settings.userName);
			for (int i = 9; fileName[i] != '\0'; ++i) {
				fileName[i] = static_cast<char>(tolower(fileName[i]));
			}
			flLog = fopen(fileName, "a");

			if (flLog == NULL)
				return;
		}
		SYSTEMTIME time;
		GetLocalTime(&time);

		fprintf(flLog, "[%02d:%02d:%02d.%03d] ", time.wHour, time.wMinute, time.wSecond, time.wMilliseconds);

		fprintf(flLog, buffer);
		fprintf(flLog, "\n");
		fflush(flLog);
	}

}

bool isSubstring(const char* input, const char* substr) {
	while (*input != '\0') {
		const char* p1 = input;
		const char* p2 = substr;
		while (*p1 != '\0' && *p2 != '\0' && *p1 == *p2) {
			++p1;
			++p2;
		}
		if (*p2 == '\0') {
			return true;
		}
		++input;
	}
	return false; 
}
