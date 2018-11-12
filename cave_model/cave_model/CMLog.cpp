#include "CMLog.h"

CMLog* CMLog::instatnce = NULL;
CMLog* CMLog::inst() {
	if (!instatnce) instatnce = new CMLog;
	return instatnce;
}
