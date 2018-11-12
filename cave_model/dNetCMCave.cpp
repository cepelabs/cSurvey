// This is the main DLL file.

#include <msclr/marshal_cppstd.h>
#include "dNetCMCave.h"
#include "CMCave.h"
#include <stdlib.h>
#include <string.h>
#include <sstream>
#include <CMLog.h>
#include <msclr\marshal_cppstd.h>

namespace DotNetCaveModel {

	using namespace CM;
	using namespace msclr::interop;
	using namespace System;
	using namespace System::Collections::Generic;
	using namespace msclr::interop;


	class DNetCMLog : public CMLog {
	public:
		virtual void log(const std::string& message) {
			std::cerr << message << std::endl;
		}
		virtual void logDebug(const std::string& message) {
			std::cerr << message << std::endl;
		}

		static void init() {
			if (!instatnce) {
				instatnce = new DNetCMLog;
			}
		}
	};

	DNetCMCave::DNetCMCave() {
		DNetCMLog::init();

		CM::PointsInMeter = 1.0f;

		cmCave = new Cave();
		LOG("create cave: " << (void*)cmCave);

		caveViewPrefs = new CaveViewPrefs();
		//	caveViewPrefs->showDebug = true;
	}


	DNetCMCave::~DNetCMCave()
	{
		LOG("delete cave: " << (void*)cmCave);
		delete cmCave;
		cmCave = nullptr;

		delete caveViewPrefs;
		caveViewPrefs = nullptr;
	}

	bool DNetCMCave::setMode(RenderMode mode)
	{
		switch (mode)
		{
		case DotNetCaveModel::RenderMode::SM_ROUGH_WALLS:
			updateForRoughWallsMode(caveViewPrefs);
			break;
		case DotNetCaveModel::RenderMode::SM_SMOOTH_WALLS:
			updateForSmoothWallsMode(caveViewPrefs);
			break;
		case DotNetCaveModel::RenderMode::SM_CUTS:
			updateForSectionsWallsMode(caveViewPrefs);
			break;
		case DotNetCaveModel::RenderMode::SM_OUTLINE:
			updateForOutlineMode(caveViewPrefs);
			break;
		}
		lastSetRenderMode = mode;
		return cmCave->setCaveViewPrefs(*caveViewPrefs);
	}

	bool DNetCMCave::setColoringMode(ColoringMode mode) {
		return setColoringMode(mode, false);
	}

	bool DNetCMCave::setLookDirection(float x, float y, float z) {
		caveViewPrefs->lookDirrection.x = x;
		caveViewPrefs->lookDirrection.y = y;
		caveViewPrefs->lookDirrection.z = z;
		caveViewPrefs->lookDirrection.normalise();
		return cmCave->setCaveViewPrefs(*caveViewPrefs);
	}

	void DNetCMCave::setShouldConvertToExtendedElevation(bool x)
	{
		cmCave->setShouldConvertToExtendedElevation(x);
	}

	bool DNetCMCave::setColoringMode(ColoringMode mode, bool grayscale)
	{
		switch (mode)
		{
		case DotNetCaveModel::ColoringMode::CM_CAVEBRANCH:
			caveViewPrefs->wallColoringMode = WCM_SMOOTH;
			break;
		case DotNetCaveModel::ColoringMode::CM_TIGHTNESS_SMOOTH:
			caveViewPrefs->wallColoringMode = WCM_TIGHTNESS_SMOOTH;
			break;
		case DotNetCaveModel::ColoringMode::CM_DEPTH_SMOOTH:
			caveViewPrefs->wallColoringMode = WCM_DEPTH_SMOOTH;
			break;
		}

		caveViewPrefs->grayscale = grayscale;

		return cmCave->setCaveViewPrefs(*caveViewPrefs);
	}

	void DNetCMCave::updateForRoughWallsMode(CaveViewPrefs* caveViewPrefs) {
		caveViewPrefs->wallsPropagateMode = CM::WPM_NONE;
		caveViewPrefs->wallsShadowMode = CM::WSM_ROUGH;
		caveViewPrefs->wallsBlowMode = CM::WBM_NONE;
		caveViewPrefs->wallsSurfaceMode = CM::WSFM_SURF;
		caveViewPrefs->wallsTrianglesBlowMode = CM::WTBM_NONE;
		caveViewPrefs->wallsTrianglesBlowStrength = CM::WTBS_LOW;
		caveViewPrefs->showSections = false;
		caveViewPrefs->showWallLines = false;
		caveViewPrefs->showOutline = false;
	}

