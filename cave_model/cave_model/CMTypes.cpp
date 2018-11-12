#include "CMTypes.h"

namespace CM {
	float PointsInMeter = 100.0f;
};

using namespace CM;

Color Color::Red(1, 0, 0);
Color Color::Blue(0, 0, 1);
Color Color::Green(0, 1, 0);
Color Color::White(1, 1, 1);

Color Color::None(0, 0, 0, 0);

int PiketInfo::getUniqId() {
	static int staticCounter = 0;
	return ++staticCounter;
}
