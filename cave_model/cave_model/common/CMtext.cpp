/******************************************************************************/

//#include "stdafx.h"
//#include "init.h"
#include <stdarg.h>
#include <string>
#include <vector>
#include <string.h>
#include <stdio.h>
//#include "error.h"
#include <ctype.h>
//#include "config.h"
//#include "file.h"  
#include "CMtext.h"
#include <algorithm> 
#include <map>

using namespace std;
namespace CM {

	/******************************************************************************/

	vector<string> ParseCSV(const string & line, char delimiter/* = ','*/)
	{
		vector<string> record;
		if (line.empty())
		{
			record.clear();
			return record;
		}

		int linepos = 0;
		bool inquotes = false;
		char c;
		int linemax = (int)line.length();
		string curstring;
		record.clear();

		while (line[linepos] != 0 && linepos < linemax)
		{
			c = line[linepos];

			if (!inquotes && curstring.length() == 0 && c == '"')
				inquotes = true; //beginquotechar
			else if (inquotes && c == '"')
			{
				//quotechar
				if ((linepos + 1 < linemax) && (line[linepos + 1] == '"'))
				{
					//encountered 2 double quotes in a row (resolves to 1 double quote)
					curstring.push_back(c);
					linepos++;
				}
				else
					inquotes = false; //endquotechar
			}
			else if (!inquotes && c == delimiter)
			{
				record.push_back(curstring); //end of field
				curstring = "";
			}
			else if (!inquotes && (c == '\r' || c == '\n'))
			{
				record.push_back(curstring);
				return record;
			}
			else
				curstring.push_back(c);

			linepos++;
		}

		record.push_back(curstring);

		return record;
	}

	/******************************************************************************/

	string xprintf_va(const char* Format, va_list Args)
	{
		int Length = 4096, RealLength;
		char* String;
		while (1)
		{
			String = (char*)malloc(Length * sizeof(char));
			RealLength = vsnprintf(String, Length, Format, Args);
			if (RealLength >= 0 && RealLength < Length)
			{
				break;
			}
			free(String);
			Length *= 4;
		}
		va_end(Args);
		string Result(String, RealLength);
		free(String);
		return Result;
	}

	/* like sprintf, but returns string
	   (avoid using operator_new() here, or else infinite recursion) */
	string xprintf(const char* Format, ...)
	{
		va_list Args;
		va_start(Args, Format);
		return xprintf_va(Format, Args);
	}

	/******************************************************************************/

	/* convert numbers to strings */
	string ToString(string String)
	{
		return String;
	}
	string ToString(int Number)
	{
		return xprintf("%d", Number);
	}
	string ToString(long long Number)
	{
		return xprintf("%lld", Number);
	}
	string ToString(size_t Number)
#ifdef WINDOWS
	{
		return xprintf("%Iu", Number);
	}
#else
	{	return xprintf("%zu", Number); }
#endif
	string ToString(double Number)
	{
		return xprintf("%f", Number);
	}
	string ToString(bool Flag)
	{
		return Flag ? "true" : "false";
	}

	/******************************************************************************/

	/* convert strings to numbers */

	string StringFromString(const string& String, bool* WasSuccessful/*=NULL*/)
	{
		if ((WasSuccessful != NULL) && (WasSuccessful != (bool*)-1))
		{
			*WasSuccessful = TRUE;
		}
		return String;
	}
	void FromString(string& Value, const string& String, bool* WasSuccessful/*=NULL*/)
	{
		Value = StringFromString(String, WasSuccessful);
	}

	bool BoolFromString(const string& String, bool* WasSuccessful/*=NULL*/)
	{
		int Result = String == "true" ? TRUE : String == "false" ? FALSE : -1;
		bool Success = Result != -1;
		if ((WasSuccessful != NULL) && (WasSuccessful != (bool*)-1))
		{
			*WasSuccessful = Success;
		}
		else if (WasSuccessful != (bool*)-1 && !Success)
		{ /*Warning ( "failed to convert '%s' to bool", String.c_str() ) ;*/ Result = 0;
		}
		return Result != 0;
	}
	void FromString(bool& Value, const string& String, bool* WasSuccessful/*=NULL*/)
	{
		Value = BoolFromString(String, WasSuccessful);
	}

