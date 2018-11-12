del csurvey32.zip
cd cSurveyPC\bin\Release
cSurveyUpdateVersion.exe
..\..\..\7za a -tzip csurvey32 it
..\..\..\7za a -tzip csurvey32 en
..\..\..\7za a -tzip csurvey32 ru
..\..\..\7za a -tzip csurvey32 Objects 
..\..\..\7za a -tzip csurvey32 cSurveyPC.exe
..\..\..\7za a -tzip csurvey32 designtools.xml
..\..\..\7za a -tzip csurvey32 designtools_debug.xml
..\..\..\7za a -tzip csurvey32 *.dll
..\..\..\7za a -tzip csurvey32 *.txt
..\..\..\7za a -tzip csurvey32 resources.resources
..\..\..\7za a -tzip csurvey32 resources.en.resources
..\..\..\7za a -tzip csurvey32 resources.ru.resources
..\..\..\7za a -tzip csurvey32 version.xml
move csurvey32.zip ..\..\..\
cd ..\..\..\

del csurvey64.zip
cd cSurveyPC\bin\x64\Release
cSurveyUpdateVersion.exe
..\..\..\..\7za a -tzip csurvey64 it
..\..\..\..\7za a -tzip csurvey64 en
..\..\..\..\7za a -tzip csurvey64 ru
..\..\..\..\7za a -tzip csurvey64 Objects 
..\..\..\..\7za a -tzip csurvey64 cSurveyPC.exe
..\..\..\..\7za a -tzip csurvey64 designtools.xml
..\..\..\..\7za a -tzip csurvey64 designtools_debug.xml
..\..\..\..\7za a -tzip csurvey64 *.dll
..\..\..\..\7za a -tzip csurvey64 *.txt
..\..\..\..\7za a -tzip csurvey64 resources.resources
..\..\..\..\7za a -tzip csurvey64 resources.en.resources
..\..\..\..\7za a -tzip csurvey64 resources.ru.resources
..\..\..\..\7za a -tzip csurvey64 version.xml
move csurvey64.zip ..\..\..\..\
cd ..\..\..\..\

copy cSurveyPC\bin\x64\Debug\version.xml 