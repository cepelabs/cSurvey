//---------------------------------------------------------------------------
#pragma once          
#include "CMTypes.h"
#include <set>
#include "OgreVector2.h"
#include "OgreMath.h"
#include "wykobi_wrap.h"
namespace CM {


#define CLOCKWISE true
#define CONTERCLOCKWISE false


inline V3 projectPointToLine(V3 lineA, V3 lineB, V3 point) {
    V3 A = lineA;
    V3 B = lineB;
    V3 P = point;
    V3 AB = B - A;
    V3 AP = P - A; 

    V3 a = AB * (AB.dotProduct(AP)/AB.dotProduct(AB)) ;
    return A + a;
}

inline float projectPointToVector(V3 vector, V3 point) {
	return vector.dotProduct(point) / vector.dotProduct(vector);
// 	V3 projection = projectPointToLine(V3::ZERO, vector, point);
// 	if (projection.angleBetween(vector).valueRadians() < M_PI) {
// 		return vector.length();
// 	} else {
// 		return -vector.length();
// 	}
}

inline V3 triangleNormal(V3 a, V3 b, V3 c) {
    return ((a - b).crossProduct(c - a).normalisedCopy());                      
}
                          
struct PiketWall {
    PiketWall(const V3& p, int o = -1)
    : pos(p), outerToPiket(o)
    { }
    
    V3 pos;
    // -1 - innner, other - outer
    int outerToPiket;    
};

struct SurfaceTriangle {
    SurfaceTriangle(const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) :
    ca(ca), cb(cb), cc(cc), a(a), an(an), b(b), bn(bn), c(c), cn(cn) { }
    Color ca;
    Color cb;
    Color cc;
    V3 a;
    V3 b;
    V3 c;
    V3 an;
    V3 bn;
    V3 cn;
};

struct WallTriangle {
    WallTriangle(const Color& ca, const Color& cb, const Color& cc, bool clockwise, const PiketWall& a, const PiketWall& b, const PiketWall& c) :
    ca(ca), cb(cb), cc(cc), clockwise(clockwise), a(&a), b(&b), c(&c) { }
	Color ca;
	Color cb;
    Color cc;
    bool clockwise;
    const PiketWall* a;
    const PiketWall* b;
    const PiketWall* c;
};

struct VerticeTriangle {
    VerticeTriangle(const Color& ca, const Color& cb, const Color& cc, bool clockwise, const V3& a, const V3& b, const V3& c) :
    ca(ca), cb(cb), cc(cc), clockwise(clockwise), a(a), b(b), c(c) { }
    Color ca;
    Color cb;
    Color cc;
    bool clockwise;
    V3 n;
    V3 a;
    V3 b;
    V3 c;
};

typedef std::vector<std::pair<const PiketWall*, const PiketWall*> > WallEdges;
typedef std::vector<WallTriangle> WallTriangles;    
    
struct WallNormal {
    WallNormal():
    normalCollect(0, 0, 0),
    assumWeight(0) { }
    void add(Ogre::Vector3 n, float weight) {
        normalCollect += n * weight;
        assumWeight += weight;
    }
    Ogre::Vector3 get() {
        if (assumWeight == 0) return V3(0, 0, 0);            
        return normalCollect/assumWeight; 
    }
       
protected:
    Ogre::Vector3 normalCollect;
    float assumWeight;
};

struct Vertice {
    Vertice():
    x(0), y(0), z(0) { }

    Vertice(const V3& vec):
    x((int)(vec.x * 0.02f * PointsInMeter)), y((int)(vec.y * 0.02f * PointsInMeter)), z((int)(vec.z * 0.02f * PointsInMeter)) { }

    bool operator< (const Vertice& vtc) const {
        return x < vtc.x || ( x == vtc.x && (y < vtc.y || y == vtc.y && z < vtc.z)); 
    }

    int x, y, z;    
};

struct VerticeNormal {
    VerticeNormal():
    normalCollect(0, 0, 0),
    assumWeight(0) { }
    void add(Ogre::Vector3 n, float weight) {
        if (!n.isZeroLength()) {
            normalCollect += n * weight;
            assumWeight += weight;
        }
    }
    Ogre::Vector3 get() {
        if (assumWeight == 0) return V3(0, 0, 0);
        return normalCollect/assumWeight;
    }
       
protected:
    Ogre::Vector3 normalCollect;
    float assumWeight;
};

struct WallProj {
    WallProj(int idx, V2 posBySelfDir, Ogre::Radian to0XAngleBySelfDir/*, V2 posByGlobalDir, Ogre::Radian to0XAngleByGlobalDir*/):
    idx(idx), posBySelfDir(posBySelfDir), to0XAngleBySelfDir(to0XAngleBySelfDir)/*, posByGlobalDir(posByGlobalDir), to0XAngleByGlobalDir(to0XAngleByGlobalDir)*/{ }
                
    static bool compareBySelf0XAngle(const WallProj& w1, const WallProj& w2);
    static int minSelf0XAngleWallPoint(WallProj point, const std::vector<WallProj>& rotWalls, bool abs, int skipPoint);
    
