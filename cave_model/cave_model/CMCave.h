// ---------------------------------------------------------------------------
#pragma once
#include <vector>           
#include <map>
// #include "OgrePrerequisites.h"
#include "CMHelpers.h"
#include <unordered_map>    
#include <unordered_set>      
#include "CMPiket.h"

namespace CM {

    typedef std::vector<V3>vectorV3;

    class Cave {
    public:
        Cave();
        ~Cave();

        bool setCaveViewPrefs(const CaveViewPrefs& prefs);

        void addVertice(const PiketInfo& piketInfo, int equatesVerticeId = 0);
        void addEdge(int verticeId0, int verticeId1);
        void addEdge(const EdgeInfo& info);
        void addWall(const Wall& wall, int linkToVerticeId, int parentPiketId = 0);
        void setShouldConvertToExtendedElevation(bool convert);

        void finishInit(OutputType enabledToGenerateOutput = (OutputType)~OT_UNKNOW);

        const std::vector<OutputPoly>& getOutputPoly(OutputType type) {
            return outputPoly[type];
        }

        const std::vector<OutputLine>& getOutputLine(OutputType type) {
            return outputLines[type];
        }

        bool isOutputEnabled(OutputType type) {
            return outputLayers[type];
        }

        bool isOutputChanged(OutputType type) {
            return outputChanged.count(type) == 1;
        }
        std::vector<CrossPiketLineBesier3> calcOutineBesier() const ;
        // const CaveViewPrefs& getCaveViewPrefs() const { return caveViewPrefs; }
                                       
        std::vector<int> getPath(int fromVerticeId, int toVerticeId) const;

        V3 getVerticePos(int id) const;
        std::string getVerticeName(int id) const;
        
    protected:
        void convertToExtendedElevation(float rate = 1.0f);

        void buildFakeZSurveyPikets(); // ������������ ���������� ������ �������� �������������� ������
        void prebuildPikets(); // prepare pikets for build walls and oultine
        void buildWallsObject(); // ��������� ����������� ������ ����
        // ������������� ����������� ���� ����� ����� �������� ������� ��������� � ����������
        WallTriangles buildWallSegment(const Piket* piket, const Piket* nextPiket);
        // ������������� ����������� ���� ����� ����� �������� ������� ��������������
        // ���� ����� ������� ������ ������ ����������� ��� ������
        // WallTriangles buildWallSegmentCenterMode(const Piket* piket, const Piket* nextPiket);
        // ������������� ����������� ���� ����� ����� �������� ������� ��������������
        // �� ����������� ������������ ������ �������� ���������������
        WallTriangles buildWallSegmentConvexPolyMode(const Piket* piket, const Piket* nextPiket);
        // ������������� ����������� ���� ����� ����� �������� ������� ��������������
        // �� �������� �� ������� ������������ �����������������
        // WallTriangles buildWallSegmentConvexQuadMode(const Piket* piket, const Piket* nextPiket);
        void buildThreadObject(); // ������ ����������� ������ ����� ����
        void buildPointsObject(); // ������ ����������� ������ ����� �������
        void buildCutsObject(); // ������ ����������� ������ ����� �������
        void buildBoxObject();

        // build outline visual output
        // ������������� ������ ������. ����������� ����� ������ ����� � ����� ����� ��� �����������
        void buildOutline();
        void buildOutlineCut();

        void buildOutlineBezier(std::vector<CrossPiketLineBesier3>& output, std::tr1::unordered_set<int> * piketsForCreateCutOutline = NULL) const ;
        void buildOutlineSegmenteBezier(const Piket* nextPiket, const Piket* curPiket, std::vector<CrossPiketLineBesier3>& output,
            std::tr1::unordered_set<int> * piketsForCreateCutOutline = NULL) const ;

        void updateWallsSurrfaceMode(); // �������� / ������ ����.������� � ������������ � �����������

        void invalidatePrebuild() {
            prebuildInvalidated = true;
        };

        // ��������� ����� � ������ ��� ���� �� ������ ������� ������� �� �������
        // �������� genPiketsFakeWalls�hainSearch ��� ���� ��������� ������� �� �������
        void genPiketsFakeWalls(FakeWallsMode mode);
        // ����������� ������� ������ ������� ���������� ������� ����������� ���������� ��������
        void genPiketsFakeWalls�hainSearch(FakeWallsMode mode, Piket* beginPiket, Piket* curEnd, int accumLength, std::vector<Piket*>& intermPikets);
        // ������ ��������������� ��������� ������� � ����� ���������� ���������� ������ ���������
        void genPiketsFakeWallsProcessChain(FakeWallsMode mode, Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket);
        // ������������ ����������
        void genPiketsFakeWallsSkip(Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket);
        // ��������� ����������
        void genPiketsFakeWallsTrail(Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket);
        // ������ ����� ��������� � ������������
        void genPiketsFakeWallsBudge(Piket* beginPiket, std::vector<Piket*>intermPikets, Piket* endPiket);

        // ������� ���������� �����
        Piket* getPiketMut(int id);
        const Piket* getPiket(int id) const ;

        void logPikets();

        // ������� ��������� ����
        std::string getWallMaterial();

        // ������� ��������� �� ���� ����� �� ������
        static int minAngleWallPoint(V2 point, const std::vector<V2>& rotWalls, bool abs, int skipPoint);

