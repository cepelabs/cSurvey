//---------------------------------------------------------------------------

#pragma hdrstop

#include "CMHelpers.h"
#include "OgreVector2.h"
#include "CMAssertions.h"
#include "wykobi.hpp"      
#include "CMtext.h"
#define _USE_MATH_DEFINES
#include <math.h> 


namespace CM {
using namespace wykobi;
using namespace Ogre;
using namespace std;

//---------------------------------------------------------------------------

bool WallProj::compareBySelf0XAngle(const WallProj& w1, const WallProj& w2) {
    return w1.to0XAngleBySelfDir < w2.to0XAngleBySelfDir;
}
                        
int WallProj::minSelf0XAngleWallPoint(WallProj point, const std::vector<WallProj>& rotWalls, bool abs, int skipPoint) {

    Radian minAngle(M_PI*2);
    int minWallJ = 0;
    for (int j = 0; j < rotWalls.size(); j++) {
        if (j == skipPoint) continue;
        Radian angle;
        const V2& point2 = rotWalls[j].posBySelfDir;
        if (abs) angle = point.posBySelfDir.angleBetween(point2); 
        else angle = point.posBySelfDir.angleTo(point2);
        if (angle < minAngle) {
            minAngle = angle;
            minWallJ = j;                        
        }    
    } 
    return minWallJ; 
}

float sinusate(float val) {
    if (val < 0) return 0;    
    else if (val > 1) return 1;
    else return (cos((1.0f - val) * M_PI) + 1.0f) / 2;    
}
           
std::vector<WallProj> getWalls2d(V3 center, V3 selfDirrection, const std::vector<PiketWall>& walls) {
    Quaternion selfDirrectionRotation = selfDirrection.getRotationTo(V3::UNIT_Z);
    
    std::vector<WallProj> rotWalls;
    for (int widx = 0; widx < walls.size(); widx++) {
        const PiketWall& w = walls[widx];

        V3 selfRotWall = selfDirrectionRotation * (w.pos - center);
        
        V2 selfProjPos(selfRotWall.x, selfRotWall.y);
        Radian toSelf0XAngle = V2::UNIT_X.angleTo(selfProjPos);

		rotWalls.push_back(WallProj(widx, selfProjPos, toSelf0XAngle));
    }

    std::sort(rotWalls.begin(), rotWalls.end(), &WallProj::compareBySelf0XAngle);

    return rotWalls;  
}



int getClothestEdge(const std::vector<WallProj>& walls, const WallProj& wall) {
    int minEdgeIdx = 0;
    float minDist = INT_MAX / 100;
    for (int i = 0; i < walls.size(); i++) {
        int ni = (i + 1) % walls.size();
        float dist = wykobi::minimum_distance_from_point_to_segment(
            wall.posBySelfDir.x, wall.posBySelfDir.y,
            walls[i].posBySelfDir.x, walls[i].posBySelfDir.y,
            walls[ni].posBySelfDir.x, walls[ni].posBySelfDir.y
        );
        if (dist < minDist) {
            minEdgeIdx = ni;
            minDist = dist;    
        }
    }
    return minEdgeIdx;
}

std::vector<WallProj> getWalls2dWithConvexCorrection(V3 center, V3 selfDirrection/*, V3 globalDirrection*/, const std::vector<PiketWall>& walls) {
	std::vector<WallProj> sorted = getWalls2d(center, selfDirrection/*, globalDirrection*/, walls);
    std::vector<int> convexPoly = getConvexPoly(sorted);
    if (convexPoly.size() != sorted.size() && !sorted.empty()) {
//        // first- after wall insert idx  second- wall to insert idx
//        std::map<int, std::vector<int> > wallsToInsert;
        std::vector<WallProj> sortedCorrected;        
        for (int a = 0; a < convexPoly.size(); a++) {
			sortedCorrected.push_back(sorted.at(convexPoly.at(a)));
        }
        
        for (int a = 0; a < convexPoly.size(); a++) {        
            int i = convexPoly.at(a);
            int ni = (i + 1) % sorted.size();
            int enda = (a + 1) % convexPoly.size();
            int endi = convexPoly.at(enda);
            for ( ; ni != endi; ni = (ni + 1) % sorted.size()) {
                int insertAfterIdx = getClothestEdge(sortedCorrected, sorted.at(ni));
                sortedCorrected.insert(sortedCorrected.begin() + insertAfterIdx , sorted.at(ni));
            }               
        }    
        return sortedCorrected; 
    } else {
        return sorted; 
    }
}


float trinagleSquare(V2 a, V2 b, V2 c) {
    float A = (a-c).length();
    float B = (b-a).length();
    float C = (c-b).length();

    float p = (A+B+C)/2;
    float s = sqrt(p*(p-A)*(p-B)*(p-C));

    return s;
}

V2 trinagleCenter(V2 a, V2 b, V2 c) {
    return (a + b + c) / 3;
}
  
float trinagleSquare(V3 a, V3 b, V3 c)  {
    float A = (a-c).length();
    float B = (b-a).length();
    float C = (c-b).length();

    float p = (A+B+C)/2;
    float s = sqrt(p*(p-A)*(p-B)*(p-C));

    return s;
}

V3 trinagleCenter(V3 a, V3 b, V3 c)  {
    return (a + b + c) / 3;
}  

//V2 polyCenter(const std::vector<WallProj>& verts) {
//    V2 zeroVert(0, 0);
//    V2 polyCent(0, 0);
//    float totalSquare = 0;
//    for (int i = 0; i < verts.size(); i++) {
//        int j = (i + 1) % verts.size();
//        V2 vi = verts[i].posBySelfDir;
//        V2 vj = verts[j].posBySelfDir;
//        float square = trinagleSquare(zeroVert, vi, vj);
//        V2 center = trinagleCenter(zeroVert, vi, vj);
//        polyCent += square * center;
//        totalSquare += square; 
//    }
//
//    if (totalSquare != 0) polyCent /= totalSquare;
//
//    return polyCent;
//}

float polySquare(const std::vector<WallProj>& verts) {
    wykobi::polygon<float, 2> poly(verts.size());
    for (int i = 0; i < verts.size(); i++) { 
        poly[i] = wykobi::point2d<float>(verts[i].posBySelfDir.x, verts[i].posBySelfDir.y);
    }
    return wykobi::area<float>(poly);
//    V2 zeroVert(0, 0);
//    float totalSquare = 0;
//    for (int i = 0; i < verts.size(); i++) {
//        int j = (i + 1) % verts.size();
//        V2 vi = verts[i].posBySelfDir;
//        V2 vj = verts[j].posBySelfDir;
//        float square = trinagleSquare(zeroVert, vi, vj);
//        if (vi) {
//            
//        }
//        totalSquare += square; 
//    }
//
//    return totalSquare;    
}
       
WallEdges separateTriangleForEdges(const WallTriangles& wallTriangles, const std::vector<PiketWall>& piketsA, const std::vector<PiketWall>& piketsB) {
    WallEdges result;
    for (int i = 0; i < wallTriangles.size(); i++) {
        const WallTriangle& trgl = wallTriangles[i];
        bool bFromAGroup = (std::find_if(piketsA.begin(), piketsA.end(), ComareObjByAdr<PiketWall>(trgl.b)) != piketsA.end());
        bool cFromAGroup = (std::find_if(piketsA.begin(), piketsA.end(), ComareObjByAdr<PiketWall>(trgl.c)) != piketsA.end());

        AssertReturn(cFromAGroup != bFromAGroup, return WallEdges());
        
        if (i == 0) {   
            bool aFromAGroup = (std::find_if(piketsA.begin(), piketsA.end(), ComareObjByAdr<PiketWall>(trgl.a)) != piketsA.end());
            AssertReturn(aFromAGroup != bFromAGroup, return WallEdges());
            if (aFromAGroup) result.push_back(make_pair(trgl.a, trgl.b));   
            else result.push_back(make_pair(trgl.b, trgl.a));
        }

        if (bFromAGroup) result.push_back(make_pair(trgl.b, trgl.c));   
        else result.push_back(make_pair(trgl.c, trgl.b));
     }

     return result;
}


bool isQuadrangleATriangulationIsConvexRalativePoint(V3 a0, V3 b0, V3 a1, V3 b1, V3 C) {

    float aModeTr1Square = trinagleSquare(a0, b0, a1);
    float aModeTr2Square = trinagleSquare(a1, b0, b1); 
    float bModeTr1Square = trinagleSquare(a0, b0, b1);
    float bModeTr2Square = trinagleSquare(a0, b1, a1);
     
    V3 aModeTr1Center = trinagleCenter(a0, b0, a1);
    V3 aModeTr2Center = trinagleCenter(a1, b0, b1);
    V3 bModeTr1Center = trinagleCenter(a0, b0, b1);
    V3 bModeTr2Center = trinagleCenter(a0, b1, a1);
    
    V3 aModeMassCenter = (aModeTr1Square * aModeTr1Center + aModeTr2Square * aModeTr2Center) / (aModeTr1Square + aModeTr2Square);  
    V3 bModeMassCenter = (bModeTr1Square * bModeTr1Center + bModeTr2Square * bModeTr2Center) / (bModeTr1Square + bModeTr2Square);  

    return aModeMassCenter.distance(C) > bModeMassCenter.distance(C);
}

bool isQuadrangleATriangulationIsConvexClockwise(V3 dirrection, V3 a_1, V3 b_1, V3 a0, V3 b0, V3 a1, V3 b1) {
    if (a0.distance(a1) < 0.01 * PointsInMeter) return true; // if a0 equadls a1 select a
    if (b0.distance(b1) < 0.01 * PointsInMeter) return false; // if b0 equadls b1 select b 
                                                    
//    V3 aNormal = (a1-a0).crossProduct(dirrection).normalisedCopy();     
//    V3 bNormal = (-dirrection).crossProduct(b1-b0).normalisedCopy();

    float ang = (b0-a0).angleBetween(dirrection).valueRadians();
    if (abs(ang) < M_PI / 180 || abs(ang) > M_PI * 179 / 180) {
        return isQuadrangleATriangulationIsConvexClockwise(dirrection, a0, b0, a1, b1);
    }

    Quaternion rot = dirrection.getRotationTo(V3::UNIT_Z);
    V3 a0a1 = rot * (a1-a0);
    V3 b0b1 = rot * (b1-b0);
    V3 a_1a0 = rot * (a0-a_1);
    V3 b_1b0 = rot * (b0-b_1);
    V3 a0b0v3 = rot * (b0-a0);
    V2 a0b0(a0b0v3.x, a0b0v3.y);

    V2 prevWallDir = V2(a_1a0.x, a_1a0.y) + V2(b_1b0.x, b_1b0.y);

    if (a0b0.angleBetween(prevWallDir) < Radian(M_PI_2)) a0b0 = -a0b0;
                        
    Radian aAngle = a0b0.angleTo(V2(a0a1.x, a0a1.y));
    Radian bAngle = a0b0.angleTo(V2(b0b1.x, b0b1.y));
    
    return aAngle <= bAngle;
}

bool isQuadrangleATriangulationIsConvexClockwise(V3 dirrection, V3 a0, V3 b0, V3 a1, V3 b1) {
    if (a0.distance(a1) < 0.01 * PointsInMeter) return true; // if a0 equadls a1 select a
    if (b0.distance(b1) < 0.01 * PointsInMeter) return false; // if b0 equadls b1 select b
    
    V3 aNormal = (a1-a0).crossProduct(dirrection).normalisedCopy();     
    V3 bNormal = (-dirrection).crossProduct(b1-b0).normalisedCopy();   
 

//    V3 aNormal = (a1-a0).crossProduct(b0-a0).normalisedCopy();
//    V3 bNormal = ((a0-b0)).crossProduct(b1-b0).normalisedCopy();            

    bool aIsMoreConvex = bNormal.crossProduct(aNormal).angleBetween(dirrection) > Radian(M_PI_2);

    Radian a1a0b0 = (a1-a0).angleBetween(b0-a0);
    Radian b1b0a0 = (b1-b0).angleBetween(a0-b0);

   // if (aIsMoreConvex == (a1a0b0 < b1b0a0)) {
        return aIsMoreConvex;         
//    } else {
//        float dAngle1 = abs((a1a0b0 - b1b0a0).valueRadians());
//        float dAngle2 = aNormal.angleBetween(bNormal).valueRadians();
//        if (dAngle1 / 2 > dAngle2) 
//            return !aIsMoreConvex; 
//        else 
//            return aIsMoreConvex;
//    }
}

std::pair<int, int> getMaxMinDistanceWallsPairInst(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets) {
    std::pair<int, int> result(-1, -1);

    float maxDist = -FLT_MAX;    
    for (int i = 0; i < aPikets.size(); i++) {
        float minDist = FLT_MAX;
        int minDistPiket(-1);
        for (int j = 0; j < bPikets.size(); j++) {
            float d = aPikets[i].pos.distance(bPikets[j].pos);
            if (d < minDist) {
                minDist = d;
                minDistPiket = j;   
            }
        }
        if (minDist > maxDist) {
            maxDist = minDist;
            result.first = i;
            result.second = minDistPiket;   
        }    
    }

    return result;
}

std::pair<int, int> getMaxMinDistanceWallsPair(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets) {
    std::pair<int, int> aToB = getMaxMinDistanceWallsPairInst(aPikets, bPikets);    
    std::pair<int, int> bToA = getMaxMinDistanceWallsPairInst(bPikets, aPikets);    

    if (aToB.first != -1 && aToB.second != -1 && bToA.first != -1 && bToA.second != -1) {
        float aToBedgeLength = (aPikets.at(aToB.first).pos + bPikets.at(aToB.second).pos).length();  
        float bToAedgeLength = (bPikets.at(bToA.first).pos + aPikets.at(bToA.second).pos).length();
        if (aToBedgeLength >= bToAedgeLength) {
            return  aToB;            
        } else {
            return  bToA; 
        }    
    } else if (aToB.first != -1 && aToB.second != -1) {
        return  aToB;      
    } else if (bToA.first != -1 && bToA.second != -1) {
        std::swap(bToA.first, bToA.second);
        return  bToA;
    } else {
        return std::pair<int, int>(-1, -1);      
    }
}                 
 
//std::pair<int, int> getMaxDistFromPointMinDistWallsPairInst(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets, V3 c) {
//    std::pair<int, int> result(-1, -1);
//
//    float maxDist = -FLT_MAX;    
//    for (int i = 0; i < aPikets.size(); i++) {
//        float minDist = FLT_MAX;
//        int minDistJ(-1);
//        for (int j = 0; j < bPikets.size(); j++) {
//            float d = aPikets[i].pos.distance(bPikets[j].pos);
//            if (d < minDist) {
//                minDist = d;
//                minDistJ = j;
//            }
//        }
//        
//        if (minDistJ >= 0) {
//            float distFromCtoEdge = c.distance((aPikets[i].pos + bPikets[minDistJ].pos)/2);    
//
//            if (distFromCtoEdge > maxDist) {
//                maxDist = distFromCtoEdge;
//                result.first = i;
//                result.second = minDistJ;   
//            }   
//        }
//    }
//
//    return result;
//}
//
//std::pair<int, int> getMaxDistFromPointMinDistWallsPair(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets, V3 c) {
//    std::pair<int, int> aToB = getMaxMinDistanceWallsPairInst(aPikets, bPikets);  
//    std::pair<int, int> bToA = getMaxMinDistanceWallsPairInst(bPikets, aPikets);    
//    return  aToB;              
//
//    if (aToB.first != -1 && aToB.second != -1 && bToA.first != -1 && bToA.second != -1) {
//        float aToBedgeDist = c.distance((aPikets.at(aToB.first).pos + bPikets.at(aToB.second).pos)/2);  
//        float bToAedgeDist = c.distance((bPikets.at(bToA.first).pos + aPikets.at(bToA.second).pos)/2);
//        if (aToBedgeDist >= bToAedgeDist) {
//            return  aToB;            
//        } else {
//            return  bToA; 
//        }    
//    } else if (aToB.first != -1 && aToB.second != -1) {
//        return  aToB;      
//    } else if (bToA.first != -1 && bToA.second != -1) {
//        std::swap(bToA.first, bToA.second);
//        return  bToA;
//    } else {
//        return std::pair<int, int>(-1, -1);      
//    }
//}
std::pair<int, int> getMaxDistFromPointEdge(const std::vector<PiketWall>& aPikets, const std::vector<PiketWall>& bPikets, V3 c) {
    std::pair<int, int> result(-1, -1);
    float maxDist = 0;
    for (int i = 0; i < aPikets.size(); i++) { 
        for (int j = 0; j < bPikets.size(); j++) {
            float dist = c.distance((aPikets.at(i).pos + bPikets.at(j).pos)/2);
            if (maxDist < dist) {
                maxDist = dist;
                result.first = i;                
                result.second = j;
            } 
        }
    }
    return result;  
}

std::pair<int, int> getMinTangentAngleDifEdge(const std::vector<ExtWallProj>& aPikets, const std::vector<int>& aCovexIdx, const std::vector<ExtWallProj>& bPikets, const std::vector<int>& bCovexIdx) {
    std::pair<int, int> result(-1, -1);
    if (aCovexIdx.size() > 2 && bCovexIdx.size() > 2) {
        Radian minAngle(M_PI);
        for (int a = 0; a < aCovexIdx.size(); a++) {
            int i = aCovexIdx.at(a);
            int pa = (a-1 + aCovexIdx.size()) % aCovexIdx.size(); 
            int pi = aCovexIdx.at(pa);
            //int ni = (i+1 + aPikets.size()) % aPikets.size(); 
            V2 veca = aPikets[i].posByGlobalDir - aPikets[pi].posByGlobalDir;  
            if (veca.isZeroLength()) continue;
            for (int b = 0; b < bCovexIdx.size(); b++) {      
                int j = bCovexIdx.at(b);
                int pb = (b-1 + bCovexIdx.size()) % bCovexIdx.size(); 
                int pj = bCovexIdx.at(pb);
                //int nj = (j+1 + bPikets.size()) % bPikets.size(); 
                V2 vecb = bPikets[j].posByGlobalDir - bPikets[pj].posByGlobalDir;
                if (vecb.isZeroLength()) continue;
                Radian angle = (veca).angleBetween(vecb);
                if (minAngle > angle) {
                    minAngle = angle;
                    result.first = a;                
                    result.second = b;
                } 
            }
        } 
        int i = 0; 
    } else if (!aCovexIdx.empty() && !bCovexIdx.empty()) {
        result.first = 0; 
        result.second = 0;
    }
//                result.second = bPikets[1].idx; 
//        if (!aPikets.empty() && !aPikets.empty()) {
//            if (aPikets.size() == 1 || bPikets.size() == 1) {
//                result.first = aPikets[0].idx; 
//                result.second = bPikets[1].idx;
//            }
//            if (aPikets.size() == 2) {
//                result.second = aPikets[0].idx;
//                if (bPikets[0].posByGlobalDir.distance(aPikets[0].posByGlobalDir) < bPikets[0].posByGlobalDir.distance(aPikets[1].posByGlobalDir)) {
//                    result.first = bPikets[0].idx;                    
//                } else {
//                    result.first = bPikets[1].idx;                    
//                }
//            } else if (bPikets.size() == 2) {
//                result.first = bPikets[0].idx;
//                if (bPikets[0].posBySelfDir.distance(aPikets[0].posByGlobalDir) < bPikets[1].posBySelfDir.distance(aPikets[0].posByGlobalDir)) {
//                    result.second = aPikets[0].idx;                    
//                } else {
//                    result.second = aPikets[1].idx;
//                }
//            }
//        }
//    }
    return result;  
}

// возврадает set WallProj::idx впуклых вершин многоугольника
std::set<int> getPolygonConcavePoints(std::vector<WallProj> polygon) {
    std::set<int> res;
    for (int j = 0; j < polygon.size(); ) {
        if (polygon.size() <= 3) break;
        int i = (polygon.size() + j - 1) % polygon.size();
        int k = (polygon.size() + j + 1) % polygon.size();

        V2 ji(polygon.at(i).posBySelfDir - polygon.at(j).posBySelfDir);
        V2 jk(polygon.at(k).posBySelfDir - polygon.at(j).posBySelfDir);

        if (ji.crossProduct(jk) >= 0) {
            res.insert(res.size() + j);
            polygon.erase(polygon.begin() + j);
           // j++;
        } else {
            j++;
        }           
    }                                 
    return res;      
}

V3 besierSurf3x3x3Nrm(float u, float v, V3 a, V3 ab, V3 ac, V3 b, V3 ba, V3 bc, V3 c, V3 ca, V3 cb) {
    float u0 = std::max(0.0f, std::min(u - 0.0001f, 1.0f));
    float u1 = std::max(0.0f, std::min(u + 0.0001f, 1.0f));
    float v0 = std::max(0.0f, std::min(v - 0.0001f, 1.0f));
    float v1 = std::max(0.0f, std::min(v + 0.0001f, 1.0f));

    if (u == 0) u = u1;
    else if (u == 1) u = u0;

    if (v == 0) v = v1;
    else if (v == 1) v = v0;
    
    V3 u0p = besierSurf3x3x3(u0, v, a, ab, ac, b, ba, bc, c, ca, cb);    
    V3 u1p = besierSurf3x3x3(u1, v, a, ab, ac, b, ba, bc, c, ca, cb);   
    V3 v0p = besierSurf3x3x3(u, v0, a, ab, ac, b, ba, bc, c, ca, cb);    
    V3 v1p = besierSurf3x3x3(u, v1, a, ab, ac, b, ba, bc, c, ca, cb);   

    V3 nrm = (u1p - u0p).crossProduct(v1p - v0p).normalisedCopy();
    return nrm;
}

V3 besierSurfBarNormControl(V3 a, V3 an, V3 b, V3 bn) {
    V3 v = b-a;
    if (v.isZeroLength()) return V3(0, 0, 0);
    V3 vab = 2.0 * (b-a).crossProduct(an+bn) / (b-a).dotProduct(b-a);
    V3 abn = (an + bn - vab * (b-a)).normalisedCopy();
    return abn; 
}

V3 besierSurfBarNorm(float u, float v, V3 a, V3 ab, V3 b, V3 bc, V3 c, V3 ca) {
    //Barycentric Coordinates
    u = 1.0f-u;
    float k = u;
    float i = (1.0f-u) * v;
    float j = (1.0f-u) * (1.0f-v);
    
    return a*i*i + ab*i*j + b*j*j + bc*j*k + c*k*k + ca*k*i;
}

V3 phongSurf(float u, float v, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
    //Barycentric Coordinates
    u = 1.0f-u;
    float k = u;
    float i = (1.0f-u) * v;
    float j = (1.0f-u) * (1.0f-v);
   
    V3 p = i*a + j*b + k*c; 

    V3 aControl(a);       
    V3 bControl(b);
    V3 cControl(c);
    
    if (!an.isZeroLength()) {
        plane3d aPlane = make_plane(V3toP3(a), V3toP3(an));
        aControl = P3toV3(closest_point_on_plane_from_point<float>(aPlane, V3toP3(p)));      
    }

    if (!bn.isZeroLength()) {
        plane3d bPlane = make_plane(V3toP3(b), V3toP3(bn));
        bControl = P3toV3(closest_point_on_plane_from_point<float>(bPlane, V3toP3(p)));
    }

    if (!cn.isZeroLength()) {
        plane3d cPlane = make_plane(V3toP3(c), V3toP3(cn));
        cControl = P3toV3(closest_point_on_plane_from_point<float>(cPlane, V3toP3(p)));
    }

    V3 res = i*aControl + j*bControl + k*cControl; 
    
    return res;
}

V3 phongSurfNorm(float u, float v, V3 an, V3 bn, V3 cn) {
     //Barycentric Coordinates
    u = 1.0f-u;
    float k = u;
    float i = (1.0f-u) * v;
    float j = (1.0f-u) * (1.0f-v);

    V3 n = i*an + j*bn + k*cn;
    
    return n.normalisedCopy();
}
V3 getNormal(V3 a, V3 b, V3 c, V3 sampleNorm) {
    V3 n = (c-a).crossProduct(b-a);
    if (n.angleBetween(sampleNorm) > Radian(M_PI_2)) n = -n;    

    return n.normalisedCopy();
}

// ¬озвращает список вершин выпуклого многоугольника включающего в себ€ заданный невыпуклый
// template <typename WP>
// std::vector<int> getConvexPoly(const std::vector<WP>& poly, int startPolyIdx, int finishPolyIdx, bool clockwise) {
//     std::vector<int> result(poly.size());
//     int polySegmentSize = finishPolyIdx - startPolyIdx + 1;
//     for (int i = startPolyIdx; i <= finishPolyIdx; i++) {
//         result[i] = i;                   
//     } 
//     
//     if (polySegmentSize <= 3) {
//         return result;   
//     } else {
//         bool concaveVerticeRemoved = false;
//         do {
//             concaveVerticeRemoved = false;
//             for (int i = 0; i < result.size(); i++) {
//                 int pi = (i + result.size() - 1) % result.size();
//                 int ni = (i + result.size() + 1) % result.size();
//                 V2 piPos = poly.at(result.at(pi)).posBySelfDir;
//                 V2 iPos = poly.at(result.at(i)).posBySelfDir;
//                 V2 niPos = poly.at(result.at(ni)).posBySelfDir;
//                 
//                 if (((piPos-iPos).crossProduct(niPos-iPos) > 0) == clockwise) {
//                     result.erase(result.begin() + i);
//                     concaveVerticeRemoved = true;
//                     break;
//                 }
//             }
//         } while(concaveVerticeRemoved && polySegmentSize > 3);
//     }
//                 
//     return result;
// }
// 
// template void getConvexPoly<WallProj>(const std::vector<WallProj>& poly, bool clockwise);
// template void getConvexPoly<ExtWallProj>(const std::vector<ExtWallProj>& poly, bool clockwise);
}
