#include "CMPiket.h"
// #include "OgreManualObject.h"
#include "CMAssertions.h"
#include "wykobi_wrap.h"
#include "CMDebug.h"    
#include "CMLog.h"     
#include "CMtext.h"   
#include <algorithm>

using namespace wykobi;
using namespace Ogre;
using namespace std;

namespace CM {
    /*
     struct PreperedForClassifyWall {
     PreperedForClassifyWall(const Wall* raw, V3 rotRelPos);
     // является ли внешней для ассоциированного пикета
     bool fixed;
     const Wall* raw;
     V3 rotRelPos;
     // угол вдоль Z
     Radian alongZAngle;
     // угол вокруг Z (от X0)
     Radian crossZAngle;
     };

     bool compareWallsByRotatedZ(const PreperedForClassifyWall& w1, const PreperedForClassifyWall& w2) {
     return w1.rotRelPos.z < w2.rotRelPos.z;
     }

     PreperedForClassifyWall::PreperedForClassifyWall(const Wall* raw, V3 rotRelPos)
     : raw(raw)
     , rotRelPos(rotRelPos)
     , fixed(false) {
     alongZAngle = rotRelPos.angleBetween(V3::UNIT_Z);
     crossZAngle = V2(rotRelPos.x, rotRelPos.y).angleTo(V2::UNIT_X);
     }
     */

    void Piket::addP3D(const PiketInfo& piket) {
        allP3D.push_back(piket);
    }

    void Piket::addW3D(long long parentPiket, const Wall w3d) {
        for (int i = 0; i < allP3D.size(); i++) {
            if (allP3D[i].id == parentPiket) {
                allP3D[i].hasWalls++;
                break;
            }
        }
        allWalls.push_back(w3d);
    }

    void Piket::preProcessWalls(const CaveViewPrefs& caveViewPrefs) {
        pos = origPos;

        classifyWalls();
        recalcPosCenterDirrection();

        adjFakePikets.clear();
    }

    void Piket::recalcPosCenterDirrection() {
        updateEffectivePos();
        updateDirrection();
        updateWallsCenter();
    }

    void Piket::updateEffectivePos() {
        V3 center(0, 0, 0);
        if (!classifiedWalls.empty()) {
            center = V3(0, 0, 0);
            for (int i = 0; i < classifiedWalls.size(); i++) {
                center += classifiedWalls[i].pos;
            }
            center /= classifiedWalls.size();
        }
        // смещаем пикет немного в сторону чтобы не было стен прямо на пикете, откуда были бы проблемы с углами
        piketEffectivePos = pos + (center - pos).normalisedCopy() * 0.01f * PointsInMeter;

        resetCache();
    }

    void Piket::updateWallsCenter() {
        if (!classifiedWalls.empty()) {
            wallsCenter = V3(0, 0, 0);
            for (int i = 0; i < classifiedWalls.size(); i++) {
                wallsCenter += classifiedWalls[i].pos;
            }
            wallsCenter /= classifiedWalls.size();
        }
        else {
            wallsCenter = piketEffectivePos;
        }

        resetCache();
        // wallsCenter = piketEffectivePos;
        // wallsMassCenter = getWallsMassCenter(dirrection);
    }
    
    V3 Piket::getDirrectionForOverlay() const {
        V3 res(0, 0, 0);

        if (adjPikets.size() >= 1 && adjPikets.size() <= 2) {
            res += (adjPikets.front()->wallsCenter - wallsCenter).normalisedCopy();
        }
        if (adjPikets.size() == 2) {
            res += (wallsCenter - adjPikets.back()->wallsCenter).normalisedCopy();
        }
        
        if (res == V3::ZERO) return res = dirrection;
        res.normalise();

        return res;
    }
    
