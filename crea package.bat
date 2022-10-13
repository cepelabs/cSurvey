del csurvey64.zip
cd cSurveyPC\bin\x64\Release
xcopy D:\Downloads\localization\DevExpressLocalizedResources_2021.2_it\*.dll it /y
cSurveyUpdateVersion.exe
..\..\..\..\7za a -tzip csurvey64 it
..\..\..\..\7za a -tzip csurvey64 en
..\..\..\..\7za a -tzip csurvey64 ru
..\..\..\..\7za a -tzip csurvey64 Objects 
..\..\..\..\7za a -tzip csurvey64 cSurveyPC.exe
..\..\..\..\7za a -tzip csurvey64 cSurveyPC.exe.config
..\..\..\..\7za a -tzip csurvey64 designtools.xml
..\..\..\..\7za a -tzip csurvey64 designtools_debug.xml
..\..\..\..\7za a -tzip csurvey64 papersizes.xml
..\..\..\..\7za a -tzip csurvey64 *.dll
..\..\..\..\7za a -tzip csurvey64 *.txt
..\..\..\..\7za a -tzip csurvey64 resources.resources
..\..\..\..\7za a -tzip csurvey64 resources.it.resources
..\..\..\..\7za a -tzip csurvey64 resources.ru.resources
..\..\..\..\7za a -tzip csurvey64 version.xml
move csurvey64.zip ..\..\..\..\
cd ..\..\..\..\

copy cSurveyPC\bin\x64\Release\version.xml 