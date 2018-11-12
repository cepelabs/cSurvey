// ---------------------------------------------------------------------------

#define OGRE_DEBUG_MODE 1
                   
#include "CMtext.h"
#include "CMCave.h"
#include "CMAssertions.h"
#include "stdio.h"           
#include "CMHelpers.h"
#include "OgreMath.h"     
#include "wykobi.hpp"     
#include "wykobi_wrap.h"   
#include "CMtext.h"
#include "CMcommon.h"
#include <iostream>
#include "CMLog.h" 
#include "CMcommon.h" 
#include <math.h>  

namespace CM {

    using namespace std;
    using namespace tr1;
    using namespace Ogre;
    using namespace wykobi;

    Cave::Cave() : debugTriangulationAlgo(false), wasInited(false), shouldConvertToExtendedElevation(false), colourMult(1.0f), prebuildInvalidated(true) {

    }

    void Cave::finishInit(OutputType enabledToGenerateOutput) {
        enabledToGenerate = enabledToGenerateOutput;

        if (!shouldConvertToExtendedElevation)
            buildFakeZSurveyPikets();

        prebuildPikets();

        buildThreadObject();
        buildBoxObject();

        buildWallsObject();
        buildOutline();
        buildOutlineCut();
        buildCutsObject();
        updateWallsSurrfaceMode();

        wasInited = true;
    }

    void Cave::convertToExtendedElevation(float rate) {
        AssertReturn(!wasInited, return;);

        std::tr1::unordered_map<int, Piket>::iterator pikiIt;
        for (pikiIt = pikets.begin(); pikiIt != pikets.end(); pikiIt++) {
            pikiIt->second.convertToExtendedElevation(rate);
        }
    }

    std::vector<CM::CrossPiketLineBesier3> Cave::calcOutineBesier() const {

        std::tr1::unordered_set<int> piketsForCreateCutOutline;
        std::vector<CrossPiketLineBesier3>outineBesier;

        AssertReturn(wasInited, LOG("fail to calc outline: cave not finish initialisation "); return outineBesier;);

        buildOutlineBezier(outineBesier, &piketsForCreateCutOutline);

        std::tr1::unordered_set<int>::const_iterator it = piketsForCreateCutOutline.begin();
        for (; it != piketsForCreateCutOutline.end(); it++) {
            const Piket* piket = getPiket(*it);
            AssertReturn(piket, continue;);
            piket->getCrossPiketLineBesier3(outineBesier);
        }
        return outineBesier;
    }

    Cave::~Cave() {
    }

    bool Cave::setCaveViewPrefs(const CaveViewPrefs& prefs) {
        if (!wasInited) {
            caveViewPrefs = prefs;
            return false;
        }
        outputChanged.clear();

        caveViewPrefs.wallsSurfaceMode = prefs.wallsSurfaceMode;
        caveViewPrefs.showDebug = prefs.showDebug;
        caveViewPrefs.fillRate = prefs.fillRate;
        caveViewPrefs.ambientLightStrength = prefs.ambientLightStrength;
        caveViewPrefs.showThread = prefs.showThread;
        caveViewPrefs.showWallLines = prefs.showWallLines;
        caveViewPrefs.showBox = prefs.showBox;
        bool lookDirrectionChanged = (caveViewPrefs.lookDirrection != prefs.lookDirrection);
        caveViewPrefs.lookDirrection = prefs.lookDirrection;
        caveViewPrefs.showOutline = prefs.showOutline;        
        bool generateWallsForNoWallsPiketsModeChanged = (caveViewPrefs.generateWallsForNoWallsPiketsMode != prefs.generateWallsForNoWallsPiketsMode);

        if (caveViewPrefs != prefs) {
            caveViewPrefs = prefs;

            if (caveViewPrefs.darkMode)
                colourMult = 0.6f;
            else
                colourMult = 1.0f;

            if (generateWallsForNoWallsPiketsModeChanged) {
                invalidatePrebuild();
            }

            resetOutput(OT_DEBUG);
            resetOutput(OT_DEBUG2);

            buildThreadObject();
            buildWallsObject();
            buildCutsObject();
            buildOutline();
            buildOutlineCut();
            updateWallsSurrfaceMode();

            return true;
        }
        else {               
            updateWallsSurrfaceMode();
            if (lookDirrectionChanged) {
                buildOutline();
                if (!caveViewPrefs.allOutlineCuts) buildOutlineCut();
                return true;
            }
            else {
                return false;
            }
        }
    }

    void Cave::updateWallsSurrfaceMode() {
        outputLayers[OT_THREAD] = caveViewPrefs.showThread;
        outputLayers[OT_DEBUG] = caveViewPrefs.showDebug;
        outputLayers[OT_DEBUG2] = caveViewPrefs.showDebug;
        outputLayers[OT_WALL] = caveViewPrefs.wallsSurfaceMode == WSFM_SURF;
        outputLayers[OT_WALL_CUTS] = caveViewPrefs.showSections;
        outputLayers[OT_BOX] = caveViewPrefs.showBox;
        outputLayers[OT_OUTLINE] = caveViewPrefs.showOutline;
        outputLayers[OT_OUTLINE_CUT] = caveViewPrefs.showOutline;
    }

    void Cave::buildFakeZSurveyPikets() {
        std::set< const Piket*>processedPikets;
        std::tr1::unordered_map<int, Piket>::iterator pikiIt;
        for (pikiIt = pikets.begin(); pikiIt != pikets.end(); pikiIt++) {
            Piket* curPiket = &pikiIt->second;
            std::vector< const Piket*>zEdges = getZSurveyEdges(curPiket);
            if (!zEdges.empty() && processedPikets.count(curPiket) == 0) {
                // cчитаем количество соседних пикетов зигзаг-съемки
                int numAdjZSurvPikets = zEdges.size();
                if (numAdjZSurvPikets == 1) { // если это крайний пикет съемки
                    CMLog a;
                    LOG("start process zig-zag survey");
                    std::list< const Piket*>piketsChain;
                    const Piket* chainPiket = curPiket;
                    processedPikets.insert(curPiket);
                    piketsChain.push_back(curPiket);
                    LOG("   add link " << curPiket->id << " label \"" << curPiket->getLabel() << "\"");
                    bool endReached = false;
                    do { // строим цепочку
                        endReached = true;
                        std::vector< const Piket*>zEdges = getZSurveyEdges(chainPiket);
                        for (int i = 0; i < zEdges.size(); i++) {
                            const Piket* adjPiket = zEdges[i];
                            if (adjPiket && processedPikets.count(adjPiket) == 0) {
                                processedPikets.insert(adjPiket);
                                piketsChain.push_back(adjPiket);
                                chainPiket = adjPiket;
                                LOG("   add link " << chainPiket->id << " label \"" << chainPiket->getLabel() << "\"");
                                endReached = false;
                                break;
                            }
                        }
                    }
                    while (!endReached);

                    if (piketsChain.size() > 1) {
                        processZSurveyPiketsChain(piketsChain);
                    }
                    LOG("finish process zig-zag survey");
                }
            }
        }
    }

    void Cave::processZSurveyPiketsChain(const std::list< const Piket*>& chain) {
        if (chain.size() < 2)
            return;

        int piketsMedNum = 0;
        V3 piketsMedPos(0, 0, 0);
//        Color col = Color::None;
        int edgeColNum = 0;
        Color edgeCol = Color::None;
        PiketMark priz = MARK_NONE;
        std::vector<Wall>wallsSumm;
        std::vector<EdgeInfo>externalEdges;
        const Piket* prevPiket = NULL;
        const Piket* prevFakePiket = NULL;
        // std::vector<Color> adjPketsEdgesColors;

        bool prevLinkWasTurn = false; ;
        std::list< const Piket*>::const_iterator it = chain.begin();
        while (true) {
            const Piket* linkPiket = NULL;
            if (it != chain.end()) {
                prevPiket = linkPiket;
                linkPiket = *it;
                piketsMedNum++;
                piketsMedPos += linkPiket->pos;
//                col += linkPiket->getColorOfP3DWithPriz(MARK_Z_SURVEY);
                wallsSumm.insert(wallsSumm.end(), linkPiket->allWalls.begin(), linkPiket->allWalls.end());
                std::vector< const Piket*>linkAdjPkets = linkPiket->getAdjPiketsWithoutPriz(MARK_Z_SURVEY);
                // adjPkets.insert(adjPkets.end(), linkAdjPkets.begin(), linkAdjPkets.end());
                for (int i = 0; i < linkAdjPkets.size(); i++) {
                    externalEdges.push_back(EdgeInfo(linkAdjPkets[i]->id, 0, getColorForEdge(linkPiket, linkAdjPkets[i])));
                }
                if (prevPiket) {
                    Color edgeColor = getColorForEdge(prevPiket, linkPiket);
                    if (!edgeColor.isNone()) {
                        edgeColNum++;
                        edgeCol += edgeColor;
                    }
                }
                priz = (PiketMark)(priz | linkPiket->getSumPriz());

                LOG("   add piket " << linkPiket->id << " to group");
            }

            if ((linkPiket && linkPiket->hasPriz(MARK_Z_TURN) && !prevLinkWasTurn) || it == chain.end()) {
                prevLinkWasTurn = true;
                priz = (PiketMark)(priz&~MARK_Z_SURVEY&~MARK_Z_TURN);
                priz = (PiketMark)(priz | MARK_Z_SURVEY_FAKE);
                //col /= piketsMedNum;
                if (prevFakePiket) {
                    if (!edgeCol.isNone()) {
                        edgeCol /= edgeColNum;
                        externalEdges.push_back(EdgeInfo(prevFakePiket->id, 0, edgeCol));
                    }
                }
                LOG("   fix piket with  " << piketsMedNum << " pikets, pos " << piketsMedPos << " and " << wallsSumm.size() << " walls");
                const Piket* fakePiket = addFakePiket(piketsMedPos / (Real)piketsMedNum, /*col,*/ priz, wallsSumm, externalEdges);
                piketsMedNum = 0;
                piketsMedPos = V3(0, 0, 0);
                //col = Color::None;
                priz = MARK_NONE;
                wallsSumm.clear();
                externalEdges.clear();
                prevFakePiket = fakePiket;
                prevPiket = NULL;
                edgeColNum = 0;
                edgeCol = Color::None;

                if (it == chain.end())
                    break;
            }
            else {
                prevLinkWasTurn = false;
                it++;
            }
        }
    }

    const Piket* Cave::addFakePiket(V3 pos, /*Color col,*/ PiketMark priz, const std::vector<Wall>& walls, const std::vector<EdgeInfo>& edges) {

        PiketInfo fakePiketInfo;
        fakePiketInfo.pos = pos;
//        fakePiketInfo.col = col;
        fakePiketInfo.priz = priz;
        // fakePiketsData.push_back(fakePiketInfo);

        int piketId = fakePiketInfo.id; // getFreePiketId();
        pikets.insert(make_pair(piketId, Piket(fakePiketInfo)));

        Piket* fakePiket = getPiketMut(piketId);
        fakePiket->allWalls.insert(fakePiket->allWalls.end(), walls.begin(), walls.end());

        for (int i = 0; i < edges.size(); i++) {
            int adjPiketId = edges[i].fromPiketId;
            Piket* adjPiket = getPiketMut(adjPiketId);
            adjPiket->adjPikets.push_back(fakePiket);
            fakePiket->adjPikets.push_back(adjPiket);

            if (!edges[i].col.isNone()) {
                this->edges[make_pair(std::min(piketId, adjPiketId), std::max(piketId, adjPiketId))] = EdgeInfo(piketId, adjPiketId, edges[i].col);
            }
        }

        return fakePiket;
    }

    void Cave::genPiketsFakeWalls(FakeWallsMode mode) {
        if (mode == GWNWPM_NONE)
            return;
        std::tr1::unordered_map<int, Piket>::iterator pikiIt;
        for (pikiIt = pikets.begin(); pikiIt != pikets.end(); pikiIt++) {
            Piket* curPiket = &pikiIt->second;
            if (!curPiket->classifiedWalls.empty() && !curPiket->isInactive()) {
                std::vector<Piket*>noWallsPikets;
                genPiketsFakeWallsСhainSearch(mode, curPiket, curPiket, 0, noWallsPikets);
            }
        }
    }
    std::tr1::unordered_map<int, Piket>::iterator pikiIt;

    void Cave::genPiketsFakeWallsСhainSearch(FakeWallsMode mode, Piket* beginPiket, Piket* curEnd, int accumLength, std::vector<Piket*>& intermPikets) {
        AssertReturn(curEnd, return);
        for (int i = 0; i < curEnd->adjPikets.size(); i++) {
            Piket* piket = getPiketMut(curEnd->adjPikets[i]->id);
            if (beginPiket == piket)
                continue; // loop
            if (beginPiket->isInactive())
                continue; // zsurvey
            if (find(intermPikets.begin(), intermPikets.end(), piket) != intermPikets.end())
                continue; // loop

            if (!piket->classifiedWalls.empty()) {
                if (!intermPikets.empty())
                    genPiketsFakeWallsProcessChain(mode, beginPiket, intermPikets, piket);
            }
            else {
                if (intermPikets.size() >= caveViewPrefs.stretchWallsOverPiketNumMax)
                    break; // too long walls stretch

                intermPikets.push_back(piket);
                genPiketsFakeWallsСhainSearch(mode, beginPiket, piket, accumLength, intermPikets);
                intermPikets.pop_back();
            }
        }
    }

    void Cave::genPiketsFakeWallsProcessChain(FakeWallsMode mode, Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket) {

        DLOG("Gnerate fake walls");
        DLOG("\t begin: " << beginPiket->id);
        string interm;
        for (int i = 0; i < intermPikets.size(); i++) {
            if (i > 0)
                interm.append(", ");
            interm.append(ToString(intermPikets[i]->id));
        }
        DLOG("\t interm: " << interm);
        DLOG("\t end: " << endPiket->id);

        AssertReturn(!beginPiket->classifiedWalls.empty(), return;);
        AssertReturn(!endPiket->classifiedWalls.empty(), return;);
        if (intermPikets.empty())
            return;

        for (int i = 0; i < intermPikets.size(); i++) {
            if (!intermPikets[i]->classifiedWalls.empty()) {
                if (i >= 1) {
                    std::vector<Piket*>head(intermPikets.begin(), intermPikets.begin() + i - 1);
                    genPiketsFakeWallsProcessChain(mode, beginPiket, std::vector<Piket*>(head), intermPikets[i]);
                }
                if (i <= intermPikets.size() - 2) {
                    std::vector<Piket*>tail(intermPikets.begin() + i + 1, intermPikets.end());
                    genPiketsFakeWallsProcessChain(mode, intermPikets[i], tail, endPiket);
                }

                return;
            }
        }

        if (mode == GWNWPM_SKIP) {
            genPiketsFakeWallsSkip(beginPiket, intermPikets, endPiket);
        }
        else if (mode == GWNWPM_TRAIL) {
            genPiketsFakeWallsTrail(beginPiket, intermPikets, endPiket);
        }
        else if (mode == GWNWPM_BUDGE) {
            genPiketsFakeWallsBudge(beginPiket, intermPikets, endPiket);
        }
    }

    void Cave::genPiketsFakeWallsSkip(Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket) {
        if (!CM::ContainerFind(beginPiket->adjFakePikets, endPiket))
            beginPiket->adjFakePikets.push_back(endPiket);
        if (!CM::ContainerFind(endPiket->adjFakePikets, beginPiket))
            endPiket->adjFakePikets.push_back(beginPiket);
    }