        void buildWallTriangles();

        // ��������� ������������ ���������������� ������������� � ����������� ��
        // ����������� ����������� ����������� ������������� (�������� smooth)
        // ����������� ������ ���� ������������ �� �������
        // ����������� ��������� - �����
        void drawTriangleSmooth(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn);
        // ���������� ���������� ����������� �����. �� ���������, �������� �������
        void drawTriangleSmooth2(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn);
        // �� �������������������� ���������� ����������� �����. �� ���������
        void drawTriangleSmooth3(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn);
        // ������������ �����. �� ������������� ��������. �� ���������
        void drawTriangleSmooth4(int smooth, const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn);

        // �������� ����������� � walls ManualObject
        // ����������� ������ ���� ������������ �� �������
        void drawTriangle(const Color& ca, const Color& cb, const Color& cc, V3 a, V3 an, V3 b, V3 bn, V3 c, V3 cn);
        // �������� ����������� ��� ������������ ������������ ��������
        void addSmoothedTriangle(const Color& ca, const Color& cb, const Color& cc, bool clockwise, V3 a, V3 b, V3 c);

        V3 normalisedEdgeCenter(V3 a, V3 an, V3 b, V3 bn);

        void debugDraw(V3 a, V3 b, Color col = Color(0, 0.5, 0, 1));

        void processZSurveyPiketsChain(const std::list< const Piket*>& chain);

        // int getFreePiketId() const;
        const Piket* addFakePiket(V3 pos,/* Color col,*/ PiketMark priz, const std::vector<Wall>& walls, const std::vector<EdgeInfo>& edges);

        static std::vector<std::pair<bool, int> >calcTriangulationOrdertConvexPolyMode(const std::vector<ExtWallProj>& a, const std::vector<ExtWallProj>& b, bool clockwise,
            bool force_convex);
        static std::vector<std::pair<bool, int> >calcTriangulationOrdertConvexPolyMode(const std::vector<ExtWallProj>& a, int aStart, int aEnd, const std::vector<ExtWallProj>& b,
            int bStart, int bEnd, bool clockwise, bool force_convex);

//        Color getColorForPiket(const Piket* piket) const ;
//        Color getColorForPiketByEdges(const Piket* piket) const ;
        Color getColorForPiketAtEdge(const Piket* primary, const Piket* secondary) const ;
        const Color& getColorForEdge(const Piket* from, const Piket* to) const ;
        Color getDepthColor(float zPos) const;

        static Color getColorByRatio(const std::vector<std::pair<float, Color> >& colors, float rate);

        const EdgeInfo& getEdgeInfo(const Piket* from, const Piket* to) const {
            return getEdgeInfo(from->id, to->id);
        }
        const EdgeInfo& getEdgeInfo(int from, int to) const ;

        std::vector< const Piket*>getZSurveyEdges(const Piket* from) const ;

        // output:
        bool isOutputEnabledToGenerate(OutputType ot) {
            return (ot & enabledToGenerate) > 0;
        }
        void resetOutput(OutputType type);
        void addOutputPoly(OutputType type, V3 a, V3 b, V3 c, V3 an, V3 bn, V3 cn, const Color& ca, const Color& cb, const Color& cc);
        void addOutputPoly(OutputType type, V3 a, V3 b, V3 c, const Color& col);
        void addOutputLine(OutputType type, V3 a, V3 b, const Color& c);
        void addOutputLine(OutputType type, V3 a, V3 b, const Color& ca, const Color& cb);

        void addApproximartedCurvesToOuotput(const std::vector<CrossPiketLineBesier3>& curves, OutputType dst);

    protected: // �������������
        // std::vector<V3> calcCube(int i);
        // void addPolygon(OuputType type, Ogre::Vector3 p0, Ogre::Vector3 p1, Ogre::Vector3 p2, Ogre::Vector3 p3);

        bool wasInited;

        bool shouldConvertToExtendedElevation;

        std::tr1::unordered_map<int, Piket>pikets;
        std::map<std::pair<int, int>, EdgeInfo>edges;

        CaveViewPrefs caveViewPrefs;

        V3 boxMin;
        V3 boxMax;

        std::string curWallsMaterial;
        // ������� � ��������� ������������ � ���������.
//        std::vector<SurfaceTriangle>lastTriangles;

        bool debugTriangulationAlgo;

        // ��������� ������
        // ����������� � ������� �� ������, ������������ ����� ������������ �����������
        // ������������ ������������ ����� � ���������� �� ����������
        std::vector<VerticeTriangle>smoothedTriangles;
        std::map<Vertice, VerticeNormal>smoothedTrianglesVerticesNormals;

        std::tr1::unordered_map<OutputType, std::vector<OutputPoly> >outputPoly;
        std::tr1::unordered_map<OutputType, std::vector<OutputLine> >outputLines;
        std::tr1::unordered_map<OutputType, bool>outputLayers;
        std::set<OutputType>outputChanged;

        float colourMult;

        bool prebuildInvalidated;

        OutputType enabledToGenerate;
        float minZPos {FLT_MAX};
        float maxZPos {0};
        
        std::tr1::unordered_set<int> piketsForCreateCutOutline;
    };

}
