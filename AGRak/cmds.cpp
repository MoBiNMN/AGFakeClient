#include "main.h"

void RunCommand(char* szCMD)
{
	if (szCMD[0] == 0x00)
		return;
	if (settings.isConsole)
		memset(&szCMD[(strlen(szCMD) - 2)], 0, 2);
	if (szCMD[0] == '!') {
		szCMD++;
		if (!strncmp(szCMD, "seltd", 5) || !strncmp(szCMD, "SELTD", 5))
		{
			int iSelectableTextDrawID;

			if (sscanf(&szCMD[6], "%d", &iSelectableTextDrawID) < 1)
			{
				Log("USAGE: !seltd <TextDrawID>");
				return;
			}

			selectTextDraw(iSelectableTextDrawID);
			return;
		}
		else if (!strncmp(szCMD, "dr", 2) || !strncmp(szCMD, "DR", 2))
		{
			int szDialogID, szButtonID, szListBoxItem;
			char szInputResp[128];

			if (sscanf(&szCMD[3], "%d%d%d%s", &szDialogID, &szButtonID, &szListBoxItem, szInputResp) < 4)
			{
				Log("USAGE: (dialogResponse) !dr <Dialog ID> <Button ID> <Listbox item> <Input response>");
				return;
			}

			sendDialogResponse(szDialogID, szButtonID, szListBoxItem, szInputResp);
			return;
		}
	}
	else if (szCMD[0] == '/') sendServerCommand(szCMD);
	else sendChat(szCMD);
}