    void Cave::genPiketsFakeWallsBudge(Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket) {

        WallEdges wallEdges = separateTriangleForEdges(buildWallSegment(beginPiket, endPiket), beginPiket->classifiedWalls, endPiket->classifiedWalls);

        V3 endPiketPos = endPiket->pos;
        V3 beginPiketPos = beginPiket->pos;

        if (beginPiketPos == endPiketPos)
            return;

        V3 globalDirrection = endPiketPos - beginPiketPos;
        Quaternion toZ0RotationGlobal = globalDirrection.getRotationTo(V3::UNIT_Z);
        Quaternion fromZ0RotationGlobal = toZ0RotationGlobal.Inverse();
        fromZ0RotationGlobal.normalise();

        for (int i = 0; i < intermPikets.size(); i++) {

            Piket* curPiket = intermPikets[i];
            const Piket* prevPiket;
            if (i == 0)
                prevPiket = beginPiket;
            else
                prevPiket = intermPikets[i - 1];

            const Piket* nextPiket;
            if (i == intermPikets.size() - 1)
                nextPiket = endPiket;
            else
                nextPiket = intermPikets[i + 1];

            V3 curPiketPos = curPiket->pos;

            V3 prevDirrection = curPiketPos - prevPiket->pos;
            V3 nextDirrection = nextPiket->pos - curPiketPos;
            V3 localDirrection = (prevDirrection + nextDirrection).normalisedCopy();
            Quaternion globalToLocalRotation = globalDirrection.getRotationTo(localDirrection);

            Quaternion toZ0RotationLocal = localDirrection.getRotationTo(V3::UNIT_Z);
            Quaternion fromZ0RotationLocal = toZ0RotationLocal.Inverse();
            fromZ0RotationLocal.normalise();

            plane3d beginPiketNormalPlane = make_plane(V3toP3(beginPiketPos), V3toP3(globalDirrection));
            plane3d endPiketNormalPlane = make_plane(V3toP3(endPiketPos), V3toP3(globalDirrection));
            plane3d curPiketNormalPlane = make_plane(V3toP3(curPiketPos), V3toP3(globalDirrection));

            std::vector<point2d<float> >wallsPolygon2d;
            std::vector<V3>wallsPolygon3d;
            for (int j = 0; j < wallEdges.size(); j++) {
                V3 edgeBegin = wallEdges.at(j).first->pos;
                V3 edgeEnd = wallEdges.at(j).second->pos;

                line3df edgeLine = make_line(V3toP3(edgeBegin), V3toP3(edgeEnd));
                // line3df edgeLineBeforeBegin = make_line(V3toP3(edgeBegin), V3toP3(edgeBegin - globalDirrection));
                // line3df edgeLineAfterEnd = make_line(V3toP3(edgeEnd), V3toP3(edgeEnd + globalDirrection));

                V3 projCurToEdgeLine = P3toV3(intersection_point<float>(edgeLine, curPiketNormalPlane));
                float projToBeginDist = projCurToEdgeLine.distance(edgeBegin);
                float projToEndDist = projCurToEdgeLine.distance(edgeEnd);
                float beginToEndDistance = edgeBegin.distance(edgeEnd);
                if (std::max<float>(projToBeginDist, projToEndDist) > beginToEndDistance) {
                    if (projToBeginDist < projToEndDist) {
                        projCurToEdgeLine = edgeBegin;
                        // P3toV3(intersection_point<float>(edgeLineBeforeBegin, curPiketNormalPlane));
                    }
                    else {
                        projCurToEdgeLine = edgeEnd;
                        ///P3toV3(intersection_point<float>(edgeLineAfterEnd, curPiketNormalPlane));
                    }
                }

                V3 wallToZ0Rotated = toZ0RotationGlobal * (projCurToEdgeLine - curPiketPos);
                wallsPolygon2d.push_back(point2d<float>(wallToZ0Rotated.x, wallToZ0Rotated.y));
                wallsPolygon3d.push_back(projCurToEdgeLine);

                // debugDraw(projCurToEdgeLine, edgeEnd);
                // debugDraw(projCurToEdgeLine, edgeBegin);

            }

            // AssertReturn(wallsPolygon2d.size() >= 3, return);
            if (wallsPolygon2d.size() < 3)
                return;

            polygon<float, 2>wallsPolygon = make_polygon(wallsPolygon2d);

            V3 wallsShift2d(0, 0, 0);
            if (!point_in_polygon(0.0f, 0.0f, wallsPolygon)) {
                point2d<float>wallShift2dP2 = closest_point_on_polygon_from_point<float>(wallsPolygon, point2d<float>(0, 0));
                wallsShift2d.x = wallShift2dP2.x;
                wallsShift2d.y = wallShift2dP2.y;
            }
            V3 wallsShift3d = fromZ0RotationGlobal * wallsShift2d;

            for (int j = 0; j < wallsPolygon3d.size(); j++) {
                V3 pos = wallsPolygon3d[j] - (wallsShift3d * 1.05 + curPiketPos);
                // выключаем поворот по направлению хода
                // if (!wallsShift3d.isZeroLength()) pos = globalToLocalRotation * pos;
                pos += curPiketPos;
                curPiket->classifiedWalls.push_back(PiketWall(pos));
            }
            curPiket->recalcPosCenterDirrection();
        }
    }

    void Cave::genPiketsFakeWallsTrail(Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket) {

        float totalDist(0);
        std::vector<float>intermPiketsDist(intermPikets.size());
        for (int i = 0; i < intermPikets.size(); i++) {
            if (i == 0)
                totalDist += (intermPikets[i]->pos - beginPiket->pos).length();
            else
                totalDist += (intermPikets[i]->pos - intermPikets[i - 1]->pos).length();

            intermPiketsDist[i] = totalDist;
        }
        totalDist += (intermPikets.back()->pos - endPiket->pos).length();

        WallTriangles buildWalls = buildWallSegment(beginPiket, endPiket);
        // first- wall of beginPiket, second- list of triangle linked walls of endPiket
        std::map< const PiketWall*, std::set< const PiketWall*> >wallPairs;

        for (int i = 0; i < buildWalls.size(); i++) {
            const WallTriangle& trgl = buildWalls[i];
            bool aFromBeginPiket = (std::find_if(beginPiket->classifiedWalls.begin(), beginPiket->classifiedWalls.end(),
                ComareObjByAdr<PiketWall>(trgl.a)) != beginPiket->classifiedWalls.end());
            bool bFromBeginPiket = (std::find_if(beginPiket->classifiedWalls.begin(), beginPiket->classifiedWalls.end(),
                ComareObjByAdr<PiketWall>(trgl.b)) != beginPiket->classifiedWalls.end());
            bool cFromBeginPiket = (std::find_if(beginPiket->classifiedWalls.begin(), beginPiket->classifiedWalls.end(),
                ComareObjByAdr<PiketWall>(trgl.c)) != beginPiket->classifiedWalls.end());

            if (aFromBeginPiket) {
                if (!bFromBeginPiket)
                    wallPairs[trgl.a].insert(trgl.b);
                if (!cFromBeginPiket)
                    wallPairs[trgl.a].insert(trgl.c);
            }
            if (bFromBeginPiket) {
                if (!aFromBeginPiket)
                    wallPairs[trgl.b].insert(trgl.a);
                if (!cFromBeginPiket)
                    wallPairs[trgl.b].insert(trgl.c);
            }
            if (cFromBeginPiket) {
                if (!aFromBeginPiket)
                    wallPairs[trgl.c].insert(trgl.a);
                if (!bFromBeginPiket)
                    wallPairs[trgl.c].insert(trgl.b);
            }
        }

        V3 endPiketPos = endPiket->pos;
        V3 beginPiketPos = beginPiket->pos;
        V3 globalDirrection = beginPiketPos - endPiketPos;

        if (globalDirrection.isZeroLength()) {
            return;
        }

        for (int i = 0; i < intermPikets.size(); i++) {
            float progr = intermPiketsDist[i] / totalDist;

            Piket* curPiket = intermPikets[i];
            const Piket* prevPiket;
            if (i == 0)
                prevPiket = beginPiket;
            else
                prevPiket = intermPikets[i - 1];

            const Piket* nextPiket;
            if (i == intermPikets.size() - 1)
                nextPiket = endPiket;
            else
                nextPiket = intermPikets[i + 1];

            V3 curPiketPos = curPiket->pos;

            V3 prevDirrection = curPiketPos - prevPiket->pos;
            V3 nextDirrection = nextPiket->pos - curPiketPos;
            V3 localDirrection = (prevDirrection + nextDirrection).normalisedCopy();
            Quaternion rotation = globalDirrection.getRotationTo(localDirrection);
            rotation.normalise();

            plane3d beginPiketNormalPlane = make_plane(V3toP3(beginPiketPos), V3toP3(globalDirrection));
            plane3d endPiketNormalPlane = make_plane(V3toP3(endPiketPos), V3toP3(globalDirrection));
            plane3d curPiketNormalPlane = make_plane(V3toP3(curPiketPos), V3toP3(globalDirrection));

            std::map< const PiketWall*, std::set< const PiketWall*> >::iterator wpitBeg;
            for (wpitBeg = wallPairs.begin(); wpitBeg != wallPairs.end(); wpitBeg++) {
                V3 edgeBegin = wpitBeg->first->pos;

                std::set< const PiketWall*>::iterator wpitEnd;
                for (wpitEnd = wpitBeg->second.begin(); wpitEnd != wpitBeg->second.end(); wpitEnd++) {
                    V3 edgeEnd = (*wpitEnd)->pos;

                    // line3df edgeLine = make_line(V3toP3(edgeBegin), V3toP3(edgeEnd));
                    //
                    // point3df edgeBeginModP3 = intersection_point<float>(edgeLine, beginPiketNormalPlane);
                    // point3df edgeEndModP3 = intersection_point<float>(edgeLine, endPiketNormalPlane);

                    V3 edgeBeginMod = edgeBegin; // P3toV3(edgeBeginModP3);
                    V3 edgeEndMod = edgeEnd; // P3toV3(edgeEndModP3);

                    edgeBeginMod -= beginPiketPos;
                    edgeEndMod -= endPiketPos;

                    V3 pos = (edgeBeginMod * (1.0f - progr)) + (edgeEndMod * progr);
                    pos = rotation * pos;
                    pos += curPiket->pos;

                    float posToBeginDist = pos.distance(edgeBegin);
                    float posToEndDist = pos.distance(edgeEnd);
                    float beginToEndDistance = edgeBegin.distance(edgeEnd);
                    // ограничиваем, чтобы стены после поворота не выходили за передлы стен началного и конечного пикетов секции
                    if (std::max<float>(posToBeginDist, posToEndDist) > beginToEndDistance) {
                        if (posToBeginDist < posToEndDist)
                            pos = edgeBegin;
                        else
                            pos = edgeEnd;
                    }

                    curPiket->addFakeWall(PiketWall(pos));
                }
            }
            curPiket->recalcPosCenterDirrection();
        }
    }

    void Cave::addVertice(const PiketInfo& piketInfo, int id) {
        AssertReturn(!wasInited, LOG("fail to add vertice: cave already finish initialisation "); return;);

        Piket* curPiket = getPiketMut(id);
        if (!curPiket) {
            curPiket = &(pikets.insert(make_pair(piketInfo.id, Piket(piketInfo))).first->second);
        }
        else {
            curPiket->addP3D(piketInfo);
        }

        minZPos = std::min<float>(minZPos, piketInfo.pos.z);
        maxZPos = std::max<float>(maxZPos, piketInfo.pos.z);
    }

    void Cave::addEdge(const EdgeInfo& info) {
        AssertReturn(!wasInited, LOG("fail to add edge: cave already finish initialisation "); return;);

        addEdge(info.fromPiketId, info.toPiketId);
        edges[make_pair(std::min(info.fromPiketId, info.toPiketId), std::max(info.fromPiketId, info.toPiketId))] = info;
    }

    void Cave::addEdge(int verticeId0, int verticeId1) {
        AssertReturn(!wasInited, LOG("fail to add vertice: cave already finish initialisation "); return;);

        Piket* piket0 = getPiketMut(verticeId0);
        if (!piket0)
            LOG("fail to add edge: piket " << verticeId0 << " not found ");

        Piket* piket1 = getPiketMut(verticeId1);
        if (!piket1)
            LOG("fail to add edge: piket " << verticeId1 << " not found ");

        piket0->adjPikets.push_back(piket1);
        piket1->adjPikets.push_back(piket0);
    }

    void Cave::addWall(const Wall& wall, int linkToVerticeId, int parentPiketId) {
        AssertReturn(!wasInited, LOG("fail to add wall: cave already finish initialisation "); return;);

        if (parentPiketId == 0)
            parentPiketId = linkToVerticeId;

        Piket* curPiket = getPiketMut(linkToVerticeId);
        if (!curPiket) {
            LOG("fail to add wall: piket " << linkToVerticeId << " not found ");
        } else {
            curPiket->addW3D(parentPiketId, wall);
        }

        minZPos = std::min<float>(minZPos, wall.pos.z);
        maxZPos = std::max<float>(maxZPos, wall.pos.z);
    }

    void Cave::setShouldConvertToExtendedElevation(bool convert) {
        AssertReturn(!wasInited, LOG("fail to set shouldConvertToExtendedElevation: cave already finish initialisation "); return;);
        shouldConvertToExtendedElevation = convert;
    }

    void Cave::logPikets() {
        DLOG("Pikets:");
        std::tr1::unordered_map<int, Piket>::const_iterator piketsIt = pikets.begin();
        while (piketsIt != pikets.end()) {
            const Piket& piket = piketsIt->second;
            // piket.n
            DLOG('\t' << piket.id << " (met " << piket.getName() << ")" << " \"" << piket.getLabel() << "\"");
            DLOG("\t\tpos " << piket.pos);
            DLOG("\t\twalls " << piket.allWalls.size());
            string adjPiketsString;
            for (int i = 0; i < piket.adjPikets.size(); i++) {
                if (i != 0)
                    adjPiketsString.append(", ");
                adjPiketsString.append(ToString(piket.adjPikets[i]->id));
            }
            if (!adjPiketsString.empty())
                DLOG("\t\tadj " << adjPiketsString);

            string fakeAdjPiketsString;
            for (int i = 0; i < piket.adjFakePikets.size(); i++) {
                if (i != 0)
                    fakeAdjPiketsString.append(", ");
                fakeAdjPiketsString.append(ToString(piket.adjFakePikets[i]->id));
            }
            if (!fakeAdjPiketsString.empty())
                DLOG("\t\tfadj " << fakeAdjPiketsString);
            piketsIt++;
        }
    }

    void Cave::buildPointsObject() {

    }