	int IntFromString(const string& String, bool* WasSuccessful/*=NULL*/, bool IgnoreEmpty/*=FALSE*/, int Radix/*=10*/)
	{
		char* End;
		int Result = (int)strtol(String.c_str(), &End, Radix);
		bool Success = *End == '\0' && (IgnoreEmpty || !String.empty());
		if ((WasSuccessful != NULL) && (WasSuccessful != (bool*)-1))
		{
			*WasSuccessful = Success;
		}
		else if (WasSuccessful != (bool*)-1 && !Success)
		{ /*Warning ( "failed to convert '%s' to int, returning %d", String.c_str(), Result ) ;*/
		}
		return Result;
	}
	void FromString(int& Value, const string& String, bool* WasSuccessful/*=NULL*/, bool IgnoreEmpty/*=FALSE*/, int Radix/*=10*/)
	{
		Value = IntFromString(String, WasSuccessful, IgnoreEmpty, Radix);
	}

	long long LongLongFromString(const string& String, bool* WasSuccessful/*=NULL*/, bool IgnoreEmpty/*=FALSE*/, int Radix/*=10*/)
	{
		char* End;
		long long Result = strtoll(String.c_str(), &End, Radix);
		bool Success = *End == '\0' && (IgnoreEmpty || !String.empty());
		if ((WasSuccessful != NULL) && (WasSuccessful != (bool*)-1))
		{
			*WasSuccessful = Success;
		}
		else if (WasSuccessful != (bool*)-1 && !Success)
		{ /*Warning ( "failed to convert '%s' to long long, returning %lld", String.c_str(), Result ) ;*/
		}
		return Result;
	}
	void FromString(long long& Value, const string& String, bool* WasSuccessful/*=NULL*/, bool IgnoreEmpty/*=FALSE*/, int Radix/*=10*/)
	{
		Value = LongLongFromString(String, WasSuccessful, IgnoreEmpty, Radix);
	}

	double DoubleFromString(const string& String, bool* WasSuccessful/*=NULL*/, bool IgnoreEmpty/*=FALSE*/)
	{
		char* End;
		double Result = strtod(String.c_str(), &End);
		bool Success = *End == '\0' && (IgnoreEmpty || !String.empty());
		if ((WasSuccessful != NULL) && (WasSuccessful != (bool*)-1))
		{
			*WasSuccessful = Success;
		}
		else if (WasSuccessful != (bool*)-1 && !Success)
		{ /*Warning ( "failed to convert '%s' to double, returning %f", String.c_str(), Result ) ;*/
		}
		return Result;
	}
	void FromString(double& Value, const string& String, bool* WasSuccessful/*=NULL*/, bool IgnoreEmpty/*=FALSE*/)
	{
		Value = DoubleFromString(String, WasSuccessful, IgnoreEmpty);
	}

	/******************************************************************************/

	/* replace inside Text all SearchFor with ReplaceWith */
	string str_replace(const string& SearchFor, const string& ReplaceWith, std::string Text)
	{
		size_t Pos = 0;
		while (1)
		{
			Pos = Text.find(SearchFor, Pos);
			if (Pos == string::npos)
			{
				break;
			}
			Text.replace(Pos, SearchFor.length(), ReplaceWith);
			Pos += ReplaceWith.length();
		}
		return Text;
	}
	//-------------------------------------------------------------
	int StringRepl(std::string& str, const std::string& what_repl, const std::string& whereof_repl)
	{
		std::string::size_type b = str.find(what_repl);
		int i = 0;
		while (b != std::string::npos)
		{
			str.erase(b, what_repl.size());
			if (!whereof_repl.empty())
				str.insert(b, whereof_repl);
			i++;
			b = str.find(what_repl);
		}
		return i;
	}
	/******************************************************************************/

	/* merge vector or null-terminated array into string using some divider */

	//#define Merge( What, container, ForEach ) \
	//	string Merge##What ( container const& Con, string Divider/*=", "*/ )\
	//	{\
	//		string Result = "" ;\
	//		bool First = TRUE ;\
	//		ForEach ( It, container, Con )\
	//		{	Result += (string) (!First?Divider:"") + *It ; First = FALSE ; }\
	//		return Result ;\
	//	}
	//Merge ( Vector, vector<string>, foreach_const )
	//Merge ( Set, set<string>, foreach_const )
	//Merge ( List, list<string>, foreach_const )
	//Merge ( Array, char const* const*, foreach_array )
	//#undef Merge

	/******************************************************************************/

