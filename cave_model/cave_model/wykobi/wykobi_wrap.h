//---------------------------------------------------------------------------

#pragma once
#include "OgreVector3.h"
#include "wykobi.hpp"

inline wykobi::point3d<float> V3toP3 (const Ogre::Vector3& v3) {
    return wykobi::point3d<float>(v3.x, v3.y, v3.z);
}  

inline Ogre::Vector3 P3toV3 (const wykobi::point3d<float>& p3) {
    return Ogre::Vector3(p3.x, p3.y, p3.z);
}

typedef wykobi::plane<float, 3> plane3d;
typedef wykobi::line<float,3> line3df;   
typedef wykobi::point3d<float> P3; 
typedef wykobi::point2d<float> P2; 
typedef wykobi::segment<float,2> S2;

