CLS
csc.exe -nologo /target:library /out:build\figures.dll src\circle.cs src\triangle.cs
csc.exe -nologo -reference:build\figures.dll /t:exe /out:build\LibTest.exe src\LibTest.cs
pause