	/* ask and wait for pressing enter (in windows) */
	void AskToPressEnter(void)
	{
#ifdef WINDOWS
		printf("Press enter to continue...");\
			char Temp[] = "-";
		fgets(Temp, sizeof(Temp), stdin);
#endif
	}

	/******************************************************************************/

	/* get lower/upper-case string */
	//string ToLower ( string Text )
	//{	foreach ( Char, string, Text ) { *Char = tolower(*Char) ; } return Text ; }
	//string ToUpper ( string Text )
	//{	foreach ( Char, string, Text ) { *Char = toupper(*Char) ; } return Text ; }

	/******************************************************************************/

	/* unload cached tables */
	//static map<string,table_t>* Tables = NULL ;
	//void ClearTablesCache ( void )
	//{
	//	if ( Tables != NULL )
	//	{	delete Tables ; Tables = NULL ; }
	//}

	/******************************************************************************/

	/* wrapper */
	//table_t& FetchTable ( string TableName )
	//{	return LoadTable ( xprintf("%s/text/%s.csv",GetConfC(RESOURCES_DIR),TableName.c_str()) ) ; }

	/******************************************************************************/

	/* load csv table, return table (from cache) */
	//table_t& LoadTable ( string FileName, bool UseCache/*=TRUE*/ )
	//{
	//	/* init cache, install cache unloader */
	//	if ( Tables == NULL )
	//	{
	//		Tables = xnew map<string,table_t> ;
	//		atexit ( ClearTablesCache ) ;
	//	}
	//	
	//	/* return table if already loaded */
	//	if ( Find(*Tables,FileName) )
	//	{
	//		if ( UseCache )
	//		{	return (*Tables)[FileName] ; }
	//		else
	//		{	(*Tables)[FileName].clear () ; }
	//	}
	//	
	//	table_t& Table = (*Tables)[FileName] ;
	//	LoadTableBasic ( FileName, Table ) ;
	//	return Table ;
	//}

	/******************************************************************************/

