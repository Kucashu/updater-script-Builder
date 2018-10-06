:: Auto Clean Files
:: By Kucashu

:: Build Note
:: Caches -> Saved Caches

@echo off
echo Cleaning Packages Files...
cd..
for /r . %%a in (.) do @if exist "%%a\caches" rd /s /q "%%a\caches"
echo Done.