    void Cave::buildBoxObject() {
        if (!isOutputEnabledToGenerate(OT_BOX)) {
            return;
        }
        resetOutput(OT_BOX);

        V3 boxMin(FLT_MAX, FLT_MAX, FLT_MAX);
        V3 boxMax(-FLT_MAX, -FLT_MAX, -FLT_MAX);
        std::tr1::unordered_map<int, Piket>::const_iterator it = pikets.begin();
        for (; it != pikets.end(); it++) {
            boxMin.x = std::min(boxMin.x, it->second.pos.x);
            boxMin.y = std::min(boxMin.y, it->second.pos.y);
            boxMin.z = std::min(boxMin.z, it->second.pos.z);

            boxMax.x = std::max(boxMax.x, it->second.pos.x);
            boxMax.y = std::max(boxMax.y, it->second.pos.y);
            boxMax.z = std::max(boxMax.z, it->second.pos.z);

            std::vector<Wall>::const_iterator wit = it->second.allWalls.begin();
            for (; wit != it->second.allWalls.end(); wit++) {
                boxMin.x = std::min(boxMin.x, wit->pos.x);
                boxMin.y = std::min(boxMin.y, wit->pos.y);
                boxMin.z = std::min(boxMin.z, wit->pos.z);

                boxMax.x = std::max(boxMax.x, wit->pos.x);
                boxMax.y = std::max(boxMax.y, wit->pos.y);
                boxMax.z = std::max(boxMax.z, wit->pos.z);
            }
        }

        addOutputLine(OT_BOX, V3(boxMin.x, boxMin.y, boxMin.z), V3(boxMax.x, boxMin.y, boxMin.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMin.x, boxMin.y, boxMin.z), V3(boxMin.x, boxMax.y, boxMin.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMin.x, boxMin.y, boxMin.z), V3(boxMin.x, boxMin.y, boxMax.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMax.y, boxMin.z), V3(boxMax.x, boxMin.y, boxMin.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMax.y, boxMin.z), V3(boxMin.x, boxMax.y, boxMin.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMin.y, boxMax.z), V3(boxMin.x, boxMin.y, boxMax.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMin.y, boxMax.z), V3(boxMax.x, boxMin.y, boxMin.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMin.x, boxMax.y, boxMax.z), V3(boxMin.x, boxMin.y, boxMax.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMin.x, boxMax.y, boxMax.z), V3(boxMin.x, boxMax.y, boxMin.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMax.y, boxMax.z), V3(boxMin.x, boxMax.y, boxMax.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMax.y, boxMax.z), V3(boxMax.x, boxMin.y, boxMax.z), Color(0.75, 0.0, 0.0));

        addOutputLine(OT_BOX, V3(boxMax.x, boxMax.y, boxMax.z), V3(boxMax.x, boxMax.y, boxMin.z), Color(0.75, 0.0, 0.0));
    }

    void Cave::buildCutsObject() {
        if (!isOutputEnabledToGenerate(OT_WALL_CUTS)) {
            return;
        }
        prebuildPikets();

        resetOutput(OT_WALL_CUTS);

        std::tr1::unordered_map<int, Piket>::iterator it = pikets.begin();
        for (; it != pikets.end(); it++) {
            const Piket* piket = &it->second;
            Color col = getColorForPiketAtEdge(piket, nullptr);
            Color polyecol = col;
            polyecol.a = 0.5f;

            const std::vector<WallProj>&rotWalls = piket->getWalls2d(piket->dirrection);
            for (int i = 0; i < ((int)rotWalls.size())/* + std::min(0, -caveViewPrefs.skipNum)*/; i++) {
                int ni = (i + 1) % rotWalls.size();
                const WallProj& iWallProj = rotWalls[i];
                const WallProj& niWallProj = rotWalls[ni];

                const PiketWall& iWall = piket->classifiedWalls[iWallProj.idx];
                const PiketWall& niWall = piket->classifiedWalls[niWallProj.idx];

                addOutputLine(OT_WALL_CUTS, iWall.pos, niWall.pos, col);
                addOutputPoly(OT_WALL_CUTS, piket->piketEffectivePos, iWall.pos, niWall.pos, polyecol);
            }
        }
    }

    void Cave::buildThreadObject() {
        if (!isOutputEnabledToGenerate(OT_THREAD)) {
            return;
        }
        resetOutput(OT_THREAD);

        std::tr1::unordered_map<int, Piket>::const_iterator itFrom = pikets.begin();
        for (; itFrom != pikets.end(); itFrom++) {
            const Piket& pFrom = itFrom->second;
            std::vector< const Piket*>::const_iterator itTo = pFrom.adjPikets.begin();
            for (; itTo != pFrom.adjPikets.end(); itTo++) {
                const Piket& pTo = **itTo;
                if (pFrom.id < pTo.id) {
                    Color fromCol = getColorForPiketAtEdge(&pFrom, &pTo);
                    Color toCol = getColorForPiketAtEdge(&pTo, &pFrom);
                    addOutputLine(OT_THREAD, pFrom.pos, pTo.pos, fromCol, toCol);
                }
            }
        }
    }

    void Cave::prebuildPikets() {
        if (prebuildInvalidated) {
            std::tr1::unordered_map<int, Piket>::iterator pikiIt;
            for (pikiIt = pikets.begin(); pikiIt != pikets.end(); pikiIt++) {
                pikiIt->second.preProcessWalls(caveViewPrefs);
            }

            
            if (shouldConvertToExtendedElevation)
                convertToExtendedElevation(1.0f -std::max(0, std::min(10, caveViewPrefs.skipNum)) / 10.0f);

            genPiketsFakeWalls(caveViewPrefs.generateWallsForNoWallsPiketsMode);
                                      
            prebuildInvalidated = false;
        }
    }

    void Cave::buildOutlineBezier(std::vector<CrossPiketLineBesier3>& output, std::tr1::unordered_set<int> * piketsForCreateCutOutline) const {

        unordered_map< const Piket*, std::vector< const Piket*> >buildWalls;
        std::tr1::unordered_map<int, Piket>::const_iterator it = pikets.begin();
        for (; it != pikets.end(); it++) {
            // if (segmentDraw > 0) break;
            int id = it->first;
            const Piket* curPiket = &it->second;
            if (curPiket->isInactive())
                continue;
            int i = 0;
            float adjPiketsNum = curPiket->adjPikets.size();
            float totalAdjPikets = curPiket->adjPikets.size() + curPiket->adjFakePikets.size();

            for (int j = 0; j < totalAdjPikets; j++) {
                const Piket* nextPiket = NULL;
                if (j < adjPiketsNum)
                    nextPiket = curPiket->adjPikets.at(j);
                else
                    nextPiket = curPiket->adjFakePikets.at(j - adjPiketsNum);

                if (nextPiket->isInactive())
                    continue;

                const Piket* minPiket = std::min(curPiket, nextPiket);
                const Piket* maxPiket = std::max(curPiket, nextPiket);

                std::vector< const Piket*>&buildOutlineForCurPiket = buildWalls[minPiket];
                if (find(buildOutlineForCurPiket.begin(), buildOutlineForCurPiket.end(), maxPiket) != buildOutlineForCurPiket.end()) {
                    continue;
                }
                else {
                    buildOutlineForCurPiket.push_back(maxPiket);
                }

                bool findAtadjPikets = find(nextPiket->adjPikets.begin(), nextPiket->adjPikets.end(), curPiket) != nextPiket->adjPikets.end();
                bool findAtFakeadjPikets = find(nextPiket->adjFakePikets.begin(), nextPiket->adjFakePikets.end(), curPiket) != nextPiket->adjFakePikets.end();
                AssertReturn(findAtFakeadjPikets || findAtadjPikets, continue);
                LOG("\tbuild segment " << nextPiket->id << " - " << curPiket->id);
                buildOutlineSegmenteBezier(nextPiket, curPiket, output, piketsForCreateCutOutline);
            }

        }
    }

    void Cave::buildOutlineCut() {
        if (!isOutputEnabledToGenerate(OT_OUTLINE) && !isOutputEnabledToGenerate(OT_OUTLINE_CUT)) {
            return;
        }

        LOG("Cave builld outline cut object started");

        prebuildPikets();

        resetOutput(OT_OUTLINE_CUT);

        std::vector<CrossPiketLineBesier3> outlineCutsBezier;

        unordered_map< const Piket*, std::vector< const Piket*> >buildWalls;
        std::tr1::unordered_map<int, Piket>::const_iterator it = pikets.begin();
        for (; it != pikets.end(); it++) {    
            const Piket* piket = &it->second;
            if (!caveViewPrefs.allOutlineCuts && piketsForCreateCutOutline.count(piket->id) == 0) {
                continue;
            }
            outlineCutsBezier.clear();
            outlineCutsBezier.reserve(piket->classifiedWalls.size());
            piket->getCrossPiketLineBesier3(outlineCutsBezier);
            addApproximartedCurvesToOuotput(outlineCutsBezier, OT_OUTLINE_CUT);
        }
    }

    void Cave::buildOutline() {
        if (!isOutputEnabledToGenerate(OT_OUTLINE) && !isOutputEnabledToGenerate(OT_OUTLINE_CUT)) {
            return;
        }

        prebuildPikets();

        LOG("Cave builld outline object started");
        resetOutput(OT_OUTLINE);
                       
        // std::tr1::unordered_set<int>* piketsForCreateCutOutline
        std::vector<CrossPiketLineBesier3>outineBesier;
        outineBesier.reserve(pikets.size() * (2 + 1.05));
        piketsForCreateCutOutline.clear();
        if (caveViewPrefs.allOutlineCuts) {
            buildOutlineBezier(outineBesier);
        } else {
            buildOutlineBezier(outineBesier, &piketsForCreateCutOutline);
        }
        addApproximartedCurvesToOuotput(outineBesier, OT_OUTLINE);
    }

    void Cave::addApproximartedCurvesToOuotput(const std::vector<CrossPiketLineBesier3>& curves, OutputType dst) {
        for (int i = 0; i < curves.size(); i++) {
            const CrossPiketLineBesier3& line = curves[i];
            const Piket* aPiket = getPiket(line.aid);
            const Piket* bPiket = getPiket(line.bid);

            AssertReturn(aPiket, continue);
            AssertReturn(bPiket, continue);

            Color aCol = getColorForPiketAtEdge(aPiket, bPiket);
//            aCol.r *= 0.5;
//            aCol.g *= 0.5;
//            aCol.b *= 0.5;
            Color bCol = getColorForPiketAtEdge(bPiket, aPiket);
//            bCol.r *= 0.5;
//            bCol.g *= 0.5;
//            bCol.b *= 0.5;

//            addOutputLine(dst, line.a + (line.ac - line.a) * 0.1, line.ac, aCol, aCol);
//            addOutputLine(dst, line.ac, line.bc, aCol, bCol);
//            addOutputLine(dst, line.bc, line.b + (line.bc - line.b) * 0.1, bCol, bCol);
                         
            for (int i = 0; i < 4; i++) {
                float irate = i / 4.0f;
                float nirate = (i + 1) / 4.0f;
                V3 ipos = besier3(irate, line.a, line.ac, line.bc, line.b);
                V3 nipos = besier3(nirate, line.a, line.ac, line.bc, line.b);

                addOutputLine(dst, ipos, nipos, bCol * irate + aCol*(1.0f - irate), bCol * nirate + aCol*(1.0f - nirate));
            }
        }
    }

    void Cave::buildWallsObject() {
        if (!isOutputEnabledToGenerate(OT_WALL) && !caveViewPrefs.showDebug) {
            return;
        }

        LOG("Cave builld walls object started");

        prebuildPikets();

        std::vector<WallTriangle>wallTriangles;
        unordered_map< const PiketWall*, WallNormal>wallNormals;

        unordered_map< const Piket*, std::vector< const Piket*> >buildWalls;
        int segmentDraw = 0;

        std::tr1::unordered_map<int, Piket>::const_iterator it = pikets.begin();
        for (; it != pikets.end(); it++) {
            // if (segmentDraw > 0) break;
            int id = it->first;
            const Piket* curPiket = &it->second;
            if (curPiket->isInactive())
                continue;
            int i = 0;
            float adjPiketsNum = curPiket->adjPikets.size();
            float totalAdjPikets = curPiket->adjPikets.size() + curPiket->adjFakePikets.size();
            if (totalAdjPikets != adjPiketsNum) {
                int i = 0;
            }
            for (int j = 0; j < totalAdjPikets; j++) {
                const Piket* nextPiket = NULL;
                if (j < adjPiketsNum)
                    nextPiket = curPiket->adjPikets.at(j);
                else
                    nextPiket = curPiket->adjFakePikets.at(j - adjPiketsNum);

                if (nextPiket->isInactive())
                    continue;

                const Piket* minPiket = std::min(curPiket, nextPiket);
                const Piket* maxPiket = std::max(curPiket, nextPiket);

                std::vector< const Piket*>&buildWallsForCurPiket = buildWalls[minPiket];
                if (find(buildWallsForCurPiket.begin(), buildWallsForCurPiket.end(), maxPiket) != buildWallsForCurPiket.end()) {
                    continue;
                }
                else {
                    buildWallsForCurPiket.push_back(maxPiket);
                }

                bool findAtadjPikets = find(nextPiket->adjPikets.begin(), nextPiket->adjPikets.end(), curPiket) != nextPiket->adjPikets.end();
                bool findAtFakeadjPikets = find(nextPiket->adjFakePikets.begin(), nextPiket->adjFakePikets.end(), curPiket) != nextPiket->adjFakePikets.end();
                AssertReturn(findAtFakeadjPikets || findAtadjPikets, continue);

                debugDraw(curPiket->pos, curPiket->pos + curPiket->dirrection * 10, Color::Green);
                debugDraw(nextPiket->pos, nextPiket->pos + nextPiket->dirrection * 10, Color::Green);

                // debug2->position(curPiket->wallsCenter);
                // debug2->colour(Color::White);
                // debug2->position(nextPiket->wallsCenter);

                if (!curPiket->classifiedWalls.empty() && !nextPiket->classifiedWalls.empty()) {
                    for (int widx = 0; widx < curPiket->classifiedWalls.size(); widx++) {
                        debugDraw(curPiket->piketEffectivePos, curPiket->classifiedWalls[widx].pos, Color::Red);
                        // debug2->position(curPiket->piketEffectivePos);
                        // debug2->colour(Color::Red);
                        // debug2->position(curPiket->classifiedWalls[widx].pos);
                    }
                    for (int widx = 0; widx < nextPiket->classifiedWalls.size(); widx++) {
                        debugDraw(nextPiket->piketEffectivePos, nextPiket->classifiedWalls[widx].pos, Color::Red);
                        // addOutputLine(OT_DEBUG, nextPiket->piketEffectivePos, nextPiket->classifiedWalls[widx].pos, Color::Blue);
                        // debug2->position(nextPiket->piketEffectivePos);
                        // debug2->colour(Color::Blue);
                        // debug2->position(nextPiket->classifiedWalls[widx].pos);
                    }
                }
                debugTriangulationAlgo = true;
                LOG("buildWallSegment " << nextPiket->id << " to " << curPiket->id);
                WallTriangles wallPairs = buildWallSegment(nextPiket, curPiket);
                debugTriangulationAlgo = false;
                wallTriangles.insert(wallTriangles.end(), wallPairs.begin(), wallPairs.end());

                for (int wallPairIdx = 0; wallPairIdx < wallPairs.size(); wallPairIdx++) {
                    const WallTriangle& trgl = wallPairs[wallPairIdx];

                    V3 normal = triangleNormal(trgl.a->pos, trgl.b->pos, trgl.c->pos);
                    if (!trgl.clockwise)
                        normal = -normal;

                    float aWeight = (trgl.b->pos - trgl.a->pos).angleBetween(trgl.c->pos - trgl.a->pos).valueRadians() / M_PI;
                    float bWeight = (trgl.c->pos - trgl.b->pos).angleBetween(trgl.a->pos - trgl.b->pos).valueRadians() / M_PI;
                    float cWeight = (trgl.a->pos - trgl.c->pos).angleBetween(trgl.b->pos - trgl.c->pos).valueRadians() / M_PI;

                    wallNormals[trgl.a].add(normal, aWeight);
                    wallNormals[trgl.b].add(normal, bWeight);
                    wallNormals[trgl.c].add(normal, cWeight);

                    // debugDraw(trgl.a->pos, trgl.a->pos + normal.normalisedCopy() * 300 * aWeight, Color(1, 0, 1, 1));
                    // debugDraw(trgl.b->pos, trgl.b->pos + normal.normalisedCopy() * 300 * bWeight, Color(1, 0, 1, 1));
                    // debugDraw(trgl.c->pos, trgl.c->pos + normal.normalisedCopy() * 300 * cWeight, Color(1, 0, 1, 1));
                }
                if (!wallPairs.empty())
                    segmentDraw++;
            }
        }

        // debug2->end();

        int triangulationSmooth = 1;
        switch (caveViewPrefs.wallsTrianglesBlowMode) {
        case WTBM_4:
            triangulationSmooth = 2;
            break;
        case WTBM_9:
            triangulationSmooth = 3;
            break;
        case WTBM_16:
            triangulationSmooth = 4;
            break;
        case WTBM_24:
            triangulationSmooth = 5;
            break;
        case WTBM_33:
            triangulationSmooth = 6;
            break;
        case WTBM_44:
            triangulationSmooth = 7;
            break;
        case WTBM_57:
            triangulationSmooth = 8; // 64;
            break;
        }

        smoothedTriangles.clear();
        smoothedTrianglesVerticesNormals.clear();

        // for (int i = 1; i < 3/*wallTriangles.size()*/; i++ ) {
        for (int i = 0; i < wallTriangles.size(); i++) {
            const WallTriangle& triangle = wallTriangles.at(i);
            if (triangle.clockwise == CLOCKWISE) {
                drawTriangleSmooth3(triangulationSmooth, triangle.ca, triangle.cb, triangle.cc, triangle.a->pos, wallNormals[triangle.a].get(), triangle.b->pos,
                    wallNormals[triangle.b].get(), triangle.c->pos, wallNormals[triangle.c].get());
            }
            else {
                drawTriangleSmooth3(triangulationSmooth, triangle.ca, triangle.cc, triangle.cb, triangle.a->pos, wallNormals[triangle.a].get(), triangle.c->pos,
                    wallNormals[triangle.c].get(), triangle.b->pos, wallNormals[triangle.b].get());
            }
            // break;
        }

        resetOutput(OT_WALL);
        
//        lastTriangles.clear();
        for (int i = 0; i < smoothedTriangles.size(); i++) {
            const VerticeTriangle& vt = smoothedTriangles[i];
            V3 an = smoothedTrianglesVerticesNormals[vt.a].get();
            V3 bn = smoothedTrianglesVerticesNormals[vt.b].get();
            V3 cn = smoothedTrianglesVerticesNormals[vt.c].get();

            if (vt.clockwise)
                drawTriangle(vt.ca, vt.cb, vt.cc, vt.a, an, vt.b, bn, vt.c, cn);
//                lastTriangles.push_back(SurfaceTriangle(vt.ca, vt.cb, vt.cc, vt.a, an, vt.b, bn, vt.c, cn));
            else
                drawTriangle(vt.ca, vt.cc, vt.cb, vt.a, an, vt.c, cn, vt.b, bn);
//                lastTriangles.push_back(SurfaceTriangle(vt.ca, vt.cc, vt.cb, vt.a, an, vt.c, cn, vt.b, bn));
        }

        smoothedTriangles.clear();
        smoothedTrianglesVerticesNormals.clear();

//        buildWallTriangles();
    }

//    void Cave::buildWallTriangles() {
//        if (!isOutputEnabledToGenerate(OT_WALL)) {
//            return;
//        }
//
//        float maxHeight = -FLT_MAX / 10;
//        float minHeight = FLT_MAX / 10;
//        if (caveViewPrefs.wallColoringMode == WCM_DEPTH_SMOOTH) {
//            for (int i = 0; i < lastTriangles.size(); i++) {
//                const SurfaceTriangle& triangle = lastTriangles.at(i);
//                maxHeight = std::max(maxHeight, std::max((triangle.a.z), std::max((triangle.b.z), (triangle.c.z))));
//                minHeight = std::min(minHeight, std::min((triangle.a.z), std::min((triangle.b.z), (triangle.c.z))));
//            }
//        }
//
//        // float fillHeight = minHeight + (maxHeight-minHeight) * caveViewPrefs.fillRate;
//
//        resetOutput(OT_WALL);
//
//        curWallsMaterial = getWallMaterial();
//        for (int i = 0; i < lastTriangles.size(); i++) {
//            const SurfaceTriangle& tr = lastTriangles.at(i);
//            if (caveViewPrefs.wallColoringMode != WCM_DEPTH_SMOOTH) {
//                drawTriangle(tr.ca, tr.cb, tr.cc, tr.a, tr.an, tr.b, tr.bn, tr.c, tr.cn);
//            }
//            else {
//                float aDepth = (tr.a.z - minHeight) / (maxHeight - minHeight);
//                float bDepth = (tr.b.z - minHeight) / (maxHeight - minHeight);
//                float cDepth = (tr.c.z - minHeight) / (maxHeight - minHeight);
//                drawTriangle(getDepthColor(aDepth), getDepthColor(bDepth), getDepthColor(cDepth), tr.a, tr.an, tr.b, tr.bn, tr.c, tr.cn);
//            }
//        }
//    }