	/* basic loader of csv */
	//void LoadTableBasic ( string FileName, table_t& Table, bool FullFilling/*=TRUE*/, bool CombineSameIds/*=FALSE*/, bool accept_add_to_not_empty_map/*=FALSE*/, bool allowEmptyRow )
	//{
	//	Check ( accept_add_to_not_empty_map || Table.size() == 0 ) ;
	//	
	//	const char Divider = ',' /*';'*/ ;
	//	
	//	/* get file */
	//	bool Success ;
	//	string Contents = file_get_contents ( FileName, &Success ) ;
	//	const unsigned  char* c = (const unsigned  char*)Contents.c_str();
	//	if (c[0] == 0xEF 
	//		&& c[1] == 0xBB 
	//		&& c[2] == 0xBF)
	//	{
	//		Contents = Contents.substr(3);
	//	}
	//	CheckError ( Success, "could not load '%s'", FileName.c_str() ) ;
	//	
	//	const char* Pointer = Contents.c_str() ;
	//	bool InQuotes = FALSE ;
	//	int RowsNumber = 0 ;
	//	vector<string> RowWithIds ;
	//	row_t Row ;
	//	int FieldsNumber = 0 ;
	//	string RowsId ;
	//	string Field = "" ;
	//	bool EmptyLine = TRUE ;
	//	#define Add( c ) Field += c ; EmptyLine = FALSE ;
	//	while ( 1 )
	//	{
	//		/* get chars */
	//		char Char = Pointer[0] ;
	//		char NextChar = Char=='\0'? '\0': Pointer[1] ;
	//		
	//		/* outside qoutes? */
	//		if ( !InQuotes )
	//		{
	//			/* end of field (divider, newline, eof) */
	//			if (( Char == Divider ) ||
	//				( Char == '\n' ) ||
	//				( ( Char == '\r' ) && ( NextChar == '\n' ) ) ||
	//				( Char == '\0' ) )
	//			{
	//				/* add _new field (first row is row with ids) */
	//				if ( RowsNumber == 0 )
	//				{	RowWithIds.push_back ( Field ) ; }
	//				else
	//				{
	//					CheckError ( FieldsNumber<(int)RowWithIds.size(), "too large row '%s' in file '%s'", RowsId.c_str(), FileName.c_str()  )
	//					Row[RowWithIds[FieldsNumber]] = Field ;
	//					if ( FieldsNumber == 0 )
	//					{	RowsId = Field ; }
	//				}
	//				Field = "" ;
	//				FieldsNumber++ ;
	//				
	//				/* _new line or eof? */
	//				if (( Char == '\n' ) ||
	//					( ( Char == '\r' ) && ( NextChar == '\n' ) ) ||
	//					( Char == '\0' ) )
	//				{
	//					if ( Char == '\r' )
	//					{	Pointer++ ; }
	//					
	//					/* ignore last empty line */
	//					if ( EmptyLine )
	//					{
	//						if ( Char != '\0' && !allowEmptyRow)
	//						{	Error ( "empty row in '%s'", FileName.c_str() ) ; }
	//					}
	//					else
	//					{
	//						/* add _new row (skip first row with ids) */
	//						if ( RowsNumber != 0 )
	//						{
	//							if ( !CombineSameIds )
	//							{	CheckError ( !Find(Table,RowsId), "duplicate row's id '%s' in '%s'", RowsId.c_str(), FileName.c_str() ) ; }
	//							CheckError ( RowsId!="", "empty row's id in '%s'", FileName.c_str() ) ;
	//							if ( !FullFilling )
	//							{	CheckError ( Row.size() == RowWithIds.size(), "invalid row size in '%s'", FileName.c_str() ) ; }
	//							if (CombineSameIds)
	//							{
	//								foreach(s, row_t, Row)
	//									Table[RowsId][s->first] = s->second;
	//							}else
	//								Table[RowsId].insert ( Row.begin(), Row.end() ) ;
	//						}
	//						EmptyLine = TRUE ;
	//					}
	//					RowsId = "" ;
	//					RowsNumber++ ;
	//					FieldsNumber = 0 ;
	//				}
	//			}
	//			/* quote? */
	//			else if ( Char == '"' )
	//			{
	//				/* enter quotes */
	//				InQuotes = TRUE ;
	//			}
	//			/* just add char */
	//			else
	//			{	Add ( Char ) ; }
	//		}
	//		/* inside quotes */
	//		else
	//		{
	//			/* skip end of file */
	//			if ( Char == '\0' )
	//			{	/**/ }
	//			/* quotes? */
	//			else if ( Char == '"' )
	//			{
	//				/* convert double quote to quote, else leave quotes */
	//				if ( NextChar == '"' )
	//				{	Add ( '"' ) ; Pointer++ ; }
	//				else
	//				{	InQuotes = FALSE ; }
	//			}
	//			/* just add char */
	//			else
	//			{	Add ( Char ) ; }
	//		}
	//		
	//		/* end of file? stop */
	//		if ( Char == '\0' )
	//		{	break ; }
	//		
	//		/* goto next char */
	//		Pointer++ ;
	//	}
	//	#undef Add
	//}

	/******************************************************************************/

	/* dump table for debug */
	//template <typename table_type> void DumpTable ( const table_type& Table )
	//{
	//	foreach_const ( Row, typename table_type, Table )
	//	{
	//		Log ( "%s:", Row->first.c_str() ) ;
	//		foreach_const ( Field, row_t, Row->second )
	//		{
	//			Log ( "%s -> %s", Field->first.c_str(), Field->second.c_str() ) ;
	//		}
	//	}
	//}

	/******************************************************************************/