    void Piket::updateDirrection() {
        V3 sampleDirrection = V3::ZERO;
        dirrection = V3::ZERO;

        if (adjPikets.size() >= 1 && adjPikets.size() <= 2) {
            sampleDirrection += (adjPikets.front()->pos - pos).normalisedCopy();
        }
        if (adjPikets.size() == 2) {
            sampleDirrection += (pos - adjPikets.back()->pos).normalisedCopy();
        }
        cerr << "walls :" << classifiedWalls.size() << "\n";
        for (int i = 0; i < classifiedWalls.size(); i++) {
            for (int j = i + 1; j < classifiedWalls.size(); j++) {
                cerr << i << " - " << j << "\n";
                V3 ish = (classifiedWalls[i].pos - pos);
                V3 jsh = (classifiedWalls[j].pos - pos);
                float interangle = ish.angleBetween(jsh).valueRadians();
                if (interangle > M_PI - M_PI / 8 || interangle < M_PI / 8)
                    continue;
                V3 norm = ish.crossProduct(jsh);
                norm.normalise();

                if (!sampleDirrection.isZeroLength() && norm.angleBetween(sampleDirrection) > Radian(M_PI_2)) {
                    norm = -norm;
                }
                sampleDirrection += norm;
                dirrection += norm;
                // cerr << "i :" << ish.x << " " << ish.y << " " << ish.z << "\n";
                // cerr << "j :" << jsh.x << " " << jsh.y << " " << jsh.z << "\n";
                // cerr << "n :" << norm.x << " " << norm.y << " " << norm.z << "\n";
                // cerr << "d :" << dirrection.x << " " << dirrection.y << " " << dirrection.z << "\n";
            }
        }
        dirrection.normalise();

        if (dirrection == V3::ZERO)
            dirrection = sampleDirrection;

//        static bool b = true;
//        if (b) {
//          dirrection = -dirrection;
//        }
//        b = !b;
            
        resetCache();
    }

    // V3 OgrePiket::getWallsMassCenter(V3 dirrection) {
    // if (!dirrection.isZeroLength()) {
    // Quaternion dirrectionRotation = dirrection.getRotationTo(V3::UNIT_Z);
    // std::vector<WallProj> walls2d = getWalls2d(piketEffectivePos, dirrection, dirrection, classifiedWalls);
    //
    // V2 polyCenter2d = polyCenter(walls2d);
    // V3 polyCenter3d = piketEffectivePos + dirrectionRotation.Inverse() * V3(polyCenter2d.x, polyCenter2d.y, 0);
    //
    // return polyCenter3d;
    // } else {
    // return piketEffectivePos;
    // }
    // }

    void Piket::processPiketPosAsWall() {
        if (classifiedWalls.empty())
            return;

        std::vector<WallProj>rotWalls = getWalls2d(dirrection);

        for (int i = 0; i < classifiedWalls.size(); i++) {
            if (classifiedWalls[i].pos.distance(pos) < 0.001 * PointsInMeter) {
                return;
            }
        }

        Quaternion dirrectionRotation = dirrection.getRotationTo(V3::UNIT_Z);
        V3 rotPiketPos(pos);
        rotPiketPos -= wallsCenter;
        rotPiketPos = dirrectionRotation * rotPiketPos;
        point2d<float>rotPiketProjPos(rotPiketPos.x, rotPiketPos.y);

        std::vector<point2d<float> >wallsPolygon2d;
        for (int i = 0; i < rotWalls.size(); i++) {
            const V2& v2 = rotWalls[i].posBySelfDir;
            wallsPolygon2d.push_back(point2d<float>(v2.x, v2.y));

            // debugDraw(V3(rotPiketProjPos.x, rotPiketProjPos.y, -100), V3(v2.x, v2.y, -100));
        }
        polygon<float, 2>wallsPolygon = make_polygon(wallsPolygon2d);

        // if (!point_in_polygon(rotPiketProjPos, wallsPolygon)) {
        // classifiedWalls.push_back(PiketWall(pos));
        // recalcPosCenterDirrection();
        // }
    }