    V3 Cave::normalisedEdgeCenter(V3 a, V3 an, V3 b, V3 bn) {
        V3 aControl = getControlPoint(a, b, an, 1 / 1.5);
        V3 bControl = getControlPoint(a, b, bn, 1 / 1.5);

        return besier3(0.5, a, aControl, bControl, b);
    }

    void Cave::drawTriangleSmooth(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
        if (smooth <= 1) {
            addSmoothedTriangle(ca, cb, cc, CLOCKWISE, a, b, c);
        }
        else {
            V3 abCenter = normalisedEdgeCenter(a, an, b, bn);
            Color cab = ca + cb / 2;
            V3 bcCenter = normalisedEdgeCenter(b, bn, c, cn);
            Color cbc = cb + cc / 2;
            V3 caCenter = normalisedEdgeCenter(c, cn, a, an);
            Color cca = cc + ca / 2;

            V3 abCenterN = normalisedEdgeCenter(an, an, bn, bn);
            V3 bcCenterN = normalisedEdgeCenter(bn, bn, cn, cn);
            V3 caCenterN = normalisedEdgeCenter(cn, cn, an, an);

            drawTriangleSmooth(smooth - 1, ca, cca, cab, a, an, caCenter, caCenterN, abCenter, abCenterN);
            drawTriangleSmooth(smooth - 1, cb, cab, cbc, b, bn, abCenter, abCenterN, bcCenter, bcCenterN);
            drawTriangleSmooth(smooth - 1, cc, cbc, cca, c, cn, bcCenter, bcCenterN, caCenter, caCenterN);
            drawTriangleSmooth(smooth - 1, cab, cbc, cca, abCenter, abCenterN, bcCenter, bcCenterN, caCenter, caCenterN);
        }
    }

    void Cave::drawTriangle(const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
        if (caveViewPrefs.wallsShadowMode == WSM_SMOOTH) {
            addOutputPoly(OT_WALL, a, b, c, an, bn, cn, ca, cb, cc);
        }
        else if (caveViewPrefs.wallsShadowMode == WSM_ROUGH) {
            V3 n = triangleNormal(a, b, c);
            addOutputPoly(OT_WALL, a, b, c, n, n, n, ca, cb, cc);
        }
    }

    void Cave::addSmoothedTriangle(const Color& ca, const Color& cb, const Color& cc, bool clockwise, V3 a, V3 b, V3 c) {
        smoothedTriangles.push_back(VerticeTriangle(ca, cb, cc, clockwise, a, b, c));

        float aWeight = (b - a).angleBetween(c - a).valueRadians() / M_PI;
        float bWeight = (c - b).angleBetween(a - b).valueRadians() / M_PI;
        float cWeight = (a - c).angleBetween(b - c).valueRadians() / M_PI;

        V3 n = triangleNormal(a, b, c);
        if (!clockwise)
            n = -n;

        smoothedTrianglesVerticesNormals[a].add(n, aWeight);
        smoothedTrianglesVerticesNormals[b].add(n, bWeight);
        smoothedTrianglesVerticesNormals[c].add(n, cWeight);
    }

    float getControlLength(WallsTrianglesBlowStrength wallsTrianglesBlowStrength) {
        float controlLength = 0;
        switch (wallsTrianglesBlowStrength) {
        case WTBS_LOW:
            controlLength = 1 / 6.0;
            break;
        case WTBS_MEDIUM:
            controlLength = 1 / 4.0;
            break;
        case WTBS_STRONG:
            controlLength = 1 / 3.0;
            break;
        case WTBS_HUDGE:
            controlLength = 1 / 2.2;
            break;
        }
        return controlLength;
    }

    V3 getABCcontrolPoint(V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
        V3 ab = (a + b) / 2;
        V3 abn = (an + bn) / 2;

        V3 c_c = getControlPoint(c, ab, cn, 1);
        V3 ab_c = getControlPoint(ab, c, abn, 1);
        // (ab - c).
        Radian c_a = (ab - c).angleBetween(c_c - c);
        Radian ab_a = (c - ab).angleBetween(abn - ab);
        Radian phi = Radian(M_PI) - c_a - ab_a;

        float ab_c_to_sin_phi = (ab - c).length() / sin(phi.valueRadians());
        ab_c = ab + (ab_c - ab).normalisedCopy() * (sin(c_a.valueRadians()) * ab_c_to_sin_phi);
        c_c = c + (c_c - c).normalisedCopy() * (sin(ab_a.valueRadians()) * ab_c_to_sin_phi);

        return (ab_c + c_c) / 2;
    }

    void Cave::drawTriangleSmooth4(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
        an.normalise();
        bn.normalise();
        cn.normalise();

        for (int curRowIdx = 0; curRowIdx < smooth; curRowIdx++) {
            int nxtRowIdx = curRowIdx + 1;
            float i0 = curRowIdx / float(smooth);
            float i1 = nxtRowIdx / float(smooth);

            for (int curColIdx = 0; curColIdx <= curRowIdx; curColIdx++) {
                int nxtColIdx = curColIdx + 1;

                float i0_j0 = (curRowIdx == 0) ? (0) : (curColIdx / float(curRowIdx));
                float i0_j1 = (curRowIdx == 0) ? (0) : (nxtColIdx / float(curRowIdx));
                float i1_j0 = curColIdx / float(nxtRowIdx);
                float i1_j1 = nxtColIdx / float(nxtRowIdx);

                V3 i0_j0_pos = phongSurf(i0, i0_j0, a, an, b, bn, c, cn);
                V3 i0_j1_pos = phongSurf(i0, i0_j1, a, an, b, bn, c, cn);
                V3 i1_j0_pos = phongSurf(i1, i1_j0, a, an, b, bn, c, cn);
                V3 i1_j1_pos = phongSurf(i1, i1_j1, a, an, b, bn, c, cn);

                // debug->position(i0_j0_pos);
                // debug->colour(Color::Blue+Color::Green);
                // debug->position(i0_j0_pos + i0_j0_nrm * 100);
                //
                // debug->position(i0_j1_pos);
                // debug->colour(Color::Blue+Color::Green);
                // debug->position(i0_j1_pos + i0_j1_nrm * 100);
                //
                // debug->position(i1_j0_pos);
                // debug->colour(Color::Blue+Color::Green);
                // debug->position(i1_j0_pos + i1_j0_nrm * 100);
                //
                // debug->position(i1_j1_pos);
                // debug->colour(Color::Blue+Color::Green);
                // debug->position(i1_j1_pos + i1_j1_nrm * 100);

                Color i0_j0_col = cc * (1.0f - i0) + i0 * (cb * (1.0f - i0_j0) + ca * i0_j0);
                Color i0_j1_col = cc * (1.0f - i0) + i0 * (cb * (1.0f - i0_j1) + ca * i0_j1);
                Color i1_j0_col = cc * (1.0f - i1) + i1 * (cb * (1.0f - i1_j0) + ca * i1_j0);
                Color i1_j1_col = cc * (1.0f - i1) + i1 * (cb * (1.0f - i1_j1) + ca * i1_j1);

                addSmoothedTriangle(i0_j0_col, i1_j0_col, i1_j1_col, CLOCKWISE, i0_j0_pos, i1_j0_pos, i1_j1_pos);
                if (curColIdx < curRowIdx) {
                    addSmoothedTriangle(i0_j0_col, i0_j1_col, i1_j1_col, CONTERCLOCKWISE, i0_j0_pos, i0_j1_pos, i1_j1_pos);
                }
            }
        }
    }

    void Cave::drawTriangleSmooth3(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
        // if ((b-a).crossProduct(c-a).angleBetween(an + bn + cn) > Radian(M_PI_2)) {
        // drawTriangleSmooth3(smooth, color, a, an, c, cn, b, bn);
        // return;
        // }

        an.normalise();
        bn.normalise();
        cn.normalise();

        float controlLength = getControlLength(caveViewPrefs.wallsTrianglesBlowStrength);
        V3 ab_ctl = getControlPoint(a, b, an, controlLength);
        V3 ac_ctl = getControlPoint(a, c, an, controlLength);
        V3 ba_ctl = getControlPoint(b, a, bn, controlLength);
        V3 bc_ctl = getControlPoint(b, c, bn, controlLength);
        V3 ca_ctl = getControlPoint(c, a, cn, controlLength);
        V3 cb_ctl = getControlPoint(c, b, cn, controlLength);

        V3 abacbabccacb_ctl = (ab_ctl + ac_ctl + ba_ctl + bc_ctl + ca_ctl + cb_ctl) / 6;
        V3 abc = abacbabccacb_ctl + (abacbabccacb_ctl - (a + b + c) / 3) / 2;

        // #define L(var) LOG( #var ": " << var.x << ", " << var.y << ", " << var.z);
        // L(a);
        // L(ab);
        // L(ac);
        // L(b);
        // L(ba);
        // L(bc);
        // L(c);
        // L(ca);
        // L(cb);
        // #undef L

        // debugDraw(a, ab);
        // debugDraw(a, ac);
        // debugDraw(b, ba);
        // debugDraw(b, bc);
        // debugDraw(c, ca);
        // debugDraw(c, cb);
        // debugDraw((a+b+c)/3, abc);

        for (int curRowIdx = 0; curRowIdx < smooth; curRowIdx++) {
            int nxtRowIdx = curRowIdx + 1;
            float i0 = curRowIdx / float(smooth);
            float i1 = nxtRowIdx / float(smooth);

            for (int curColIdx = 0; curColIdx <= curRowIdx; curColIdx++) {
                int nxtColIdx = curColIdx + 1;

                float i0_j0 = (curRowIdx == 0) ? (0) : (curColIdx / float(curRowIdx));
                float i0_j1 = (curRowIdx == 0) ? (0) : (nxtColIdx / float(curRowIdx));
                float i1_j0 = curColIdx / float(nxtRowIdx);
                float i1_j1 = nxtColIdx / float(nxtRowIdx);

                V3 i0_j0_pos = besierSurfBar(i0, i0_j0, a, ab_ctl, ac_ctl, b, ba_ctl, bc_ctl, c, ca_ctl, cb_ctl, abc);
                V3 i0_j1_pos = besierSurfBar(i0, i0_j1, a, ab_ctl, ac_ctl, b, ba_ctl, bc_ctl, c, ca_ctl, cb_ctl, abc);
                V3 i1_j0_pos = besierSurfBar(i1, i1_j0, a, ab_ctl, ac_ctl, b, ba_ctl, bc_ctl, c, ca_ctl, cb_ctl, abc);
                V3 i1_j1_pos = besierSurfBar(i1, i1_j1, a, ab_ctl, ac_ctl, b, ba_ctl, bc_ctl, c, ca_ctl, cb_ctl, abc);

                Color i0_j0_col = cc * (1.0f - i0) + i0 * (cb * (1.0f - i0_j0) + ca * i0_j0);
                Color i0_j1_col = cc * (1.0f - i0) + i0 * (cb * (1.0f - i0_j1) + ca * i0_j1);
                Color i1_j0_col = cc * (1.0f - i1) + i1 * (cb * (1.0f - i1_j0) + ca * i1_j0);
                Color i1_j1_col = cc * (1.0f - i1) + i1 * (cb * (1.0f - i1_j1) + ca * i1_j1);

                addSmoothedTriangle(i0_j0_col, i1_j0_col, i1_j1_col, CLOCKWISE, i0_j0_pos, i1_j0_pos, i1_j1_pos);
                if (curColIdx < curRowIdx) {
                    addSmoothedTriangle(i0_j0_col, i0_j1_col, i1_j1_col, CONTERCLOCKWISE, i0_j0_pos, i0_j1_pos, i1_j1_pos);
                }
            }
        }
    }

