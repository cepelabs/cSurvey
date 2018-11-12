#pragma once
#include "assert.h" 
//#include "yprintf.h"  
#include <string>      
#include <sstream>
#include <csignal>

#define AssertReturn(var, exec) \
if(!(var)) { \
/*_asm {int 3};*/\
exec; \
}\

#define Assert(var) AssertReturn(var, ; )