	void DNetCMCave::updateForSmoothWallsMode(CaveViewPrefs* caveViewPrefs) {
		caveViewPrefs->wallsPropagateMode = CM::WPM_NONE;
		caveViewPrefs->wallsShadowMode = CM::WSM_ROUGH;
		caveViewPrefs->wallsBlowMode = CM::WBM_NONE;
		caveViewPrefs->wallsSurfaceMode = CM::WSFM_SURF;
		caveViewPrefs->wallsTrianglesBlowMode = CM::WTBM_9;
		caveViewPrefs->wallsTrianglesBlowStrength = CM::WTBS_LOW;
		caveViewPrefs->showSections = false;
		caveViewPrefs->showWallLines = false;
		caveViewPrefs->showOutline = false;
	}

	void DNetCMCave::updateForSectionsWallsMode(CaveViewPrefs* caveViewPrefs) {
		caveViewPrefs->wallsPropagateMode = CM::WPM_NONE;
		caveViewPrefs->wallsShadowMode = CM::WSM_ROUGH;
		caveViewPrefs->wallsBlowMode = CM::WBM_NONE;
		caveViewPrefs->wallsSurfaceMode = CM::WSFM_NONE;
		caveViewPrefs->wallsTrianglesBlowMode = CM::WTBM_NONE;
		caveViewPrefs->wallsTrianglesBlowStrength = CM::WTBS_LOW;
		caveViewPrefs->showSections = true;
		caveViewPrefs->showWallLines = true;
		caveViewPrefs->showOutline = false;
	}

	void DNetCMCave::updateForOutlineMode(CaveViewPrefs* caveViewPrefs) {
		caveViewPrefs->wallsPropagateMode = CM::WPM_NONE;
		caveViewPrefs->wallsShadowMode = CM::WSM_ROUGH;
		caveViewPrefs->wallsBlowMode = CM::WBM_NONE;
		caveViewPrefs->wallsSurfaceMode = CM::WSFM_NONE;
		caveViewPrefs->wallsTrianglesBlowMode = CM::WTBM_NONE;
		caveViewPrefs->wallsTrianglesBlowStrength = CM::WTBS_LOW;
		caveViewPrefs->showThread = true;
		caveViewPrefs->showSections = false;
		caveViewPrefs->showWallLines = true;
		caveViewPrefs->showOutline = true;
	}
	
	CM::PiketInfo DNPiketInfo::toPiketMark()
	{
		PiketInfo res;
		res.id = id;
		String^ temp = name;
		res.name = marshal_as< std::string>(temp);
		temp = label;
		res.label = marshal_as< std::string>(temp);
		res.pos = V3(x, y, z);
		res.extendedElevationX = extendedElevationX;
//		res.col = Color(r, g, b);
		res.priz = (PiketMark)priz;
		//res.hasWalls = hasWalls;

		return res;
	
	}
	void DNetCMCave::addVertice(DNPiketInfo^ piketInfo) {
		auto piket = piketInfo->toPiketMark();
		LOG("\tst id: " << piket.id << " name: " << piket.name << " pos:" << piket.pos);
		cmCave->addVertice(piket);
	}

	void DNetCMCave::addVertice(DNPiketInfo^ piketInfo, int equatesVerticeId) {
		auto piket = piketInfo->toPiketMark();
		LOG("\tst id: " << piket.id << " name: " << piket.name << " pos:" << piket.pos);
		cmCave->addVertice(piket, equatesVerticeId);
	}

	void DNetCMCave::addEdge(int verticeId0, int verticeId1)
	{
		//LOG("\tedge: " << verticeId0 << "- " << verticeId1);

		cmCave->addEdge(verticeId0, verticeId1);
	}