    void Cave::drawTriangleSmooth2(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn) {
        an.normalise();
        bn.normalise();
        cn.normalise();

        V3 ab = b - a;
        V3 ac = c - a;

        float controlLength = getControlLength(caveViewPrefs.wallsTrianglesBlowStrength);

        V3 ab_aControl = getControlPoint(a, b, an, controlLength);
        V3 ab_bControl = getControlPoint(b, a, bn, controlLength);
        V3 ac_aControl = getControlPoint(a, c, an, controlLength);
        V3 ac_cControl = getControlPoint(c, a, cn, controlLength);

        V3 ab_anControl = getControlPoint(an, bn, an, controlLength);
        V3 ab_bnControl = getControlPoint(bn, an, bn, controlLength);
        V3 ac_anControl = getControlPoint(an, cn, an, controlLength);
        V3 ac_cnControl = getControlPoint(cn, an, cn, controlLength);

        for (int curRowIdx = 0; curRowIdx < smooth; curRowIdx++) {
            int nxtRowIdx = curRowIdx + 1;
            float curRowFloat = curRowIdx / float(smooth);
            float nxtRowFloat = nxtRowIdx / float(smooth);

            Color cCurRowColComp = cc * (1.0f - curRowFloat);
            Color cNxtRowColComp = cc * (1.0f - nxtRowFloat);

            V3 ab_curRowPos = besier3(curRowFloat, a, ab_aControl, ab_bControl, b);
            V3 ab_nxtRowPos = besier3(nxtRowFloat, a, ab_aControl, ab_bControl, b);
            V3 ac_curRowPos = besier3(curRowFloat, a, ac_aControl, ac_cControl, c);
            V3 ac_nxtRowPos = besier3(nxtRowFloat, a, ac_aControl, ac_cControl, c);

            V3 ab_curRowNrm = besier3(curRowFloat, an, ab_anControl, ab_bnControl, bn).normalisedCopy();
            V3 ab_nxtRowNrm = besier3(nxtRowFloat, an, ab_anControl, ab_bnControl, bn).normalisedCopy();
            V3 ac_curRowNrm = besier3(curRowFloat, an, ac_anControl, ac_cnControl, cn).normalisedCopy();
            V3 ac_nxtRowNrm = besier3(nxtRowFloat, an, ac_anControl, ac_cnControl, cn).normalisedCopy();

            V3 ab_curRowPosControl = getControlPoint(ab_curRowPos, ac_curRowPos, ab_curRowNrm, controlLength);
            V3 ac_curRowPosControl = getControlPoint(ac_curRowPos, ab_curRowPos, ac_curRowNrm, controlLength);
            V3 ab_nxtRowPosControl = getControlPoint(ab_nxtRowPos, ac_nxtRowPos, ab_nxtRowNrm, controlLength);
            V3 ac_nxtRowPosControl = getControlPoint(ac_nxtRowPos, ab_nxtRowPos, ac_nxtRowNrm, controlLength);

            for (int curColIdx = 0; curColIdx <= curRowIdx; curColIdx++) {
                int nxtColIdx = curColIdx + 1;

                float curColCurRowFloat = (curRowIdx == 0) ? (0) : (curColIdx / float(curRowIdx));
                float nxtColCurRowFloat = (curRowIdx == 0) ? (0) : (nxtColIdx / float(curRowIdx));
                float curColNxtRowFloat = curColIdx / float(nxtRowIdx);
                float nxtColNxtRowFloat = nxtColIdx / float(nxtRowIdx);

                Color curColCurRowCol = cCurRowColComp + curRowFloat * (cb * (1.0f - curColCurRowFloat) + ca * (curColCurRowFloat));
                Color curColNxtRowCol = cCurRowColComp + curRowFloat * (cb * (1.0f - curColNxtRowFloat) + ca * (curColNxtRowFloat));
                Color nxtColCurRowCol = cNxtRowColComp + nxtRowFloat * (cb * (1.0f - nxtColCurRowFloat) + ca * (nxtColCurRowFloat));
                Color nxtColNxtRowCol = cNxtRowColComp + nxtRowFloat * (cb * (1.0f - nxtColNxtRowFloat) + ca * (nxtColNxtRowFloat));

                V3 curColCurRowPos = besier3(curColCurRowFloat, ab_curRowPos, ab_curRowPosControl, ac_curRowPosControl, ac_curRowPos);
                V3 curColNxtRowPos = besier3(curColNxtRowFloat, ab_nxtRowPos, ab_nxtRowPosControl, ac_nxtRowPosControl, ac_nxtRowPos);

                V3 nxtColCurRowPos = besier3(nxtColCurRowFloat, ab_curRowPos, ab_curRowPosControl, ac_curRowPosControl, ac_curRowPos);
                V3 nxtColNxtRowPos = besier3(nxtColNxtRowFloat, ab_nxtRowPos, ab_nxtRowPosControl, ac_nxtRowPosControl, ac_nxtRowPos);

                addSmoothedTriangle(curColCurRowCol, curColNxtRowCol, nxtColNxtRowCol, CLOCKWISE, curColCurRowPos, curColNxtRowPos, nxtColNxtRowPos);
                if (curColIdx < curRowIdx) {
                    addSmoothedTriangle(curColCurRowCol, nxtColCurRowCol, nxtColNxtRowCol, CONTERCLOCKWISE, curColCurRowPos, nxtColCurRowPos, nxtColNxtRowPos);
                }
            }
        }
    }

    WallTriangles Cave::buildWallSegment(const Piket* piket, const Piket* nextPiket) {
        // if (caveViewPrefs.wallsSegmentTriangulationMode == WSTM_ANGLE) {
        // return buildWallSegmentCenterMode(piket, nextPiket);
        // } else
        // if (caveViewPrefs.wallsSegmentTriangulationMode == WSTM_CONVEX_QUAD) {
        // return buildWallSegmentConvexQuadMode(piket, nextPiket);
        // } else
        if (caveViewPrefs.wallsSegmentTriangulationMode == WSTM_CONVEX_POLY) {
            return buildWallSegmentConvexPolyMode(piket, nextPiket);
        }
        else {
            AssertReturn(false, return WallTriangles());
        }
    }

    void dsf(const std::vector<WallProj>& poly, int startPolyIdx, int finishPolyIdx) {

    }

    int nextSegmentIdx(int idx, int polySize, int start, int finish) {
        idx++;
        if (start < finish) {
            if (idx > finish)
                idx = start;
        }
        else {
            if (idx >= polySize)
                idx = 0;
        }
        return idx;
    }

    int prevSegmentIdx(int idx, int polySize, int start, int finish) {
        idx--;
        if (start < finish) {
            if (idx < start)
                idx = finish;
        }
        else {
            if (idx <= 0)
                idx = polySize - 1;
        }
        return idx;
    }

    WallTriangles Cave::buildWallSegmentConvexPolyMode(const Piket* prevPiket, const Piket* curPiket) {
        WallTriangles wallPairs;
        AssertReturn(prevPiket && curPiket, return wallPairs);
        if (!prevPiket->classifiedWalls.empty() && !curPiket->classifiedWalls.empty()) {

            Color prevCol = getColorForPiketAtEdge(prevPiket, curPiket);
            Color curCol = getColorForPiketAtEdge(curPiket, prevPiket);
            //caveViewPrefs.wallColoringMode == WCM_ROUGE ? prevCol : getColorForPiket(curPiket);

            V3 curPikPos = curPiket->piketEffectivePos;
            V3 prevPikPos = prevPiket->piketEffectivePos;
            V3 roughDirrection = curPiket->wallsCenter - prevPiket->wallsCenter;
            V3 middlePos = (curPikPos + prevPikPos) / 2;

            debugDraw(prevPikPos, prevPikPos + prevPiket->dirrection.normalisedCopy() * 200, Color(0, 1, 0, 1));
            debugDraw(curPikPos, curPikPos + curPiket->dirrection.normalisedCopy() * 200, Color(0, 1, 0, 1));

            V3 prevPiketDirrection = prevPiket->dirrection;
            if (prevPiketDirrection.angleBetween(roughDirrection) > Radian(M_PI_2)) {
                prevPiketDirrection = -prevPiketDirrection;
            }
            V3 curPiketDirrection = curPiket->dirrection;
            if (curPiketDirrection.angleBetween(roughDirrection) > Radian(M_PI_2)) {
                curPiketDirrection = -curPiketDirrection;
            }

            V3 dirrection = (prevPiketDirrection + curPiketDirrection) / 2;

            std::vector<ExtWallProj>prevWalls2dOrder;
            std::vector<ExtWallProj>curWalls2dOrder;

            bool onlyConvexWalls = prevPiket->hasPriz(MARK_ONLY_CONVEX_WALLS) || curPiket->hasPriz(MARK_ONLY_CONVEX_WALLS);
            bool autoGeneratetPiket = curPiket->hasPriz(MARK_Z_SURVEY_FAKE) || prevPiket->hasPriz(MARK_Z_SURVEY_FAKE);
            if (autoGeneratetPiket && !onlyConvexWalls) {
                prevWalls2dOrder = prevPiket->getExtWalls2dWithConvexCorrection(prevPiketDirrection, dirrection);
                curWalls2dOrder = curPiket->getExtWalls2dWithConvexCorrection(curPiketDirrection, dirrection);
            }
            else {
                prevWalls2dOrder = prevPiket->getExtWalls2d(prevPiketDirrection, dirrection);
                curWalls2dOrder = curPiket->getExtWalls2d(curPiketDirrection, dirrection);
            }

            std::vector<std::pair<bool, int> >trianOrder = calcTriangulationOrdertConvexPolyMode(prevWalls2dOrder, curWalls2dOrder, true, onlyConvexWalls);

            // debugDraw(prevPikPos, prevPikPos + dirrection.normalisedCopy() * 200);
            // debugDraw(curPikPos, curPikPos + curPiketDirrection.normalisedCopy() * 200);
            //
            // Quaternion revDirrectionRotation = V3::UNIT_Z.getRotationTo(dirrection);
            // for (int i = 0; i < prevWalls2dOrder.size(); i++) {
            // V3 pos(prevWalls2dOrder[i].posByGlobalDir.x, prevWalls2dOrder[i].posByGlobalDir.y, 0);
            // pos = revDirrectionRotation * pos;
            // debugDraw(prevPikPos, prevPikPos + pos, (Color::Red + Color::Blue));
            // }
            // for (int i = 0; i < curWalls2dOrder.size(); i++) {
            // V3 pos(curWalls2dOrder[i].posByGlobalDir.x, curWalls2dOrder[i].posByGlobalDir.y, 0);
            // pos = revDirrectionRotation * pos;
            // debugDraw(curPikPos, curPikPos + pos, (Color::Red + Color::Blue) );
            // }

            int prevIdx = -1;
            int curIdx = -1;

            int skipNum = 0;//td::max(caveViewPrefs.skipNum, 0);
            for (int i = 0; i < (int)trianOrder.size() - skipNum; i++) {
                int idx = trianOrder.at(i).second;
                if (prevIdx == -1 || curIdx == -1) {
                    if (trianOrder.at(i).first) {
                        prevIdx = idx;
                    }
                    else {
                        curIdx = idx;
                    }
                }
                else {
                    const PiketWall& wi = prevPiket->classifiedWalls[(prevWalls2dOrder)[prevIdx].idx];
                    const PiketWall& wj = curPiket->classifiedWalls[(curWalls2dOrder)[curIdx].idx];
                    if (trianOrder.at(i).first) {
                        const PiketWall& wni = prevPiket->classifiedWalls[(prevWalls2dOrder)[idx].idx];
                        wallPairs.push_back(WallTriangle(prevCol, curCol, prevCol, CONTERCLOCKWISE, wi, wj, wni));
                        // ПОРЯДОК ВАЖЕН
                        prevIdx = idx;
                    }
                    else {
                        const PiketWall& wnj = curPiket->classifiedWalls[(curWalls2dOrder)[idx].idx];
                        wallPairs.push_back(WallTriangle(curCol, prevCol, curCol, CLOCKWISE, wj, wi, wnj)); // ПОРЯДОК ВАЖЕН
                        curIdx = idx;
                    }
                }
            }
        }
        return wallPairs;
    }

    std::vector<std::pair<bool, int> >Cave::calcTriangulationOrdertConvexPolyMode(const std::vector<ExtWallProj>& a, const std::vector<ExtWallProj>& b, bool clockwise,
        bool force_convex) {
        return calcTriangulationOrdertConvexPolyMode(a, 0, a.size() - 1, b, 0, b.size() - 1, clockwise, force_convex);
    }

    std::vector<std::pair<bool, int> >Cave::calcTriangulationOrdertConvexPolyMode(const std::vector<ExtWallProj>& a, int aStart, int aEnd, const std::vector<ExtWallProj>& b,
        int bStart, int bEnd, bool clockwise, bool force_convex) {
        // массивы индексов в массивах a и b
        std::vector<int>aConvex = getConvexPoly(a, aStart, aEnd, clockwise);
        std::vector<int>bConvex = getConvexPoly(b, bStart, bEnd, clockwise);
        std::pair<int, int>start = getMinTangentAngleDifEdge(a, aConvex, b, bConvex);

        if (start.first < 0 || start.second < 0) {
            return std::vector<std::pair<bool, int> >();
        }
        // LOG("aConvex: " + ToString(aConvex));
        // LOG("bConvex: " + ToString(bConvex));

        // first- вершина из массива а или б
        // second- индекс вершины в массиве
        std::vector<std::pair<bool, int> >localOrder; // localTriangulationOrder
        int maxSteps = aConvex.size() + bConvex.size();
        int ca = start.first;
        int cb = start.second;
        int achanged = 0;
        int bchanged = 0;
        // LOG("localOrder: ");
        localOrder.push_back(make_pair(true, aConvex.at(ca)));
        localOrder.push_back(make_pair(false, bConvex.at(cb)));
        // LOG("   true " << aConvex.at(ca));
        // LOG("   false " << bConvex.at(cb));
        for (int step = 0; step < maxSteps; step++) {
            int na = (ca + 1) % aConvex.size();
            int nb = (cb + 1) % bConvex.size();
            V2 cana = a.at(aConvex.at(na)).posByGlobalDir - a.at(aConvex.at(ca)).posByGlobalDir;
            V2 cbnb = b.at(bConvex.at(nb)).posByGlobalDir - b.at(bConvex.at(cb)).posByGlobalDir;

            bool selctA = true;
            if (achanged == a.size()) {
                selctA = false;
            }
            else if (bchanged == b.size()) {
                selctA = true;
            }
            else if (cana.length() < 0.01f * PointsInMeter) {
                selctA = true;
            }
            else if (cbnb.length() < 0.01f * PointsInMeter) {
                selctA = false;
            }
            else {
                selctA = ((cana.crossProduct(cbnb) > 0) == clockwise);
            }

            if (selctA) {
                if (force_convex) {
                    // LOG("   true " << aConvex.at(na));
                    localOrder.push_back(make_pair(true, aConvex.at(na)));
                }
                else {
                    // вставляем стены (i, ni] не попавшиме в выпуклый многоугольник
                    int i = aConvex.at(ca);
                    int ni = aConvex.at(na);
                    do {
                        i = (i + 1) % a.size();
                        // LOG("   true " << i);
                        localOrder.push_back(make_pair(true, i));
                    }
                    while (i != ni);
                }
                ca = na;
                achanged++;
            }
            else {
                // вставляем стены (j, nj] не попавшиме в выпуклый многоугольник
                if (force_convex) {
                    // LOG("   false " <<  bConvex.at(nb));
                    localOrder.push_back(make_pair(false, bConvex.at(nb)));
                }
                else {
                    int j = bConvex.at(cb);
                    int nj = bConvex.at(nb);
                    do {
                        j = (j + 1) % b.size();
                        // LOG("   false " << j);
                        localOrder.push_back(make_pair(false, j));
                    }
                    while (j != nj && !force_convex);
                }
                cb = nb;
                bchanged++;
            }
        }

        std::vector<std::pair<bool, int> >globalOrder = localOrder;
        // globalTriangulationOrder
        // for (int i = 0; i < localOrder.size(); i++) {
        // int ni = (i + 1) % localOrder.size();
        //
        // if (localOrder[i]) {
        //
        // }
        // }
        return globalOrder;
    }