    // void Piket::propagateWalls(WallsPropagateMode propMode, WallsBlowMode blowMode) {
    // if (classifiedWalls.empty() || propMode == WPM_NONE) return;
    //
    // std::vector<WallProj> rotWalls = getWalls2d(dirrection);
    // std::vector<PiketWall> newWalls;
    //
    // for (int i = 0; i < rotWalls.size(); i++) {
    // int j = (i + 1) % rotWalls.size();
    //
    // V3 iPos = classifiedWalls[rotWalls[i].idx].pos - wallsCenter;
    // V3 jPos = classifiedWalls[rotWalls[j].idx].pos - wallsCenter;
    //
    // int addWallsNum = 0;
    // if (propMode == WPM_X2) addWallsNum = 1;
    // else if (propMode == WPM_X4) addWallsNum = 2;
    // else if (propMode == WPM_1M) addWallsNum = (jPos - iPos).length() / 100 / 1;
    // else if (propMode == WPM_2M) addWallsNum = (jPos - iPos).length() / 100 / 2;
    // else if (propMode == WPM_4M) addWallsNum = (jPos - iPos).length() / 100 / 4;
    // else if (propMode == WPM_10D) addWallsNum = (jPos.angleBetween(iPos)).valueDegrees() / 5;
    // else if (propMode == WPM_20D) addWallsNum = (jPos.angleBetween(iPos)).valueDegrees() / 20;
    // else if (propMode == WPM_30D) addWallsNum = (jPos.angleBetween(iPos)).valueDegrees() / 30;
    //
    // std::vector<PiketWall> addinWalls;
    // if (blowMode == WBM_NONE
    // || blowMode == WBM_LINEAR
    // || blowMode == WBM_COS2PI
    // || blowMode == WBM_COSCOS2PI) {
    // addinWalls = propagateWallAngleAbove(rotWalls[i].idx, rotWalls[j].idx, addWallsNum, blowMode);
    // } else if (blowMode == WBM_BESIER3) {
    // int wallsNum = rotWalls.size();
    // int h = (wallsNum + i - 1) % wallsNum;
    // int k = (wallsNum + j + 1) % wallsNum;
    // addinWalls = propagateWallBesier3(rotWalls[h].idx, rotWalls[i].idx, rotWalls[j].idx, rotWalls[k].idx, addWallsNum);
    // }
    //
    // newWalls.insert(newWalls.end(), addinWalls.begin(), addinWalls.end());
    // }
    // classifiedWalls.insert(classifiedWalls.end(), newWalls.begin(), newWalls.end());
    // }
    //
    // std::vector<PiketWall> Piket::propagateWallAngleAbove(int wallId1, int wallId2, int addWallsNum, WallsBlowMode blowMode) const {
    // std::vector<PiketWall> result;
    //
    // AssertReturn(classifiedWalls.size() > wallId1, return result);
    // AssertReturn(classifiedWalls.size() > wallId2, return result);
    //
    // V3 iPos = classifiedWalls[wallId1].pos - wallsCenter;
    // V3 jPos = classifiedWalls[wallId2].pos - wallsCenter;
    //
    // for (int addWallIdx = 1; addWallIdx <= addWallsNum; addWallIdx++) {
    // float offset = (float)addWallIdx / (addWallsNum + 1);
    // V3 pos = iPos + (jPos - iPos) * offset;
    // if (blowMode == WBM_NONE) {
    // pos = wallsCenter + pos;
    // } else {
    // float sinOffset = 0.5f;
    //
    // if (blowMode == WBM_LINEAR) sinOffset = offset;
    // else if (blowMode == WBM_COS2PI) sinOffset = sinusate(offset);
    // else if (blowMode == WBM_COSCOS2PI) sinOffset = sinusate(sinusate(offset));
    //
    // pos = wallsCenter + pos.normalisedCopy() * (iPos.length()*(1.0f - sinOffset) + jPos.length()*sinOffset);
    // }
    //
    // result.push_back(PiketWall(pos));
    // }
    // return result;
    // }

    LineBesier3 Piket::getCutSegmentBesier3(int h, int i, int j, int k, float strong) const {
        LineBesier3 result;

        int wallsNum = classifiedWalls.size();

        AssertReturn(wallsNum > h, return result);
        AssertReturn(wallsNum > i, return result);
        AssertReturn(wallsNum > j, return result);
        AssertReturn(wallsNum > k, return result);

        V3 hPos = classifiedWalls[h].pos;
        V3 iPos = classifiedWalls[i].pos;
        V3 jPos = classifiedWalls[j].pos;
        V3 kPos = classifiedWalls[k].pos;

        V3 icPos = (iPos + (iPos - hPos)) * 0.5f + jPos * 0.5f;
        V3 jcPos = (jPos + (jPos - kPos)) * 0.5f + iPos * 0.5f;

        float strongi = strong * pow(Math::Sin((hPos - iPos).angleBetween((jPos - iPos)) / 2), 0.5f);
        float strongj = strong * pow(Math::Sin((kPos - jPos).angleBetween((iPos - jPos)) / 2), 0.5f);

        icPos = iPos + (icPos - iPos).normalisedCopy() * (iPos - jPos).length() * strongi;
        jcPos = jPos + (jcPos - jPos).normalisedCopy() * (iPos - jPos).length() * strongj;

        result.a = iPos;
        result.ac = icPos;
        result.bc = jcPos;
        result.b = jPos;

        return result;
    }

