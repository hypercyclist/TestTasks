javac.exe -d bin src\*.java
jar.exe -cmvf manifest\MANIFEST.MF build\Main.jar -C bin .
pause
