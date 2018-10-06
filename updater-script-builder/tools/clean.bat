:: Auto Clean Files
:: By Kucashu

:: Build Note
:: Package -> Saved Package 

@echo off
echo Cleaning Packages Files...
cd..
for /r . %%a in (.) do @if exist "%%a\Package" rd /s /q "%%a\Package"
echo Done.