    std::vector<PiketWall>Piket::propagateWallBesier3(int h, int i, int j, int k, int addWallsNum, float strong) const {
        std::vector<PiketWall>result;

        LineBesier3 lineBezier3 = getCutSegmentBesier3(h, i, j, k, strong);

        // Debug::inst()->drawLine(lineBezier3.a, lineBezier3.b, Color::Red);
        //
        // Debug::inst()->drawLine(lineBezier3.b, lineBezier3.bc, Color::Red);

        for (int addWallIdx = 1; addWallIdx <= addWallsNum; addWallIdx++) {
            double t = (float)addWallIdx / (addWallsNum + 1);
            V3 pos = besier3(t, lineBezier3);
            result.push_back(PiketWall(pos));
        }
        return result;
    }

    Piket::LeftRight Piket::getCornerCutPoints(V3 lookDirection, V3 norm) const {   
        bool swap = false;
        if (norm.z < 0 || (norm.z == 0 && norm.y < 0) || (norm.z == 0 && norm.y == 0 && norm.x < 0)) {
            swap = true;
            norm = -norm;
        }
    
        LeftRight lr;
        lr.left = V3(0, 0, 0);
        lr.right = V3(0, 0, 0);
        AssertReturn(lookDirection != V3::ZERO, return lr);

        V3 piketPos = piketEffectivePos;

        const std::vector<WallProj>&rotWalls = getWalls2d(norm);

        V3 axis = lookDirection.crossProduct(norm).normalisedCopy();
        if (axis.isZeroLength())
            axis = lookDirection.crossProduct(V3::UNIT_Z).normalisedCopy();
        if (axis.isZeroLength())
            axis = lookDirection.crossProduct(V3::UNIT_X).normalisedCopy();
        // debugDraw(piketPos, piketPos + axis * 10);
        float min = FLT_MAX;
        float max = -(FLT_MAX / 2);

        for (int i = 0; i < rotWalls.size(); i++) {
            int j = (i + 1) % rotWalls.size();

            V3 iPos = classifiedWalls[rotWalls[i].idx].pos;
            V3 jPos = classifiedWalls[rotWalls[j].idx].pos;

            float val = projectPointToVector(axis, iPos - piketPos);
            if (val >= max) {
                max = val;
                lr.right = iPos;
            }
            if (val < min) {
                min = val;
                lr.left = iPos;
            }

            int addWallsNum = std::ceil(std::max(0.0f, iPos.distance(jPos) / PointsInMeter * 8 - 2));

            int wallsNum = rotWalls.size();
            int h = (wallsNum + i - 1) % wallsNum;
            int k = (wallsNum + j + 1) % wallsNum;
            std::vector<PiketWall>addinWalls = propagateWallBesier3(rotWalls[h].idx, rotWalls[i].idx, rotWalls[j].idx, rotWalls[k].idx, addWallsNum);

            for (int j = 0; j < addinWalls.size(); j++) {
                const PiketWall& pWall = addinWalls[j];
                float val = projectPointToVector(axis, pWall.pos - piketPos);
                if (val >= max) {
                    max = val;
                    lr.right = pWall.pos;
                }
                if (val < min) {
                    min = val;
                    lr.left = pWall.pos;
                }
            }
        }
        if (swap) std::swap(lr.left, lr.right);
        return lr;
        // if (const LeftRight* res = cache.getCornerCut(lookDirection)) {
        // return *res;                                                                                                         
        // } else {
        // cache.setCornerCut(lr, lookDirection);
        // return getCornerCutPoints(lookDirection);
        // }
    }

    void Piket::classifyWalls() {
        classifiedWalls.clear();
        for (int i = 0; i < allWalls.size(); i++) {
            classifiedWalls.push_back(PiketWall(allWalls.at(i).pos));
            // if (!allWalls.at(i)->ignoreAt3d) {
            // }
        }

        if (classifiedWalls.size() == 1) {
            classifiedWalls.push_back(PiketWall(pos));
        }

        resetCache();
    }

    void Piket::addFakeWall(const PiketWall& wall) {
        classifiedWalls.push_back(wall);
        resetCache();
    }

