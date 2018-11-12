#include "CMDebug.h"

namespace CM {

Debug* Debug::instance = NULL;

Debug* Debug::inst() {
	if (!instance) {
		instance = new Debug();
	}
	return instance;
}
}
