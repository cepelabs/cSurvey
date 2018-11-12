/******************************************************************************/

#ifndef __TEXT_H__
#define __TEXT_H__

/******************************************************************************/


#define TRUE true
#define FALSE false

#include "CMcommon.h"
#include <string>
#include <vector>
#include <list>
#include <map>
#include <set>
#include <stdarg.h>

namespace CM {
/******************************************************************************/

/* stupid windows does not printf "0x" prefix for %p printf-s */
const char PointerHexPrefix[] =
	#ifdef WINDOWS
	"0x" ;
	#else
	"" ;
	#endif

/******************************************************************************/

#ifdef VC
	 #pragma warning (disable:4503)
#endif
/* map with column_name=>value */
typedef std::map<std::string,std::string> row_t ;
/* map with rows_id=>row */
typedef std::map<std::string,row_t> table_t ;
//typedef malloc_map<std::string, row_t> malloc_table_t ;

/******************************************************************************/

std::vector<std::string> ParseCSV(const std::string & line, char delimiter = ',');
std::string xprintf_va ( const char* Format, va_list Args ) ;
std::string xprintf ( const char* Format, ... ) ;
#define cxprintf(Format,...) (xprintf(Format,##__VA_ARGS__).c_str())
std::string ToString ( std::string String ) ;
std::string ToString ( int Number ) ;
std::string ToString ( long long Number ) ;
std::string ToString ( size_t Number ) ;
std::string ToString ( double Number ) ;
std::string ToString ( bool Flag ) ;
template <typename type> std::string ToString ( std::vector<type> Vector )
{
	std::string Result = "{" ;
	foreach ( It, typename std::vector<type>, Vector )
	{	Result += (It!=Vector.begin()?",":"")+ToString(*It) ; }
	Result += "}" ;
	return Result ;
}
template <typename type> std::string ToCSV(std::vector<type> Vector)
{
	std::string Result = "";
	foreach(It, typename std::vector<type>, Vector)
	{
		Result += (It != Vector.begin() ? ";" : "") + ToString(*It);
	}
	Result += "";
	return Result;
}
template <typename type> std::string ToString ( std::set<type> Vector )
{
	std::string Result = "{" ;
	foreach ( It, typename std::set<type>, Vector )
	{	Result += (It!=Vector.begin()?",":"")+ToString(*It) ; }
	Result += "}" ;
	return Result ;
}

std::string StringFromString (const std::string& String, bool* WasSuccessful=NULL ) ;
void FromString ( std::string& Value, const std::string& String, bool* WasSuccessful=NULL ) ;

bool BoolFromString (const std::string& String, bool* WasSuccessful=NULL ) ;
void FromString ( bool& Value, const std::string& String, bool* WasSuccessful=NULL ) ;

int IntFromString (const std::string& String, bool* WasSuccessful=NULL, bool IgnoreEmpty=FALSE, int Radix=10 ) ;
void FromString ( int& Value, const std::string& String, bool* WasSuccessful=NULL, bool IgnoreEmpty=FALSE, int Radix=10 ) ;

long long LongLongFromString (const std::string& String, bool* WasSuccessful=NULL, bool IgnoreEmpty=FALSE, int Radix=10 ) ;
void FromString ( long long& Value, const std::string& String, bool* WasSuccessful=NULL, bool IgnoreEmpty=FALSE, int Radix=10 ) ;

double DoubleFromString (const std::string& String, bool* WasSuccessful=NULL, bool IgnoreEmpty=FALSE ) ;
void FromString ( double& Value, const std::string& String, bool* WasSuccessful=NULL, bool IgnoreEmpty=FALSE ) ;

#define ToCString(Number) (ToString(Number).c_str())
std::string str_replace ( const std::string& SearchFor, const std::string& ReplaceWith, std::string Text ) ;
std::string MergeVector ( std::vector<std::string> const& Vector, std::string Divider=", " ) ;
std::string MergeSet ( std::set<std::string> const& Vector, std::string Divider=", " ) ;
std::string MergeList ( std::list<std::string> const& Vector, std::string Divider=", " ) ;
std::string MergeArray ( const char* const* const& Array, std::string Divider=", " ) ;
void AskToPressEnter ( void ) ;
std::string ToLower ( std::string Text ) ;
std::string ToUpper ( std::string Text ) ;
table_t& FetchTable ( std::string TableName ) ;
table_t& LoadTable ( std::string FileName, bool UseCache=TRUE ) ;
void AddStringToTable (const std::string& name,  const std::string& string) ;
void LoadTableBasic ( std::string FileName, table_t& Table, bool FullFilling=TRUE, bool CombineSameIds=FALSE, bool accept_add_to_not_empty_map=FALSE, bool allowEmptyRow = false ) ;
void SaveTable ( std::string FileName, const table_t& Table, std::string Id, std::set<std::string> Header, bool equal_column_rows = true) ;
void StrLang ( const char* NewLanguage ) ;
void StrLoad ( std::string Name, bool RawPath=FALSE ) ;
void SetLanguage();
const char* GetLanguage();
void ClearStrCache ( void );
void ClearTablesCache ( void );
const char* Str ( std::string Name ) ;
std::string ExtractFileName ( std::string Location ) ;
std::vector<std::string> SplitString ( std::string String, std::string Div=";" ) ;
std::vector<std::string> SplitByNewlines ( std::string String ) ;
std::map<std::string, std::string> SplitStringToMap ( std::string String, std::string Div1=";", std::string Div2=":" );
std::string& TrimToNLines(std::string& str, int n, const std::string& message = "(MORE LINES SKIPPED)");

bool StringEqual(const std::string & one, const std::string & two);
int StringRepl(std::string& str, const std::string& what_repl, const std::string& whereof_repl);
/******************************************************************************/

// Line-by-line CSV reader
// Does not treat first column as key
// I'll adapt LoadTableBasic for such case later
class MiniCSV
{
public:
	MiniCSV(const std::string& filename);
	bool GetLine();
	const std::string& GetField(const std::string& fieldname);
private:
	std::vector<std::string> mLines;
	std::map<std::string, size_t> mColNames;
	size_t mCurLine;
	std::vector<std::string> mFields;
	const std::string mFileName;
};

/******************************************************************************/

/* convert vector to set */
template <typename type> std::set<type> VectorToSet ( std::vector<type> Vec )
{
	std::set<type> Set ;
	foreach ( It, typename std::vector<type>, Vec )
	{	Set.insert ( *It ) ; }
	return Set ;
}

/******************************************************************************/

/* convert map of string to map of something else */
template <typename key, typename value> std::map<key,value> ConvertMap ( std::map<key,std::string> Map, value Dummy )
{
	std::map<key,value> Result ;
	foreach_map ( Pair, typename std::map<key,std::string>, Map )
	{	value Value ; FromString ( Value, Pair->second ) ; Result[Pair->first] = Value ; }
}
/******************************************************************************/

/* does string start with or ends on something? */
#define StringStartsWith( String, Sub ) (\
	( std::string(String).length() >= std::string(Sub).length() ) &&\
	( std::string(String).substr(0,std::string(Sub).length()) == std::string(Sub) ) )
#define StringEndsOn( String, Sub ) (\
	( std::string(String).length() >= std::string(Sub).length() ) &&\
	( std::string(String).substr(std::string(String).length()-std::string(Sub).length()) == std::string(Sub) ) )

/******************************************************************************/

/* text colors */
enum text_color
{
	Black=30, Red, Green, Yellow, Blue, Magenta, Cyan, White,
	BgBlack=40, BgRed, BgGreen, BgYellow, BgBlue, BgMagenta, BgCyan, BgWhite
} ;
/* text modes (not all supported) */
enum text_mode
{
	Normal=0, Bold, Faint, Italic, Underline, Blink, BlinkFast, Negative, Conceal,
	UnderlineDouble=21, BoldFaintOff, UnderlineOff=24, BlinkOff, Positive=27, Reveal
} ;

}
/******************************************************************************/

#endif

/******************************************************************************/