    void Piket::convertToExtendedElevation(float rate) {
        AssertReturn(!allP3D.empty(), return);
        LOG(getName());
        pos = getExtendedElevationPos(rate);
        V3 z0Dirrection(dirrection.x, dirrection.y, 0);
                 
        Quaternion rotQuat = Quaternion::IDENTITY;
        if (adjPikets.size() > 1) {     
            float minAngleDiff = FLT_MAX;
            const Piket* pik1 = nullptr;
            const Piket* pik2 = nullptr;
            for (int i = 0; i < adjPikets.size()-1; i++) {
                V3 origDirToI = adjPikets[i]->origPos - origPos;
                origDirToI.z = 0;
                
                if (origDirToI.length() < 0.01 * PointsInMeter) continue;
                
                V3 newDirToI = adjPikets[i]->getExtendedElevationPos(rate) - pos;
                newDirToI.z = 0;
                for (int j = i+1; j < adjPikets.size(); j++) {
                    V3 origDirToJ = adjPikets[j]->origPos - origPos;
                    origDirToJ.z = 0;
                    V3 newDirToJ = adjPikets[j]->getExtendedElevationPos(rate) - pos;
                    newDirToJ.z = 0;
                                       
                    if (origDirToJ.length() < 0.01 * PointsInMeter) continue;
                
                    float diff = abs(newDirToI.angleBetween(newDirToJ).valueRadians() - origDirToI.angleBetween(origDirToJ).valueRadians());
                    if (diff < minAngleDiff) {
                        minAngleDiff = diff;
                        pik1 = adjPikets[i];
                        pik2 = adjPikets[j];
                    }
                }
            }
            
            if (pik1 && pik2) {
                V3 origDir = z0Dirrection;
                
                V3 origDirTo1 = pik1->origPos - origPos;
                origDirTo1.z = 0;
                V3 newDirTo1 = pik1->getExtendedElevationPos(rate) - pos;
                newDirTo1.z = 0;                       
                
                V3 origDirTo2 = pik2->origPos - origPos;
                origDirTo2.z = 0; 
                V3 newDirTo2 = pik2->getExtendedElevationPos(rate) - pos;
                newDirTo2.z = 0;   

                if (origDir.length() < 0.001) {
                    origDir = ((origDirTo1 + origDirTo2)/2).normalisedCopy();
                    if (origDir.length() < 0.001) {
                        origDir = (origDirTo2 - origDirTo1).crossProduct(Vector3::UNIT_Z).normalisedCopy();
                    }
                }
                
                float angleOrigDirToOrigDirTo1 = origDir.angleBetween(origDirTo1).valueRadians();
                float angleOrigDirToOrigDirTo2 = origDir.angleBetween(origDirTo2).valueRadians();

//                float rot1Mult = 1.0f - angleOrigDirToOrigDirTo1 / (angleOrigDirToOrigDirTo1 + angleOrigDirToOrigDirTo2);
//                float rot2Mult = 1.0f - angleOrigDirToOrigDirTo2 / (angleOrigDirToOrigDirTo1 + angleOrigDirToOrigDirTo2);

                V3 d1 = origDirTo1.getRotationTo(newDirTo1, V3::UNIT_Z) * origDir;
                V3 d2 = origDirTo2.getRotationTo(newDirTo2, V3::UNIT_Z) * origDir;
                
                rotQuat = origDir.getRotationTo(d1 + d2);
            }
        }

        if (rotQuat == Quaternion::IDENTITY) {
            for (int i = 0; i < adjPikets.size(); i++) {
                V3 origDirToAdj = adjPikets[i]->origPos - origPos;
                origDirToAdj.z = 0;

                V3 newDirToAdj = adjPikets[i]->getExtendedElevationPos(rate) - pos;
                newDirToAdj.z = 0;

                if (origDirToAdj.length() > 0.01 * PointsInMeter) {
                    rotQuat = origDirToAdj.getRotationTo(newDirToAdj, V3::UNIT_Z);
                    break;
                }
            }
        }

//        float minAngle = M_PI * 2;
//        const Piket* minAnglePiket = NULL;
//        bool reverted = false;
//        for (int i = 0; i < adjPikets.size(); i++) {
//            const Piket* adjPik = adjPikets[i];
//            if (adjPik) {
//                V3 vecToPik = (adjPik->origPos - origPos); // .normalisedCopy();
//                vecToPik.z = 0;
//                if (vecToPik.length() > 0.25 * PointsInMeter) {
//                    float angle = noZDirrection.angleBetween(vecToPik).valueRadians();
//                    if (angle < minAngle) {
//                        minAngle = angle;
//                        minAnglePiket = adjPik;
//                        reverted = false;
//                    }
//                    vecToPik = -vecToPik;
//                    angle = noZDirrection.angleBetween(vecToPik).valueRadians();
//                    if (angle < minAngle) {
//                        minAngle = angle;
//                        minAnglePiket = adjPik;
//                        reverted = true;
//                    }
//                }
//            }
//        }
//
//        bool rotateForward = true;
//        if (minAnglePiket && minAnglePiket->getExtendedElevationX() < getExtendedElevationX()) {
//            rotateForward = false;
//        }
//
//        if (reverted)
//            rotateForward = !rotateForward;
//        /* rotateForward = !rotateForward; */
//
//        V3 z0Dirrection(dirrection.x, dirrection.y, 0);
//        V3 z0DSTDirrection(rotateForward ? 1 : -1, 0, 0);
//
//        Quaternion rotQuat = z0Dirrection.getRotationTo(z0DSTDirrection);
        dirrection = rotQuat * dirrection;

        for (int i = 0; i < classifiedWalls.size(); i++) {
            PiketWall& wall = classifiedWalls[i];
            V3 relPos = wall.pos - origPos;

            relPos = rotQuat * relPos;
            wall.pos = relPos + pos;
        }

        // for (int i = 0; i < allWalls.size(); i++) {
        // Wall& wall = allWalls[i];
        // V3 relPos = wall.pos - oldPos;
        // relPos = rot * relPos;
        // wall.pos = relPos + pos;
        // }

        updateEffectivePos();
        updateWallsCenter();
    }