    void Cave::buildOutlineSegmenteBezier(const Piket* prevPiket, const Piket* curPiket, std::vector<CrossPiketLineBesier3>& output,
        std::tr1::unordered_set<int> * piketsForCreateCutOutline) const {
        AssertReturn(prevPiket && curPiket, return);
        if (!prevPiket->classifiedWalls.empty() && !curPiket->classifiedWalls.empty()) {        
            Color prevCol = getColorForPiketAtEdge(prevPiket, curPiket);
            Color curCol = getColorForPiketAtEdge(curPiket, prevPiket);
//            Color prevCol = getColorForPiket(prevPiket);
//            Color curCol = caveViewPrefs.wallColoringMode == WCM_ROUGE ? prevCol : getColorForPiket(curPiket);

            V3 curPikPos = curPiket->piketEffectivePos;
            V3 prevPikPos = prevPiket->piketEffectivePos;
            V3 roughDirrection = curPiket->wallsCenter - prevPiket->wallsCenter;

            V3 curPiketDirrection = curPiket->getDirrectionForOverlay();
            V3 prevPiketDirrection = prevPiket->getDirrectionForOverlay();

            const float codirectionToleranceAngle = M_PI * (30.0f / 180);

            float prevToLookAngle = prevPiketDirrection.angleBetween(caveViewPrefs.lookDirrection).valueRadians();
            prevToLookAngle = std::min<float>(prevToLookAngle, M_PI - prevToLookAngle);

            if (prevToLookAngle < codirectionToleranceAngle) {
                prevPiketDirrection = roughDirrection;
                if (piketsForCreateCutOutline)
                    piketsForCreateCutOutline->insert(prevPiket->id);
            }

            float curToLookAngle = curPiketDirrection.angleBetween(caveViewPrefs.lookDirrection).valueRadians();
            curToLookAngle = std::min<float>(curToLookAngle, M_PI - curToLookAngle);

            if (curToLookAngle < codirectionToleranceAngle) {
                curPiketDirrection = roughDirrection;
                if (piketsForCreateCutOutline)
                    piketsForCreateCutOutline->insert(curPiket->id);
            }

            if (prevPiketDirrection.angleBetween(roughDirrection) > Radian(M_PI_2)) {
                prevPiketDirrection = -prevPiketDirrection;
            }

            if (curPiketDirrection.angleBetween(roughDirrection) > Radian(M_PI_2)) {
                curPiketDirrection = -curPiketDirrection;
            }

            Piket::LeftRight prevPiketLeftRight = prevPiket->getCornerCutPoints(caveViewPrefs.lookDirrection, prevPiketDirrection);
            Piket::LeftRight curPiketLeftRight = curPiket->getCornerCutPoints(caveViewPrefs.lookDirrection, curPiketDirrection);

            // if (prevPiketLeftRight.left.distance(curPiketLeftRight.left) > prevPiketLeftRight.left.distance(curPiketLeftRight.left))

            V3 controlVecA = prevPiketDirrection.normalisedCopy();
            V3 controlVecB = -curPiketDirrection.normalisedCopy();

            Quaternion projQuat = caveViewPrefs.lookDirrection.getRotationTo(V3::UNIT_Z);
            V3 curPikPosProj = projQuat * curPikPos;
            V3 prevPikPosProj = projQuat * prevPikPos;

            auto limitFunc = [&projQuat, &curPikPosProj, &prevPikPosProj, &prevPiket, &curPiket] (const V3& a, V3& ac) {
                V3 aProj = projQuat * a; 
                V3 acProj = projQuat * ac;

                P2 sect(0, 0);
                S2 s1;
                s1[0] = P2(curPikPosProj.x, curPikPosProj.y);
                s1[1] = P2(prevPikPosProj.x, prevPikPosProj.y);  
                S2 s2;
                s2[0] = P2(aProj.x, aProj.y);
                s2[1] = P2(acProj.x, acProj.y); 
                bool isSect = intersect(s1, s2, sect);            

                if (isSect) {
                    //LOG("outline " << prevPiket->getName() << " - " << curPiket->getName());
                    acProj.x = sect.x;    
                    acProj.y = sect.y;               
                    //LOG("\t" << ac);
                    ac = projQuat.Inverse() * acProj;
                    //LOG("\t" << ac);
                }
            };
                                         
            CrossPiketLineBesier3 leftCurve;
            leftCurve.aid = prevPiket->id;
            leftCurve.bid = curPiket->id;
            leftCurve.a = prevPiketLeftRight.left;
            leftCurve.b = curPiketLeftRight.left;
            leftCurve.ac = leftCurve.a + controlVecA * leftCurve.b.distance(leftCurve.a) * 0.25;
            leftCurve.bc = leftCurve.b + controlVecB * leftCurve.b.distance(leftCurve.a) * 0.25;
                         
            limitFunc(leftCurve.a, leftCurve.ac);
            limitFunc(leftCurve.b, leftCurve.bc);
            
            CrossPiketLineBesier3 rightCurve;
            rightCurve.aid = prevPiket->id;
            rightCurve.bid = curPiket->id;
            rightCurve.a = prevPiketLeftRight.right;
            rightCurve.b = curPiketLeftRight.right;
            rightCurve.ac = rightCurve.a + controlVecA * rightCurve.b.distance(rightCurve.a) * 0.25;
            rightCurve.bc = rightCurve.b + controlVecB * rightCurve.b.distance(rightCurve.a) * 0.25;
                       
            limitFunc(rightCurve.a, rightCurve.ac);
            limitFunc(rightCurve.b, rightCurve.bc); 
         
            output.push_back(leftCurve);
            output.push_back(rightCurve);
        }
    }

    // WallTriangles Cave::buildWallSegmentConvexQuadMode(const Piket* prevPiket, const Piket* curPiket) {
    // WallTriangles wallPairs;
    // AssertReturn(prevPiket && curPiket, return wallPairs);
    // if (!prevPiket->classifiedWalls.empty() && !curPiket->classifiedWalls.empty()) {
    //
    // Color prevCol = getColorForPiket(prevPiket);
    // Color curCol = caveViewPrefs.wallColoringMode == WCM_ROUGE ? prevCol : getColorForPiket(curPiket);
    //
    // V3 curPikPos = curPiket->piketEffectivePos;
    // V3 prevPikPos = prevPiket->piketEffectivePos;
    // V3 roughDirrection = curPiket->wallsCenter - prevPiket->wallsCenter;
    // V3 middlePos = (curPikPos + prevPikPos)/2;
    //
    // //        debugDraw(curPiket->wallsCenter, prevPiket->wallsCenter, Color::Green+Color::Blue);
    // //        debugDraw(curPiket->wallsCenter, curPikPos);
    // //        debugDraw(prevPikPos, prevPiket->wallsCenter);
    //
    // V3 prevPiketDirrection = prevPiket->dirrection;
    // if (prevPiketDirrection.angleBetween(roughDirrection) > Radian(M_PI_2)) {
    // prevPiketDirrection = -prevPiketDirrection;
    // }
    // V3 curPiketDirrection = curPiket->dirrection;
    // if (curPiketDirrection.angleBetween(roughDirrection) > Radian(M_PI_2)) {
    // curPiketDirrection = -curPiketDirrection;
    // }
    //
    // V3 dirrection = (prevPiketDirrection + curPiketDirrection) / 2;
    //
    // //        debug->position(curPikPos);
    // //        debug->position(curPikPos + curPiketDirrection * 500);
    // //
    // //        debug->position(prevPikPos);
    // //        debug->position(prevPikPos + prevPiketDirrection * 500);
    //
    // std::vector<WallProj> prevWalls2dOrder = getWalls2d(prevPikPos, prevPiketDirrection, dirrection, prevPiket->classifiedWalls);
    // std::vector<WallProj> curWalls2dOrder = getWalls2d(curPikPos, curPiketDirrection, dirrection, curPiket->classifiedWalls);
    //
    //
    //
    // //        std::set<int> prevConcaveWalls = getPolygonConcavePoints(prevWalls2dOrder);
    // //        std::set<int> curConcaveWalls = getPolygonConcavePoints(curWalls2dOrder);
    //
    // //        for (int i = 0; i < curWalls2dOrder.size(); i++) {
    // //            V3 p(1000, 0, 1000);
    // //            debug->position(p);
    // //            if (i == 0) debug->colour(Color::Red);
    // //            else if (curConcaveWalls.count(i) == 1) debug->colour(Color::White);
    // //            else debug->colour(Color::Blue);
    // //            debug->position(p + V3(curWalls2dOrder[i].pos.x, curWalls2dOrder[i].pos.y, 0));\
    // //        }
    // //        std::set<int>::iterator it = prevConcaveWalls.begin();
    // //        for (; it != prevConcaveWalls.end(); it++) {
    // //            debug->position(middlePos + V3(5, 5, 0));
    // //            debug->colour(Color::White);
    // //            debug->position(prevPiket->classifiedWalls[prevWalls2dOrder[*it].idx].pos);
    // //        }
    // //
    // //        it = curConcaveWalls.begin();
    // //        for (; it != curConcaveWalls.end(); it++) {
    // //            debug->position(middlePos + V3(5, 5, 0));
    // //            debug->colour(Color::White);
    // //            debug->position(curPiket->classifiedWalls[curWalls2dOrder[*it].idx].pos);
    // //        }
    //
    // //        reverse(prevWalls2dOrder.begin(), prevWalls2dOrder.end());
    // //        reverse(curWalls2dOrder.begin(), curWalls2dOrder.end());
    //
    // std::pair<int, int> startPikets = getMaxDistFromPointEdge(prevPiket->classifiedWalls, curPiket->classifiedWalls, middlePos);
    //
    // //        std::vector<WallProj> ____prevWalls2dOrder = getWalls2d(prevPikPos, dirrection, prevPiket->classifiedWalls);
    // //        std::vector<WallProj> ____curWalls2dOrder = getWalls2d(curPikPos, dirrection, curPiket->classifiedWalls);
    //
    // //        std::pair<int, int> startPikets = getMinTangentAngleDifEdge(____prevWalls2dOrder, ____curWalls2dOrder);
    // if (startPikets.first >= 0 && startPikets.second >= 0) {
    // int bi = 0;
    // int bj = 0;
    // for (; bi < prevWalls2dOrder.size(); bi++)
    // if (prevWalls2dOrder[bi].idx == startPikets.first) break;
    // for (; bj < curWalls2dOrder.size(); bj++)
    // if (curWalls2dOrder[bj].idx == startPikets.second) break;
    // AssertReturn(bi < prevWalls2dOrder.size(), return wallPairs);
    // AssertReturn(bj < curWalls2dOrder.size(), return wallPairs);
    //
    // //            debug->position(prevPiket->classifiedWalls[prevWalls2dOrder[bi].idx].pos);
    // //            debug->colour(Color::Blue);
    // //            debug->position(curPiket->classifiedWalls[curWalls2dOrder[bj].idx].pos);
    // //            bi = (prevWalls2dOrder.size() + bi + 1) % prevWalls2dOrder.size();
    // //            bj = (curWalls2dOrder.size() + bj - 1) % curWalls2dOrder.size();
    //
    // int i = bi;
    // int j = bj;
    // int ichanged = 0;
    // int jchanged = 0;
    //
    // int skipNum = debugTriangulationAlgo ? caveViewPrefs.skipNum : 0;
    // int maxIterNum = prevWalls2dOrder.size() + curWalls2dOrder.size() - skipNum;
    // do {
    // int pi = (prevWalls2dOrder.size() + i - 1) % prevWalls2dOrder.size();
    // int pj = (curWalls2dOrder.size() + j - 1) % curWalls2dOrder.size();
    // int ni = (prevWalls2dOrder.size() + i + 1) % prevWalls2dOrder.size();
    // int nj = (curWalls2dOrder.size() + j + 1) % curWalls2dOrder.size();
    //
    // bool seelct_i;
    // if (ichanged == prevWalls2dOrder.size()) {
    // seelct_i = false;
    // } else if (jchanged == curWalls2dOrder.size()) {
    // seelct_i = true;
    // } else {
    //
    // V3 a_1 = prevPiket->classifiedWalls[prevWalls2dOrder[pi].idx].pos;
    // V3 b_1 = curPiket->classifiedWalls[curWalls2dOrder[pj].idx].pos;
    // V3 a0 = prevPiket->classifiedWalls[prevWalls2dOrder[i].idx].pos;
    // V3 b0 = curPiket->classifiedWalls[curWalls2dOrder[j].idx].pos;
    // V3 a1 = prevPiket->classifiedWalls[prevWalls2dOrder[ni].idx].pos;
    // V3 b1 = curPiket->classifiedWalls[curWalls2dOrder[nj].idx].pos;
    //
    // //                    seelct_i = isQuadrangleATriangulationIsConvexClockwise(dirrection, a_1, b_1, a0, b0, a1, b1);
    // seelct_i = isQuadrangleATriangulationIsConvexClockwise(dirrection, a0, b0, a1, b1);
    //
    // //                    Quaternion rot = dirrection.getRotationTo(V3::UNIT_Z);
    // //                    V3 a0a1 = rot * (a1-a0);
    // //                    V3 b0b1 = rot * (b1-b0);
    // //                    V3 a_1a0 = rot * (a0-a_1);
    // //                    V3 b_1b0 = rot * (b0-b_1);
    // //                    V3 a0b0v3 = rot * (b0-a0);
    // //                    V2 a0b0(a0b0v3.x, a0b0v3.y);
    // //
    // //                    V2 prevWallDir = V2(a_1a0.x, a_1a0.y) + V2(b_1b0.x, b_1b0.y);
    // //
    // //                    if (a0b0.angleBetween(prevWallDir) < Radian(M_PI_2)) a0b0 = -a0b0;
    // //
    // //                    Radian aAngle = a0b0.angleTo(V2(a0a1.x, a0a1.y));
    // //                    Radian bAngle = a0b0.angleTo(V2(b0b1.x, b0b1.y));
    // //
    // //                    seelct_i = aAngle <= bAngle;
    //
    // //                    seelct_i = isQuadrangleATriangulationIsConvexClockwise(dirrection, a0, b0, a1, b1);
    //
    // //                    dirrection
    // //                    V3 aNormal = (a1-a0).crossProduct(dirrection).normalisedCopy();
    // //                    V3 bNormal = (-dirrection).crossProduct(b1-b0).normalisedCopy();
    // //
    // //                    bool res = bNormal.crossProduct(aNormal).angleBetween(b0 - a0) > Radian(M_PI_2);
    // ////                    if ((a0 - a1).angleBetween(b0 - b1) > Radian(M_PI * 3.0f / 4.0f)) {
    // ////                        res = !res;
    // ////                    }
    // //
    // //                    Radian a0a1b0Angle = (a0 - a1).angleBetween((b0 - a1));
    // //                    Radian a0b1b0Angle = (a0 - b1).angleBetween((b0 - b1));
    // //
    // //                    if (a0a1b0Angle * 2 < a0b1b0Angle) {
    // //                        res = false;
    // //                    } else  if (a0b1b0Angle * 2 < a0a1b0Angle) {
    // //                        res = true;
    // //                    }
    // //                    if (/*prevConcaveWalls.count(ni) + */curConcaveWalls.count(nj) > 0) {
    // //                        res = !res;
    // //                    }
    //
    // //                    seelct_i = res;
    //
    //
    // if (debugTriangulationAlgo && maxIterNum == 1 && caveViewPrefs.skipNum > 0) {
    // V3 aNormal = (a1-a0).crossProduct(dirrection).normalisedCopy();
    // V3 bNormal = (-dirrection).crossProduct(b1-b0).normalisedCopy();
    //
    // debugDraw(a0, b0, Color::Green);
    // debugDraw(a0, a1, Color::Red + Color::Green);
    // debugDraw(b0, b1, Color::Blue + Color::Green);
    //
    // debugDraw(a1, b0, Color::White);
    // debugDraw(b1, a0, Color::White);
    //
    // //                        debugDraw(a_1 + V3(5, 5, 5), a1 + V3(5, 5, 5), Color::Blue + Color::Red/2 + Color::Green/2);
    // //                        debugDraw(b_1 + V3(5, 5, 5), b1 + V3(5, 5, 5), Color::Blue + Color::Red/2 + Color::Green/2);
    //
    // //                        debugDraw(V3::ZERO, V3(a0b0.x, a0b0.y, 0), Color::Green);
    // //                        debugDraw(V3::ZERO, V3(a0a1.x, a0a1.y, 0), Color::Red + Color::Green);
    // //                        debugDraw(V3::ZERO, V3(b0b1.x, b0b1.y, 0), Color::Blue + Color::Green);
    // //
    // //                        debugDraw(a0, a0 + dirrection * 100, Color::Blue + Color::Red);
    // //                        debugDraw(b0, b0 + dirrection * 100, Color::Blue + Color::Red);
    //
    // //                        debugDraw(a0, a0 + aNormal * 100, Color::White);
    // //                        debugDraw(b0, b0 + bNormal * 100, Color::White);
    //
    //
    // V3 dir = bNormal.crossProduct(aNormal).normalisedCopy();
    // //                        debugDraw(a0, a0 + bNormal * 100, Color::White);
    // //                        debugDraw(a0, a0 + dir * 100, Color::White);
    //
    // break;
    // }
    // }
    //
    // const PiketWall& wi = prevPiket->classifiedWalls[prevWalls2dOrder[i].idx];
    // const PiketWall& wj = curPiket->classifiedWalls[curWalls2dOrder[j].idx];
    // V3 poswi(wi.pos);
    // V3 poswj(wj.pos);
    // if (seelct_i) {
    // const PiketWall& wni = prevPiket->classifiedWalls[prevWalls2dOrder[ni].idx];
    // wallPairs.push_back(WallTriangle(prevCol, curCol, prevCol, CONTERCLOCKWISE, wi, wj, wni));  // ПОРЯДОК ВАЖЕН
    // i = ni;
    // ichanged++;
    // } else {
    // const PiketWall& wnj = curPiket->classifiedWalls[curWalls2dOrder[nj].idx];
    // wallPairs.push_back(WallTriangle(curCol, prevCol, curCol, CLOCKWISE, wj, wi, wnj)); // ПОРЯДОК ВАЖЕН
    // j = nj;
    // jchanged++;
    // }
    // maxIterNum --;
    // } while (maxIterNum > 0);
    // }
    // }
    // return wallPairs;
    // }

