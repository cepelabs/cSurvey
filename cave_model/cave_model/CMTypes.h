#pragma once
#include "ogre/OgreVector3.h"
#include "ogre/OgreVector2.h"
#define _USE_MATH_DEFINES
#include <math.h>

namespace CM {

extern float PointsInMeter;

typedef Ogre::Vector3 V3;
typedef Ogre::Vector2 V2;


enum GenerateWallsForNoWallsPiketsMode { //если между двумя пикетами со стенами есть пикеты без стен
	GWNWPM_NONE,     // пикеты со стенами между собой не не соединяются
    GWNWPM_SKIP,     // пикеты со стенами соединяются между собой так как будто они соседние
    GWNWPM_TRAIL,    // стены интерполируются на пикетах без стен и петляют вслед за ними
    GWNWPM_BUDGE,    // стены интерполируются но сдвигаются так, чтобы все промежуточные пикеты были внутри объема
    GWNWPM_NUM
};

typedef GenerateWallsForNoWallsPiketsMode FakeWallsMode;

enum WallsPropagateMode {
    WPM_NONE,
    WPM_4M, // add wall every 4 meters
    WPM_2M, // add wall every 2 meters
    WPM_1M, // add wall every 1 meters
    WPM_NUM,
    WPM_X2, // twice walls num
    WPM_X4, // x4 walls num
    WPM_10D, // add wall every 10 degree
    WPM_20D, // add wall every 20 degree
    WPM_30D, // add wall every 30 degree
};

enum WallsShadowMode {
    WSM_ROUGH,   // плоские тени на стенах
	WSM_SMOOTH,  // гладкие(округлые) округлые тени
    WSM_NUM
};

enum WallsBlowMode {
    WBM_NONE,      // нет раздутия совсем, доп, стены лежат на прямой между пикетами
    WBM_BESIER3,   // использование Безье 2 порядка
    WBM_NUM,
    WBM_LINEAR,    // скругление пропорционально смещению
    WBM_COS2PI,    // увеличенное у концов скругление
    WBM_COSCOS2PI, // дважды увеличенное у концов скругление (сильно раздутые стены)
};

enum WallsTrianglesBlowMode {
    WTBM_NONE,      // нет раздутия треугольников
    WTBM_4,         // каждый треугольник заменяется 4мя
    WTBM_9,         // каждый треугольник заменяется 9ю
    WTBM_16,        // каждый треугольник заменяется x16
    WTBM_24,        // каждый треугольник заменяется x24
    WTBM_33,        // каждый треугольник заменяется x22
    WTBM_44,        // каждый треугольник заменяется x44
    WTBM_57,        // каждый треугольник заменяется x57
    WTBM_NUM,
};

enum WallsTrianglesBlowStrength {
    WTBS_LOW,         // слабое надутие
    WTBS_MEDIUM,      // среднее надутие
    WTBS_STRONG,      // сильное надутие
    WTBS_HUDGE,       // огромное надутие
    WTBS_NUM,
};

enum WallsSurfaceMode {
    WSFM_NONE,     // поверхность не рисуется
    WSFM_SURF,     // поверхность рисуется
    WSFM_NUM,
};

enum WallsSegmentTriangulationMode {
    WSTM_CONVEX_POLY, // рекурсивным методом на основе строго выпуглых многоугольников
    WSTM_CONVEX_QUAD, // методом на основе выпуглых четырехугольников
    WSTM_NUM,
    WSTM_ANGLE,     // методом на основеw центрального угла
};

enum AmbientLightStrength {
    ALS_100,
    ALS_90,
    ALS_75,
    ALS_50,
    ALS_30,
    ALS_10,
    ALS_00,
    ALS_NUM
};

enum WallColoringMode {
    WCM_SMOOTH,
    WCM_TIGHTNESS_SMOOTH,
    WCM_DEPTH_SMOOTH,
    WCM_NUM,
    WCM_ROUGE
};

enum RenderSimpleMode {
	SM_ORIGINAL, // оригинальный режим работы, старый рендерер, никаких поверхностей
	SM_OUTLINE, // walls projection to camera
	SM_SECTIONS_WALLS, // новый рендерер, рисуются сечени, стены отображаются проволокой
	SM_ROUGH_WALLS, // новый рендерер, без постобработки полигонов
	SM_SMOOTH_WALLS, // новый рендерер, "мягкое" освещение, "деформация" полигонов
	SM_NUM
};

struct CaveViewPrefs {
    bool operator== (const CaveViewPrefs& o2) {
        return surfColorId == o2.surfColorId
        && dupColorId == o2.dupColorId
        && stretchWallsOverPiketNumMax == o2.stretchWallsOverPiketNumMax
        && stretchWallsOverPiketLengthMax == o2.stretchWallsOverPiketLengthMax
        && wallsPropagateMode == o2.wallsPropagateMode
        && wallsShadowMode == o2.wallsShadowMode
        && wallsBlowMode == o2.wallsBlowMode
        && wallsSurfaceMode == o2.wallsSurfaceMode
        && showDebug == o2.showDebug
        && generateWallsForNoWallsPiketsMode == o2.generateWallsForNoWallsPiketsMode
        && wallsSegmentTriangulationMode == o2.wallsSegmentTriangulationMode
        && wallsTrianglesBlowMode == o2.wallsTrianglesBlowMode
        && wallsTrianglesBlowStrength == o2.wallsTrianglesBlowStrength
        && ambientLightStrength == o2.ambientLightStrength
        && wallColoringMode == o2.wallColoringMode
        && showThread == o2.showThread
		&& showSections == o2.showSections
		&& showWallLines == o2.showWallLines
		&& showBox == o2.showBox
		&& fillRate == o2.fillRate
		&& lookDirrection == o2.lookDirrection
		&& showOutline == o2.showOutline
		&& skipNum == o2.skipNum
		&& darkMode == o2.darkMode
		&& grayscale == o2.grayscale
   		&& allOutlineCuts == o2.allOutlineCuts;
		
    }

