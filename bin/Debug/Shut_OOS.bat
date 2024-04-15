@echo off
color C
title Terminal
:start
echo root@kali:~# pskill -f -im "Occupation of states.exe"
pause > nul
echo.
echo waiting to kill process. . .
taskkill -f -im "Occupation of states.exe"
echo killing process...
echo suggestfull done
echo.
goto start