    // WallTriangles Cave::buildWallSegmentCenterMode(const Piket* prevPiket, const Piket* curPiket) {
    // WallTriangles wallPairs;
    // AssertReturn(prevPiket && curPiket, return wallPairs);
    // if (!prevPiket->classifiedWalls.empty() && !curPiket->classifiedWalls.empty()) {
    //
    // Color prevCol = getColorForPiket(prevPiket);
    // Color curCol = caveViewPrefs.wallColoringMode == WCM_ROUGE ? prevCol : getColorForPiket(curPiket);
    //
    // V3 curPikPos = (curPiket->wallsCenter + curPiket->pos)/2;
    // V3 prevPikPos = (prevPiket->wallsCenter + curPiket->pos)/2;
    // V3 dirrection = curPikPos - prevPikPos;
    //
    // std::vector<std::vector<WallProj> > rotWalls(2);
    //
    // rotWalls[0] = getWalls2d(prevPikPos, dirrection, dirrection, prevPiket->classifiedWalls);
    // rotWalls[1] = getWalls2d(prevPikPos, dirrection, dirrection, curPiket->classifiedWalls);
    //
    // int bi = 0;
    // int bj = WallProj:: minSelf0XAngleWallPoint(rotWalls[0][bi], rotWalls[1], true, -1);
    // Radian angleBiToBj = rotWalls[0][bi].posBySelfDir.angleTo(rotWalls[1][bj].posBySelfDir);
    // Radian angleBjToBi = rotWalls[1][bj].posBySelfDir.angleTo(rotWalls[0][bi].posBySelfDir);
    // bool iLessThanj = angleBiToBj <= angleBjToBi;
    //
    // int i = bi;
    // int j = bj;
    // int ichanged = 0;
    // int jchanged = 0;
    // int maxIterNum = rotWalls[0].size() + rotWalls[1].size();
    // do {
    // Radian iAngle = rotWalls[0][i].to0XAngleBySelfDir;
    // Radian jAngle = rotWalls[1][j].to0XAngleBySelfDir;
    // if (iAngle <= jAngle != iLessThanj) {
    // if (iAngle > jAngle) jAngle += Radian(2 * M_PI);
    // else iAngle += Radian(2 * M_PI);
    // }
    //
    // int ni = (i + 1) % rotWalls[0].size();
    // int nj = (j + 1) % rotWalls[1].size();
    //
    // Radian niAngle = rotWalls[0][ni].to0XAngleBySelfDir;
    // Radian njAngle = rotWalls[1][nj].to0XAngleBySelfDir;
    //
    // while (niAngle < iAngle) niAngle += Radian(2 * M_PI);
    // while (njAngle < jAngle) njAngle += Radian(2 * M_PI);
    //
    // bool seelct_i;
    // if (ichanged == rotWalls[0].size()) {
    // seelct_i = false;
    // } else if (jchanged == rotWalls[1].size()) {
    // seelct_i = true;
    // } else if (iLessThanj && niAngle < jAngle) {
    // seelct_i = true;
    // } else if (!iLessThanj && njAngle < iAngle) {
    // seelct_i = false;
    // } else {
    // seelct_i = niAngle < njAngle;
    // }
    //
    // if (seelct_i)  iLessThanj = niAngle <= jAngle;
    // else  iLessThanj = iAngle <= njAngle;
    //
    // const PiketWall& wi = prevPiket->classifiedWalls[rotWalls[0][i].idx];
    // const PiketWall& wj = curPiket->classifiedWalls[rotWalls[1][j].idx];
    // V3 poswi(wi.pos);
    // V3 poswj(wj.pos);
    // if (seelct_i) {
    // const PiketWall& wni = prevPiket->classifiedWalls[rotWalls[0][ni].idx];
    // wallPairs.push_back(WallTriangle(prevCol, curCol, prevCol, CONTERCLOCKWISE, wi, wj, wni));  // ПОРЯДОК ВАЖЕН
    // i = ni;
    // ichanged++;
    // } else {
    // const PiketWall& wnj = curPiket->classifiedWalls[rotWalls[1][nj].idx];
    // wallPairs.push_back(WallTriangle(curCol, prevCol, curCol, CLOCKWISE, wj, wi, wnj)); // ПОРЯДОК ВАЖЕН
    // j = nj;
    // jchanged++;
    // }
    // maxIterNum --;
    // if (maxIterNum < 0 ) {
    // break;
    // }
    // } while ((bi != i || bj != j));
    // }
    //
    // return wallPairs;
    //

    const Color& Cave::getColorForEdge(const Piket* from, const Piket* to) const {
        if (from) {
            if (to && from != to) {
                auto key = make_pair(std::min(from->id, to->id), std::max(from->id, to->id));
                auto edgeIt = edges.find(key);
                if (edgeIt != edges.end()) return edgeIt->second.col;
            } else {
                for (const auto& edge : edges) {
                    if (edge.first.first == from->id || edge.first.second == from->id) {
                        return edge.second.col;
                    }
                }
            }     
        }
        return Color::None;
    }

//    Color Cave::getColorForPiketByEdges(const Piket* piket) const {
//        int num = 0;
//        Color res = Color::None;
//        for (const Piket * adjPiket : piket->adjPikets) {
//            const auto& col = getColorForEdge(piket, adjPiket);
//            if (col != Color::None) {
//                num++;
//                res += col;
//            }
//        }
//
//        for (const Piket * adjfPiket : piket->adjFakePikets) {
//            const auto& col = getColorForEdge(piket, adjfPiket);
//            if (col != Color::None) {
//                num++;
//                res += col;
//            }
//        }
//
//        res /= num;
//
//        return res;
//    }

    Color Cave::getColorForPiketAtEdge(const Piket* primary, const Piket* secondary) const  {
        if (!primary) return Color::None;
        if (caveViewPrefs.wallColoringMode == WCM_ROUGE || caveViewPrefs.wallColoringMode == WCM_SMOOTH) {
            Color col = getColorForEdge(primary, secondary) * colourMult;
            col.a = 1.0f;
            return col;
        } else if (caveViewPrefs.wallColoringMode == WCM_TIGHTNESS_SMOOTH) {
            float minDim = primary->getMinCutDimension();

            static std::vector<std::pair<float, Color> >colors;
            if (colors.empty()) {
                colors.push_back(make_pair(0.000f * PointsInMeter, Color(1, 0, 0, 1)));
                colors.push_back(make_pair(0.325f * PointsInMeter, Color(1, 0, 0, 1) * 1.0));
                colors.push_back(make_pair(0.750f * PointsInMeter, Color(1, 1, 0, 1) * 0.6 / 0.7));
                colors.push_back(make_pair(1.500f * PointsInMeter, Color(0, 1, 0, 1) * 0.6 / 0.7));
                colors.push_back(make_pair(5.000f * PointsInMeter, Color(0, 1, 0, 1) * 0.6 / 0.7));
                colors.push_back(make_pair(11.000f * PointsInMeter, Color(0, 1, 1, 1) * 1.0));
            }

            static std::vector<std::pair<float, Color> >grayColors;
            if (grayColors.empty()) {
                grayColors.push_back(make_pair(0.000f * PointsInMeter, Color(0.1, 0.1, 0.1, 1)));
                grayColors.push_back(make_pair(0.325f * PointsInMeter, Color(0.1, 0.1, 0.1, 1)));
                grayColors.push_back(make_pair(0.750f * PointsInMeter, Color(0.25, 0.25, 0.25, 1)));
                grayColors.push_back(make_pair(1.500f * PointsInMeter, Color(0.5, 0.5, 0.5, 1)));
                grayColors.push_back(make_pair(5.000f * PointsInMeter, Color(0.8, 0.8, 0.8, 1)));
                grayColors.push_back(make_pair(11.00f * PointsInMeter, Color(0.9, 0.9, 0.9, 1)));
            }

            Color col = getColorByRatio(!caveViewPrefs.grayscale ? colors : grayColors, minDim) * colourMult;
            col.a = 1.0f;
            return col;
        } else if (caveViewPrefs.wallColoringMode == WCM_DEPTH_SMOOTH) {
            return getDepthColor(primary->pos.z);
        }
    }

//    Color Cave::getColorForPiket(const Piket* piket) const {
//        if (caveViewPrefs.wallColoringMode == WCM_ROUGE || caveViewPrefs.wallColoringMode == WCM_SMOOTH) {
//            Color col = piket->getPrevailWallColor() * colourMult;
//            if (col.r + col.g + col.b == 0) {
//                col = getColorForPiketByEdges(piket);
//            }
//            col.a = 1.0f;
//            return col;
//        }
//        else if (caveViewPrefs.wallColoringMode == WCM_TIGHTNESS_SMOOTH) {
//            float minDim = piket->getMinCutDimension();
//
//            static std::vector<std::pair<float, Color> >colors;
//            if (colors.empty()) {
//                colors.push_back(make_pair(0.000f * PointsInMeter, Color(1, 0, 0, 1)));
//                colors.push_back(make_pair(0.325f * PointsInMeter, Color(1, 0, 0, 1) * 1.0));
//                colors.push_back(make_pair(0.750f * PointsInMeter, Color(1, 1, 0, 1) * 0.6 / 0.7));
//                colors.push_back(make_pair(1.500f * PointsInMeter, Color(0, 1, 0, 1) * 0.6 / 0.7));
//                colors.push_back(make_pair(5.000f * PointsInMeter, Color(0, 1, 0, 1) * 0.6 / 0.7));
//                colors.push_back(make_pair(11.000f * PointsInMeter, Color(0, 1, 1, 1) * 1.0));
//            }
//
//            static std::vector<std::pair<float, Color> >grayColors;
//            if (grayColors.empty()) {
//                grayColors.push_back(make_pair(0.000f * PointsInMeter, Color(0.1, 0.1, 0.1, 1)));
//                grayColors.push_back(make_pair(0.325f * PointsInMeter, Color(0.1, 0.1, 0.1, 1)));
//                grayColors.push_back(make_pair(0.750f * PointsInMeter, Color(0.25, 0.25, 0.25, 1)));
//                grayColors.push_back(make_pair(1.500f * PointsInMeter, Color(0.5, 0.5, 0.5, 1)));
//                grayColors.push_back(make_pair(5.000f * PointsInMeter, Color(0.8, 0.8, 0.8, 1)));
//                grayColors.push_back(make_pair(11.00f * PointsInMeter, Color(0.9, 0.9, 0.9, 1)));
//            }
//
//            Color col = getColorByRatio(!caveViewPrefs.grayscale ? colors : grayColors, minDim) * colourMult;
//            col.a = 1.0f;
//            return col;
//        }
//        else {
//            return Color(0.5, 0.5, 0.5, 0.5);
//        }
//    }

