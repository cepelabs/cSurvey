#pragma once

#include "format.h"
#include "string.h"

//https://github.com/vitaut/format

// template <class T>
// std::string yFormat(T& param)
// {
// 	try
// 	{
// 		return fmt::str(param);
// 	}
// 	catch (fmt::FormatError err)
// 	{
// 		return err.what();//fmt::string("wrong format");
// 	}
// }

namespace CM {

inline std::string yprintf (const char* format)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) );
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1>
std::string yprintf (const char* format, const pt1& p1)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 );
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2 , class pt3>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12, class pt13>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12, const pt13& p13)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12 << p13);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12, class pt13, class pt14>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12, const pt13& p13, const pt14& p14)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12 << p13 << p14);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12, class pt13, class pt14, class pt15>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12, const pt13& p13, const pt14& p14, const pt15& p15)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12 << p13 << p14 << p15);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12, class pt13, class pt14, class pt15, class pt16>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12, const pt13& p13, const pt14& p14, const pt15& p15, const pt16& p16)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12 << p13 << p14 << p15 << p16);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12, class pt13, class pt14, class pt15, class pt16, class pt17>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12, const pt13& p13, const pt14& p14, const pt15& p15, const pt16& p16, const pt17& p17)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12 << p13 << p14 << p15 << p16 << p17);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

template <class pt1, class pt2, class pt3, class pt4, class pt5, class pt6, class pt7, class pt8, class pt9, class pt10, class pt11, class pt12, class pt13, class pt14, class pt15, class pt16, class pt17, class pt18>
std::string yprintf (const char* format, const pt1& p1, const pt2& p2, const pt3& p3, const pt4& p4, const pt5& p5, const pt6& p6, const pt7& p7, const pt8& p8, const pt9& p9, const pt10& p10, const pt11& p11, const pt12& p12, const pt13& p13, const pt14& p14, const pt15& p15, const pt16& p16, const pt17& p17, const pt18& p18)
{
	try
	{
		return fmt::str/*yFormat*/(fmt::Format(format) << p1 << p2 << p3 << p4 << p5 << p6 << p7 << p8 << p9 << p10 << p11 << p12 << p13 << p14 << p15 << p16 << p17 << p18);
	}
	catch (fmt::FormatError err)
	{
		return err.what();//fmt::string("wrong format");
	}
}

#define YWarning( Format, ... ) Warning(yprintf(Format,##__VA_ARGS__).c_str())
#define YCheckWarning( Condition, Format, ...  ) CheckWarning(Condition, yprintf(Format,##__VA_ARGS__).c_str())
#define YCheckError( Condition, Format, ... ) CheckError(Condition, yprintf(Format,##__VA_ARGS__).c_str())

} 