    bool Piket::isInactive() const {
        return !hasNoPriz(MARK_Z_SURVEY);
    }

    bool Piket::hasPriz(PiketMark priz) const {
        for (int i = 0; i < allP3D.size(); i++) {
            int res = allP3D[i].priz & priz;
            if (res > 0)
                return true;
        }

        return false;
    }

    bool Piket::hasNoPriz(PiketMark priz) const {
        for (int i = 0; i < allP3D.size(); i++) {
            int res = allP3D[i].priz & priz;
            if (res == 0)
                return true;
        }

        return false;
    }

//    Color Piket::getColorOfP3DWithPriz(PiketMark priz) const {
//        for (int i = 0; i < allP3D.size(); i++) {
//            if (priz & allP3D[i].priz) {
//                return allP3D[i].col;
//            }
//        }
//        return Color::Green;
//    }

    PiketMark Piket::getSumPriz() const {
        PiketMark res = MARK_NONE;
        for (int i = 0; i < allP3D.size(); i++) {
            res = (PiketMark)(res | allP3D[i].priz);
        }
        return res;
    }

//    Color Piket::getPrevailWallColor() const {
//        Color col = Color::Green;
//        int walls = 0;
//        for (int i = 0; i < allP3D.size(); i++) {
//            if (allP3D[i].hasWalls >= walls) {
//                walls = allP3D[i].hasWalls;
//                col = allP3D[i].col;
//            }
//        }
//        return col;
//    }

    std::vector< const Piket*>Piket::getAdjPiketsWithPriz(PiketMark prz) const {
        std::vector< const Piket*>res;
        for (int i = 0; i < adjPikets.size(); i++) {
            const Piket* piket = adjPikets[i];
            if (piket && piket->hasPriz(MARK_Z_SURVEY))
                res.push_back(piket);
        }
        return res;
    }

    std::vector< const Piket*>Piket::getAdjPiketsWithoutPriz(PiketMark prz) const {
        std::vector< const Piket*>res;
        for (int i = 0; i < adjPikets.size(); i++) {
            const Piket* piket = adjPikets[i];
            if (piket && !piket->hasPriz(MARK_Z_SURVEY))
                res.push_back(piket);
        }
        return res;
    }

    // void Piket::debugDraw(V3 a, V3 b, Color col) {
    // DEBUG_DRAW(a, b col);
    ////	debugManualObject->position(a);
    ////	debugManualObject->colour(col);
    ////	debugManualObject->position(b);
    // }