    int idx;
    V2 posBySelfDir;
	Ogre::Radian to0XAngleBySelfDir;
//     V2 posByGlobalDir;
// 	Ogre::Radian to0XAngleByGlobalDir;
};

struct ExtWallProj: public WallProj {
	ExtWallProj(int idx, V2 posBySelfDir, Ogre::Radian to0XAngleBySelfDir, V2 posByGlobalDir/*, Ogre::Radian to0XAngleByGlobalDir*/) :
		WallProj(idx, posBySelfDir, to0XAngleBySelfDir), posByGlobalDir(posByGlobalDir)/*, to0XAngleByGlobalDir(to0XAngleByGlobalDir)*/ { }
	ExtWallProj(const WallProj& wproj, V2 posByGlobalDir/*, Ogre::Radian to0XAngleByGlobalDir*/) :
		WallProj(wproj), posByGlobalDir(posByGlobalDir)/*, to0XAngleByGlobalDir(to0XAngleByGlobalDir)*/ { }

	V2 posByGlobalDir;
	//Ogre::Radian to0XAngleByGlobalDir;
};


// возврадает отсортированные по углу вокруг оси selfDirrection проход€щей чере center
// вершины двумерного многоугольника - проекции
// стен пикета на плоскость с нормалью selfDirrection и центром center
// заодно вычил€ет двумерные углы и позиции дл€ нормали globadDirrection
std::vector<WallProj> getWalls2d(V3 center, V3 selfDirrection/*, V3 globalDirrection*/, const std::vector<PiketWall>& walls); 
std::vector<WallProj> getWalls2dWithConvexCorrection(V3 center, V3 selfDirrection/*, V3 globalDirrection*/, const std::vector<PiketWall>& walls);  

float sinusate(float val);

float trinagleSquare(V2 a, V2 b, V2 c);
V2 trinagleCenter(V2 a, V2 b, V2 c);  
//V2 polyCenter(const std::vector<WallProj>& vert); 
float polySquare(const std::vector<WallProj>& vert);

float trinagleSquare(V3 a, V3 b, V3 c);
V3 trinagleCenter(V3 a, V3 b, V3 c);  

template<typename T>
class ComareObjByAdr {
public:
    ComareObjByAdr(const PiketWall* p): p(p) { }
    bool operator()(const PiketWall& o) { return (&o) == p; }
protected:
    const PiketWall* p;
};

WallEdges separateTriangleForEdges(const WallTriangles& wallPairs, const std::vector<PiketWall>& piketsA, const std::vector<PiketWall>& piketsB);

// a0, b0 - fixed edge
// a0, a1- walls for piket a
// b0, b1- walls for piket b
// there is two possible triangulations :
//  a0 b0 a1, a1 b0 b1 - A triangulation
//  a0 b0 b1, a0 b1 a1 - B triangulation
// function calc is A triangulation convex relative point C
bool isQuadrangleATriangulationIsConvexRalativePoint(V3 a0, V3 b0, V3 a1, V3 b1, V3 C);

// dirrection - some master dirrection from a piket to b piket. 
// a0, b0 - fixed edge
// a0, a1- walls for piket a
// b0, b1- walls for piket b
// there is two possible triangulations :
//  a0 b0 a1, a1 b0 b1 - A triangulation
//  a0 b0 b1, a0 b1 a1 - B triangulation
// function calc is A triangulation convex clockwise order
bool isQuadrangleATriangulationIsConvexClockwise(V3 dirrection, V3 a0, V3 b0, V3 a1, V3 b1);    
bool isQuadrangleATriangulationIsConvexClockwise(V3 dirrection, V3 a_1, V3 b_1, V3 a0, V3 b0, V3 a1, V3 b1);    

// return pair of walls with maximum minumum distance between
std::pair<int, int> getMaxMinDistanceWallsPair(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets);
                                          
// return pair of walls with minumum distance between and maximum distance from point C
//std::pair<int, int> getMaxDistFromPointMinDistWallsPair(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets, V3 c);

std::pair<int, int> getMaxDistFromPointEdge(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets, V3 c);

std::pair<int, int> getMinTangentAngleDifEdge(const std::vector<ExtWallProj>& aPikets, const std::vector<int>& aCovexIdx, const std::vector<ExtWallProj>& bPikets, const std::vector<int>& bCovexIdx);

// возврадает set WallProj::idx впуклых вершин многоугольника
std::set<int> getPolygonConcavePoints(std::vector<WallProj> polygon);


// вернуть контрольную точку дл€ кривой безье 3 пор€дка дл€ пр€мой ab дл€ вершины a c известной нормалью an 
inline V3 getControlPoint(V3 a, V3 b, V3 an, float controlLength) {
    V3 controlVec = (-(b-a)).crossProduct(an).crossProduct(an).normalisedCopy();
    return a + controlVec * b.distance(a) * controlLength;     

//    float angle = (controlVec).angleBetween(b-a).valueRadians();
//    return a + controlVec * a.distance((a+b)/2) * cos(angle);
}

// расчет безье 3 пор€дка
inline V3 besier3(float t, V3 a, V3 ac, V3 bc, V3 b) {
    return a * (1.0f-t)*(1.0f-t)*(1.0f-t) + 3.0f * ac * t*(1.0f-t)*(1.0f-t) + 3.0f * bc * t*t*(1.0f-t) + b * t*t*t;            
}
 
inline V3 besier3(float t, const LineBesier3& a) {
	return besier3(t, a.a, a.ac, a.bc, a.b);
}

// расчет поверхности безье дл€ треугольника
// besier surface for triangle: 
// u=0      C
//  |     ca cb
// \|/  ac     bc
// u=1 A  ab ba  B    
//    v=0 ----> v=1

inline V3 besierSurf3x3x3(float u, float v, V3 a, V3 ab, V3 ac, V3 b, V3 ba, V3 bc, V3 c, V3 ca, V3 cb) {
    float u1 = std::max(0.0f, std::min(u, 1.0f));
    float u0 = 1.0f - u1;
    float v1 = std::max(0.0f, std::min(v, 1.0f));
    float v0 = 1.0f - v1;
    return      (u0*u0*u0)*(c) +
           3.0f*(u0*u0*u1)*(v0*ca + v1*cb) +
           3.0f*(u0*u1*u1)*(v0*ac + v*bc) +
                (u1*u1*u1)*(besier3(v1, a, ab, ba, b));
}
    
// расчет нормали к поверхности безье дл€ трекгольника в заданной точке
V3 besierSurf3x3x3Nrm(float u, float v, V3 a, V3 ab, V3 ac, V3 b, V3 ba, V3 bc, V3 c, V3 ca, V3 cb);

// http://triplepointfive.github.io/ogltutor/tutorials/tutorial31.html
// http://onrendering.blogspot.ru/2011/12/tessellation-on-gpu-curved-pn-triangles.html
// расчет поверхности безье дл€ треугольника
// besier surface for triangle: 
// u=0      C
//  |     ca cb
// \|/  ac abc bc
// u=1 A  ab ba  B    
//    v=0 ----> v=1
inline V3 besierSurfBar(float u, float v, V3 a, V3 ab, V3 ac, V3 b, V3 ba, V3 bc, V3 c, V3 ca, V3 cb, V3 abc) {
    //Barycentric Coordinates
    u = 1.0f-u;
    float k = u;
    float i = (1.0f-u) * v;
    float j = (1.0f-u) * (1.0f-v);
    
    return a*i*i*i + b*j*j*j + c*k*k*k +
           ab*3*i*i*j + ac*3*i*i*k + 
           ba*3*j*j*i + bc*3*j*j*k +
           ca*3*k*k*i + cb*3*k*k*j +            
           abc*6*i*j*k;
}
                                                                           
V3 besierSurfBarNormControl(V3 a, V3 an, V3 b, V3 bn); 
V3 besierSurfBarNorm(float u, float v, V3 a, V3 ab, V3 b, V3 bc, V3 c, V3 ca); 

// http://steps3d.narod.ru/tutorials/tessellation-algos-tutorial.html
// http://onrendering.blogspot.ru/2011/12/tessellation-on-gpu-curved-pn-triangles.html
// тессел€ци€ ‘онга
// u=0      C
//  |     
// \|/  
// u=1 A       B    
//    v=0 ----> v=1
V3 phongSurf(float u, float v, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn); 

// расчет нормали к поверхности ‘онга
V3 phongSurfNorm(float u, float v, V3 an, V3 bn, V3 cn);


//V3 besier3x3x3Barycentric(float u, float v, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn);

template <typename WP>
std::vector<int> getConvexPoly(const std::vector<WP>& poly, int startPolyIdx, int finishPolyIdx, bool clockwise) {
	std::vector<int> result(poly.size());
	int polySegmentSize = finishPolyIdx - startPolyIdx + 1;
	for (int j = startPolyIdx; j <= finishPolyIdx; j++) {
		result[j] = j;
	}

	if (polySegmentSize <= 3) {
		return result;
	}
	else {
		bool concaveVerticeRemoved = false;
		do {
			concaveVerticeRemoved = false;
			for (int i = 0; i < result.size(); i++) {
				int pi = (i + result.size() - 1) % result.size();
				int ni = (i + result.size() + 1) % result.size();
				V2 piPos = poly.at(result.at(pi)).posBySelfDir;
				V2 iPos = poly.at(result.at(i)).posBySelfDir;
				V2 niPos = poly.at(result.at(ni)).posBySelfDir;

				if (((piPos - iPos).crossProduct(niPos - iPos) > 0) == clockwise) {
					result.erase(result.begin() + i);
					concaveVerticeRemoved = true;
					break;
				}
			}
		} while (concaveVerticeRemoved && polySegmentSize > 3);
	}

	return result;
}

template <typename WP>
std::vector<int> getConvexPoly(const std::vector<WP>& poly, bool clockwise = true) {
	return getConvexPoly<WP>(poly, 0, poly.size() - 1, clockwise);
}



}
