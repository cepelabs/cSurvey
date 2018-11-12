#pragma once
//#include "OgreColourValue.h"
#include "CMTypes.h"

namespace CM {

class Debug {
public:
	static Debug* inst();
	void drawLine(V3 p0, V3 p1, const Color& color) { }

protected:
	static Debug* instance;
};

#define DEBUG_DRAW(__p0, __p1, __color) Debug::inst()->drawLine(p0, p1, color);

}