    Color Cave::getDepthColor(float zPos) const {
        float depthRate = (zPos - minZPos) / (maxZPos - minZPos); 
        static std::vector<std::pair<float, Color> >colors;
        if (colors.empty()) {
            colors.push_back(make_pair(0 / 6.0f, Color(1, 0, 0, 1)));
            colors.push_back(make_pair(1 / 6.0f, Color(1, 1, 0, 1)));
            colors.push_back(make_pair(2 / 6.0f, Color(0, 1, 0, 1)));
            colors.push_back(make_pair(3 / 6.0f, Color(0, 1, 1, 1)));
            colors.push_back(make_pair(4 / 6.0f, Color(0, 0, 1, 1)));
            colors.push_back(make_pair(5 / 6.0f, Color(1, 0, 1, 1)));
        }

        static std::vector<std::pair<float, Color> >grayColors;
        if (grayColors.empty()) {
            grayColors.push_back(make_pair(0 / 6.0f, Color(0.1, 0.1, 0.1, 1)));
            grayColors.push_back(make_pair(5 / 6.0f, Color(0.9, 0.9, 0.9, 1)));
        }

        Color col = getColorByRatio(!caveViewPrefs.grayscale ? colors : grayColors, depthRate) * colourMult; ;
        col.a = 1.0f;
        return col;
    }

    Color Cave::getColorByRatio(const std::vector<std::pair<float, Color> >& colors, float rate) {
        for (int i = 0; i < colors.size(); i++) {
            int ni = i + 1;
            if (ni >= colors.size()) {
                return colors[i].second;
            }

            float ri = colors[i].first;
            float rni = colors[ni].first;
            if (ri <= rate && rni > rate) {
                float r = (rate - ri) / (rni - ri);
                return (1.0f - r) * colors[i].second + r * colors[ni].second;
            }
        }

        return Color(0.5, 0.5, 0.5, 0.5);
    }

    std::string Cave::getWallMaterial() {
        return "ColoredWall";
        // if (caveViewPrefs.wallColoringMode == WCM_SMOOTH || caveViewPrefs.wallColoringMode == WCM_TIGHTNESS_SMOOTH) {
        // return "ColoredWall";
        // } else {
        // switch(color){
        // case 0: return "BlackWall";
        // case 1: return "BlueWall";
        // case 2: return "GreenWall";
        // case 3: return "AquaWall";
        // case 4: return "RedWall";
        // case 5: return "PurpleWall";
        // case 6: return "SoftRedWall";
        // case 7: return "LightGrayWall";
        // case 8: return "DarkGrayWall";
        // case 9: return "PureBlueWall";
        // case 10: return "LimeWall";
        // case 11: return "KhakiWall";
        // case 12: return "RedWall";
        // case 13: return "FuchsiaWall";
        // case 14: return "YellowWall";
        // case 15: return "WhiteWall";
        // case 16: return "OrangeWall";
        // default: return "LimeWall";
        // }
        // }
    }

    // std::string Cave::getThreadMaterial(int color) {
    // switch(color){
    // case 0: return "BlackThread";
    // case 1: return "BlueThread";
    // case 2: return "GreenThread";
    // case 3: return "AquaThread";
    // case 4: return "RedThread";
    // case 5: return "PurpleThread";
    // case 6: return "SoftRedThread";
    // case 7: return "LightGrayThread";
    // case 8: return "DarkGrayThread";
    // case 9: return "PureBlueThread";
    // case 10: return "LimeThread";
    // case 11: return "KhakiThread";
    // case 12: return "RedThread";
    // case 13: return "FuchsiaThread";
    // case 14: return "YellowThread";
    // case 15: return "WhiteThread";
    // case 16: return "OrangeThread";
    // default: return "LimeThread";
    // }
    // }

    // const Color& Cave::getThreadColour(int color, P3DPriz priz) const {
    // static const Color BlackThread(0.2, 0.2, 0.2);
    // static const Color BlueThread(0.0, 0.0, 1.0);
    // static const Color GreenThread(0.0, 0.5, 0.0);
    // static const Color AquaThread(0.0, 1, 1);
    // static const Color RedThread(0.5, 0.0, 0.0);
    // static const Color PurpleThread(0.5, 0.0, 0.5);
    // static const Color SoftRedThread(0.94, 1, 1);
    // static const Color LightGrayThread(0.76, 0.76, 0.76);
    // static const Color DarkGrayThread(0.5, 0.5, 0.5);
    // static const Color PureBlueThread(0, 0.666, 1);
    // static const Color LimeThread(0, 1, 0.0);
    // static const Color KhakiThread(0.76, 0.76, 0.124);
    // static const Color FuchsiaThread(1, 0.0, 1);
    // static const Color YellowThread(1, 1, 0.0);
    // static const Color WhiteThread(1, 1, 1);
    // static const Color OrangeThread(0.94, 0.666, 0);
    //
    // if(priz & MARK_SURFACE)
    // return getThreadColour(caveViewPrefs.surfColorId);
    //
    // if(priz & MARK_DUPLICATE)
    // return getThreadColour(caveViewPrefs.dupColorId);
    //
    // switch(color){
    // case 0: return BlackThread;
    // case 1: return BlueThread;
    // case 2: return GreenThread;
    // case 3: return AquaThread;
    // case 4: return RedThread;
    // case 5: return PurpleThread;
    // case 6: return SoftRedThread;
    // case 7: return LightGrayThread;
    // case 8: return DarkGrayThread;
    // case 9: return PureBlueThread;
    // case 10: return LimeThread;
    // case 11: return KhakiThread;
    // case 12: return RedThread;
    // case 13: return FuchsiaThread;
    // case 14: return YellowThread;
    // case 15: return WhiteThread;
    // case 16: return OrangeThread;
    // default: return LimeThread;
    // }
    // }

    // const P3D* Cave::getP3D(int id) const {
    // const P3D* result = NULL;
    // if (id >= 0 && id < piketsData.size()) {
    // result = &piketsData.at(id);
    // }
    // Assert(result);
    // return result;
    // }

    V3 Cave::getVerticePos(int id) const {
        const Piket* pik = getPiket(id);
        if (pik) return pik->pos;
        else return V3::ZERO;
    }

    std::string Cave::getVerticeName(int id) const {
        const Piket* pik = getPiket(id);
        if (pik) return pik->getName();
        else return "";
    }
    
    const Piket* Cave::getPiket(int id) const {
        const Piket* result = NULL;
        unordered_map<int, Piket>::const_iterator fndRes = pikets.find(id);
        if (fndRes != pikets.end()) {
            result = &fndRes->second;
        }

        return result;
    }

    Piket* Cave::getPiketMut(int id) {
        Piket* result = NULL;
        unordered_map<int, Piket>::iterator fndRes = pikets.find(id);
        if (fndRes != pikets.end()) {
            result = &fndRes->second;
        }

        return result;
    }

    // int Cave::getPiketId(const P3D* sampleP3d) const {
    // return getPiketId(sampleP3d, sampleP3d->met);
    // }

    // int Cave::getPiketId(int met) const {
    // return getPiketId(NULL, met);
    // }

    // int Cave::getPiketId(const P3D* sampleP3d, int met) const {
    // if (met > 0) {
    // static int loopCounter = 0;
    // AssertReturn(loopCounter < 1000, "probably infinite loop detected");
    // std::tr1::unordered_map<int, int>::const_iterator equateFind = equates.find(met);
    // if (equateFind != equates.end() && loopCounter < 1000) {
    // loopCounter++;
    // int piketId = getPiketId(equateFind->second);
    // loopCounter--;
    // return piketId;
    // }
    // }
    //
    // std::tr1::unordered_map<int, Piket>::const_iterator pikiIt;
    // for (pikiIt = pikets.begin(); pikiIt != pikets.end(); pikiIt++) {
    // const P3D* p3d = pikiIt->second.piket;
    // if (met > 0 && p3d->met == met) {
    // return pikiIt->first;
    // }
    // if (sampleP3d != NULL && p3d == sampleP3d) {
    // return pikiIt->first;
    // }
    // }
    // return -1;
    // }

    // const P3D* Cave::getP3DbyMet(int met) const {
    // for (int i = 0; i < piketsData.size(); i++) {
    // if (piketsData[i].met == met) return &piketsData[i];
    // }
    // return NULL;
    // }

    // void Cave::attachToNode(Node* node) {
    // if (caveNode->getParent()) caveNode->getParent()->removeChild(caveNode);
    // node->addChild(caveNode);
    // }

    // const std::string& Cave::getPiketLabel(int met) {
    // const static std::string nullString;
    // if (met < piketsNames.size()) return piketsNames[met];
    // else return nullString;
    // }

    // cube->begin("Cave", RenderOperation::OT_TRIANGLE_LIST);
    // float s = 1000;
    // cube->position(-s, +s, +s);
    // cube->normal(-s, 0, 0);
    // cube->position(-s, -s, +s);
    // cube->position(-s, -s, -s);
    //
    // cube->position(-s, -s, -s);
    // cube->position(-s, +s, -s);
    // cube->position(-s, +s, +s);
    //
    //
    // cube->position(+s, +s, +s);
    // cube->normal(+s, 0, 0);
    // cube->position(+s, -s, +s);
    // cube->position(+s, -s, -s);
    //
    // cube->position(+s, -s, -s);
    // cube->position(+s, +s, -s);
    // cube->position(+s, +s, +s);
    //
    //
    //
    // cube->position(+s, -s, +s);
    // cube->normal(0, -s, 0);
    // cube->position(-s, -s, +s);
    // cube->position(-s, -s, -s);
    //
    // cube->position(-s, -s, -s);
    // cube->position(+s, -s, -s);
    // cube->position(+s, -s, +s);
    //
    //
    // cube->position(+s, +s, +s);
    // cube->normal(0, +s, 0);
    // cube->position(-s, +s, +s);
    // cube->position(-s, +s, -s);
    //
    // cube->position(-s, +s, -s);
    // cube->position(+s, +s, -s);
    // cube->position(+s, +s, +s);
    //
    //
    //
    // cube->position(+s, +s, -s);
    // cube->normal(0, 0, -s);
    // cube->position(-s, +s, -s);
    // cube->position(-s, -s, -s);
    //
    // cube->position(-s, -s, -s);
    // cube->position(+s, -s, -s);
    // cube->position(+s, +s, -s);
    //
    //
    // cube->position(+s, +s, +s);
    // cube->position(-s, +s, +s);
    // cube->position(-s, -s, +s);
    //
    // cube->position(-s, -s, +s);
    // cube->position(+s, -s, +s);
    // cube->position(+s, +s, +s);
    //
    // cube->end();

    void Cave::debugDraw(V3 a, V3 b, Color col) {
        addOutputLine(OT_DEBUG, a, b, col);
    }

    void Cave::addOutputPoly(OutputType type, V3 a, V3 b, V3 c, V3 an, V3 bn, V3 cn, const Color& ca, const Color& cb, const Color& cc) {
        OutputPoly poly;
        poly.a = a;
        poly.an = an;
        poly.b = b;
        poly.bn = bn;
        poly.c = c;
        poly.cn = cn;
        poly.ca = ca;
        poly.cb = cb;
        poly.cc = cc;
        outputPoly[type].push_back(poly);
    }

    void Cave::addOutputPoly(OutputType type, V3 a, V3 b, V3 c, const Color& col) {
        OutputPoly poly;
        poly.a = a;
        poly.an = V3(0, 0, 0);
        poly.b = b;
        poly.bn = V3(0, 0, 0);
        poly.c = c;
        poly.cn = V3(0, 0, 0);
        poly.ca = col;
        poly.cb = col;
        poly.cc = col;
        outputPoly[type].push_back(poly);
    }

    void Cave::addOutputLine(OutputType type, V3 a, V3 b, const Color& ca, const Color& cb) {
        OutputLine poly;
        poly.a = a;
        poly.b = b;
        poly.ca = ca;
        poly.cb = cb;
        outputLines[type].push_back(poly);
    }

    void Cave::addOutputLine(OutputType type, V3 a, V3 b, const Color& c) {
        addOutputLine(type, a, b, c, c);
    }

    const CM::EdgeInfo& Cave::getEdgeInfo(int from, int to) const {
        static EdgeInfo nullEdge;
        auto key = make_pair(std::min(from, to), std::max(from, to));
        auto edgeIt = edges.find(key);
        if (edgeIt != edges.end())
            return edgeIt->second;
        else
            return nullEdge;
    }

    std::vector< const Piket*>Cave::getZSurveyEdges(const Piket* from) const {
        std::vector< const Piket*>res;
        for (int i = 0; i < from->adjPikets.size(); i++) {
            const Piket* piket = from->adjPikets[i];
            if (piket && (piket->hasPriz(MARK_Z_SURVEY) || getEdgeInfo(from, piket).zsurvey))
                res.push_back(piket);
        }
        return res;
    }

    void Cave::resetOutput(OutputType type) {
        outputPoly[type].clear();
        outputLines[type].clear();
        outputChanged.insert(type);
    }

    std::vector<int> Cave::getPath(int fromVerticeId, int toVerticeId) const {
        LOG("path from vert: " << fromVerticeId << "  to vert:" << toVerticeId);
        
        std::map<int, float> verticeMinDist;
        std::set<int> front;                   
        std::set<int> nextFront;

        front.insert(fromVerticeId);
        verticeMinDist[fromVerticeId] = 0;
        float destinationMinDistance = FLT_MAX;

        for (int loopCounter = 0; loopCounter < pikets.size(); loopCounter++) {
            for (int frontPiketId :  front) {
                float frontPiketDist = verticeMinDist.at(frontPiketId);
                const Piket* frontPiket = getPiket(frontPiketId);      
                for(const Piket* adjPiket : frontPiket->adjPikets) { 
                    int adjPiketId = adjPiket->id;
                    float adjNewDist = frontPiketDist + adjPiket->pos.distance(frontPiket->pos);
                    float adjCurDist = FLT_MAX;
                    auto wit = verticeMinDist.find(adjPiketId);
                    if (wit != verticeMinDist.end()) adjCurDist = wit->second;

                    if (adjPiketId != toVerticeId) {
                        if (adjNewDist < adjCurDist && 
                            adjNewDist < destinationMinDistance) {  
                            verticeMinDist[adjPiketId] = adjNewDist;    
                            nextFront.insert(adjPiketId);
                        }    
                    } else {
                        destinationMinDistance = std::min(destinationMinDistance, adjNewDist);
                    }
                }
            }
            std::swap(front, nextFront);
            nextFront.clear();
        }

        if (destinationMinDistance != FLT_MAX && fromVerticeId != toVerticeId) {
            std::list<int> result;
            result.push_front(toVerticeId);
            int curPiketId = toVerticeId;
            for (int loopCounter = 0; loopCounter < pikets.size() && curPiketId != fromVerticeId; loopCounter++) {
                const Piket* curPiket = getPiket(curPiketId);  
                float minDist = FLT_MAX;    
                int minDistAdjPiketId = 0;
                for(const Piket* adjPiket : curPiket->adjPikets) {
                    int adjPiketId = adjPiket->id;
                    float adjPiketDist = FLT_MAX;
                    if (verticeMinDist.count(adjPiketId) == 1) {
                        adjPiketDist = verticeMinDist.at(adjPiketId);
                    }
                    if (minDist > adjPiketDist) {
                       minDist = adjPiketDist;
                       minDistAdjPiketId = adjPiketId;
                    }
                }  
                curPiketId = minDistAdjPiketId;  
                result.push_front(minDistAdjPiketId);  
                LOG("add: " << ToString(minDistAdjPiketId) << " dist " << minDist );
            }

            std::vector<int> resultVec(result.begin(), result.end());
                                                 
            LOG("result dist: " << destinationMinDistance );
            LOG("result: " << ToString(resultVec) );
        
            return resultVec;
        } else {
            return {};
        }
    }

}