    float Piket::getMaxDimension() const {
        float maxDist = 0;
        for (int i = 0; i < classifiedWalls.size(); i++) {
            for (int j = i + 1; j < classifiedWalls.size(); j++) {
                float dist = classifiedWalls[i].pos.distance(classifiedWalls[j].pos);
                maxDist = std::max(dist, maxDist);
            }
        }
        return maxDist;
    }

    std::string Piket::getLabel() const {
        if (!allP3D.empty()) {
            return "";
        }
        return allP3D.front().label;
    }

    std::string Piket::getName() const {
        std::vector<std::string> names;
        for (int i = 0; i < allP3D.size(); i++) {
            names.push_back( allP3D[i].name);// += allP3D[i].name + " ";
        }
        std::sort(names.begin(), names.end());
        names.erase(std::unique(names.begin(), names.end()), names.end());
        if (names.size() == 1) {
            return names.front();
        } else {
            return ToString(names);
        }                    
        // if (allP3D.empty()) {
        // return "";
        // }
        // return allP3D.front().name;
    }

    const std::vector<CM::WallProj>& Piket::getWalls2d(V3 dirrection) const {
        if (const std::vector<WallProj> *res = cache.getWalls2d(dirrection)) {
            return *res;
        }
        else {
//            if (const std::vector<CM::WallProj> *reverseW2d = cache.getWalls2d(-dirrection)) {
//                std::vector<CM::WallProj>copyForRevert = *reverseW2d;
//                std::reverse(copyForRevert.begin(), copyForRevert.end());
//                for (int i = 0; i < copyForRevert.size(); i++) {
//                    copyForRevert[i].to0XAngleBySelfDir = Radian(2 * M_PI) - copyForRevert[i].to0XAngleBySelfDir;
//                    copyForRevert[i].posBySelfDir.x = -copyForRevert[i].posBySelfDir.x;
//                }
//                cache.addWalls2d(dirrection, copyForRevert);
//                return getWalls2d(dirrection);
//            }
//            else {
                cache.addWalls2d(dirrection, CM::getWalls2d(piketEffectivePos, dirrection, classifiedWalls));
                return getWalls2d(dirrection);
//            } 
        }
    }

    const std::vector<CM::WallProj>& Piket::getWalls2dWithConvexCorrection(V3 dirrection) const {
        if (const std::vector<WallProj> *res = cache.getWalls2dWithConvexCorrection(dirrection)) {
            return *res;
        }
        else {
//            if (const std::vector<CM::WallProj> *reverseW2d = cache.getWalls2dWithConvexCorrection(-dirrection)) {
//                std::vector<CM::WallProj>copyForRevert = *reverseW2d;
//                std::reverse(copyForRevert.begin(), copyForRevert.end());
//                for (int i = 0; i < copyForRevert.size(); i++) {
//                    copyForRevert[i].to0XAngleBySelfDir = Radian(2 * M_PI) - copyForRevert[i].to0XAngleBySelfDir;
//                    copyForRevert[i].posBySelfDir.x = -copyForRevert[i].posBySelfDir.x;
//                }
//                cache.addWalls2dWithConvexCorrection(dirrection, copyForRevert);
//                return getWalls2dWithConvexCorrection(dirrection);
//            }
//            else {
                cache.addWalls2dWithConvexCorrection(dirrection, CM::getWalls2dWithConvexCorrection(piketEffectivePos, dirrection, classifiedWalls));
                return getWalls2dWithConvexCorrection(dirrection);
//            }
        }
    }

    std::vector<ExtWallProj>Piket::convertToExtWalls2d(const std::vector<WallProj>& source, V3 globalDirrection) const {
        Quaternion globalDirrectionRotation = globalDirrection.getRotationTo(V3::UNIT_Z);
        std::vector<ExtWallProj>result;
        const V3 center = piketEffectivePos;
        for (int i = 0; i < source.size(); i++) {
            const PiketWall& w = classifiedWalls[source[i].idx];
            V3 globalRotWall = globalDirrectionRotation * (w.pos - center);
            V2 globalProjPos(globalRotWall.x, globalRotWall.y);
            // Radian toGlobal0XAngle = V2::UNIT_X.angleTo(globalProjPos);
            result.emplace_back(source[i], globalProjPos);
        }
        return result;
    }

    std::vector<ExtWallProj>Piket::getExtWalls2d(V3 sortDirrection, V3 globalDirrection) const {
        const std::vector<WallProj>&wall2d = getWalls2d(sortDirrection);
        return convertToExtWalls2d(wall2d, globalDirrection);
    }

