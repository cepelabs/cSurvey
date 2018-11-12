cd %~dp0
if exist "ResGen.exe" (
	
	cd .\cSurveyPC
	call:genResourceFunc
	echo "<<<<<<<<<<<<<<< COPIED >>>>>>>>>>>>>>>>>>"
	
	cd %~dp0
	if exist ".\cSurveyPC-3D" (
		cd .\cSurveyPC-3D
		call:genResourceFunc
		echo "<<<<<<<<<<<<<<< TO 3D COPIED >>>>>>>>>>>>>>>>>>"
	)
	
	cd %~dp0
	if exist ".\cSurveyPC-RU" (
		cd .\cSurveyPC-RU
		call:genResourceFunc
		echo "<<<<<<<<<<<<<<< TO RU COPIED >>>>>>>>>>>>>>>>>>"
	)
) 	

GOTO:EOF

:genResourceFunc
if exist .\bin\Debug (
	..\resgen ".\resources.txt" ".\bin\Debug\resources.resources"
	..\resgen ".\resources.it.txt" ".\bin\Debug\resources.it.resources"
	if exist ".\resources.ru.txt" (..\resgen ".\resources.ru.txt" ".\bin\Debug\resources.ru.resources")
)
if exist .\bin\x64\Debug (
	..\resgen ".\resources.txt" ".\bin\x64\Debug\resources.resources"
	..\resgen ".\resources.it.txt" ".\bin\x64\Debug\resources.it.resources
	if exist ".\resources.ru.txt" (..\resgen ".\resources.ru.txt" ".\bin\x64\Debug\resources.ru.resources")
)
if exist .\bin\x86\Debug (
	..\resgen ".\resources.txt" ".\bin\x86\Debug\resources.resources"
	..\resgen ".\resources.it.txt" ".\bin\x86\Debug\resources.it.resources
	if exist ".\resources.ru.txt" (..\resgen ".\resources.ru.txt" ".\bin\x86\Debug\resources.ru.resources")
)
if exist .\bin\Release (
	..\resgen ".\resources.txt" ".\bin\Release\resources.resources"
	..\resgen ".\resources.it.txt" ".\bin\Release\resources.it.resources"
	if exist ".\resources.ru.txt" (..\resgen ".\resources.ru.txt" ".\bin\Release\resources.ru.resources")
)
if exist .\bin\x64\Release (
	..\resgen ".\resources.txt" ".\bin\x64\Release\resources.resources"
	..\resgen ".\resources.it.txt" ".\bin\x64\Release\resources.it.resources"
	if exist ".\resources.ru.txt" (..\resgen ".\resources.ru.txt" ".\bin\x64\Release\resources.ru.resources")
)
if exist .\bin\x86\Release (
	..\resgen ".\resources.txt" ".\bin\x86\Release\resources.resources"
	..\resgen ".\resources.it.txt" ".\bin\x86\Release\resources.it.resources"
	if exist ".\resources.ru.txt" (..\resgen ".\resources.ru.txt" ".\bin\x86\Release\resources.ru.resources")
)
GOTO:EOF