	void DNetCMCave::addEdge(int verticeId0, int verticeId1, bool zSurvey, float r, float g, float b)
	{
		//LOG("\tedge: " << verticeId0 << "- " << verticeId1);
		EdgeInfo info(verticeId0, verticeId1);
		info.col = Color(r, g, b, 1.0f) ;
		info.zsurvey = zSurvey;
		cmCave->addEdge(info);
	}

	void DNetCMCave::addWall(DNWall ^ wall, int linkToVerticeId, int parentPiketId)
	{
		cmCave->addWall(wall->toWall(), linkToVerticeId, parentPiketId);
	}

	void DNetCMCave::addWall(float x, float y, float z, int linkToVerticeId, int parentPiketId)
	{
		DNWall ^ wall = gcnew DNWall;
		wall->x = x;
		wall->y = y;
		wall->z = z;
		addWall(wall, linkToVerticeId, parentPiketId);
	}

	void DNetCMCave::finishInit() 
	{
		cmCave->finishInit();
	}
	
	void DNetCMCave::finishInit(DMOuputType outputMask)
	{
		cmCave->finishInit((CM::OutputType)outputMask);
	}

	System::Collections::Generic::List<DNOutputPoly^>^ DNetCMCave::getOutputPoly(DMOuputType type)
	{
		const auto& outputPoly = cmCave->getOutputPoly((OutputType)type);
		List<DNOutputPoly^>^ res = gcnew List<DNOutputPoly^>(outputPoly.size());
		for (const auto& poly : outputPoly) {
			res->Add(gcnew DNOutputPoly(poly));
		}
		return res;
	}

	List<DMOutputLine^>^ DNetCMCave::getOutputLine(DMOuputType type)
	{
		const auto& outputLine = cmCave->getOutputLine((OutputType)type);
		List<DMOutputLine^>^ res = gcnew List<DMOutputLine^>(outputLine.size());
		for (const auto& line : outputLine) {
			res->Add(gcnew DMOutputLine(line));
		}
		return res;
	}

	List<DNCrossPiketLineBesier3^>^ DNetCMCave::calcOutineBesier()
	{
		const auto& outlineBezier = cmCave->calcOutineBesier();
		List<DNCrossPiketLineBesier3^>^ res = gcnew List<DNCrossPiketLineBesier3^>(outlineBezier.size());
		for (const auto& line : outlineBezier) {
			res->Add(gcnew DNCrossPiketLineBesier3(line));
		}
		return res;
	}

	bool DNetCMCave::isOutputEnabled(DMOuputType type)
	{
		return cmCave->isOutputEnabled((OutputType)type);
	}


	CM::Wall DNWall::toWall()
	{
		return Wall(V3(x, y, z));
	}

	DNOutputPoly::DNOutputPoly(const CM::OutputPoly poly)
	{
		vertice = gcnew array<float, 2>{ {poly.a.x, poly.a.y, poly.a.z}, { poly.b.x, poly.b.y, poly.b.z }, { poly.c.x, poly.c.y, poly.c.z } };
		color = gcnew array<float, 2> { {poly.ca.r, poly.ca.g, poly.ca.b, poly.ca.a}, { poly.cb.r, poly.cb.g, poly.cb.b, poly.cb.a }, { poly.cc.r, poly.cc.g, poly.cc.b, poly.cc.a } };
	}

	DMOutputLine::DMOutputLine(const CM::OutputLine line)
	{
		vertice = gcnew array<float, 2>{ {line.a.x, line.a.y, line.a.z}, { line.b.x, line.b.y, line.b.z } };
		color = gcnew array<float, 2> { {line.ca.r, line.ca.g, line.ca.b, line.ca.a}, { line.cb.r, line.cb.g, line.cb.b, line.cb.a } };
	}

	DNCrossPiketLineBesier3::DNCrossPiketLineBesier3(const CM::CrossPiketLineBesier3 line)
	{
		aid = line.aid;
		bid = line.bid;

		points = gcnew array<float, 2>{ { line.a.x, line.a.y, line.a.z }, 
										{ line.ac.x, line.ac.y, line.ac.z }, 
										{ line.bc.x, line.bc.y, line.bc.z }, 
										{ line.b.x, line.b.y, line.b.z } };
	}

}