	/* save table */
	//void SaveTable( std::string FileName, const table_t& Table, std::string Id, std::set<std::string> Header, bool equal_column_rows /*= true*/ )
	//{
	//	if ( Table.size() == 0 )
	//	{
	//		Warning ( "empty table" ) ;
	//		return;
	//	}
	//
	//	/* save header */
	//	string Contents = Id ;
	//	set<string> ActualHeader ;
	//	if (equal_column_rows)
	//	{
	//		foreach_const ( It, row_t, Table.begin()->second )
	//		{
	//			ActualHeader.insert ( It->first ) ;
	//			if ( It->first == Id )
	//			{	continue ; }
	//			Contents += ","+It->first ;
	//		}
	//		Contents += "\n" ;
	//		
	//		/* check header */
	//		CheckError ( Header==ActualHeader, "invalid header supplied" ) ;
	//	}else
	//	{
	//		foreach_const ( It, std::set<std::string>, Header )
	//		{
	//			if ( *It == Id )
	//			{	continue ; }
	//			Contents += ","+*It;
	//		}
	//		Contents += "\n" ;
	//	}
	//	/* save rows */
	//	/* TODO: expand quotes and enquote */
	//	foreach_const ( Row, table_t, Table )
	//	{
	//		Contents += Row->first ;
	//		CheckError ( Find(Row->second,Id), "missing id in row '%s'", Row->first.c_str() ) ;
	//		CheckError ( Row->second.find(Id)->second==Row->first, "in row '%s' actual id is '%s' ", Row->second.find(Id)->second.c_str(), Row->first.c_str() ) ;
	//		set<string> TestHeader ;
	//		row_t::const_iterator It = Row->second.begin();
	//		std::set<std::string>::const_iterator ColIt = Header.begin();
	//		while ( It != Row->second.end() )
	//		{
	//			TestHeader.insert ( It->first ) ;
	//			if ( It->first == Id )
	//				{	ColIt++;	It++;	 continue ; }
	//
	//			if (!equal_column_rows)
	//			{
	//				if (!Find(Header, It->first))
	//				{
	//					It++;
	//					continue ;
	//				}
	//				if (It->first != *ColIt)
	//				{
	//					Contents += ",";
	//					ColIt++;
	//					continue;
	//				}
	//			}
	//			string Value = It->second ;
	//			bool Enquote = Value.find_first_of(",\"\n" )!=string::npos  ;
	//			Value = str_replace ( "\"", "\"\"", Value ) ;
	//			if ( Enquote )
	//			{	Value = xprintf ( "\"%s\"", Value.c_str() ) ; }
	//			Contents += ","+Value ;
	//
	//			ColIt++;
	//			It++;
	//		}
	//		if (equal_column_rows && Header != TestHeader )
	//		{
	//			list<string> Difference ;
	//			set_symmetric_difference (
	//				Header.begin(),
	//				Header.end(),
	//				TestHeader.begin(),
	//				TestHeader.end(),
	//				back_insert_iterator<list<string> >(Difference) ) ;
	//			Error (
	//				"invalid header in row '%s', difference is '%s'",
	//				Row->first.c_str(),
	//				MergeList(Difference).c_str() ) ;
	//		}
	//		Contents += "\n" ;
	//	}
	//	
	//	/* save file */
	//	file_put_contents ( FileName, Contents ) ;
	//}

	/******************************************************************************/

	/* set language (all safe) */
	//char Language[] = "ru" ;
	//void StrLang ( const char* NewLanguage )
	//{
	//	Check ( strlen(Language)==2 && strlen(NewLanguage)==2 ) ;
	//	strcpy ( Language, NewLanguage );
	//}

	/******************************************************************************/

	/* clear str cache */
	//set<string>* LoadedTables = NULL ;
	//table_t* Strings = NULL ;
	//void ClearStrCache ( void )
	//{
	//	if ( LoadedTables != NULL )
	//	{
	//		delete LoadedTables ;
	//		LoadedTables = NULL ;
	//		Check ( Strings != NULL ) ;
	//		delete Strings ;
	//		Strings = NULL ;
	//	}
	//}
	//	
	///******************************************************************************/
	//
	///* load module with text */
	//void StrLoad ( string Name, bool RawPath/*=FALSE*/ )
	//{
	//	if ( LoadedTables == NULL )
	//	{
	//		LoadedTables = xnew set<string> ;
	//		Check ( Strings == NULL ) ;
	//		Strings = xnew table_t ;
	//		atexit ( ClearStrCache ) ;
	//	}
	//	
	//	if ( Find(*LoadedTables,Name) )
	//	{	return ; }
	//	LoadedTables->insert ( Name ) ;
	//	table_t& Data = RawPath? LoadTable(Name.c_str()): FetchTable(Name.c_str()) ;
	//	foreach ( It, table_t, Data )
	//	{
	//		CheckError ( !Find(*Strings,It->first), "duplicate id '%s' in '%s'", It->first.c_str(), Name.c_str() )
	//		(*Strings)[It->first] = It->second ;
	//		/*Log ( "+str[%d]: {%s}=<%s>", (int)Strings.size(), It->first.c_str(), It->second[Language].c_str() ) ;*/
	//	}
	//}
	//
	///******************************************************************************/
	//
	///* return string */
	//const char* Str ( string Name )
	//{
	//	Check ( Strings != NULL ) ;
	//	/* return string */
	//	if ( !Find(*Strings,Name) )
	//	{	/*Warning ( "missing string '%s'", Name.c_str() ) ;*/ }
	//	else if ( !Find((*Strings)[Name],Language) )
	//	{	Error ( "missing language '%s' for '%s'", Language, Name.c_str() ) ; }
	//	else
	//	{	return (*Strings)[Name][Language].c_str() ; }
	//	return "???" ;
	//}