    std::vector<ExtWallProj>Piket::getExtWalls2dWithConvexCorrection(V3 sortDirrection, V3 globalDirrection) const {
        const std::vector<WallProj>&wall2d = getWalls2dWithConvexCorrection(sortDirrection);
        return convertToExtWalls2d(wall2d, globalDirrection);
    }

    const std::vector<CM::LineBesier3>& Piket::getCutBezier3() const {
        if (const std::vector<CM::LineBesier3> *res = cache.getCutBezier3()) {
            return *res;
        }
        else {
            std::vector<CM::LineBesier3>temp;

            std::vector<WallProj>rotWalls = getWalls2d(dirrection);

            int wallsNum = rotWalls.size();
            for (int i = 0; i < rotWalls.size(); i++) {
                int j = (i + 1) % rotWalls.size();

                V3 iPos = classifiedWalls[rotWalls[i].idx].pos;
                V3 jPos = classifiedWalls[rotWalls[j].idx].pos;

                int h = (wallsNum + i - 1) % wallsNum;
                int k = (wallsNum + j + 1) % wallsNum;

                temp.push_back(getCutSegmentBesier3(rotWalls[h].idx, rotWalls[i].idx, rotWalls[j].idx, rotWalls[k].idx));
            }

            cache.setCutBezier3(temp);
            return *cache.getCutBezier3();
        }
    }

    void Piket::getCrossPiketLineBesier3(std::vector<CrossPiketLineBesier3>& output) const {
        const std::vector<CM::LineBesier3>&cut = getCutBezier3();
        for (int i = 0; i < cut.size(); i++) {
            CrossPiketLineBesier3 cutSegment(id, id, cut[i]);
            output.push_back(cutSegment);
        }
    }

    float Piket::getMinCutDimension() const {
        if (const float* res = cache.getMinCutDimension()) {
            return *res;
        }
        else {
            float maxDim = getMaxDimension();
            float square = polySquare(getWalls2d(dirrection));
            float minDim = 0;
            if (maxDim > 0)
                minDim = square / maxDim / (M_PI * 0.9) * 4;
            cache.setMinCutDimension(minDim);
            return minDim;
        }
    }

    float Piket::getExtendedElevationX() const {
        AssertReturn(!allP3D.empty(), return 0;);
        return allP3D.front().extendedElevationX;
    }

    void PiketCache::addWalls2d(V3 dirrection, std::vector<WallProj>w2d) {
        std::vector<Walls2dCache>::iterator it = walls2d.begin();
        for (; it != walls2d.end(); it++) {
            if (it->dirrection == dirrection) {
                it->walls2d = w2d;
                return;
            }
        }
        Walls2dCache cache;
        cache.dirrection = dirrection;
        cache.walls2d = w2d;
        walls2d.push_back(cache);
    }

    void PiketCache::addWalls2dWithConvexCorrection(V3 dirrection, std::vector<WallProj>w2d) {
        std::vector<Walls2dCache>::iterator it = walls2dWithConvexCorrection.begin();
        for (; it != walls2dWithConvexCorrection.end(); it++) {
            if (it->dirrection == dirrection) {
                it->walls2d = w2d;
                return;
            }
        }
        Walls2dCache cache;
        cache.dirrection = dirrection;
        cache.walls2d = w2d;
        walls2dWithConvexCorrection.push_back(cache);
    }

    void PiketCache::reset() {
        walls2d.clear();
        walls2dWithConvexCorrection.clear();
        delete minCutDimension;
        minCutDimension = NULL;
        delete cutBezier3;
        cutBezier3 = NULL;
    }

    const std::vector<WallProj> * PiketCache::getWalls2d(V3 dirrection) const {
        std::vector<Walls2dCache>::const_iterator it = walls2d.begin();
        for (; it != walls2d.end(); it++) {
            if (it->dirrection == dirrection)
                return&(it->walls2d);
        }
        return NULL;
    }

    const std::vector<WallProj> * PiketCache::getWalls2dWithConvexCorrection(V3 dirrection) const {
        std::vector<PiketCache::Walls2dCache>::const_iterator it = walls2dWithConvexCorrection.begin();
        for (; it != walls2dWithConvexCorrection.end(); it++) {
            if (it->dirrection == dirrection)
                return&(it->walls2d);
        }
        return NULL;
    }

}