    bool operator!= (const CaveViewPrefs& o2) { return !(*this == o2); };

    int surfColorId{-1};
    int dupColorId{-1};
    int stretchWallsOverPiketNumMax{8};
    int stretchWallsOverPiketLengthMax{50};
    WallsPropagateMode wallsPropagateMode{WPM_NONE};
    WallsShadowMode wallsShadowMode{WSM_SMOOTH};
    WallsBlowMode wallsBlowMode{WBM_NONE};
    WallsSurfaceMode wallsSurfaceMode{WSFM_NONE};
    GenerateWallsForNoWallsPiketsMode generateWallsForNoWallsPiketsMode{GWNWPM_BUDGE};
    WallsSegmentTriangulationMode wallsSegmentTriangulationMode{WSTM_CONVEX_POLY};
    WallsTrianglesBlowMode wallsTrianglesBlowMode{/*WTBM_16*/WTBM_NONE};
    WallsTrianglesBlowStrength wallsTrianglesBlowStrength{WTBS_MEDIUM};
    AmbientLightStrength ambientLightStrength{ALS_50};
    WallColoringMode wallColoringMode{WCM_TIGHTNESS_SMOOTH};
	bool showThread{true};
	bool showSections{false};
	bool showWallLines{false};
	bool showBox{false};
	V3 lookDirrection{0, 0, 0};
	bool showOutline{false};
	float fillRate{1.0f}; // 0..1
	bool showDebug {false};
    int skipNum {0};
	bool darkMode {false};
	bool grayscale {false};
    bool allOutlineCuts {true};
};

struct Color {
	Color(): r(1), g(1), b(1), a(1) {}
	Color(float r, float g,	float b, float a = 1.0f): r(r), g(g), b(b), a(a) {}

	bool operator!= (const Color& c1) const {
		return !(*this == c1);
	}