	/******************************************************************************/

	/* get filename from location */
	std::string ExtractFileName(std::string Location)
	{
		size_t LastSlash = Location.find_last_of("\\/");
		if (LastSlash != string::npos)
		{
			Location = Location.substr(LastSlash + 1);
		}
		return Location;
	}

	/******************************************************************************/

	/* split string into array by divider */
	vector<string> SplitString(string String, string Div/*=";"*/)
	{
		vector<string> Result;
		if (Div.length() <= 0) return Result;
		if (String == "")
		{
			return Result;
		}
		size_t Pos = 0;
		while (1)
		{
			size_t Next = String.find(Div, Pos);
			string Part = String.substr(Pos, Next != string::npos ? Next - Pos : string::npos);
			Result.push_back(Part);
			if (Next == string::npos)
			{
				break;
			}
			Pos = Next + Div.length();
		}
		return Result;
	}
	//-------------------------------------------------------------
	//map<string, string> SplitStringToMap ( string String, string Div1/*=";"*/, string Div2/*=":"*/ )
	//{
	//	map<string, string> res;
	//
	//	vector<string> spl1 = SplitString(String, Div1);
	//	foreach_const(s, vector<string>, spl1)
	//	{
	//		vector<string> spl2 = SplitString(*s, Div2);
	//		if (!spl2.empty())
	//		{
	//			if (spl2.size() == 1)
	//			{
	//				res[spl2[0]]="";
	//			}else
	//			{
	//				res[spl2[0]]=spl2[1];
	//			}
	//		}
	//	}
	//
	//	return res;
	//}
	/******************************************************************************/

	/* split string by newlines */
	vector<string> SplitByNewlines(string String)
	{
		return SplitString(str_replace("\r", "", String), "\n");
	}
	//void AddStringToTable( const std::string& name, const std::string& string )
	//{
	//	Check(Strings != NULL);
	//	(*Strings)[name][Language] = string;
	//}
	/******************************************************************************/

	// Limit string to n lines, appending a message if limit happens
	std::string& TrimToNLines(std::string& str, int n, const std::string& message)
	{
		size_t ofs = 0;
		for (int i = 0; i < n; i++)
		{
			ofs = str.find('\n', ofs);
			if (ofs != std::string::npos)
				ofs++;
			else
				break;
		}

		if (ofs != std::string::npos)
		{
			str.resize(ofs);
			str += message;
		}

		return str;
	}
}
//bool StringEqual( const std::string & one, const std::string & two )
//{
//	return ToUpper(one) == ToUpper(two);
//}

//void SetLanguage()
//{
//	bool result;
//	std::string lang = file_get_contents(UserFile(".cl__locale"), &result);
//
//	if (result)
//		StrLang(lang.c_str());
//}
//
//const char* GetLanguage()
//{
//	return Language;
//}

//MiniCSV::MiniCSV(const std::string& filename)
//	: mFileName(filename)
//{
//	std::string contents = file_get_contents(filename);
//	if (contents.size()>=3 && contents[0] == 0xEF && contents[1] == 0xBB && contents[2] == 0xBF)
//		contents = contents.substr(3);
//
//	mLines = SplitByNewlines(contents);
//	CheckError(!mLines.empty(), "Empty table '%s'", filename.c_str());
//
//	auto ids = ParseCSV(mLines[0]);
//	for (size_t i = 0; i<ids.size(); i++)
//		mColNames[ids[i]] = i;
//
//	mCurLine = 0;
//}
//
//bool MiniCSV::GetLine()
//{
//	do
//	{
//		if (++mCurLine>=mLines.size())
//			return false;
//	} while (mLines[mCurLine].empty());
//
//	mFields = ParseCSV(mLines[mCurLine]);
//	return true;
//}
//
//const std::string& MiniCSV::GetField(const std::string& fieldname)
//{
//	static const std::string empty;
//	auto it = mColNames.find(fieldname);
//	CheckError(it!=mColNames.end(), "no field '%s' in table '%s'", fieldname.c_str(), mFileName.c_str());
//	return it->second<mFields.size() ? mFields[it->second] : empty;
//}

