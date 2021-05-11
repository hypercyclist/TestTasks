REM csc.exe -nologo /target:library /out:build\figureArea.dll src\area.cs src\circleArea.cs src\triangleArea.cs
csc.exe -nologo /t:exe /out:build\LibTest.exe src\LibTest.cs
pause