	bool operator== (const Color& c1) const {
		return r == c1.r && g == c1.g && b == c1.b && a == c1.a;
	}

	Color operator+ (const Color& c1) const {
		return Color(r + c1.r, g + c1.g, b + c1.b, a + c1.a);
	}

	void operator+= (const Color& c1) {
		r += c1.r;
		g += c1.g;
		b += c1.b;
		a += c1.a;
	}

	Color operator/ (float f) const {
		return Color(r / f, g / f, b / f, a / f);
	}

	void operator/= (float f) {
		r /= f;
		g /= f;
		b /= f;
		a /= f;
	}

	Color operator* (float f) const {
		return Color(r * f, g * f, b * f, a * f);
	}

	static Color None;
	static Color White;
	static Color Red;
	static Color Blue;
	static Color Green;

	float r;
	float g;
	float b;
	float a;

	bool isNone() const { return *this == None; }
};

inline Color operator* (float f, const Color& c) {
	return c*f;
}

enum OutputType {
	OT_UNKNOW = 0,
	OT_NONE = 0,
	OT_THREAD = 1,
	OT_WALL = 2,
	OT_WALL_CUTS = 4,
	OT_DEBUG = 8,
    OT_DEBUG2 = 16,
	OT_BOX = 32,
	OT_OUTLINE = 64,
	OT_OUTLINE_CUT = 128,
	OT_ALL = ~OT_NONE,
};

struct OutputPoly {
	V3 a;
	V3 an;
	V3 b;
	V3 bn;
	V3 c;
	V3 cn;
	Color ca;
	Color cb;
	Color cc;
};

struct OutputLine {
	V3 a;
	V3 b;
	Color ca;
	Color cb;
};

struct Wall {
	Wall(V3 p): pos(p)  {}
	V3 pos;
};

enum PiketMark {
	MARK_NONE = 0,
	MARK_Z_SURVEY = 1,
	MARK_Z_TURN = 2,
	MARK_Z_SURVEY_FAKE = 4, // пикет - автогенеренный в результате зиг-заг съемки
	MARK_ONLY_CONVEX_WALLS = 8 //исползовать триангуляцию отбрасывающую вогнутые стены
};

struct PiketInfo {
	PiketInfo(): id(getUniqId()), pos(0,0,0), extendedElevationX(0), priz(MARK_NONE), hasWalls(0) { }
	int id;
	std::string name;
	std::string label;
	V3 pos;
	float extendedElevationX;
//	Color col;
	PiketMark priz;
	int hasWalls;

	static int getUniqId();
};

struct EdgeInfo {
	EdgeInfo() : fromPiketId(0), toPiketId(0), zsurvey(0) { }
	EdgeInfo(int from, int to, const Color& col = Color::None) : fromPiketId(from), toPiketId(to), col(col) { }
	bool isEmpty() const { return fromPiketId == 0 && toPiketId == 0; }

	int fromPiketId;
	int toPiketId;
	Color col;
	bool zsurvey;
};

inline bool operator<(const std::pair<int, int>& p1, const std::pair<int, int>& p2) {
	if (p1.first != p2.first) return p1.first < p2.first;
	else return p1.second < p2.second;
}


struct LineBesier3 {
	LineBesier3() :
		a(0, 0, 0),
		ac(0, 0, 0),
		bc(0, 0, 0),
		b(0, 0, 0) { }

	V3 a;
	V3 ac;
	V3 bc;
	V3 b;
};

struct CrossPiketLineBesier3 : public LineBesier3 {
	CrossPiketLineBesier3(int aid, int bid, const LineBesier3& b) :
		LineBesier3(b),
		aid(aid),
		bid(bid) { }
	CrossPiketLineBesier3() :
		aid(0),
		bid(0) { }

	int aid;
	int bid;
};

struct CrossPiketLine2dBesier3  {
    V2 a {0, 0};
	V2 ac {0, 0};
	V2 bc {0, 0};
	V2 b {0, 0};
	int aid {0};
	int bid {0};
};


}
