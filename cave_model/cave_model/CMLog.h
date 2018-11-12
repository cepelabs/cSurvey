#pragma once
#include <string>

class CMLog {
public:
	static CMLog* inst();
	virtual void log( const std::string& message) { }
	virtual void logDebug( const std::string& message) { }

protected:
	static CMLog* instatnce;
};

#define LOG(...) do{ \
	std::stringstream ss; \
	ss << __VA_ARGS__;     \
	CMLog::inst()->log(ss.str());  \
} while(false)

#define DLOG(...) do { \
	std::stringstream ss; \
	ss << __VA_ARGS__;     \
	CMLog::inst()->log(ss.str());   \
} while(false)


