#pragma once
#include "CMTypes.h"
#include "CMHelpers.h"

namespace CM {

    struct PiketCache {
    public:
        PiketCache() : minCutDimension(NULL), cutBezier3(NULL) {
        }

        struct Walls2dCache {
            V3 dirrection;

            std::vector<WallProj>walls2d;
        };

        void reset();

        const std::vector<WallProj> * getWalls2d(V3 dirrection) const ;
        const std::vector<WallProj> * getWalls2dWithConvexCorrection(V3 dirrection) const ;
        void addWalls2d(V3 dirrection, std::vector<WallProj>walls2d);
        void addWalls2dWithConvexCorrection(V3 dirrection, std::vector<WallProj>walls2d);

        const float* getMinCutDimension() const {
            return minCutDimension;
        }

        void setMinCutDimension(float dim) {
            delete minCutDimension;
            minCutDimension = new float(dim);
        }

        const std::vector<LineBesier3> * getCutBezier3() const {
            return cutBezier3;
        }

        void setCutBezier3(const std::vector<LineBesier3>& c) {
            delete cutBezier3;
            cutBezier3 = new std::vector<LineBesier3>(c);
        }

    protected:
        std::vector<Walls2dCache>walls2d;
        std::vector<Walls2dCache>walls2dWithConvexCorrection;

        float* minCutDimension;

        std::vector<LineBesier3> *cutBezier3;
    };

    struct Piket {
    public:
        Piket(PiketInfo info /* V3 pos */) : id(info.id), pos(info.pos), origPos(info.pos), wallsCenter(0, 0, 0),
            // wallsMassCenter(0, 0, 0),
            piketEffectivePos(0, 0, 0), dirrection(0, 0, 0) {
            allP3D.push_back(info);
        }

        void preProcessWalls(const CaveViewPrefs& caveViewPrefs);
        void recalcPosCenterDirrection();
        bool isInactive() const ;

        void addP3D(const PiketInfo& piket);
        void addW3D(long long parentPiket, const Wall w3d);
        void addFakeWall(const PiketWall& wall);

        void convertToExtendedElevation(float rate = 1.0f);

        V3 getDirrectionForOverlay() const;
        
        // ВНИМАНИЕ
        // hasPriz(priz) != !hasNoPriz(priz) в общем случае !!!
        // ВНИМАНИЕ
        bool hasPriz(PiketMark priz) const ;
        bool hasNoPriz(PiketMark priz) const ;

        std::vector< const Piket*>getAdjPiketsWithPriz(PiketMark prz) const ;
        std::vector< const Piket*>getAdjPiketsWithoutPriz(PiketMark prz) const ;
        PiketMark getSumPriz() const ;

        // Color getPrevailWallColor() const;
        // Color getColorOfP3DWithPriz(PiketMark priz) const;

        float getMaxDimension() const ;
        std::string getName() const ;
        std::string getLabel() const ;
        // const V3& pos() const { return allP3D.front().pos; }

        void resetCache() const {
            cache.reset();
        };

        struct LeftRight {
            V3 left;
            V3 right;
        };

        LeftRight getCornerCutPoints(V3 lookDirection, V3 normal) const ;
        const std::vector<LineBesier3>& getCutBezier3() const ;
        void getCrossPiketLineBesier3(std::vector<CrossPiketLineBesier3>& output) const ;

        const std::vector<WallProj>& getWalls2d(V3 dirrection) const ;
        const std::vector<WallProj>& getWalls2dWithConvexCorrection(V3 dirrection) const ;
        std::vector<ExtWallProj>getExtWalls2d(V3 sortDirrection, V3 addinDirrection) const ;
        std::vector<ExtWallProj>getExtWalls2dWithConvexCorrection(V3 sortDirrection, V3 addinDirrection) const ;

        float getMinCutDimension() const ;
        float getExtendedElevationX() const ;

        V3 getExtendedElevationPos(float rate) const {
            return origPos * (1.0f - rate) + V3(getExtendedElevationX(), 0, origPos.z) * rate;
        }

    protected:
        void processPiketPosAsWall();
        void updateEffectivePos(); // рассчитать центр стен
        void updateWallsCenter(); // рассчитать центр стен
        void updateDirrection(); // рассчитать нормаль к сечению хода образованному стенами
        // void propagateWalls(WallsPropagateMode propMode, WallsBlowMode blowMode); // размножить стены
        // std::vector<PiketWall> propagateWallAngleAbove(int wallId1, int wallId2, int num, WallsBlowMode blowMode ) const; // алгорим размножения стен на основе угламежду ими и центром
        std::vector<PiketWall>propagateWallBesier3(int h, int i, int j, int k, int addWallsNum, float strong = 0.4f) const ; // алгоритм размножения стен на основе безье 3 порядка
        LineBesier3 getCutSegmentBesier3(int h, int i, int j, int k, float strong = 0.4f) const ; // строит безье для сегмента стены

        void classifyWalls(); // разделить на внутренние и внешние стены

        std::vector<ExtWallProj>convertToExtWalls2d(const std::vector<WallProj>& source, V3 globalDirrection) const ;

    public:
        int id;
        V3 pos;
        V3 origPos; // non processed pos

        std::vector< const Piket*>adjPikets;
        std::vector< const Piket*>adjFakePikets;
        std::vector<Wall>allWalls;
        std::vector<PiketInfo>allP3D;

        V3 wallsCenter;
        V3 piketEffectivePos;
        V3 dirrection;

        std::vector<PiketWall>classifiedWalls;

        mutable PiketCache cache;
    };

}
